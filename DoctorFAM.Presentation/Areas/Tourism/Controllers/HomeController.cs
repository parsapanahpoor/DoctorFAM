﻿#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.Tourism.Controllers;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Tourism.Controllers;

public class HomeController : TourismBaseController
{
    #region Ctor

    private readonly IDashboardsService _dashboardService;
    private readonly IOrganizationService _organizationService;
    private readonly ILaboratoryService _laboratoryService;

    public HomeController(IOrganizationService organizationService , IDashboardsService dashboardService
                            , ILaboratoryService laboratoryService)
    {
        _organizationService = organizationService;
        _dashboardService = dashboardService;
        _laboratoryService = laboratoryService;
    }

    #endregion

    #region Index Page 

    public  async Task<IActionResult> Index(bool employeeHasNotPermission = false)
    {
        #region Check Tourism Login

        if (!await _organizationService.IsExistAnyTourismByUserId(User.GetUserId()))
        {
            #region If Tourism Is Not Found In Tourism Table 

            if (!await _laboratoryService.IsExistAnyLaboratoryByUserId(User.GetUserId()))
            {
                await _laboratoryService.AddLaboratoryForFirstTime(User.GetUserId());
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
