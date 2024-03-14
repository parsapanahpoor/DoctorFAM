using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    public class CentersIntrud : Controller
    {
       
        
        public async Task<IActionResult> CentersIntruds()
        {
            return View();
        }
    }
}
