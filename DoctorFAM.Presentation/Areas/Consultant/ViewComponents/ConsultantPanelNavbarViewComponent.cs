using BusinessPortal.Application.Services.Implementation;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Consultant.ViewComponents
{
    public class ConsultantPanelNavbarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;
        public ConsultantPanelNavbarViewComponent(IUserService userService, IPermissionService permissionService)
        {
            _userService = userService;
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

                if (userRole == GetUserRoles.LaboratoryOfficeEmployee) ViewBag.LaboratoryOfficeEmployee = true;

                if (userRole == GetUserRoles.Laboratory) ViewBag.Labratory = true;
            }

            #endregion

            var user = await _userService.GetUserById(User.GetUserId());

            return View("ConsultantPanelNavbar", user);
        }
    }
}
