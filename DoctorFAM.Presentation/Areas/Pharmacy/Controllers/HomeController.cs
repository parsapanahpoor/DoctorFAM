using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Pharmacy.Controllers
{
    public class HomeController : PharmacyBaseController
    {
        #region Ctor



        #endregion

        #region Index

        public IActionResult Index()
        {
            return View();
        }

        #endregion
    }
}
