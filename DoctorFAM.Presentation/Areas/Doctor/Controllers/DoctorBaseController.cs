using DoctorFAM.Web.Areas.Doctor.ActionFilterAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize]
    [CheckUserHasPermission]

    public class DoctorBaseController : Controller
    {
        public static string SuccessMessage = "SuccessMessage";
        public static string ErrorMessage = "ErrorMessage";
        public static string InfoMessage = "InfoMessage";
        public static string WarningMessage = "WarningMessage";
    }
}
