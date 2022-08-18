using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    public class FocalPointController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DocPage()
        {
            return View();
        }

        public IActionResult DocBooking()
        {
            return View();
        }
    }
}
