#region Using

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoctorFAM.Web.Areas.Tourist.ActionFilterAttributes;

#endregion

public class CheckThatIsExistAnyWaitingForPaymentTokenRequest : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var service = (ITouristTokenService)context.HttpContext.RequestServices.GetService(typeof(ITouristTokenService))!;

        base.OnActionExecuting(context);

        var isExistWaitingToken = service.IsExistAnyWaitingForPaymentTokenRequestForCurrentTourist(context.HttpContext.User.GetUserId()).Result;

        if (isExistWaitingToken)
        {
            context.HttpContext.Response.Redirect("/Tourist/Token/ShowInvoiceForTokenRequet");
        }
    }
}
