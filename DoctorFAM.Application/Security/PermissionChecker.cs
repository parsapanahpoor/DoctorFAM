using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoctorFAM.Application.Security
{
    public class PermissionChecker : AuthorizeAttribute, IAuthorizationFilter
    {
        #region Ctor

        private readonly string _permission;

        public PermissionChecker(string permission)
        {
            _permission = permission;
        }

        #endregion

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var _permissionService = (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService));

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = context.HttpContext.User.GetUserId();

                if (!_permissionService.HasUserPermission(userId, _permission).Result)
                {
                    context.Result = new RedirectResult("/");
                }
            }
            else
            {
                context.Result = new RedirectResult("/");
            }
        }
    }
}
