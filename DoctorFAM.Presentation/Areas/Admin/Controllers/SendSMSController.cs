using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class SendSMSController : AdminBaseController
    {
        #region Ctor

        private readonly IDoctorsService _doctorService;

        public SendSMSController(IDoctorsService doctorService)
        {
            _doctorService = doctorService;
        }

        #endregion

        #region List Of Request For Send SMS From Doctor 

        [HttpGet]
        public async Task<IActionResult> ListOfRequestForSendSMSFromDoctor()
        {
            return View(await _doctorService.ListOfRequestForSendSMSFromDoctorsToDoctorsAdminSide());
        }

        #endregion
    }
}
