using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class HomeController : UserBaseController
    {
        #region Ctor

        private readonly IDashboardsService _dashboardService;

        public HomeController(IDashboardsService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        #endregion

        #region Index

        public async Task<IActionResult> Index()
        {
            return View(await _dashboardService.FillUserPanelDashboardViewModel(User.GetUserId()));
        }

        #endregion
    }
}
