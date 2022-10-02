using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.ViewComponents
{
    public class SiteSideBarViewComponent : ViewComponent
    {
        #region Ctor

        public IPermissionService _permissionService;

        public SiteSideBarViewComponent(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region Get User Role

            if (User.Identity.IsAuthenticated)
            {
                var userRole = await _permissionService.GetUserRole(User.GetUserId());

                if (userRole == GetUserRoles.Admin) ViewBag.Admin = true;

                if (userRole == GetUserRoles.Doctor) ViewBag.Doctor = true;

                if (userRole == GetUserRoles.Supporter) ViewBag.Supporter = true;

                if (userRole == GetUserRoles.Seller) ViewBag.Seller = true;

                if (userRole == GetUserRoles.User) ViewBag.User = true;

                if (userRole == GetUserRoles.Pharmacy) ViewBag.Pharmacy = true;

                if (userRole == GetUserRoles.Nurse) ViewBag.Nurse = true;

                if (userRole == GetUserRoles.Consultant) ViewBag.Consultant = true;

                if (userRole == GetUserRoles.DoctorOfficeEmployee) ViewBag.DoctorOfficeEmployee = true;

                if (userRole == GetUserRoles.Laboratory) ViewBag.Labratory = true;
            }
          
            #endregion

            return View("SiteSideBar");
        }
    }
}
