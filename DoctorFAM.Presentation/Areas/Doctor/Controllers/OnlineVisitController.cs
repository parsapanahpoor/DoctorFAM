using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using DoctorFAM.Web.Doctor.Controllers;
using DoctorFAM.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    public class OnlineVisitController : DoctorBaseController
    {
        #region Ctor

        private readonly IOnlineVisitService _onlineVisitService;
        private readonly ILocationService _locationService;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly INotificationService _notificationService;
        private readonly ISMSService _smsservice;
        private readonly IRequestService _requestService;
        private readonly ITicketService _ticketService;

        public OnlineVisitController(IOnlineVisitService onlineVisitService, ILocationService locationService, IHubContext<NotificationHub> notificationHub
                                                , INotificationService notificationService, ISMSService smsservice, IRequestService requestService , ITicketService ticketService)
        {
            _onlineVisitService = onlineVisitService;
            _locationService = locationService;
            _notificationHub = notificationHub;
            _notificationService = notificationService;
            _smsservice = smsservice;
            _requestService = requestService;
            _ticketService = ticketService;
        }

        #endregion

        #region List Of Online Visit Requests

        public async Task<IActionResult> FilterOnlineVisitRequests(FilterOnlineVisitViewModel filter)
        {
            ViewData["Countries"] = await _locationService.GetAllCountries();

            if (filter.CountryId != null)
            {
                ViewData["States"] = await _locationService.GetStateChildren(filter.CountryId.Value);
                if (filter.StateId != null)
                {
                    ViewData["Cities"] = await _locationService.GetStateChildren(filter.StateId.Value);
                }
            }

            return View(await _onlineVisitService.FilterOnlineVisitRequests(filter));
        }

        #endregion

        #region Online Visit Request Detail

        [HttpGet]
        public async Task<IActionResult> OnlineVisitRequestDetail(ulong requestId)
        {
            #region Fill View Model 

            var model = await _onlineVisitService.FillOnlineVisitRequestDetailDoctorPanelViewModel(requestId);
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Confirm Online Visit Request From Doctor And Create Ticket 

        public async Task<IActionResult> ConfirmOnlineVisitRequest(ulong requestId)
        {
            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return NotFound();

            #endregion

            #region Confirm Online Visit Request 

            var res = await _onlineVisitService.ConfirmOnlineVisitRequestFromDoctor(requestId, User.GetUserId());
            if (res)
            {
                #region Send SMS

                var message = Messages.SendSMSForAcceptOnlineVisitRequestFromDoctor();
                await _smsservice.SendSimpleSMS(request.User.Mobile, message);

                #endregion

                #region Create Ticket 

                await _ticketService.AddTicketForFirstTimeInOnlineVisitInDoctorPanel(request);

                #endregion

                TempData[SuccessMessage] = "قبول درخواست باموفقیت ثبت شده است .";
                return RedirectToAction("Index", "Home", new { area = "Doctor" });
            }

            #endregion

            TempData[ErrorMessage] = "قبول درخواست باموفقیت شکست مواجه شده است .";
            return RedirectToAction("Index", "Home", new { area = "Doctor" });
        }

        #endregion

        #region Filter Your Online Visit Request

        public async Task<IActionResult> FilterYourOnlineVisitRequest(FilterOnlineVisitViewModel filter)
        {
            filter.UserId = User.GetUserId();
            return View(await _onlineVisitService.FilterYourOnlineVisitRequest(filter));
        }

        #endregion
    }
}
