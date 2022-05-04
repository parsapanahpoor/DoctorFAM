using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using Microsoft.AspNetCore.Mvc;


namespace DoctorFAM.Web.Controllers
{
    public class DeathCertificatController : SiteBaseController
    {
        #region Ctor

        public IDeathCertificateService _deathCertificatService { get; set; }

        public DeathCertificatController(IDeathCertificateService deathCertificateService)
        {
            _deathCertificatService = deathCertificateService;
        }

        #endregion
        #region Death Certificate

        public async Task<IActionResult> DeathCertificate()
        {
            var userName = "";

            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }

            var requestId = await _deathCertificatService.CreateDeathCertificateRequest(userName);

            ViewBag.RequestId = requestId;
            return View();
        }
        #endregion

        #region Patient Detail

        [HttpGet]
        public async Task<IActionResult> PatientDetails(ulong id)
        {
            if (!await _deathCertificatService.IsExistDeathCertificateRequestById(id)) return NotFound();

            return View(new PatientViewModel()
            {
                RequestId = id
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PatientDetails(PatientViewModel patient)
        {
            #region Model State

            if (!ModelState.IsValid) return View(patient);

            #endregion

            #region Validate model 

            var result = await _deathCertificatService.ValidateCreatePatient(patient);

            switch (result)
            {
                case CreatePatientResult.Faild:
                    return NotFound();
                case CreatePatientResult.RequestIdNotFound:
                    return NotFound();
                case CreatePatientResult.Success:
                    var patientId = await _deathCertificatService.CreatePatientDetail(patient);
                    return RedirectToAction("PatientAddress", "DeathCertificat", new { patientId = patientId });
            }

            #endregion

            return View(patient);
        }

        #endregion

        #region Patient Address

        [HttpGet]
        public IActionResult PatientAddress(ulong id)
        {
            //if (!await _deathCertificatService.IsExistDeathCertificatRequestById(id)) return NotFound();

            return View();
        }
        #endregion
    }


}
