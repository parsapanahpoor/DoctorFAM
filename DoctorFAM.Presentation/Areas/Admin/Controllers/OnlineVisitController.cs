using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.OnlineVisit;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Tikcet;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class OnlineVisitController : AdminBaseController
    {
        #region Ctor

        private readonly IOnlineVisitService _onlineVisitService;
        private readonly ITicketService _ticketService;
        private readonly ILocationService _locationService;
        private readonly IRequestService _requestService;

        public OnlineVisitController(IOnlineVisitService onlineVisitService, ITicketService tikcetService, ILocationService locationService, IRequestService requestService)
        {
            _onlineVisitService = onlineVisitService;
            _ticketService = tikcetService;
            _locationService = locationService;
            _requestService = requestService;
        }

        #endregion

        #region Old Methods

        #region Filter Online Reservation Requests

        public async Task<IActionResult> FilterOnlineVisitRequests(FilterOnlineVisitAdminSideViewModel filter)
        {
            #region Selected Countries

            ViewData["Countries"] = await _locationService.GetAllCountries();

            if (filter.CountryId != null)
            {
                ViewData["States"] = await _locationService.GetStateChildren(filter.CountryId.Value);
                if (filter.StateId != null)
                {
                    ViewData["Cities"] = await _locationService.GetStateChildren(filter.StateId.Value);
                }
            }

            #endregion

            return View(await _onlineVisitService.FilterOnlineVisitRequestsAdminSide(filter));
        }

        #endregion

        #region Online Visit Request Detail

        [HttpGet]
        public async Task<IActionResult> OnlineVisitRequestDetail(ulong requestId)
        {
            #region Fill View Model 

            var model = await _onlineVisitService.FillOnlineVisitRequestDetailAdminPanelViewModel(requestId);
            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        #endregion

        #region Online Visit Request Message Detail

        [HttpGet]
        public async Task<IActionResult> OnlineVisitRequestMessageDetail(ulong requestId)
        {
            #region Get Request By Id

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return NotFound();

            #endregion

            #region Get Ticket By Request Id

            var ticket = await _ticketService.GetTicketByOnlineVisitRequestId(requestId);
            if (ticket == null) return NotFound();
            if (ticket.OwnerId != request.OperationId.Value) return NotFound();
            if (ticket.TargetUserId != request.UserId) return NotFound();

            #endregion

            #region Get Ticket Messages

            var messages = await _ticketService.GetTikcetMessagesByTicketId(ticket.Id);

            ViewData["Ticket"] = ticket;
            ViewData["TicketMessages"] = messages;

            #endregion

            return View(new AnswerTikcetDoctorViewModel
            {
                TicketId = ticket.Id
            });
        }

        #endregion

        #endregion

        #region List Of Work Shifts

        [HttpGet]
        public async Task<IActionResult> ListOfWorkShiftsDates()
        {
            return View(await _onlineVisitService.FillListOfWorkShiftsDatesAdminSideViewModel());
        }

        #endregion
    }
}
