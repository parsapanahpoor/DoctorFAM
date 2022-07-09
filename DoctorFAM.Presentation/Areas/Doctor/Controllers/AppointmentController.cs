using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    public class AppointmentController : DoctorBaseController
    {
        #region ctor

        #endregion

        #region Appointment Setting 

        public async Task<IActionResult> AppointmentSetting()
        {
            return View();
        }

        #endregion
    }
}
