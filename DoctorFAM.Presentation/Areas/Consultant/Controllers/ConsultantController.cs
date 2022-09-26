using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Entities.FamilyDoctor;
using DoctorFAM.Domain.Enums.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantRequest;
using DoctorFAM.Domain.ViewModels.DoctorPanel.PopulationCovered;
using DoctorFAM.Web.Consultant.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Consultant.Controllers
{
    public class ConsultantController : ConsultantBaseController
    {
        #region ctor

        private readonly IConsultantService _consultantService;
        private readonly IUserService _userService;
        private readonly ISMSService _smsservice;
        private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;

        public ConsultantController(IConsultantService consultantService, IUserService userService, ISMSService smsservice, IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer)
        {
            _consultantService = consultantService;
            _userService = userService;
            _smsservice = smsservice;
            _sharedLocalizer = sharedLocalizer;
        }

        #endregion

        #region List Of Population Covered Request

        public async Task<IActionResult> FilterPopulationCovered(ListOfConsultantPopulationCoveredViewModel filter)
        {
            filter.UserId = User.GetUserId();
            return View(await _consultantService.FilterListOfConsultantPopulationCoveredViewModel(filter));
        }

        #endregion

        #region Person In Your Population Covered Detail

        public async Task<IActionResult> PersonInPopulationCoveredDetail(ulong patientId)
        {
            #region Get Persone Information Detail In Consultant Population Covered 

            var model = await _consultantService.GetPersoneInformationDetailInConsultantPopulationCovered(patientId, User.GetUserId());
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Change Population Covered Request State From Consultant

        public async Task<IActionResult> ChangePopulationCoveredRequestStateFromConsultant(ulong Id, FamilyDoctorRequestState State, string? RejectDescription)
        {
            #region Get User Selected Consultant Request 

            var request = await _consultantService.GetUserSelectedConsultantByRequestId(Id);
            if (request == null) return NotFound();

            #endregion

            #region Fill View Model

            UserSelectedConsultant model = new UserSelectedConsultant()
            {
                RejectDescription = RejectDescription,
                CreateDate = request.CreateDate,
                ConsultantId = request.ConsultantId,
                Id = request.Id,
                ConsultantRequestState = State,
                PatientId = request.PatientId
            };

            #endregion

            #region Update User Selected Consultant

            var res = await _consultantService.ChangeUserSeletedConsultantRequestFromConsultant(model, User.GetUserId());

            if (res)
            {
                //Get Patient 
                var patient = await _userService.GetUserById(request.PatientId);

                #region Send SMS For Patient

                if (State == FamilyDoctorRequestState.Accepted)
                {
                    var message = Messages.SendSMSForAcceptConsultantRequest();

                    await _smsservice.SendSimpleSMS(patient.Mobile, message);
                }
                if (State == FamilyDoctorRequestState.Decline)
                {
                    var message = Messages.SendSMSForDeclineConsultantRequest();

                    await _smsservice.SendSimpleSMS(patient.Mobile, message);
                }

                #endregion

                TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                return RedirectToAction(nameof(FilterPopulationCovered));
            }

            #endregion

            TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
            return RedirectToAction(nameof(FilterPopulationCovered));
        }

        #endregion
    }
}
