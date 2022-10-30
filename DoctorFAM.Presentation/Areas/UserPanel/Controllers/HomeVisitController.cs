using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.ViewModels.Site.Notification;
using DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse.HomeVisit;
using DoctorFAM.Web.ActionFilterAttributes;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    [CheckUserFillPersonalInformation]
    public class HomeVisitController : UserBaseController
    {
        #region Ctor 

        private readonly IHomeVisitService _homeVisitService;
        private readonly IRequestService _requestService;
        private readonly ISMSService _smsservice;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;

        public HomeVisitController(IHomeVisitService homeVisitService, IRequestService requestService, ISMSService smsservice, IHubContext<NotificationHub> notificationHub
                                                , INotificationService notificationService, IUserService userService)
        {
            _homeVisitService = homeVisitService;
            _requestService = requestService;
            _smsservice = smsservice;
            _notificationService = notificationService;
            _notificationHub = notificationHub;
            _userService = userService;
        }

        #endregion

        #region Filter Home Visit From User Panel 

        public async Task<IActionResult> FilterHomeVisitViewModel(FilterHomeVisitViewModel filter)
        {
            filter.UserId = User.GetUserId();
            return View(await _homeVisitService.FilterListOfUserHomeVisitRequest(filter));
        }

        #endregion

        #region Request Detail

        public async Task<IActionResult> RequestDetail(ulong requestId)
        {
            #region Get Request

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return NotFound();
            if (request.OperationId == null) return NotFound();

            #endregion

            #region Fill Model

            var model = await _homeVisitService.FillShowDoctorInformationDetailViewModel(request.OperationId.Value);
            if (model == null) return NotFound();

            #endregion

            ViewBag.RequestId = requestId;

            return View(model);
        }

        #endregion

        #region Accept Doctor 

        public async Task<IActionResult> AcceptDoctor(ulong requestId)
        {
            #region Get Request By Id

            var request = await _requestService.GetRequestById(requestId);
            if (request == null || request.UserId != User.GetUserId()) return NotFound();

            #endregion

            #region Accept Doctor Method

            var res = await _homeVisitService.AcceptDoctorRequestFromHomeVisitRequest(request);
            if (res)
            {
                #region Send SMS

                var message = Messages.SendSMSForAcceptHomeVisitRequestFromUser();

                await _smsservice.SendSimpleSMS(request.User.Mobile, message);

                #endregion

                #region Send Notification In SignalR

                //Create Notification For Supporters And Admins
                var notifyResult = await _notificationService.CreateSupporterNotification(request.Id, Domain.Enums.Notification.SupporterNotificationText.AcceptHomeVisitRequestFromUser, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                //Send Notification From Doctor 
                await _notificationService.CreateNotificationForSendAcceptHomeVisitRequestFromUserPanel(requestId, Domain.Enums.Notification.SupporterNotificationText.AcceptHomeVisitRequestFromUser, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                //Get Current User
                var currentUser = await _userService.GetUserById(User.GetUserId());

                if (notifyResult)
                {
                    //Get List Of Admins And Supporter To Send Notification Into Them
                    var users = await _userService.GetAdminsAndSupportersNotificationForSendNotificationInHomeVisit();

                    //Get Doctor For Send Notification  
                    users.Add(request.OperationId.Value.ToString());

                    //Fill Send Supporter Notification ViewModel For Send Notification
                    SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                    {
                        CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                        NotificationText = "تایید درخواست ویزیت درمنزل از طرف کاربر",
                        RequestId = request.Id,
                        Username = User.Identity.Name,
                        UserImage = currentUser.Avatar
                    };

                    await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
                }

                #endregion

                TempData[SuccessMessage] = "قبول درخواست باموفقیت ثبت شده است .";
                return RedirectToAction("Index", "Home", new { area = "UserPanel" });
            }

            #endregion

            return NotFound();
        }

        #endregion

        #region Decline Doctor 

        public async Task<IActionResult> DeclineDoctor(ulong requestId)
        {
            #region Get Request By Id

            var request = await _requestService.GetRequestById(requestId);
            if (request == null || request.UserId != User.GetUserId() || !request.OperationId.HasValue) return NotFound();

            #endregion

            #region Get User By Operation Id 

            var user = await _userService.GetUserById(request.OperationId.Value);
            if (user == null) return NotFound();

            #endregion

            #region Send SMS

            var message = Messages.SendSMSForDeclineHomeVisitRequestFromUser();

            await _smsservice.SendSimpleSMS(request.Operation.Mobile, message);

            #endregion

            #region Send Notification In SignalR

            //Create Notification For Supporters And Admins
            var notifyResult = await _notificationService.CreateSupporterNotification(request.Id, Domain.Enums.Notification.SupporterNotificationText.DeclineHomeVisitRequestFromUser, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

            //Send Notification From Doctor 
            await _notificationService.CreateNotificationForSendAcceptHomeVisitRequestFromUserPanel(requestId, Domain.Enums.Notification.SupporterNotificationText.DeclineHomeVisitRequestFromUser, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

            //Get Current User
            var currentUser = await _userService.GetUserById(User.GetUserId());

            if (notifyResult)
            {
                //Get List Of Admins And Supporter To Send Notification Into Them
                var users = await _userService.GetAdminsAndSupportersNotificationForSendNotificationInHomeVisit();

                //Get Doctor For Send Notification  
                users.Add(request.OperationId.Value.ToString());

                //Fill Send Supporter Notification ViewModel For Send Notification
                SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                {
                    CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                    NotificationText = "رد پزشک متقاضی ویزیت در منزل توسط کاربر",
                    RequestId = request.Id,
                    Username = User.Identity.Name,
                    UserImage = currentUser.Avatar
                };

                await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);

            }
            #endregion

            #region Accept Doctor Method

            var res = await _homeVisitService.DeclinetDoctorRequestFromHomeVisitRequest(request);

            #endregion

            TempData[SuccessMessage] = "قبول درخواست باموفقیت ثبت شده است .";
            return RedirectToAction("Index", "Home", new { area = "UserPanel" });
        }

        #endregion

        #region Remove Request

        public async Task<IActionResult> RemoveRequest(ulong requestId)
        {
            #region Get Request By Id

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return NotFound();
            if (request.UserId != User.GetUserId()) return NotFound();
            if (request.RequestState != RequestState.Finalized) return NotFound();

            #endregion

            #region Validate Request

            var res = await _homeVisitService.RemoveHomeVisitRequestFromUser(request , User.GetUserId());
            if (res)
            {
                #region Send SMS

                var message = Messages.SendSMSForCancelationHomeVisitRequestFromUser();

                await _smsservice.SendSimpleSMS(request.User.Mobile, message);

                #endregion

                #region Send Notification In SignalR

                //Create Notification For Supporters And Admins
                var notifyResult = await _notificationService.CreateSupporterNotification(request.Id, Domain.Enums.Notification.SupporterNotificationText.CancelHomeVisitRequest, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                //Send Notification From Doctor 
                await _notificationService.CreateNotificationForSendAcceptHomeVisitRequestFromUserPanel(requestId, Domain.Enums.Notification.SupporterNotificationText.CancelHomeVisitRequest, Domain.Enums.Notification.NotificationTarget.request, User.GetUserId());

                //Get Current User
                var currentUser = await _userService.GetUserById(User.GetUserId());

                if (notifyResult)
                {
                    //Get List Of Admins And Supporter To Send Notification Into Them
                    var users = await _userService.GetAdminsAndSupportersNotificationForSendNotificationInHomeVisit();

                    //Get Doctor For Send Notification  
                    users.Add(request.OperationId.Value.ToString());

                    //Fill Send Supporter Notification ViewModel For Send Notification
                    SendSupporterNotificationViewModel viewModel = new SendSupporterNotificationViewModel()
                    {
                        CreateNotificationDate = $"{DateTime.Now.ToShamsi()} - {DateTime.Now.Hour}:{DateTime.Now.Minute}",
                        NotificationText = "لغو درخواست ویزیت در منزل از طرف کاربر",
                        RequestId = request.Id,
                        Username = User.Identity.Name,
                        UserImage = currentUser.Avatar
                    };

                    await _notificationHub.Clients.Users(users).SendAsync("SendSupporterNotification", viewModel);
                }

                #endregion

                TempData[SuccessMessage] = "لغو درخواست ویزیت آنلاین با موفقیت انجام شده است .";
                return RedirectToAction("Index", "Home", new { area = "UserPanel" });
            }

            #endregion

            return NotFound();
        }

        #endregion
    }
}
