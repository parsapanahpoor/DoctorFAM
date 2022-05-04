using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Marketing.Controllers
{
    public class HomeController : MarketingBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
    }
}
