#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Interfaces.EFCore;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Dentist.ViewComponents;

#region In Menu Side Bar 

public class DentistPanelSideBarViewComponent : ViewComponent
{
    #region Ctor

    public IDentistService _dentistService;

    public DentistPanelSideBarViewComponent(IDentistService dentistService)
    {
        _dentistService = dentistService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("DentistPanelSideBar" , await _dentistService.GetDentistSideBarInfo(User.GetUserId()));
    }
}

#endregion

#region In Index View

public class DentistPanelSideBarInIndexViewComponent : ViewComponent
{
    #region Ctor

    public IDentistService _dentistService;
    private readonly IOrganizationService _organizationService;

    public DentistPanelSideBarInIndexViewComponent(IDentistService dentistService, IOrganizationService organizationService)
    {
        _dentistService = dentistService;
        _organizationService = organizationService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        #region Check Owner Of Organization

        var organization = await _organizationService.GetDentistOrganizationOwnerIdByUserId(User.GetUserId());
        if (organization != 0)
        {
            if (organization == User.GetUserId())
            {
                ViewBag.DentistIncoming = true;
            }
            else
            {
                ViewBag.DentistIncoming = false;
            }
        }

        #endregion

        return View("DentistPanelSideBarInIndex", await _dentistService.GetDentistSideBarInfo(User.GetUserId()));
    }
}

#endregion
