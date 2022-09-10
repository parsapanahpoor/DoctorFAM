using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    public class SkinController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
