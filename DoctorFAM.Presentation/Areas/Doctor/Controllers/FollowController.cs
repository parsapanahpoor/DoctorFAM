using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    public class FollowController : DoctorBaseController
    {
        #region Ctor

        private readonly IFollowService _followService;

        public FollowController(IFollowService followService)
        {
            _followService = followService;
        }

        #endregion

        #region List Of Followrs 

        public async Task<IActionResult> ListOfFollowers()
        {
            return View(await _followService.ListOfUserFollowersThatHasRole(User.GetUserId()));
        }

        #endregion
    }
}
