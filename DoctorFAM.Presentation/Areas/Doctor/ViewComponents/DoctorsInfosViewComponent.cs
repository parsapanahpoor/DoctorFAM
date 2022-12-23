using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.ViewComponents
{
    #region Side Bar 

    public class DoctorsInfosViewComponent : ViewComponent
    {
        #region Ctor

        public IDoctorsService _doctorService { get; set; }

        public DoctorsInfosViewComponent(IDoctorsService doctorService)
        {
            _doctorService = doctorService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _doctorService.GetDoctorsSideBarInfo(User.GetUserId());
            return View("DoctorsInfos", model.DoctorInfoState);
        }
    }

    public class DoctorsInfosBadgeViewComponent : ViewComponent
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
            return View("DoctorsInfosBadge", model.DoctorInfoState);
        }
    }

    #endregion

    #region  Index View

    public class DoctorsInfosBadgeIndexViewViewComponent : ViewComponent
    {
        #region Ctor

        public IDoctorsService _doctorService { get; set; }

        public DoctorsInfosBadgeIndexViewViewComponent(IDoctorsService doctorService)
        {
            _doctorService = doctorService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _doctorService.GetDoctorsSideBarInfo(User.GetUserId());
            return View("DoctorsInfosBadgeIndexView", model.DoctorInfoState);
        }
    }

    #endregion
}
