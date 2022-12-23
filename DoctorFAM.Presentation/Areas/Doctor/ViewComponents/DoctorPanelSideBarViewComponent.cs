using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.ViewComponents
{
    #region In Menu Side Bar 

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

    #endregion

    #region In Index View

    public class DoctorPanelSideBarInIndexViewComponent : ViewComponent
    {
        #region Ctor

        public IDoctorsService _doctorService;

        public DoctorPanelSideBarInIndexViewComponent(IDoctorsService doctorService)
        {
            _doctorService = doctorService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("DoctorPanelSideBarInIndex", await _doctorService.GetDoctorsSideBarInfo(User.GetUserId()));
        }
    }

    #endregion
}
