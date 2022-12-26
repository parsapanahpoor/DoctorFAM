using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Follow;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.ViewComponents
{
    public class DoctorsFollowDetailOnListOfFamilyDoctorsViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IFollowService _followServicel;

        public DoctorsFollowDetailOnListOfFamilyDoctorsViewComponent(IFollowService followService)
        {
            _followServicel = followService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync(ulong targetUserId)
        {
            return View("DoctorsFollowDetailOnListOfFamilyDoctors" , await _followServicel.ModelOfViewComponentThatShowDoctorBadgeDetailForFollowersDetail(targetUserId));
        }
    }
}
