using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Areas.UserPanel.ViewComponents
{
    public class UserPanelChatBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly INotificationService _notificationService;
        private readonly IOrganizationService _organizationService;

        public UserPanelChatBarViewComponent(INotificationService notificationService, IOrganizationService organizationService)
        {
            _notificationService = notificationService;
            _organizationService = organizationService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _notificationService.GetListOfSupporterNotificationByUserId(User.GetUserId());
            return View("UserPanelChatBar", model);
        }
    }

}
