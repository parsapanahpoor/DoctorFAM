using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.ChatRoom.Controllers
{
    public class HomeController : ChatRoomBaseController
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
