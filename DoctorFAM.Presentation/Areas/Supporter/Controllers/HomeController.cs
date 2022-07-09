using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Supporter.Controllers
{
    public class HomeController : SupporterBaseController
    {
        #region ctor

        private readonly IDashboardsService _dashboardService;

        public HomeController(IDashboardsService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        #endregion

        #region Supporter Dashboard

        public async Task<IActionResult> Index()
        {
            return View(await _dashboardService.FillSuppoeterDashboardViewModel());
        }

        #endregion

      
    }
}
