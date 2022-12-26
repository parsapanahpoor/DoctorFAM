using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.ViewComponents
{
    public class FollowersOnNavbarLayoutViewComponent : ViewComponent
    {
        #region Ctor

        public IFollowService _followService { get; set; }

        public FollowersOnNavbarLayoutViewComponent(IFollowService followService)
        {
            _followService = followService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("FollowersOnNavbarLayout", await _followService.ListOfUserFollowersThatHasRole(User.GetUserId()));
        }
    }
}
