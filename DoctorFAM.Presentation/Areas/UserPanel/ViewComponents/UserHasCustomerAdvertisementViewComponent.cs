using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.ViewComponents
{
    public class UserHasCustomerAdvertisementViewComponent : ViewComponent
    {
        #region Ctor

        private readonly ICustomerAdvertisementService _advertisement;

        public UserHasCustomerAdvertisementViewComponent(ICustomerAdvertisementService advertisement)
        {
            _advertisement = advertisement;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("UserHasCustomerAdvertisement", await _advertisement.HasUserAnyAdvertisement(User.GetUserId()));
        }
    }
}
