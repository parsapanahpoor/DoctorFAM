using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.PopulationCovered;
using DoctorFAM.Domain.ViewModels.Site.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.Site.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DoctorFAM.Web.Controllers
{
    [Authorize]
    public class OnlineVisitController : SiteBaseController
    {
        #region ctor

        private readonly IOnlineVisitService _onlineVisitService;
        private readonly IRequestService _requestService;
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;
        private readonly ILocationService _locationService;

        public OnlineVisitController(IOnlineVisitService onlineVisitService, IRequestService requestService,
                                        IUserService userService, IPatientService patientService , ILocationService locationService)
        {
            _onlineVisitService = onlineVisitService;
            _requestService = requestService;
            _userService = userService;
            _patientService = patientService;
            _locationService = locationService;
        }

        #endregion

        #region Home Visit

        [HttpGet]
        public async Task<IActionResult> OnlineVisit()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> OnlineVisit(RequestViewModel request)
        {
            #region Create New Request

            var requestId = await _onlineVisitService.CreateOnlineVisitRequest(User.GetUserId());

            if (requestId == null) return NotFound();

            #endregion

            return RedirectToAction("PatientDetails", "OnlineVisit", new { requestId = requestId });
        }

        #endregion

        #region Patient Details

        [HttpGet]
        public async Task<IActionResult> PatientDetails(ulong requestId)
        {
            #region Data Validation

            if (!await _requestService.IsExistRequestByRequestId(requestId)) return NotFound();

            if (!await _userService.IsExistUserById(User.GetUserId())) return NotFound();

            #endregion

            #region Get User By Id 

            var user = await _userService.GetUserById(User.GetUserId());

            #endregion

            #region Page Data

            ViewData["Countries"] = await _locationService.GetAllCountries();

            #endregion

            return View(new PatientDetailForOnlineVisitViewModel()
            {
                RequestId = requestId,
                UserId = User.GetUserId(),
                NationalId = !string.IsNullOrEmpty(user.NationalId) ? user.NationalId : null,
                PatientName = !string.IsNullOrEmpty(user.FirstName) ? user.FirstName : null,
                PatientLastName = !string.IsNullOrEmpty(user.LastName) ? user.LastName : null,
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientDetails(PatientDetailForOnlineVisitViewModel patient)
        {
            #region Page Data

            ViewData["Countries"] = await _locationService.GetAllCountries();

            #endregion

            #region Data Validation

            if (!await _userService.IsExistUserById(User.GetUserId())) return NotFound();

            #endregion

            #region Model State

            if (!ModelState.IsValid )
            {
                if (!string.IsNullOrEmpty(patient.RequestDescription))
                {
                    return NotFound();
                }
            }

            #endregion

            #region Validate model 

            var result = await _onlineVisitService.ValidateCreatePatient(patient);

            switch (result)
            {
                case CreatePatientResult.Faild:
                    return NotFound();

                case CreatePatientResult.RequestIdNotFound:
                    return NotFound();

                case CreatePatientResult.Success:

                    //Add Patient Detail
                     var patientId = await _onlineVisitService.CreatePatientDetail(patient);
                    if (patientId == 0)
                    {
                        TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                        return RedirectToAction("Index" , "Home");
                    }

                    //Add PatientId To The Request
                    await _requestService.AddPatientIdToRequest(patient.RequestId, patientId);

                    return RedirectToAction("OnlineVisitRequestDetail", "OnlineVisit", new { requestId = patient.RequestId, patientId = patientId });
            }

            #endregion

            return View(patient);
        }

        #endregion

        #region Online Visit Request Detail

        [HttpGet]
        public async Task<IActionResult> OnlineVisitRequestDetail(ulong requestId, ulong patientId)
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

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> OnlineVisitRequestDetail(OnlineVisitRquestDetailViewModel onlineVisitRquestDetail)
        {
            #region Model State Validation

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return View(onlineVisitRquestDetail);
            }

            if (string.IsNullOrEmpty(onlineVisitRquestDetail.OnlineVisitRequestDescription) && onlineVisitRquestDetail.OnlineVisitRequestFile == null)
            {
                TempData[ErrorMessage] = "وارد کردن حداقل یکی از اطلاعات الزامی می باشد.";
                return View(onlineVisitRquestDetail);
            }

            #endregion

            #region Add Online Visit Request Detail

            var res = await _onlineVisitService.AddOnlineVisitRequest(onlineVisitRquestDetail , User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است ";
                return RedirectToAction("BankPay", "OnlineVisit", new { requestId = onlineVisitRquestDetail.RequestId });
            }

            #endregion

            return View(onlineVisitRquestDetail);
        }

        #endregion

        #region Bank Payment



        #endregion
    }
}
