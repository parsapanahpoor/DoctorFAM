using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    public class BloodPressureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
