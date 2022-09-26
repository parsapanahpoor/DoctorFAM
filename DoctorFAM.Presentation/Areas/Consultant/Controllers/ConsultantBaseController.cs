using DoctorFAM.Web.Areas.Consultant.ActionFilterAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Consultant.Controllers
{
    [Area("Consultant")]
    [Authorize]
    [CheckUserHasPermission]

    public class ConsultantBaseController : Controller
    {
        public static string SuccessMessage = "SuccessMessage";
        public static string ErrorMessage = "ErrorMessage";
        public static string InfoMessage = "InfoMessage";
        public static string WarningMessage = "WarningMessage";
    }
}
