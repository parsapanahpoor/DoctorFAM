using DoctorFAM.Web.Areas.Pharmacy.ActionFilterAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Pharmacy.Controllers
{
    [Area("Pharmacy")]
    [Authorize]
    [CheckUserHasPermission]

    public class PharmacyBaseController : Controller
    {
        public static string SuccessMessage = "SuccessMessage";
        public static string ErrorMessage = "ErrorMessage";
        public static string InfoMessage = "InfoMessage";
        public static string WarningMessage = "WarningMessage";
    }
}
