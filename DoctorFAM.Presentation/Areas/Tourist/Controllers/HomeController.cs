#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.Tourism.Controllers;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Tourist.Controllers;

public class HomeController : TouristBaseController
{
    #region Ctor

    private readonly IDashboardsService _dashboardService;
    private readonly IOrganizationService _organizationService;
    private readonly ILaboratoryService _laboratoryService;
    private readonly ITourismService _tourismService;

    public HomeController(IOrganizationService organizationService , IDashboardsService dashboardService
                            , ILaboratoryService laboratoryService, ITourismService tourismService)
    {
        _organizationService = organizationService;
        _dashboardService = dashboardService;
        _laboratoryService = laboratoryService;
        _tourismService = tourismService;
    }

    #endregion

    #region Index Page 

    public  async Task<IActionResult> Index(bool employeeHasNotPermission = false)
    {
        #region Check Tourism Login

        if (!await _organizationService.IsExistAnyTourismByUserId(User.GetUserId()))
        {
            #region If Tourism Is Not Found In Tourism Table 

            if (!await _tourismService.IsExistAnyTourismByUserId(User.GetUserId()))
            {
                await _tourismService.AddTourismForFirstTime(User.GetUserId());
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
