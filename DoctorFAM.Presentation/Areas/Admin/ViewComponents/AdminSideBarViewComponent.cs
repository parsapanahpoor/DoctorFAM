using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.ViewComponents
{
    public class AdminSideBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly ITicketService _ticketService;

        public AdminSideBarViewComponent(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region ViewBags

            ViewBag.TicketCounts = await _ticketService.GetWaitingForResponseTicektsCountForAdminAnSupporters();

            #endregion

            return View("AdminSideBar");
        }
    }
}
