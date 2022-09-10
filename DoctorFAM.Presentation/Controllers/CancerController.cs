using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    public class CancerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
