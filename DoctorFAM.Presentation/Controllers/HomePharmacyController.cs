using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
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

        public IHomePharmacyServicec _homePharmacy;

        public IRequestService _requestService;

        public IUserService _userService;

        public IPatientService _patientService;

        public ILocationService _locationService;

        public HomePharmacyController(IHomePharmacyServicec homePharmacy, IRequestService requestService, IUserService userService, IPatientService patientService, ILocationService locationService)
        {
            _homePharmacy = homePharmacy;
            _requestService = requestService;
            _userService = userService;
            _patientService = patientService;
            _locationService = locationService;
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
        public async Task<IActionResult> PatientDetails(ulong requestId)
        {
            #region Data Validation

            if (!await _requestService.IsExistRequestByRequestId(requestId)) return NotFound();

            if (!await _userService.IsExistUserById(User.GetUserId())) return NotFound();

            #endregion

            return View(new PatientViewModel()
            {
                RequestId = requestId,
                UserId = User.GetUserId(),
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientDetails(PatientViewModel patient)
        {
            #region Data Validation

            if (!await _userService.IsExistUserById(User.GetUserId())) return NotFound();

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

            return View(patient);
        }

        #endregion

        #region Requested Drogs 

        [HttpGet]
        public async Task<IActionResult> RequestedDrogs(ulong requestId, ulong patientId)
        {
            #region Is Exist Request & Patient

            if (!await _requestService.IsExistRequestByRequestId(requestId))
            {
                return NotFound();
            }

            if (!await _patientService.IsExistPatientById(patientId))
            {
                return NotFound();
            }

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
            #region Is Exist Request & Patient

            if (!await _requestService.IsExistRequestByRequestId(requestId))
            {
                return NotFound();
            }

            var request = await _requestService.GetRequestById(requestId);

            if (!await _patientService.IsExistPatientById(request.PatientId.Value))
            {
                return NotFound();
            }

            #endregion

            #region Page Data

            ViewData["Countries"] = await _locationService.GetAllCountries();

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
                    return RedirectToAction("SecPage", "Home");

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
    }
}
