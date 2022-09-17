using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.PopulationCovered;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.Site.Request;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    public class OnlineVisitController : SiteBaseController
    {
        #region ctor

        private readonly IOnlineVisitService _onlineVisitService;
        private readonly IRequestService _requestService;
        private readonly IUserService _userService;

        public OnlineVisitController(IOnlineVisitService onlineVisitService, IRequestService requestService, IUserService userService)
        {
            _onlineVisitService = onlineVisitService;
            _requestService = requestService;
            _userService = userService;
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

        #region Online Visit Request Detail

        [HttpGet]
        public async Task<IActionResult> OnlineVisitRequestDetail(ulong requestId)
        {
            #region Data Validation

            if (!await _requestService.IsExistRequestByRequestId(requestId)) return NotFound();

            if (!await _userService.IsExistUserById(User.GetUserId())) return NotFound();

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
        public async Task<IActionResult> OnlineVisitRequestDetail(PatientViewModel patient)
        {
            #region Data Validation

            if (!await _userService.IsExistUserById(User.GetUserId())) return NotFound();

            #endregion

            #region Model State

            if (!ModelState.IsValid)
            {
                return NotFound();
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

                    //Add PatientId To The Request
                    await _requestService.AddPatientIdToRequest(patient.RequestId, patientId);

                    return RedirectToAction("BankPay", "OnlineVisit", new { requestId = patient.RequestId, patientId = patientId });
            }

            #endregion

            return View(patient);
        }

        #endregion
    }
}
