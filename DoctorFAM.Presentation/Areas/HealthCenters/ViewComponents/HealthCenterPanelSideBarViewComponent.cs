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

        public IDoctorsService _doctorService;

        public HealthCenterPanelSideBarViewComponent(IDoctorsService doctorService)
        {
            _doctorService = doctorService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("HealthCenterPanelSideBar", await _doctorService.GetDoctorsSideBarInfo(User.GetUserId()));
        }
    }

    #endregion

    #region In Index View

    public class HealthCenterPanelSideBarInIndexViewComponent : ViewComponent
    {
        #region Ctor

        public IDoctorsService _doctorService;
        private readonly IOrganizationService _organizationService;

        public HealthCenterPanelSideBarInIndexViewComponent(IDoctorsService doctorService, IOrganizationService organizationService)
        {
            _doctorService = doctorService;
            _organizationService = organizationService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region Check Owner Of Organization

            var organization = await _organizationService.GetOrganizationByUserId(User.GetUserId());
            if (organization is not null)
            {
                if (organization.OwnerId == User.GetUserId())
                {
                    ViewBag.DoctorIncoming = true;
                }
                else
                {
                    ViewBag.DoctorIncoming = false;
                }
            }

            #endregion

            return View("HealthCenterPanelSideBarInIndex", await _doctorService.GetDoctorsSideBarInfo(User.GetUserId()));
        }
    }

    #endregion
}
