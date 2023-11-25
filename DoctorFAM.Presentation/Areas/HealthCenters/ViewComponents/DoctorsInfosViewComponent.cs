using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.HealthCenters.ViewComponents
{
    #region Side Bar 

    public class HealthCentersInfosViewComponent : ViewComponent
    {
        #region Ctor

        public IDoctorsService _doctorService { get; set; }

        public HealthCentersInfosViewComponent(IDoctorsService doctorService)
        {
            _doctorService = doctorService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _doctorService.GetDoctorsSideBarInfo(User.GetUserId());
            return View("HealthCentersInfos", model.DoctorInfoState);
        }
    }

    public class HealthCentersInfosBadgeViewComponent : ViewComponent
    {
        #region Ctor

        public IDoctorsService _doctorService { get; set; }

        public DoctorsInfosBadgeViewComponent(IDoctorsService doctorService)
        {
            _doctorService = doctorService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _doctorService.GetDoctorsSideBarInfo(User.GetUserId());
            return View("HealthCentersInfosBadge", model.DoctorInfoState);
        }
    }

    #endregion

    #region  Index View

    public class HealthCentersInfosBadgeIndexViewViewComponent : ViewComponent
    {
        #region Ctor

        public IDoctorsService _doctorService { get; set; }

        public HealthCentersInfosBadgeIndexViewViewComponent(IDoctorsService doctorService)
        {
            _doctorService = doctorService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _doctorService.GetDoctorsSideBarInfo(User.GetUserId());
            return View("HealthCentersInfosBadgeIndexView", model.DoctorInfoState);
        }
    }

    #endregion
}
