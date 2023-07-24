using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Laboratory.ViewComponents
{
    #region In Menu Side Bar 
    public class LaboratoryPanelSideBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly ILaboratoryService _laboratoryService;

        public LaboratoryPanelSideBarViewComponent(ILaboratoryService laboratoryService)
        {
            _laboratoryService = laboratoryService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("LaboratoryPanelSideBar", await _laboratoryService.GetLaboratorySideBarInfo(User.GetUserId()));
        }
    }
    #endregion

    #region In Index View

    public class LaboratoryPanelSideBarInIndexViewComponent : ViewComponent
    {
        #region Ctor

        public ILaboratoryService _laboratoryService;
        private readonly IOrganizationService _organizationService;

        public LaboratoryPanelSideBarInIndexViewComponent(ILaboratoryService laboratoryService, IOrganizationService organizationService)
        {
            _laboratoryService = laboratoryService;
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
                    ViewBag.LaboratoryIncoming = true;
                }
                else
                {
                    ViewBag.LaboratoryIncoming = false;
                }
            }

            #endregion

            return View("LaboratoryPanelSideBarInIndex", await _laboratoryService.GetLaboratorySideBarInfo(User.GetUserId()));
        }
    }

    #endregion
}
