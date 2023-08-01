#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Tourism.ViewComponents;

public class TourismInfosViewComponent : ViewComponent
{
    #region Ctor

    public ITourismService  _tourismService { get; set; }

    public TourismInfosViewComponent(ITourismService tourismService)
    {
        _tourismService = tourismService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _tourismService.GetTourismSideBarInfo(User.GetUserId());
        return View("TourismInfos", model.TourismInfoState);
    }
}

public class TourismInfosBadgeViewComponent : ViewComponent
{
    #region Ctor

    public ITourismService _tourismService { get; set; }

    public TourismInfosBadgeViewComponent(ITourismService tourismService)
    {
        _tourismService = tourismService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _tourismService.GetTourismSideBarInfo(User.GetUserId());
        return View("TourismInfosBadge", model.TourismInfoState);
    }
}
