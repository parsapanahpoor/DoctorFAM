using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.DoctorPanel.ViewComponents
{
    public class PharmacyNavbarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;
        public PharmacyNavbarViewComponent(IUserService userService, IPermissionService permissionService)
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
                var userRole = await _permissionService.GetUserRolesesWithAsNoTracking(User.GetUserId());

                if (userRole == null) ViewBag.User = true;

                else
                {
                    if (userRole.Contains("Admin")) ViewBag.Admin = true;

                    if (userRole.Contains("Doctor")) ViewBag.Doctor = true;

                    if (userRole.Contains("Support")) ViewBag.Supporter = true;

                    if (userRole.Contains("Seller")) ViewBag.Seller = true;

                    if (userRole.Contains("Pharmacy")) ViewBag.Pharmacy = true;

                    if (userRole.Contains("Nurse")) ViewBag.Nurse = true;

                    if (userRole.Contains("Consultant")) ViewBag.Consultant = true;

                    if (userRole.Contains("DoctorOfficeEmployee")) ViewBag.DoctorOfficeEmployee = true;

                    if (userRole.Contains("LaboratoryOfficeEmployee")) ViewBag.LaboratoryOfficeEmployee = true;

                    if (userRole.Contains("Labratory")) ViewBag.Labratory = true;

                    if (userRole.Contains("Dentist")) ViewBag.Dentist = true;

                    if (userRole.Contains("DentistOfficeEmployee")) ViewBag.Dentist = true;

                    if (userRole.Contains("Tourism")) ViewBag.Tourist = true;

                    if (userRole.Contains("HealthCenter")) ViewBag.HealthCenter = true;
                }

            }

            #endregion

            var user = await _userService.GetUserById(User.GetUserId());

            return View("PharmacyNavbar", user);
        }
    }
}
