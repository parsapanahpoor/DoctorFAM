using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoctorFAM.Web.ActionFilterAttributes
{
    public class CheckUserFillPersonalInformation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var service = (IUserService)context.HttpContext.RequestServices.GetService(typeof(IUserService))!;

            base.OnActionExecuting(context);

            var hasUserPersonalInfo = service.CheckThatHasUserFillPersonalInformation(context.HttpContext.User.GetUserId()).Result;

            if (!hasUserPersonalInfo)
            {
                context.HttpContext.Response.Redirect("/UserPanel/Account/EditProfile?FillInfo=true");
            }
        }
    }
}
