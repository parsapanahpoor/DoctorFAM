using DoctorFAM.Web.ActionFilterAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class UserBaseController : Controller
    {
        public static string SuccessMessage = "SuccessMessage";
        public static string ErrorMessage = "ErrorMessage";
        public static string InfoMessage = "InfoMessage";
        public static string WarningMessage = "WarningMessage";
    }

}
