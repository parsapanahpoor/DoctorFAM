#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Consultant.ViewComponents;

#endregion

public class ConsultantPanelChatBarViewComponent : ViewComponent
{
    #region Ctor

    private readonly INotificationService _notificationService;
    private readonly IOrganizationService _organizationService;

    public ConsultantPanelChatBarViewComponent(INotificationService notificationService, IOrganizationService organizationService)
    {
        _notificationService = notificationService;
        _organizationService = organizationService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        #region Get Organziation 

        ulong organizationOwmerId = await _organizationService.GetOranizationOwnerIdByMemberUserId(User.GetUserId());

        #endregion

        var model = await _notificationService.GetListOfConsultantPanelNotificationByUserId(organizationOwmerId);
        return View("ConsultantPanelChatBar", model);
    }
}
