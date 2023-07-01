#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Areas.DoctorPanel.ViewComponents;

#endregion

public class LastestOnlineVisitRequestsViewComponent : ViewComponent
{
    #region Ctor

    private readonly IOnlineVisitService _onlineVisitService;

    public LastestOnlineVisitRequestsViewComponent(IOnlineVisitService onlineVisitService)
    {
        _onlineVisitService = onlineVisitService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _onlineVisitService.ListOfLastestOnlineVisitRequestDoctorSideViewModel(User.GetUserId());
        return View("LastestOnlineVisitRequests", model);
    }
}
