using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.ViewComponents
{
    public class DoctorPanelSideBarViewComponent : ViewComponent
    {
        #region Ctor

        public IDoctorsService _doctorService;

        public DoctorPanelSideBarViewComponent(IDoctorsService doctorService)
        {
            _doctorService = doctorService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("DoctorPanelSideBar" , await _doctorService.GetDoctorsSideBarInfo(User.GetUserId()));
        }
    }
}
