using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class HomeController : UserBaseController
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
