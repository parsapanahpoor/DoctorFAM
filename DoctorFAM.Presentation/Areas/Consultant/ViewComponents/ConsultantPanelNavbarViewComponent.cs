using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Consultant.ViewComponents
{
    public class ConsultantPanelNavbarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IUserService _userService;

        public ConsultantPanelNavbarViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserById(User.GetUserId());

            return View("ConsultantPanelNavbar", user);
        }
    }
}
