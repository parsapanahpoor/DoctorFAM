﻿using DoctorFAM.Web.Areas.Admin.ActionFilterAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    [CheckUserHasPermission]

    public class AdminBaseController : Controller
    {
        public static string SuccessMessage = "SuccessMessage";
        public static string ErrorMessage = "ErrorMessage";
        public static string InfoMessage = "InfoMessage";
        public static string WarningMessage = "WarningMessage";
    }
}
