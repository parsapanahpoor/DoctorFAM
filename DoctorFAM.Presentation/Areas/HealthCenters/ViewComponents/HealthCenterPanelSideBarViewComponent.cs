using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace DoctorFAM.Web.Areas.HealthCenters.ViewComponents
{
    #region In Menu Side Bar 

   public class HealthCentersBadgeIndexViewViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IHealthCentersService _healthCentersService;
        private readonly IOrganizationService _organizationService;

        public HealthCentersBadgeIndexViewViewComponent(IHealthCentersService healthCentersService,
                                                            IOrganizationService organizationService)
        {
            _healthCentersService = healthCentersService;
            _organizationService = organizationService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _healthCentersService.GetHealthCentersSideBarInfo(User.GetUserId());

            return View("HealthCentersBadgeIndexView", model.HealthCenterInfoState);
        }
    }

    #endregion

    #region In Index View

    public class HealthCenterPanelSideBarInIndexViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IHealthCentersService _healthCentersService;
        private readonly IOrganizationService _organizationService;

        public HealthCenterPanelSideBarInIndexViewComponent(IHealthCentersService healthCentersService, 
                                                            IOrganizationService organizationService)
        {
            _healthCentersService = healthCentersService;
            _organizationService = organizationService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region Check Owner Of Organization

            var organization = await _organizationService.GetOranizationOwnerIdByMemberUserId(User.GetUserId());
            if (organization != 0)
            {
                if (organization == User.GetUserId())
                {
                    ViewBag.OwnerIncoming = true;
                }
                else
                {
                    ViewBag.OwnerIncoming = false;
                }
            }

            #endregion

            return View("HealthCenterPanelSideBarInIndex", await _healthCentersService.GetHealthCentersSideBarInfo(User.GetUserId()));
        }
    }

    #endregion
}
