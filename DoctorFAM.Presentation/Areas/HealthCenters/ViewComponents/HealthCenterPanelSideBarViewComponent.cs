using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.HealthCenters.ViewComponents
{
    #region In Menu Side Bar 

   public class HealthCenterPanelSideBarViewComponent : ViewComponent
    {
        #region Ctor

        public HealthCenterPanelSideBarViewComponent()
        {
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("HealthCenterPanelSideBar");
        }
    }

    #endregion

    #region In Index View

    public class HealthCenterPanelSideBarInIndexViewComponent : ViewComponent
    {
        #region Ctor

        public HealthCenterPanelSideBarInIndexViewComponent()
        {
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("HealthCenterPanelSideBarInIndex");
        }
    }

    #endregion
}
