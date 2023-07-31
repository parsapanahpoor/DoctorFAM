using DoctorFAM.Web.Areas.Laboratory.ActionFilterAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Tourism.Controllers
{
    [Area("Tourism")]
    [Authorize]
    [CheckUserHasPermission]

    public class TourismBaseController : Controller
    {
        public static string SuccessMessage = "SuccessMessage";
        public static string ErrorMessage = "ErrorMessage";
        public static string InfoMessage = "InfoMessage";
        public static string WarningMessage = "WarningMessage";
    }
}
