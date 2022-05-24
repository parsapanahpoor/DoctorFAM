using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoctorFAM.Web.Areas.Doctor.ActionFilterAttributes
{
    public class CheckDoctorsInfo : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var service = (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService))!;

            base.OnActionExecuting(context);

            var doctorsState = service.GetDoctorsInfosState(context.HttpContext.User.GetUserId()).Result;

            if (doctorsState != "Accepted")
            {
                context.HttpContext.Response.Redirect("/Doctor");
            }
        }
    }
}
