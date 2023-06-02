#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Dentist.Controllers;

public class HomeController : DentistBaseController
{
    #region Ctor

    private readonly IDoctorsService _doctorService;
    private readonly IDashboardsService _dashboardService;
    private readonly IOrganizationService _organizationService;

    public HomeController(IDoctorsService doctorService, IOrganizationService organizationService, IDashboardsService dashboardService)
    {
        _doctorService = doctorService;
        _organizationService = organizationService;
        _dashboardService = dashboardService;
    }

    #endregion

    #region Index

    public async Task<IActionResult> Index()
    {
        #region Check Dentist Login or Employee

        //Is Exist Any Dentist Office Member By This Current UserId 
        if (!await _organizationService.IsExistAnyDentistOfficeEmployeeByUserId(User.GetUserId()))
        {
            #region If Dentist Is Not Found In Dentitst Table 

            if (!await _doctorService.IsExistAnyDoctorByUserId(User.GetUserId()))
            {
                await _doctorService.AddDoctorForFirstTime(User.GetUserId());
            }

            #endregion
        }      

        #endregion

        return View();
    }

    #endregion
}
