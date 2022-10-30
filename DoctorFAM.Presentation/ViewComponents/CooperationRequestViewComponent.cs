using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.CooperationRequest;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.ViewComponents
{
    public class CooperationRequestViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IUserService _userService;

        public CooperationRequestViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //If User Is Authenticated
            #region Render Model 

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userService.GetUserById(User.GetUserId());
                if (user != null)
                {
                    SendCooperationRequestViewModel model = new SendCooperationRequestViewModel()
                    {
                        Mobile = user.Mobile,
                        Username = user.Username
                    };

                    return View("CooperationRequest" , model);
                }
            }
          
            #endregion

            return View("CooperationRequest");
        }
    }
}
