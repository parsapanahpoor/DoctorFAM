using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.ChatRoom.Controllers
{
    [Area("ChatRoom")]
    [Authorize]
    public class ChatRoomBaseController : Controller
    {
        public static string SuccessMessage = "SuccessMessage";
        public static string ErrorMessage = "ErrorMessage";
        public static string InfoMessage = "InfoMessage";
        public static string WarningMessage = "WarningMessage";
    }
}
