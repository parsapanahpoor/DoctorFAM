using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.ViewModels.Site.Common;
using DoctorFAM.Domain.ViewModels.Site.HomePharmacy;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.Site.Request;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    [Authorize]
    public class HomePharmacyController : SiteBaseController
    {
        #region Ctor

        private readonly IHomePharmacyServicec _homePharmacy;

        private readonly IRequestService _requestService;

        private readonly IUserService _userService;

        private readonly IPatientService _patientService;

        private readonly ILocationService _locationService;

        private readonly ISiteSettingService _siteSettingService;

        private readonly IPopulationCoveredService _populationCovered;

        public HomePharmacyController(IHomePharmacyServicec homePharmacy, IRequestService requestService, IUserService userService
                                     , IPatientService patientService, ILocationService locationService , ISiteSettingService siteSettingService
                                        , IPopulationCoveredService populationCovered)
        {
            _homePharmacy = homePharmacy;
            _requestService = requestService;
            _userService = userService;
            _patientService = patientService;
            _locationService = locationService;
            _siteSettingService = siteSettingService;
            _populationCovered = populationCovered;
        }

        #endregion

        #region Home Farmacy 

        [HttpGet]
        public async Task<IActionResult> HomePharmacy()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> HomePharmacy(RequestViewModel request)
        {
            #region Create New Request

            var requestId = await _homePharmacy.CreateHomePharmacyRequest(User.GetUserId());

            if (requestId == null) return NotFound();

            #endregion

            return RedirectToAction("PatientDetails", "HomePharmacy", new { requestId = requestId });
        }

        #endregion

        #region Patient Detail

        [HttpGet]
        public async Task<IActionResult> PatientDetails(ulong requestId, ulong? populationCoveredId)
        {
            #region Data Validation

            if (!await _requestService.IsExistRequestByRequestId(requestId)) return NotFound();

            if (!await _userService.IsExistUserById(User.GetUserId())) return NotFound();

            #endregion

            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(requestId, User.GetUserId(), null, RequestType.HomeDrog)) return NotFound();

            #endregion

            #region Get User Population Covered

            ViewBag.PopulationCovered = await _populationCovered.GetUserPopulation(User.GetUserId());

            #endregion

            #region Fill Data From Selected Population Covered

            if (populationCoveredId != null && populationCoveredId.HasValue)
            {
                //Fill Page Model From Selected Population Covered Data
                var mode = await _homePharmacy.FillPatientViewModelFromSelectedPopulationCoveredData(populationCoveredId.Value, requestId, User.GetUserId());
                if (mode == null) return NotFound();

                return View(mode);
            }

            #endregion

            #region Get User By Id 

            var user = await _userService.GetUserById(User.GetUserId());

            #endregion

            return View(new PatientViewModel()
            {
                RequestId = requestId,
                UserId = User.GetUserId(),
                NationalId = !string.IsNullOrEmpty(user.NationalId) ? user.NationalId : null,
                PatientName = !string.IsNullOrEmpty(user.FirstName) ? user.FirstName : null,
                PatientLastName = !string.IsNullOrEmpty(user.LastName) ? user.LastName : null,
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientDetails(PatientViewModel patient)
        {
            #region Data Validation

            if (!await _userService.IsExistUserById(User.GetUserId())) return NotFound();
            if (User.GetUserId() != patient.UserId) return NotFound();

            #endregion

            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(patient.RequestId, User.GetUserId(), null, RequestType.HomeDrog)) return NotFound();

            #endregion

            #region Model State

            if (!ModelState.IsValid) return View(patient);

            #endregion

            #region Validate model 

            var result = await _homePharmacy.ValidateCreatePatient(patient);

            switch (result)
            {
                case CreatePatientResult.Faild:
                    return NotFound();

                case CreatePatientResult.RequestIdNotFound:
                    return NotFound();

                case CreatePatientResult.Success:

                    //Add Patient Detail
                    var patientId = await _homePharmacy.CreatePatientDetail(patient);

                    //Add PatientId To The Request
                    await _requestService.AddPatientIdToRequest(patient.RequestId, patientId);

                    return RedirectToAction("RequestedDrogs", "HomePharmacy", new { requestId = patient.RequestId, patientId = patientId });
            }

            #endregion

            #region Get User Population Covered

            ViewBag.PopulationCovered = await _populationCovered.GetUserPopulation(User.GetUserId());

            #endregion

            return View(patient);
        }

        #endregion

        #region Requested Drogs 

        [HttpGet]
        public async Task<IActionResult> RequestedDrogs(ulong requestId, ulong patientId)
        {
            #region Model State Validation 

            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(requestId, User.GetUserId(), patientId, RequestType.HomeDrog)) return NotFound();

            #endregion

            #region Patient Validation 

            if(!await _patientService.PatientValidatorWhileCompeleteDataFromUser(patientId , User.GetUserId() , requestId)) return NotFound();

            #endregion

            #endregion

            #region Fill View Model

            var model = await _homePharmacy.FillRequestedDrugsViewModel(requestId);

            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestedDrogs(RequestedDrugsViewModel model , IFormFile? DrugPrescriptionImage, IFormFile? DrugImage)
        {
            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(model.RequestId, User.GetUserId(), null , RequestType.HomeDrog)) return NotFound();

            #endregion

            #region Get Request

            var request = await _requestService.GetRequestById(model.RequestId);

            if (request == null) return NotFound();

            var ReturnModel = await _homePharmacy.FillRequestedDrugsViewModel(request.Id);

            if (model == null) return NotFound();

            #endregion

            #region Create Drug Method

            var res = await _homePharmacy.CreateDrugRequestSiteSide(model , DrugPrescriptionImage , DrugImage);

            switch (res)
            {
                case CreateDrugRequestSiteSideResult.Success:
                    TempData[SuccessMessage] = "درج دارو با موفقیت انجام شده است  ";
                    return RedirectToAction("RequestedDrogs", "HomePharmacy", new { requestId = request.Id, patientId = request.PatientId });

                case CreateDrugRequestSiteSideResult.DetailNotValid:
                    TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد";
                    break;

                case CreateDrugRequestSiteSideResult.MoreThanOneChoice:
                    TempData[ErrorMessage] = "کاربر عزیز شما نمی توانید در یک انتخاب تمام روش ها و مقادیر را یکجا پر کنید  ";
                    break;

                case CreateDrugRequestSiteSideResult.DrugNameAndImageIsNull:
                    TempData[ErrorMessage] = "کاربر عزیز شما باید نام دارو را نیز وارد کنید  ";
                    break;

                case CreateDrugRequestSiteSideResult.DrugCountIsNull:
                    TempData[ErrorMessage] = "کاربر عزیز شما باید مقدار داروی درخواستی را وارد کنید ";
                    break;

                case CreateDrugRequestSiteSideResult.AllOfPropertiesAreNull:
                    TempData[ErrorMessage] = "کاربر عزیز شما باید یکی از روش های بالا را انتخاب کنید و مقادیر را پر کنید ";
                    break;
            }

            #endregion

            return View(ReturnModel);
        }

        #endregion

        #region Delete Requested Drug

        public async Task<IActionResult> DeleteRequestedDrug(ulong requestedDrugId)
        {
            var result = await _homePharmacy.DeleteRequestedDrug(requestedDrugId);

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "داروی مورد نظر با موفقیت حذف شده است ");
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات با شکست روبرو شده است ");
        }

        #endregion

        #region Patient Request Detail

        [HttpGet]
        public async Task<IActionResult> PatientRequestDetail(ulong requestId)
        {
            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(requestId , User.GetUserId(), null, RequestType.HomeDrog)) return NotFound();

            #endregion

            #region Is Exist Request & Patient
           
            var request = await _requestService.GetRequestById(requestId);

            if (!await _patientService.IsExistPatientById(request.PatientId.Value))
            {
                return NotFound();
            }

            #endregion

            #region Page Data

            ViewData["Countries"] = await _locationService.GetAllCountriesForHomePharmacy();

            #endregion

            return View(new PatientRequestedDrugAddressViewModel()
            {
                RequestId = requestId,
                PatientId = request.PatientId.Value,
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientRequestDetail(PatientRequestedDrugAddressViewModel patientRequest)
        {
            #region Page Data

            ViewData["Countries"] = await _locationService.GetAllCountriesForHomePharmacy();

            #endregion

            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(patientRequest.RequestId, User.GetUserId(), null, RequestType.HomeDrog)) return NotFound();

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                return View(patientRequest);
            }

            #endregion

            #region Create Patient Request Method

            var result = await _homePharmacy.CreatePatientRequestDetail(patientRequest);

            switch (result)
            {
                case CreatePatientAddressResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است ";
                    return RedirectToAction("BankPay", "HomePharmacy", new { requestId = patientRequest.RequestId });

                case CreatePatientAddressResult.Failed:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شده است ";
                    break;

                case CreatePatientAddressResult.RquestNotFound:
                    TempData[ErrorMessage] = "درخواست یافت نشده است ";
                    break;

                case CreatePatientAddressResult.PatientNotFound:
                    TempData[ErrorMessage] = "بیمار یافت نشده است ";
                    break;

                case CreatePatientAddressResult.LocationNotFound:
                    TempData[ErrorMessage] = "آدرس مورد نظر یافت نشده است ";
                    break;
            }

            #endregion

            return View(patientRequest);
        }

        #endregion

        #region Bank Redirect

        [HttpGet]
        public async Task<IActionResult> BankPay(ulong requestId)
        {
            #region Get Request By Id

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return NotFound();

            #endregion

            #region Get Home Pharmacy Tarif 

            var homePharmacyTariff = await _siteSettingService.GetHomePahrmacyTariff();
            if (homePharmacyTariff == 0)
            {
                TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
                return View();
            }

            #endregion

            #region Online Payment

            var payment = new ZarinpalSandbox.Payment(homePharmacyTariff);

            var res = payment.PaymentRequest("پرداخت  ", "https://localhost:44322/HomePharmacyPayment/" + requestId, "Parsapanahpoor@yahoo.com", "09117878804");

            if (res.Result.Status == 100)
            {

                #region Update Request State 

                await _requestService.UpdateRequestStateForTramsferringToTheBankingPortal(request);

                #endregion

                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }

            #endregion

            return View();
        }

        #endregion

        #region Home Pharmacy Payment

        [Route("HomePharmacyPayment/{id}")]
        public async Task<IActionResult> HomePharmacyPayment(ulong id)
        {
            #region Get Request 

            var request = await _requestService.GetRequestById(id);

            #endregion

            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];

                #region Get Home Pharmacy Tarif 

                var homePharmacyTariff = await _siteSettingService.GetHomePahrmacyTariff();
                if (homePharmacyTariff == 0)
                {
                    TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
                    return View();
                }

                #endregion

                var payment = new ZarinpalSandbox.Payment(homePharmacyTariff);
                var res = payment.Verification(authority).Result;

                if (res.Status == 100)
                {
                    ViewBag.code = res.RefId;
                    ViewBag.IsSuccess = true;

                    //Update Request State 
                    await _requestService.UpdateRequestStateForPayed(request);

                    //Charge User Wallet
                    await _homePharmacy.ChargeUserWallet(User.GetUserId(), homePharmacyTariff);

                    //Pay Home Pharmacy Tariff
                    await _homePharmacy.PayHomePharmacyTariff(User.GetUserId(), homePharmacyTariff);

                    return View();
                }

            }
            else
            {
                await _requestService.UpdateRequestStateForNotPayed(request);
            }

            return View();
        }

        #endregion
    }
}
