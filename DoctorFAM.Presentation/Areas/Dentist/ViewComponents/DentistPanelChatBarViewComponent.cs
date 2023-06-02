#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace CRM.Web.Areas.Dentist.ViewComponents;

public class DentistPanelChatBarViewComponent : ViewComponent
{
    #region Ctor

    private readonly INotificationService _notificationService;
    private readonly IOrganizationService _organizationService;

    public DentistPanelChatBarViewComponent(INotificationService notificationService, IOrganizationService organizationService)
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

        var model = await _notificationService.GetListOfDentistPanelNotificationByUserId(organizationOwmerId);
        return View("DentistPanelChatBar", model);
    }
}



