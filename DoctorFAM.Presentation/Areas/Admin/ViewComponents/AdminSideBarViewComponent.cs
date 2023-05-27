using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.ViewComponents
{
    public class AdminSideBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly ITicketService _ticketService;
        private readonly IOnlineVisitService _onlineVisitService;

        public AdminSideBarViewComponent(ITicketService ticketService, IOnlineVisitService onlineVisitService)
        {
            _ticketService = ticketService;
            _onlineVisitService = onlineVisitService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region ViewBags

            ViewBag.TicketCounts = await _ticketService.GetWaitingForResponseTicektsCountForAdminAnSupporters();
            ViewData["CountOfUserOnlineRequests"] = await _onlineVisitService.CountOfWaitingUserRequests();

            #endregion

            return View("AdminSideBar");
        }
    }
}
