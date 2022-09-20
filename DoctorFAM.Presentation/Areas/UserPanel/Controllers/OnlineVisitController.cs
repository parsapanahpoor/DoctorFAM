using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class OnlineVisitController : UserBaseController
    {
        #region Ctor 

        private readonly IOnlineVisitService _onlineVisitService;
        private readonly ITicketService _ticketService;

        public OnlineVisitController(IOnlineVisitService onlineVisitService, ITicketService ticketService)
        {
            _onlineVisitService = onlineVisitService;
            _ticketService = ticketService;
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

        public async Task<IActionResult> OnlineVisitRequestDetail(ulong requestId)
        {
            return View();
        }

        #endregion
    }
}
