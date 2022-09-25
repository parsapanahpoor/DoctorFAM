using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.ViewModels.Nurse.HomeNurse;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Web.Hubs;
using DoctorFAM.Web.Nurse.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Net.Sockets;

namespace DoctorFAM.Web.Areas.Nurse.Controllers
{
    public class HomeNurseController : NurseBaseController
    {
        #region Ctor

        private readonly INurseService _nurseService;
        private readonly IRequestService _requestService;
        private readonly IOrganizationService _organizationService; 
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly ISMSService _smsService;
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;

        public HomeNurseController(INurseService nurseService, IRequestService requestService, IOrganizationService organizationService, INotificationService notificationService
                                    , IHubContext<NotificationHub> notificationHub, ISMSService smsService, IUserService userService)
        {
            _nurseService = nurseService;
            _requestService = requestService;
            _organizationService = organizationService;
            _notificationService = notificationService;
            _notificationHub = notificationHub;
            _smsService = smsService;
            _userService = userService;
        }

        #endregion

        #region Filter Home Nurse Requests

        public async Task<IActionResult> FilterHomeNurseRequests(FilterListOfHomeNurseRequestViewModel filter)
        {
            filter.NurseId = User.GetUserId();
            return View(await _nurseService.FilterFilterListOfHomeNurseRequestViewModel(filter));
        }

        #endregion

        #region Filter Your Home Nurse Requests

        public async Task<IActionResult> FilterYourHomeNurseRequests(FilterListOfHomeNurseRequestViewModel filter)
        {
            filter.NurseId = User.GetUserId();
            return View(await _nurseService.FilterYourListOfHomeNurseRequestViewModel(filter));
        }

        #endregion

        #region Home Nurse Request Detail 

        public async Task<IActionResult> HomeNurseRequestDetail(ulong requestId)
        {
            #region Get Nurse Request Detail

            var model = await _nurseService.FillHomeNurseRequestViewModel(requestId, User.GetUserId());
            if (model == null) return NotFound();
            if (model == null) return NotFound();
            if (model.User == null) return NotFound();
            if (model.Request == null) return NotFound();
            if (model.PatientRequestDetail == null) return NotFound();
            if (model.PatientRequestDateTimeDetail == null) return NotFound();
            if (model.Patient == null) return NotFound();

            #endregion

            #region Get Request By Id

            var request = await _requestService.GetRequestById(requestId);

            #endregion

            #region Is This Doctor Get This Request For Him Self

            ViewBag.IsThisRequestForThisNurse = await _requestService.IsOperatorIsCurrentUser(User.GetUserId(), requestId);

            #endregion

            return View(model);
        }

        #endregion

        #region Accept Request From Nurse 

        public async Task<IActionResult> AcceptHomeNurseRequestFromPharmacy(ulong requestId)
        {
            #region Get Request By Id 

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return NotFound();
            if (request.OperationId.HasValue) return NotFound();
            if (request.RequestState != Domain.Enums.Request.RequestState.Paid) return NotFound();

            #endregion

            #region Get Organization By User Id 

            var organization = await _organizationService.GetOrganizationByUserId(User.GetUserId());
            if (organization == null) return NotFound();

            #endregion

            #region Accept Request From Nurse 

            await _nurseService.AcceptHomeNurseRequestByNurse(organization.OwnerId, request);

            #endregion

            #region Send Notification For Admin And Supporters And Patient User

            //Create Notification For Supporters And Admins
            var notifyResult = await _notificationService.CreateSupporterNotification(request.Id, Domain.Enums.Notification.SupporterNotificationText.AcceptHomeNurseRequest, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

            //Send Notification From Nurse To User 
            await _notificationService.CreateNotificationForAcceptHomeNurseRequest(request.Id, Domain.Enums.Notification.SupporterNotificationText.AcceptHomeNurseRequest, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

            //Get Current Organization
            var currentOrganization = organization;

            if (notifyResult)
            {
                //Get List Of Admins And Supporter To Send Notification Into Them
                var users = await _userService.GetAdminsAndSupportersNotificationForSendNotificationInHomePharmacy();

                users.Add(request.UserId.ToString());

                //Fill Send Supporter Notification ViewModel For Send Notification
                SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                {
                    CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                    NotificationText = "قبول درخواست از طرف پرستار",
                    RequestId = request.Id,
                    Username = User.Identity.Name,
                    UserImage = currentOrganization.User.Avatar
                };

                await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
            }

            #region Send SMS For Customer User 

            var message = Messages.SendSMSForAccepteDrugRequestFromPharamcy();

            await _smsService.SendSimpleSMS(request.User.Mobile, message);

            #endregion


            #endregion

            TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است.";
            return RedirectToAction("Index" , "Home" , new { area = "Nurse" });
        }

        #endregion
    }
}
