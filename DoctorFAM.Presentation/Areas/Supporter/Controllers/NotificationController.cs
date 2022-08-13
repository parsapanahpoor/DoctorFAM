using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Supporter.Controllers
{
    public class NotificationController : SupporterBaseController
    {
        #region Ctor

        private readonly INotificationService _notificationService;

        private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;

        public NotificationController(INotificationService notificationService, IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer)
        {
            _notificationService = notificationService;
            _sharedLocalizer = sharedLocalizer;
        }

        #endregion

        #region Seen All Of Un Seen Notifications For Current User 

        public async Task<IActionResult> SeenNotificationsByUserId()
        {
            //Update State 
            var res = await _notificationService.SeenAllOfUnSeenCurrentUserNotification(User.GetUserId());

            if (res)
            {
                TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                return RedirectToAction("Index", "Home", new { area = "Supporter" });
            }

            TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
            return RedirectToAction("Index", "Home", new { area = "Supporter" });
        }

        #endregion
    }
}
