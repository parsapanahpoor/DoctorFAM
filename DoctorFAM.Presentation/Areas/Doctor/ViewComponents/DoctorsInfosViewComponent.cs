using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.ViewComponents
{
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
            var model = await _doctorService.GetDoctorsInfosState(User.GetUserId());
            return View("DoctorsInfos" , model );
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
            var model = await _doctorService.GetDoctorsInfosState(User.GetUserId());
            return View("DoctorsInfosBadge", model);
        }
    }
}
