using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    public class DentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
