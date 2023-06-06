#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Dentist.ViewComponents;

#region In Menu Side Bar 

public class DentistsResumeStateViewComponent : ViewComponent
{
    #region Ctor

    public IResumeService _resumeService { get; set; }

    public DentistsResumeStateViewComponent(IResumeService resumeService)
    {
        _resumeService = resumeService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _resumeService.GetResumeByUserId(User.GetUserId());
        return View("DentistsResumeStateResume", model);
    }
}

public class DentistsResumeStateBadgeViewComponent : ViewComponent
{
    #region Ctor

    public IResumeService _resumeService { get; set; }

    public DentistsResumeStateBadgeViewComponent(IResumeService resumeService)
    {
        _resumeService = resumeService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _resumeService.GetResumeByUserId(User.GetUserId());
        return View("DentistsResumeStateBadge", model);
    }
}

#endregion

#region In Index View

public class DentistsResumeStateInIndexViewComponent : ViewComponent
{
    #region Ctor

    public IResumeService _resumeService { get; set; }

    public DentistsResumeStateInIndexViewComponent(IResumeService resumeService)
    {
        _resumeService = resumeService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _resumeService.GetResumeByUserId(User.GetUserId());
        return View("DentistsResumeStateResumeInIndex", model);
    }
}

public class DentistsResumeStateBadgeInIndexViewComponent : ViewComponent
{
    #region Ctor

    public IResumeService _resumeService { get; set; }

    public DentistsResumeStateBadgeInIndexViewComponent(IResumeService resumeService)
    {
        _resumeService = resumeService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _resumeService.GetResumeByUserId(User.GetUserId());
        return View("DentistsResumeStateBadgeInIndex", model);
    }
}

#endregion
