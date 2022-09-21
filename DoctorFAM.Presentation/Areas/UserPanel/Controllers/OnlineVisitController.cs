using CRM.Web.Areas.Admin.Controllers;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Tikcet;
using DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics.Contracts;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class OnlineVisitController : UserBaseController
    {
        #region Ctor 

        private readonly IOnlineVisitService _onlineVisitService;
        private readonly ITicketService _ticketService;
        private readonly IRequestService _requestService;
        public IStringLocalizer<LocationController> _localizer;

        public OnlineVisitController(IOnlineVisitService onlineVisitService, ITicketService ticketService , IRequestService requestService
                                        , IStringLocalizer<LocationController> localizer)
        {
            _onlineVisitService = onlineVisitService;
            _ticketService = ticketService;
            _requestService = requestService;
            _localizer = localizer;
        }

        #endregion

        #region List Of Current User Online Visit Requests 

        public async Task<IActionResult> ListOfCurrentUserOnlineVisitRequests(FilterOnlineVisitRequestUserPanelViewModel filter)
        {
            filter.UserId = User.GetUserId();
            return View(await _onlineVisitService.FilterOnlineVisitRequestUserPanel(filter));
        }

        #endregion

        #region Show Online Visit Request Detail

        [HttpGet]
        public async Task<IActionResult> OnlineVisitRequestDetail(ulong requestId)
        {
            #region Get Request By Id

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return NotFound();
            if (request.RequestType != Domain.Enums.RequestType.RequestType.OnlineVisit || request.UserId != User.GetUserId() || !request.OperationId.HasValue) return NotFound();

            #endregion

            #region Get Ticket By Request Id

            var ticket = await _ticketService.GetTicketByOnlineVisitRequestId(requestId);
            if (ticket == null) return NotFound();
            if (ticket.OwnerId != request.OperationId.Value) return NotFound();
            if (ticket.TargetUserId != User.GetUserId()) return NotFound();

            #endregion

            #region Read Ticket

            await _ticketService.ReadTicketByUser(ticket);

            #endregion

            #region Get Ticket Messages

            var messages = await _ticketService.GetTikcetMessagesByTicketId(ticket.Id);

            ViewData["Ticket"] = ticket;
            ViewData["TicketMessages"] = messages;

            #endregion

            return View(new AnswerTikcetUserPanelViewModel
            {
                TicketId = ticket.Id
            });
        }

        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> OnlineVisitRequestDetail(AnswerTikcetUserPanelViewModel answer)
        {
            #region Get Ticket By Id

            var ticket = await _ticketService.GetTicketById(answer.TicketId);
            if (ticket == null) return NotFound();

            #endregion

            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                ViewData["Ticket"] = ticket;
                ViewData["TicketMessages"] = await _ticketService.GetTikcetMessagesByTicketId(answer.TicketId);
                return View(answer);
            }

            #endregion

            #region Create Answer For Ticket

            var result = await _ticketService.CreateAnswerTikcetFromUserPanel(answer, User.GetUserId());

            if (result)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                return RedirectToAction("OnlineVisitRequestDetail", "OnlineVisit", new { area = "UserPanel", requestId = ticket.RequestId });
            }

            TempData[ErrorMessage] = "خطایی رخ داده است لطفا مجدد تلاش کنید .";
            ViewData["Ticket"] = ticket;
            ViewData["TicketMessages"] = await _ticketService.GetTikcetMessagesByTicketId(answer.TicketId);

            #endregion

            return View(answer);
        }

        #endregion

        #region Delete Ticket Message

        public async Task<IActionResult> DeleteTicketMessage(ulong messageId)
        {
            var result = await _ticketService.DeleteTicketMessage(messageId, User.GetUserId());

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, _localizer["Mission Accomplished"].Value);
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, _localizer["The operation failed"].Value);
        }

        #endregion

    }
}
