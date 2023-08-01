#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Tourism.ViewComponents
{
    #region In Menu Side Bar 
    public class TourismPanelSideBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly ITourismService _tourismService;

        public TourismPanelSideBarViewComponent(ITourismService tourismService)
        {
            _tourismService = tourismService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("TourismPanelSideBar", await _tourismService.GetTourismSideBarInfo(User.GetUserId()));
        }
    }
    #endregion

    #region In Index View

    public class TourismPanelSideBarInIndexViewComponent : ViewComponent
    {
        #region Ctor

        public ITourismService _tourismService;
        private readonly IOrganizationService _organizationService;

        public TourismPanelSideBarInIndexViewComponent(ITourismService tourismService, IOrganizationService organizationService)
        {
            _tourismService = tourismService;
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
                    ViewBag.TourismIncoming = true;
                }
                else
                {
                    ViewBag.TourismIncoming = false;
                }
            }

            #endregion

            return View("TourismPanelSideBarInIndex", await _tourismService.GetTourismSideBarInfo(User.GetUserId()));
        }
    }

    #endregion
}
