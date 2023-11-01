using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Supporter.ViewComponents
{
    public class SupporterSideBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly ITicketService _ticketService;
        private readonly IDashboardsService _dashboardsService;

        public SupporterSideBarViewComponent(ITicketService ticketService, IDashboardsService dashboardsService)
        {
            _ticketService = ticketService;
            _dashboardsService = dashboardsService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region ViewBags

            ViewBag.TicketCounts = await _ticketService.GetWaitingForResponseTicektsCountForAdminAnSupporters();

            #endregion

            var model = await _dashboardsService.FillAdminSideBarViewModel();

            return View("SupporterSideBar" , model);
        }
    }
}
