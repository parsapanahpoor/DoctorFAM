﻿using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    public class MedicalRecordsController : DoctorBaseController
    {
        #region Ctor



        #endregion

        #region List Of Medical Records

        public async Task<IActionResult> FilterMedicalRecord()
        {
            return View();
        }

        #endregion
    }
}
