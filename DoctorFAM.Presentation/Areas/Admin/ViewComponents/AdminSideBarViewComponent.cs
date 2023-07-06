using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.ViewComponents
{
    public class AdminSideBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly ITicketService _ticketService;
        private readonly IOnlineVisitService _onlineVisitService;
        private readonly IDashboardsService _dashboardsService;

        public AdminSideBarViewComponent(ITicketService ticketService, IOnlineVisitService onlineVisitService, IDashboardsService dashboardsService)
        {
            _ticketService = ticketService;
            _onlineVisitService = onlineVisitService;
            _dashboardsService = dashboardsService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region ViewBags

            ViewBag.TicketCounts = await _ticketService.GetWaitingForResponseTicektsCountForAdminAnSupporters();
            ViewData["CountOfUserOnlineRequests"] = await _onlineVisitService.CountOfWaitingUserRequests();

            #endregion

            var model = await _dashboardsService.FillAdminSideBarViewModel();

            return View("AdminSideBar" , model); 
        }
    }
}
