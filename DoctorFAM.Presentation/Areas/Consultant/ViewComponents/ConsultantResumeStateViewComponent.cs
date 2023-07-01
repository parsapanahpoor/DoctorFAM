#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Consultant.ViewComponents;

#endregion

#region In Menu Side Bar 

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
        return View("ConsultantsResumeStateBadge", model);
    }
}

#endregion

#region In Index View

public class ConsultantsResumeStateBadgeInIndexViewComponent : ViewComponent
{
    #region Ctor

    public IResumeService _resumeService { get; set; }

    public ConsultantsResumeStateBadgeInIndexViewComponent(IResumeService resumeService)
    {
        _resumeService = resumeService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _resumeService.GetResumeByUserId(User.GetUserId());
        return View("ConsultantsResumeStateBadgeInIndex", model);
    }
}

#endregion