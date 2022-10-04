using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoctorFAM.Web.Areas.Laboratory.ActionFilterAttributes
{
    public class IsUserLaboratory : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var service = (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService))!;

            base.OnActionExecuting(context);

            var hasUserAnyRole = service.CheckIsUserMasterOfLaboratory(context.HttpContext.User.GetUserId()).Result;

            if (!hasUserAnyRole)
            {
                context.HttpContext.Response.Redirect("/Laboratory/Home/Index?employeeHasNotPermission=true");
            }
        }
    }
}
