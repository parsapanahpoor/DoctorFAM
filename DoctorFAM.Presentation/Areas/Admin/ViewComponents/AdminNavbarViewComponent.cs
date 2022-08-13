using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.ViewComponents
{
    public class AdminNavbarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IUserService _userService;

        private readonly INotificationService _notificationService;

        public AdminNavbarViewComponent(IUserService userService , INotificationService notificationService)
        {
            _userService = userService;
            _notificationService = notificationService;
        }

        #endregion
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserById(User.GetUserId());

            return View("AdminNavbar" , user);
        }
    }
}
