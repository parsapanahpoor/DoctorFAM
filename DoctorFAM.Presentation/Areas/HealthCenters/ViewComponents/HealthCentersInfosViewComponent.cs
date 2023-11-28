using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.HealthCenters.ViewComponents
{
    #region Side Bar 

    public class HealthCentersInfosViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IHealthCentersService _healthCentersService;

        public HealthCentersInfosViewComponent(IHealthCentersService healthCentersService)
        {
            _healthCentersService = healthCentersService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _healthCentersService.GetHealthCentersSideBarInfo(User.GetUserId());
            return View("HealthCentersInfos", model.HealthCenterInfoState);
        }
    }

    public class HealthCentersInfosBadgeViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IHealthCentersService _healthCentersService;

        public HealthCentersInfosBadgeViewComponent(IHealthCentersService healthCentersService)
        {
            _healthCentersService = healthCentersService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _healthCentersService.GetHealthCentersSideBarInfo(User.GetUserId());
            return View("HealthCentersInfosBadge", model.HealthCenterInfoState);
        }
    }

    #endregion

    #region  Index View

    public class HealthCentersInfosBadgeIndexViewViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IHealthCentersService _healthCentersService;

        public HealthCentersInfosBadgeIndexViewViewComponent(IHealthCentersService healthCentersService)
        {
            _healthCentersService = healthCentersService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _healthCentersService.GetHealthCentersSideBarInfo(User.GetUserId());
            return View("HealthCentersInfosBadgeIndexView", model.HealthCenterInfoState);
        }
    }

    #endregion
}
