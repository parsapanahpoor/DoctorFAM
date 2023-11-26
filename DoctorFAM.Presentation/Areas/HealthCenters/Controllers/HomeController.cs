using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.HealthCenters.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.HealthCenters.Controllers;

public class HomeController : HealthCentersBaseController
{
    #region Ctor 

    private readonly IHealthCentersService _healthCentersService;

    public HomeController(IHealthCentersService healthCentersService)
    {
         _healthCentersService = healthCentersService;
    }

    #endregion

    #region Index 

    public IActionResult Index()
    {
        return View();
    }

    #endregion
}
