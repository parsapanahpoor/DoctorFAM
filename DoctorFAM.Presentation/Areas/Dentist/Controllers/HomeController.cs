#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Interfaces.EFCore;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Dentist.Controllers;

public class HomeController : DentistBaseController
{
    #region Ctor

    private readonly IDoctorsService _doctorService;
    private readonly IDashboardsService _dashboardService;
    private readonly IOrganizationService _organizationService;
    private readonly IDentistService _dentistService;

    public HomeController(IDoctorsService doctorService, IOrganizationService organizationService, IDashboardsService dashboardService
                            , IDentistService dentistService)
    {
        _doctorService = doctorService;
        _organizationService = organizationService;
        _dashboardService = dashboardService;
        _dentistService = dentistService;
    }

    #endregion

    #region Index

    public async Task<IActionResult> Index(bool employeeHasNotPermission = false)
    {
        ulong userId = User.GetUserId();

        #region Check Dentist Login or Employee

        //Is Exist Any Dentist Office Member By This Current UserId 
        if (!await _organizationService.IsExistAnyDentistOfficeEmployeeByUserId(userId))
        {
            #region If Dentist Is Not Found In Dentitst Table 

            if (!await _dentistService.IsExistAnyDentistByUserId(userId))
            {
                await _dentistService.AddDentistForFirstTime(userId);
            }

            #endregion
        }

        #endregion

        #region Employee Permission

        if (employeeHasNotPermission == true)
        {
            TempData[WarningMessage] = "شما دسترسی ورود به این بخش را ندارید .";
        }

        #endregion

        return View(await _dashboardService.FillDentistPanelDashboardViewModel(userId));
    }

    #endregion
}
