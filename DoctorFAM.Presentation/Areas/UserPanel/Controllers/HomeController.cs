using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.ActionFilterAttributes;
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

        #region Index_Sec

        public async Task<IActionResult> Index_Sec()
        {
            return View(await _dashboardService.FillUserPanelDashboardViewModel(User.GetUserId()));
        }

        #endregion

        #region HealthHouse

        public async Task<IActionResult> HealthHouse()
        {
            return View();
        }

        #endregion

        #region HealthIndex

        public async Task<IActionResult> HealthIndex()
        {
            return View();
        }

        #endregion

    }
}
