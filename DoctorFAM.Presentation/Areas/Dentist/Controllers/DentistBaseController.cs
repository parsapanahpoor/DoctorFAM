#region Usings

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DoctorFAM.Web.Areas.Dentist.ActionFilterAttributes;

#endregion

namespace DoctorFAM.Web.Areas.Dentist.Controllers;

[Area("Dentist")]
[Authorize]
[CheckUserHasPermission]

public class DentistBaseController : Controller
{
    public static string SuccessMessage = "SuccessMessage";
    public static string ErrorMessage = "ErrorMessage";
    public static string InfoMessage = "InfoMessage";
    public static string WarningMessage = "WarningMessage";
}
