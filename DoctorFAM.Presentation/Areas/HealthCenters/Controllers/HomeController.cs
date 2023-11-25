using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.HealthCenters.Controllers;

public class HomeController : Controller
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
