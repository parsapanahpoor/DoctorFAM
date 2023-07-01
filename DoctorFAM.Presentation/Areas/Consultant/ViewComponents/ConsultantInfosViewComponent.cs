#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Consultant.ViewComponents;

#endregion

#region Consultant Infos

public class ConsultantInfosViewComponent : ViewComponent
{
    #region Ctor

    public IConsultantService _consultantService { get; set; }

    public ConsultantInfosViewComponent(IConsultantService consultantService)
    {
        _consultantService = consultantService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _consultantService.GetConsultantSideBarInfo(User.GetUserId());
        return View("ConsultantInfos", model.ConsultantInfoState);
    }
}

#endregion

#region Consultant Infos Badge

public class ConsultantInfosBadgeViewComponent : ViewComponent
{
    #region Ctor

    public IConsultantService _consultantService { get; set; }

    public ConsultantInfosBadgeViewComponent(IConsultantService consultantService)
    {
        _consultantService = consultantService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _consultantService.GetConsultantSideBarInfo(User.GetUserId());
        return View("ConsultantInfosBadge", model.ConsultantInfoState);
    }
}

#endregion

#region  Index View

public class ConsultantsInfosBadgeIndexViewViewComponent : ViewComponent
{
    #region Ctor

    public IConsultantService _consultantService { get; set; }

    public ConsultantsInfosBadgeIndexViewViewComponent(IConsultantService consultantService)
    {
        _consultantService = consultantService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _consultantService.GetConsultantSideBarInfo(User.GetUserId());
        return View("ConsultantsInfosBadgeIndexView", model.ConsultantInfoState);
    }
}

#endregion