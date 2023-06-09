#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoctorFAM.Web.Areas.Dentist.ActionFilterAttributes;

#endregion

public class CheckDentistsInfo : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var service = (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService))!;

        base.OnActionExecuting(context);

        var doctorsState = service.GetDentistSideBarInfo(context.HttpContext.User.GetUserId()).Result;

        if (doctorsState.DentistInfoState != "Accepted")
        {
            context.HttpContext.Response.Redirect("/Dentist");
        }
    }
}
