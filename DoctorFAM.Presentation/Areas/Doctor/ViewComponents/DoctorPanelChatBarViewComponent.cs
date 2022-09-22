using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Areas.DoctorPanel.ViewComponents
{
    public class DoctorPanelChatBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly INotificationService _notificationService;
        private readonly IOrganizationService _organizationService;

        public DoctorPanelChatBarViewComponent(INotificationService notificationService, IOrganizationService organizationService)
        {
            _notificationService = notificationService;
            _organizationService = organizationService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region Get Organziation 

            var organization = await _organizationService.GetOrganizationByUserId(User.GetUserId());

            #endregion

            var model = await _notificationService.GetListOfSupporterNotificationByUserId(organization.OwnerId);
            return View("DoctorPanelChatBar", model);
        }
    }
}
