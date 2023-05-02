using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.ViewModels.DoctorPanel.HomeVisit;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Web.Areas.Doctor.ActionFilterAttributes;
using DoctorFAM.Web.Doctor.Controllers;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    [IsUserDoctor]
    public class HomeVisitController : DoctorBaseController
    {
        #region Ctor

        private readonly IHomeVisitService _homeVisitService;
        private readonly IRequestService _requestService;
        private readonly IDoctorsService _doctorsService;
        private readonly ISMSService _smsservice;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;

        public HomeVisitController(IHomeVisitService homeVisitService, IDoctorsService doctorsService, IRequestService requestService, ISMSService smsservice, IHubContext<NotificationHub> notificationHub
                                                , INotificationService notificationService, IUserService userService)
        {
            _homeVisitService = homeVisitService;
            _doctorsService = doctorsService;
            _requestService = requestService;
            _smsservice = smsservice;
            _notificationService = notificationService;
            _notificationHub = notificationHub;
            _userService = userService;
        }

        #endregion

        #region List Of Home Visit Requests

        public async Task<IActionResult> ListOfHomeVisitRequest(ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel filter)
        {
            #region Validate Doctor Interest

            var doctorInterest = await _doctorsService.GetDoctorsSideBarInfo(User.GetUserId());
            if (doctorInterest.HomeVisit != true) return NotFound();

            #endregion

            #region Doctor Id

            filter.DoctorId = User.GetUserId();

            #endregion

            var model = await _homeVisitService.ListOfPayedHomeVisitsRequestsDoctorPanelSide(filter);

            #region Log For Decline 

            ViewBag.declineRequest = await _homeVisitService.CheckLogForDeclineHomeVisitRequest(User.GetUserId());

            #endregion

            return View(model);
        }

        #endregion

        #region List Of Home Visit Requests

        public async Task<IActionResult> ListOfYourHomeVisitRequest(ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel filter)
        {
            #region Validate Doctor Interest

            var doctorInterest = await _doctorsService.GetDoctorsSideBarInfo(User.GetUserId());
            if (doctorInterest.HomeVisit != true) return NotFound();

            #endregion

            #region Doctor Id

            filter.DoctorId = User.GetUserId();

            #endregion

            return View(await _homeVisitService.ListOfYourHomeVisitsRequestsDoctorPanelSide(filter));
        }

        #endregion

        #region Show Home Visit Request Detail 

        public async Task<IActionResult> HomeVisitRequestDetail(ulong requestId)
        {
            #region Fill View Model

            var model = await _homeVisitService.FillHomeVisitRequestDetailViewModel(requestId , User.GetUserId());
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Confirm Home Visit Request

        public async Task<IActionResult> ConfirmHomeVisitRequest(ulong requestId)
        {
            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return NotFound();

            #endregion

            #region Confirm Home Visit Request 

            var res = await _homeVisitService.ConfirmHomeVisitRequestFromDoctor(requestId, User.GetUserId());
            if (res)
            {
                #region Send SMS

                var link = $"{PathTools.SiteAddress}/UserPanel/HomeVisit/RequestDetail?requestId={requestId}";

                var message = Messages.SendSMSForAcceptHomeVisitRequestFromDoctor();
                var messagelink = Messages.SendSMSForLinkOfHomeVisitRequestFromDoctor(link);

                await _smsservice.SendSimpleSMS(request.User.Mobile, message);
                await _smsservice.SendSimpleSMS(request.User.Mobile, messagelink);

                #endregion

                #region Send Notification In SignalR

                //Create Notification For Supporters And Admins
                var notifyResult = await _notificationService.CreateSupporterNotification(request.Id, Domain.Enums.Notification.SupporterNotificationText.AcceptHomeVisitRequestFromDoctor, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                //Send Notification From Doctor 
                await _notificationService.CreateNotificationForSendAcceptHomeVisitRequest(requestId, Domain.Enums.Notification.SupporterNotificationText.AcceptHomeVisitRequestFromDoctor, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                //Get Current User
                var currentUser = await _userService.GetUserById(User.GetUserId());

                if (notifyResult)
                {
                    //Get List Of Admins And Supporter To Send Notification Into Them
                    var users = await _userService.GetAdminsAndSupportersNotificationForSendNotificationInHomeVisit();

                    //Get Doctor For Send Notification  
                    users.Add(request.UserId.ToString());

                    //Fill Send Supporter Notification ViewModel For Send Notification
                    SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                    {
                        CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                        NotificationText = "تایید درخواست ویزیت درمنزل از طرف پزشک",
                        RequestId = request.Id,
                        Username = User.Identity.Name,
                        UserImage = currentUser.Avatar
                    };

                    await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
                }

                #endregion

                TempData[SuccessMessage] = "قبول درخواست باموفقیت ثبت شده است .";
                return RedirectToAction("Index", "Home", new { area = "Doctor" });
            }

            #endregion

            TempData[ErrorMessage] = "قبول درخواست باشکست مواجه شده است .";
            return RedirectToAction("Index", "Home", new { area = "Doctor" });
        }

        #endregion
    }
}
