using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DeathCertificate;
using DoctorFAM.Web.Areas.Doctor.ActionFilterAttributes;
using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    [IsUserDoctor]
    public class DeathCertificateController : DoctorBaseController
    {
        #region Ctor

        private readonly IHomeVisitService _homeVisitService;

        private readonly IDoctorsService _doctorsService;

        public DeathCertificateController(IHomeVisitService homeVisitService , IDoctorsService dctorsService)
        {
            _homeVisitService = homeVisitService;
            _doctorsService = dctorsService;
        }

        #endregion

        #region List Of Death Certificate 

        public async Task<IActionResult> ListOfDeathCertificateRequests(ListOfPayedDeathCertificateRequestDoctorSideViewModel filter)
        {
            #region Validate Doctor Interest

            var doctorInterest = await _doctorsService.GetDoctorsSideBarInfo(User.GetUserId());
            if (doctorInterest.DeathCertificate != true) return NotFound();

            #endregion

            return View(await _homeVisitService.ListOfPayedDeathCertificateRequestsDoctorPanelSide(filter));
        }

        #endregion
    }
}
