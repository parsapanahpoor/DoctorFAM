using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.ViewModels.Site.Common;
using DoctorFAM.Domain.ViewModels.Site.HomeLaboratory;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.Site.Request;
using DoctorFAM.Web.ActionFilterAttributes;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoctorFAM.Web.Controllers
{
    [Authorize]
    [CheckUserFillPersonalInformation]
    public class HomeLaboratoryController : SiteBaseController
    {
        #region Ctor

        private readonly IHomeLaboratoryServices _homeLaboratory;

        private readonly IRequestService _requestService;

        private readonly IUserService _userService;

        private readonly IPatientService _patientService;

        private readonly ILocationService _locationService;

        private readonly IPopulationCoveredService _populationCovered;

        private readonly ISiteSettingService _siteSettingService;

        public HomeLaboratoryController(IHomeLaboratoryServices homeLaboratory, IRequestService requestService, IUserService userService, IPatientService patientService, ILocationService locationService, ISiteSettingService siteSettingService , IPopulationCoveredService populationCovered)
        
        {
            _homeLaboratory = homeLaboratory;
            _requestService = requestService;
            _userService = userService;
            _patientService = patientService;
            _locationService = locationService;
            _siteSettingService = siteSettingService;
            _populationCovered = populationCovered;
        }

        #endregion

        #region Home Laboratory 

        [HttpGet]
        public async Task<IActionResult> HomeLaboratory()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> HomeLaboratory(RequestViewModel request)
        {
            #region Create New Request

            var requestId = await _homeLaboratory.CreateHomeLaboratoryRequest(User.GetUserId());

            if (requestId == null) return NotFound();

            #endregion

            return RedirectToAction("PatientDetails", "HomeLaboratory", new { requestId = requestId });
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

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(requestId, User.GetUserId(), null, RequestType.HomeLab)) return NotFound();

            #endregion

            #region Get User Population Covered

            ViewBag.PopulationCovered = await _populationCovered.GetUserPopulation(User.GetUserId());

            #endregion

            #region Fill Data From Selected Population Covered

            if (populationCoveredId != null && populationCoveredId.HasValue)
            {
                //Fill Page Model From Selected Population Covered Data
                var mode = await _homeLaboratory.FillPatientViewModelFromSelectedPopulationCoveredData(populationCoveredId.Value, requestId, User.GetUserId());
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
            #region Get User Population Covered

            ViewBag.PopulationCovered = await _populationCovered.GetUserPopulation(User.GetUserId());

            #endregion

            #region Data Validation

            if (!await _userService.IsExistUserById(User.GetUserId())) return NotFound();
            if (User.GetUserId() != patient.UserId) return NotFound();

            #endregion       
            
            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(patient.RequestId, User.GetUserId(), null, RequestType.HomeLab)) return NotFound();

            #endregion

            #region Model State

            if (!ModelState.IsValid) return View(patient);

            #endregion

            #region Validate model 

            var result = await _homeLaboratory.ValidateCreatePatient(patient);

            switch (result)
            {
                case CreatePatientResult.Faild:
                    return NotFound();

                case CreatePatientResult.RequestIdNotFound:
                    return NotFound();

                case CreatePatientResult.Success:

                    //Add Patient Detail
                    var patientId = await _homeLaboratory.CreatePatientDetail(patient);

                    //Add PatientId To The Request
                    await _requestService.AddPatientIdToRequest(patient.RequestId, patientId);

                    return RedirectToAction("RequestedLaboratory", "HomeLaboratory", new { requestId = patient.RequestId, patientId = patientId });
            }

            #endregion

            return View(patient);
        }

        #endregion

        #region Requested Laboratory 

        [HttpGet]
        public async Task<IActionResult> RequestedLaboratory(ulong requestId, ulong patientId)
        {
            #region Model State Validation 

            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(requestId, User.GetUserId(), patientId, RequestType.HomeLab)) return NotFound();

            #endregion

            #region Patient Validation 

            if (!await _patientService.PatientValidatorWhileCompeleteDataFromUser(patientId, User.GetUserId(), requestId)) return NotFound();

            #endregion

            #endregion

            #region Fill View Model

            var model = await _homeLaboratory.FillRequestedLaboratoryViewModel(requestId);

            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestedLaboratory(RequestedLaboratoryViewModel model, IFormFile? ExperimentPrescriptionImage, IFormFile? ExperimentImage)
        {
            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(model.RequestId, User.GetUserId(), null, RequestType.HomeLab)) return NotFound();

            #endregion

            #region Get Request

            var request = await _requestService.GetRequestById(model.RequestId);

            if (request == null) return NotFound();

            var ReturnModel = await _homeLaboratory.FillRequestedLaboratoryViewModel(request.Id);

            if (model == null) return NotFound();

            #endregion

            #region Create Laboratory Method

            var res = await _homeLaboratory.CreateLaboratoryRequestSiteSide(model, ExperimentPrescriptionImage, ExperimentImage);

            switch (res)
            {
                case CreateLaboratoryRequestSiteSideResult.Success:
                    TempData[SuccessMessage] = "درج آزمایش با موفقیت انجام شده است  ";
                    return RedirectToAction("RequestedLaboratory", "HomeLaboratory", new { requestId = request.Id, patientId = request.PatientId });

                case CreateLaboratoryRequestSiteSideResult.DetailNotValid:
                    TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد";
                    break;

                case CreateLaboratoryRequestSiteSideResult.MoreThanOneChoice:
                    TempData[ErrorMessage] = "کاربر عزیز شما نمی توانید در یک انتخاب تمام روش ها و مقادیر را یکجا پر کنید  ";
                    break;

                case CreateLaboratoryRequestSiteSideResult.ExperimentNameAndImageIsNull:
                    TempData[ErrorMessage] = "کاربر عزیز شما باید نام آزمایش را نیز وارد کنید  ";
                    break;

                case CreateLaboratoryRequestSiteSideResult.AllOfPropertiesAreNull:
                    TempData[ErrorMessage] = "کاربر عزیز شما باید یکی از روش های بالا را انتخاب کنید و مقادیر را پر کنید ";
                    break;
            }

            #endregion

            return View(ReturnModel);
        }

        #endregion

        #region Delete Requested Laboratory

        public async Task<IActionResult> DeleteRequestedLaboratory(ulong requestedLaboratoryId)
        {
            var result = await _homeLaboratory.DeleteRequestedLaboratory(requestedLaboratoryId);

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "آزمایش مورد نظر با موفقیت حذف شده است ");
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات با شکست روبرو شده است ");
        }
        #endregion

        #region Patient Request Detail

        [HttpGet]
        public async Task<IActionResult> PatientRequestDetail(ulong requestId)
        {
            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(requestId, User.GetUserId(), null, RequestType.HomeLab)) return NotFound();

            #endregion

            #region Is Exist Request & Patient

            var request = await _requestService.GetRequestById(requestId);

            if (!await _patientService.IsExistPatientById(request.PatientId.Value))
            {
                return NotFound();
            }

            #endregion

            #region Page Data

            ViewData["Countries"] = await _locationService.GetAllCountries();

            #endregion

            return View(new PatientRequestedLaboratoryAddressViewModel()
            {
                RequestId = requestId,
                PatientId = request.PatientId.Value,
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientRequestDetail(PatientRequestedLaboratoryAddressViewModel patientRequest)
        {
            #region Page Data

            ViewData["Countries"] = await _locationService.GetAllCountriesForHomePharmacy();

            #endregion

            #region Request Validation 

            if (!await _requestService.RequestValidatorWhileCompeleteSteps(patientRequest.RequestId, User.GetUserId(), null, RequestType.HomeLab)) return NotFound();

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                return View(patientRequest);
            }

            #endregion

            #region Create Patient Request Method

            var result = await _homeLaboratory.CreatePatientRequestDetail(patientRequest);

            switch (result)
            {
                case CreatePatientAddressResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است ";
                    return RedirectToAction("BankPay", "HomeLaboratory", new { requestId = patientRequest.RequestId });

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

            #region Get Home Visit Tarif 

            var homeLaboratory = await _siteSettingService.GetHomeLaboratoryTariff();
            if (homeLaboratory == 0)
            {
                TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
                return View();
            }

            #endregion

            #region Get Site Address Domain For Redirect To Bank Portal\

            var siteAddressDomain = await _siteSettingService.GetSiteAddressDomain();
            if (string.IsNullOrEmpty(siteAddressDomain))
            {
                TempData[ErrorMessage] = "امکان اتصال به درگاه بانکی وجود ندارد";
                return RedirectToAction("Index", "Home");
            }

            #endregion

            #region Online Payment

            var payment = new ZarinpalSandbox.Payment(homeLaboratory);

            var res = payment.PaymentRequest("پرداخت  ", $"{siteAddressDomain}HomeLaboratoryPayment/" + requestId, "Parsapanahpoor@yahoo.com", "09117878804");

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

        #region Home Laboratory Payment

        [Route("HomeLaboratoryPayment/{id}")]
        public async Task<IActionResult> HomeLaboratoryPayment(ulong id)
        {
            #region Get Request 

            var request = await _requestService.GetRequestById(id);

            #endregion

            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];

                #region Get Home Laboratory Tarif 

                var homeLaboratory = await _siteSettingService.GetHomeLaboratoryTariff();
                if (homeLaboratory == 0)
                {
                    TempData[ErrorMessage] = "لطفا با پشتیبانی تماس بگیرید";
                    return View();
                }

                #endregion

                var payment = new ZarinpalSandbox.Payment(homeLaboratory);
                var res = payment.Verification(authority).Result;

                if (res.Status == 100)
                {
                    ViewBag.code = res.RefId;
                    ViewBag.IsSuccess = true;

                    //Update Request State 
                    await _requestService.UpdateRequestStateForPayed(request);

                    //Charge User Wallet
                    await _homeLaboratory.ChargeUserWallet(User.GetUserId(), homeLaboratory);

                    //Pay Home Laboratory Tariff
                    await _homeLaboratory.PayHomeLAboratoryTariff(User.GetUserId(), homeLaboratory);

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
