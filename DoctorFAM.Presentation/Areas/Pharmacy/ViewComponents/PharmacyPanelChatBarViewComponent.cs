using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Areas.Pharmacy.ViewComponents
{
    public class PharmacyChatBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly INotificationService _notificationService;

        public PharmacyChatBarViewComponent(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _notificationService.GetListOfSupporterNotificationByUserId(User.GetUserId());
            return View("PharmacyChatBar" , model);
        }
    }
}
