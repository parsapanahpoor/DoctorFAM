using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        #region Admin Dashboard

        public async Task<IActionResult> Index()
        {
            return View();
        }

        #endregion
    }
}
