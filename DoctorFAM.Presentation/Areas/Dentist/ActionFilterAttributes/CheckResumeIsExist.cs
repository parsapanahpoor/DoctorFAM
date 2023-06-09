#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoctorFAM.Web.Areas.Dentist.ActionFilterAttributes;

#endregion

public class CheckResumeIsExist : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var service = (IResumeService)context.HttpContext.RequestServices.GetService(typeof(IResumeService))!;

        base.OnActionExecuting(context);

        var res = service.CheckTahtIsExistResumeForThisUser(context.HttpContext.User.GetUserId()).Result;

        if (!res)
        {
            context.HttpContext.Response.Redirect("/");
        }
    }
}
