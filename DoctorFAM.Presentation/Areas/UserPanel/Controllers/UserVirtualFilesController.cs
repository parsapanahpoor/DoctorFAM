using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class UserVirtualFilesController : UserBaseController
    {
        #region Ctor



        #endregion

        #region List Of User Virtual Files

        [HttpGet]
        public async Task<IActionResult> ListOfUserVirtualFiles()
        {
            return View();
        }

        #endregion
    }
}
