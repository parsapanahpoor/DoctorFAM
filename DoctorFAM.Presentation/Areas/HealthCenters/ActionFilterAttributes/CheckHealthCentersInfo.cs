#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoctorFAM.Web.Areas.HealthCenters.ActionFilterAttributes;

#endregion

public class CheckHealthCentersInfo : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var service = (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService))!;

        base.OnActionExecuting(context);

        var healthCentersState = service.GetHealthCenterSideBarInfo(context.HttpContext.User.GetUserId()).Result;

        if (healthCentersState.HealthCenterInfoState != "Accepted")
        {
            context.HttpContext.Response.Redirect("/HealthCenters");
        }
    }
}
