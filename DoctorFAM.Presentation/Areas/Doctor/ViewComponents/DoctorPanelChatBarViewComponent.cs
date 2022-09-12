using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Areas.DoctorPanel.ViewComponents
{
    public class DoctorPanelChatBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly INotificationService _notificationService;

        public DoctorPanelChatBarViewComponent(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _notificationService.GetListOfSupporterNotificationByUserId(User.GetUserId());
            return View("DoctorPanelChatBar", model);
        }
    }
}
