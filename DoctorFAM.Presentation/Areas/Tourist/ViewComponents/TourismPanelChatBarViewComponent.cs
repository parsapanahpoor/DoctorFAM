#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Tourism.ViewComponents
{
    public class TourismChatBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly INotificationService _notificationService;
        private readonly IOrganizationService _organizationService;

        public TourismChatBarViewComponent(INotificationService notificationService, IOrganizationService organizationService)
        {
            _notificationService = notificationService;
            _organizationService = organizationService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _notificationService.GetListOfSupporterNotificationByUserId(User.GetUserId());
            return View("TourismChatBar", model);
        }
    }
}
