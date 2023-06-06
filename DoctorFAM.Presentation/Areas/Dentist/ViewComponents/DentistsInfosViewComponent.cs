#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Dentist.ViewComponents;

#region Side Bar 

public class DentistInfosViewComponent : ViewComponent
{
    #region Ctor

    public IDentistService _dentistService{ get; set; }

    public DentistInfosViewComponent(IDentistService dentistService)
    {
        _dentistService = dentistService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _dentistService.GetDentistSideBarInfo(User.GetUserId());
        return View("DentistInfos", model.DentistInfoState);
    }
}

public class DentistsInfosBadgeViewComponent : ViewComponent
{
    #region Ctor

    public IDentistService _dentistService{ get; set; }

    public DentistsInfosBadgeViewComponent(IDentistService dentistService)
    {
        _dentistService = dentistService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _dentistService.GetDentistSideBarInfo(User.GetUserId());
        return View("DentistInfosBadge", model.DentistInfoState);
    }
}

#endregion

#region  Index View

public class DentistsInfosBadgeIndexViewViewComponent : ViewComponent
{
    #region Ctor

    public IDentistService _dentistService { get; set; }

    public DentistsInfosBadgeIndexViewViewComponent(IDentistService dentistService)
    {
        _dentistService = dentistService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _dentistService.GetDentistSideBarInfo(User.GetUserId());
        return View("DentistsInfosBadgeIndexView", model.DentistInfoState);
    }
}

#endregion
