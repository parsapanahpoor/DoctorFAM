using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Follow;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.ViewComponents
{
    public class ShowFollowButtonInDoctorsListViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IFollowService _followServicel;

        public ShowFollowButtonInDoctorsListViewComponent(IFollowService followService)
        {
            _followServicel = followService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync(ulong targetUserId , 
                                                            string actionName ,     
                                                            string controllerName , 
                                                            string? area)
        {
            #region Fill Model

            var model = new IsUserFollowedViewModel(); 

            if (User.Identity.IsAuthenticated)
            {
                model.IsUserFollowed = await _followServicel.CheckThatCurrentUserFollowedTargetUser(User.GetUserId() , targetUserId);
                model.TargetUserId = targetUserId;
                model.ActionName = actionName;
                model.ControllerName = controllerName;
                model.AreaName = area; 
            }

            #endregion

            return View("ShowFollowButtonInDoctorsList", model);
        }
    }
}
