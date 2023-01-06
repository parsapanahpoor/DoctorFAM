using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Supporter.ViewComponents
{
    public class SupporterSideBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly ITicketService _ticketService;

        public SupporterSideBarViewComponent(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        #endregion
        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region ViewBags

            ViewBag.TicketCounts = await _ticketService.GetWaitingForResponseTicektsCountForAdminAnSupporters();

            #endregion

            return View("SupporterSideBar");
        }
    }
}
