using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.ViewModels.Site.HomeVisit;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.Site.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoctorFAM.Web.Controllers
{
    [Authorize]
    public class HomeVisitController : SiteBaseController
    {
        #region Ctor

        public IHomeVisitService _homeVisitService;

        public ILocationService _locationService;

        public IPatientService _patientService;

        public IRequestService _requestService;

        public HomeVisitController(IHomeVisitService homeVisitService, ILocationService locationService , IPatientService patientService
                                    , IRequestService requestService)
        {
            _homeVisitService = homeVisitService;
            _locationService = locationService;
            _patientService = patientService;
            _requestService = requestService;
        }

        #endregion

        #region Home Visit

        [HttpGet]
        public async Task<IActionResult> HomeVisit()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> HomeVisit(RequestViewModel request)
        {
            #region Create New Request

            var requestId = await _homeVisitService.CreateHomeVisitRequest(User.GetUserId());

            if (requestId == null) return NotFound();

            #endregion

            return RedirectToAction("PatientDetails", "HomeVisit", new { requestId = requestId });
        }

        #endregion

        #region Patient Detail

        [HttpGet]
        public async Task<IActionResult> PatientDetails(ulong requestId)
        {
            if (!await _homeVisitService.IsExistHomeVisitRequestById(requestId)) return NotFound();

            return View(new PatientViewModel()
            {
                RequestId = requestId
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientDetails(PatientViewModel patient)
        {
            #region Model State

            if (!ModelState.IsValid) return View(patient);

            #endregion

            #region Validate model 

            var result = await _homeVisitService.ValidateCreatePatient(patient);

            switch (result)
            {
                case CreatePatientResult.Faild:
                    return NotFound();

                case CreatePatientResult.RequestIdNotFound:
                    return NotFound();

                case CreatePatientResult.Success:
                    var patientId = await _homeVisitService.CreatePatientDetail(patient);
                    return RedirectToAction("PatientRequestDetail", "HomeVisit", new { requestId = patient.RequestId , patientId = patientId});
            }

            #endregion

            return View(patient);
        }

        #endregion

        #region Patient Address

        [HttpGet]
        public async Task<IActionResult> PatientRequestDetail(ulong requestId , ulong patientId)
        {
            #region Is Exist Request & Patient

            if (!await _requestService.IsExistRequestByRequestId(requestId))
            {
                return NotFound();
            }

            if (! await _patientService.IsExistPatientById(patientId))
            {
                return NotFound();
            }

            #endregion

            #region Page Data

            ViewData["Countries"] = await _locationService.GetAllCountries();

            #endregion

            return View(new PatienAddressViewModel()
            {
                RequestId = requestId,
                PatientId = patientId
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientRequestDetail(PatienAddressViewModel patientRequest)
        {
            #region Model State Validation

            if (! ModelState.IsValid)
            {
                return View(patientRequest);
            }

            #endregion

            #region Create Patient Request Method

            var result = await _requestService.CreatePatientRequestDetail(patientRequest);

            switch (result)
            {
                case CreatePatientAddressResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است ";
                    return RedirectToAction("BankPay", "HomeVisit" , new { requestId = patientRequest.RequestId });

                case CreatePatientAddressResult.Failed:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شده است ";
                    break;

                case CreatePatientAddressResult.RquestNotFound:
                    TempData[ErrorMessage] = "درخواست یافت نشده است ";
                    break ;

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

        #region Bank Payment

        [HttpGet]
        public IActionResult BankPay(ulong requestId)
        {
            ViewBag.RequestId = requestId;
            return View();
        }

        #endregion
    }
}
