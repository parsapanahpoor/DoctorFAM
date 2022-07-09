using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    public class ScienceMagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
