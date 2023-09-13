#region Usings

using BusinessPortal.Application.Services.Implementation;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Dentist.ViewComponents;

public class DentistPanelNavbarViewComponent : ViewComponent
{
    #region Ctor

    private readonly IUserService _userService;
    private readonly IPermissionService _permissionService;
    private readonly IDentistService _dentistService;

    public DentistPanelNavbarViewComponent(IUserService userService, IPermissionService permissionService , IDentistService dentistService)
    {
        _userService = userService;
        _permissionService = permissionService;
        _dentistService = dentistService;
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

                if (userRole.Contains("DentistOfficeEmployee")) ViewBag.DentistOfficeEmployee = true;

                if (userRole.Contains("Tourism")) ViewBag.Tourist = true;
            }

        }

        #endregion

        var user = await _dentistService.FillDentistPanelNavNarViewModel(User.GetUserId());

        return View("DentistPanelNavbar", user);
    }
}
