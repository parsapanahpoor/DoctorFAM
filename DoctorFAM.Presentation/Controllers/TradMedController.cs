using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    public class TradMedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
