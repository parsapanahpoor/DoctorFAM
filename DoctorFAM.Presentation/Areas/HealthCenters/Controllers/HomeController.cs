using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.HealthCenters.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.HealthCenters.Controllers;

public class HomeController : HealthCentersBaseController
{
    #region Ctor 

    private readonly IHealthCentersService _healthCentersService;
    private readonly IOrganizationService _organizationService;

    public HomeController(IHealthCentersService healthCentersService, IOrganizationService organizationService )
    {
        _healthCentersService = healthCentersService;
        _organizationService = organizationService;
    }

    #endregion

    #region Index 

    public async Task<IActionResult> Index(bool employeeHasNotPermission = false)
    {
        ulong userId = User.GetUserId();

        #region Check Health Centers

        //Is Exist Any Health Center Office Member By This Current UserId 
        if (!await _organizationService.IsExistAnyHealthCenterOfficeEmployeeByUserId(userId))
        {
            #region If Health Center Is Not Found In Dentitst Table 

            if (!await _healthCentersService.IsExistAnyHealthCenterByUserId(userId))
            {
                await _healthCentersService.AddHealthCenterForFirstTime(userId);
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

        return View();
    }

    #endregion
}
