using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class ConsultantController : Controller
    {
        #region Ctor



        #endregion

        #region Check User Has Consultant Or Not

        public async Task<IActionResult> ProccessConsultant()
        {
            return View();
        }

        #endregion
    }
}
