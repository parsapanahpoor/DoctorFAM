using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    public class HomeController : DoctorBaseController
    {
        #region Ctor

        public IDoctorsService _doctorService { get; set; }

        public HomeController(IDoctorsService doctorService)
        {
            _doctorService = doctorService;
        }

        #endregion

        #region Index Page 

        public  async Task<IActionResult> Index()
        {
            return View();
        }

        #endregion
    }
}
