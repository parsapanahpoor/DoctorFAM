﻿using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoctorFAM.Web.Areas.Admin.ActionFilterAttributes
{
    public class CheckUserHasPermission : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var service = (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService))!;

            base.OnActionExecuting(context);

            var hasUserAnyRole = service.IsUserAdmin(context.HttpContext.User.GetUserId()).Result;

            if (!hasUserAnyRole)
            {
                context.HttpContext.Response.Redirect("/");
            }
        }
    }
}
