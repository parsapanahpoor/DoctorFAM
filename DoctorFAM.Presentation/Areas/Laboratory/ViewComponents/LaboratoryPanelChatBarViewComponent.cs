using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Laboratory.ViewComponents
{
    public class LaboratoryPanelChatBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly INotificationService _notificationService;
        private readonly IOrganizationService _organizationService;

        public LaboratoryPanelChatBarViewComponent(INotificationService notificationService, IOrganizationService organizationService)
        {
            _notificationService = notificationService;
            _organizationService = organizationService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _notificationService.GetListOfSupporterNotificationByUserId(User.GetUserId());
            return View("LaboratoryPanelChatBar", model);
        }
    }
}
