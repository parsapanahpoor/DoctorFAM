#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Consultant.ViewComponents;

#endregion

#region Consultant Panel Side Bar 

public class ConsultantPanelSideBarViewComponent : ViewComponent
{
    #region Ctor

    private readonly IConsultantService _consultantService;

    public ConsultantPanelSideBarViewComponent(IConsultantService consultantService)
    {
        _consultantService = consultantService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("ConsultantPanelSideBar", await _consultantService.GetConsultantSideBarInfo(User.GetUserId()));
    }
}

#endregion

#region In Index View

public class ConsultantPanelSideBarInIndexViewComponent : ViewComponent
{
    #region Ctor

    public IConsultantService _consultantService;
    private readonly IOrganizationService _organizationService;

    public ConsultantPanelSideBarInIndexViewComponent(IConsultantService consultantService, IOrganizationService organizationService)
    {
        _consultantService = consultantService;
        _organizationService = organizationService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        #region Check Owner Of Organization

        var organization = await _organizationService.GetConsultanttOrganizationOwnerIdByUserId(User.GetUserId());
        if (organization != 0)
        {
            if (organization == User.GetUserId())
            {
                ViewBag.ConsultantIncoming = true;
            }
            else
            {
                ViewBag.ConsultantIncoming = false;
            }
        }

        #endregion

        return View("ConsultantPanelSideBarInIndex", await _consultantService.GetConsultantSideBarInfo(User.GetUserId()));
    }
}

#endregion
