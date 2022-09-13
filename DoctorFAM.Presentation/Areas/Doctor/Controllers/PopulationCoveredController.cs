using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FamilyDoctor;
using DoctorFAM.Domain.Enums.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.DoctorPanel.PopulationCovered;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Web.Areas.Doctor.ActionFilterAttributes;
using DoctorFAM.Web.Doctor.Controllers;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Localization;
using NuGet.Protocol.Plugins;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    [IsUserDoctor]
    public class PopulationCoveredController : DoctorBaseController
    {
        #region Ctor

        private readonly IFamilyDoctorService _familyDoctorService;
        private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;
        private readonly IOrganizationService _organizationService;
        private readonly ISMSService _smsservice;

        public PopulationCoveredController(IFamilyDoctorService familyDoctorService, IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer
                                            , IHubContext<NotificationHub> notificationHub, INotificationService notificationService
                                                    , IUserService userService, IOrganizationService organizationService, ISMSService smsservice)
        {
            _familyDoctorService = familyDoctorService;
            _sharedLocalizer = sharedLocalizer;
            _notificationHub = notificationHub;
            _notificationService = notificationService;
            _userService = userService;
            _organizationService = organizationService;
            _smsservice = smsservice;
        }

        #endregion

        #region List Of Population Covered

        public async Task<IActionResult> FilterPopulationCovered(ListOfDoctorPopulationCoveredViewModel filter)
        {
            filter.UserId = User.GetUserId();
            return View(await _familyDoctorService.FilterDoctorPopulationCovered(filter));
        }

        #endregion

        #region Person In Your Population Covered Detail

        public async Task<IActionResult> PersonInPopulationCoveredDetail(ulong patientId)
        {
            #region Get Persone Information Detail In Doctor Population Covered 

            var model = await _familyDoctorService.GetPersoneInformationDetailInDoctorPopulationCovered(patientId, User.GetUserId());
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Change Population Covered Request State From Doctor

        public async Task<IActionResult> ChangePopulationCoveredRequestStateFromDoctor(ulong Id, FamilyDoctorRequestState State, string? RejectDescription)
        {
            #region Get User Selected Family Doctor Request 

            var request = await _familyDoctorService.GetUserSelectedFamilyDoctorByRequestId(Id);
            if (request == null) return NotFound();

            #endregion

            #region Fill View Model

            UserSelectedFamilyDoctor model = new UserSelectedFamilyDoctor()
            {
                RejectDescription = RejectDescription,
                CreateDate = request.CreateDate,
                DoctorId = request.DoctorId,
                Id = request.Id,
                FamilyDoctorRequestState = State,
                PatientId = request.PatientId
            };

            #endregion

            #region Update User Selected Family Doctor

            var res = await _familyDoctorService.ChangeUserSeletedFamilyDoctorRequestFromDoctor(model, User.GetUserId());

            if (res)
            {
                //Get Patient 
                var patient = await _userService.GetUserById(request.PatientId);

                #region Send SMS For Patient

                if (State == FamilyDoctorRequestState.Accepted)
                {
                    var message = Messages.SendSMSForAcceptFamilyDoctorRequest();

                    await _smsservice.SendSimpleSMS(patient.Mobile, message);
                }
                if (State == FamilyDoctorRequestState.Decline)
                {
                    var message = Messages.SendSMSForDeclineFamilyDoctorRequest();

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
