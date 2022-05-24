using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Common;
using DoctorFAM.Domain.ViewModels.Site.HomeLaboratory;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.Site.Request;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    [Authorize]
    public class HomeLaboratoryController : SiteBaseController
    {
        #region Ctor

        public IHomeLaboratoryServices _homeLaboratory;

        public IRequestService _requestService;

        public IUserService _userService;

        public IPatientService _patientService;

        public ILocationService _locationService;

        public HomeLaboratoryController(IHomeLaboratoryServices homeLaboratory, IRequestService requestService, IUserService userService, IPatientService patientService, ILocationService locationService)
        {
            _homeLaboratory = homeLaboratory;
            _requestService = requestService;
            _userService = userService;
            _patientService = patientService;
            _locationService = locationService;
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

            var model = await _homeLaboratory.FillRequestedLaboratoryViewModel(requestId);

            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestedLaboratory(RequestedLaboratoryViewModel model, IFormFile? ExperimentPrescriptionImage, IFormFile? ExperimentImage)
        {
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

            return View(new PatientRequestedLaboratoryAddressViewModel()
            {
                RequestId = requestId,
                PatientId = request.PatientId.Value,
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientRequestDetail(PatientRequestedLaboratoryAddressViewModel patientRequest)
        {
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
