﻿using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    public class LabController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
