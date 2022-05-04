using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Controllers
{
    public class HomeNurseController : SiteBaseController
    {
        #region Ctor

        public IHomeNurseService _homeNurseService { get; set; }

        public HomeNurseController(IHomeNurseService homeNurseService)
        {
            _homeNurseService = homeNurseService;
        }

        #endregion

        #region Home Nurse

        public async Task<IActionResult> HomeNurse()
        {

            var userName = "";

            if (User.Identity.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }

            var requestId = await _homeNurseService.CreateHomeNurseRequest(userName);

            ViewBag.RequestId = requestId;
            return View();
        }

        #endregion

        #region Patient Detail

        [HttpGet]
        public async Task<IActionResult> PatientDetails(ulong id)
        {
            if (!await _homeNurseService.IsExistHomeNurseRequestById(id)) return NotFound();

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

            var result = await _homeNurseService.ValidateCreatePatient(patient);

            switch (result)
            {
                case CreatePatientResult.Faild:
                    return NotFound();
                case CreatePatientResult.RequestIdNotFound:
                    return NotFound();
                case CreatePatientResult.Success:
                    var patientId = await _homeNurseService.CreatePatientDetail(patient);
                    return RedirectToAction("PatientAddress", "HomeNurse", new { patientId = patientId });
            }

            #endregion

            return View(patient);
        }

        #endregion

        #region Patient Address

        [HttpGet]
        public IActionResult PatientAddress(ulong id)
        {
            //if (!await _homeVisitService.IsExistHomeVisitRequestById(id)) return NotFound();

            return View();
        }
        #endregion
    }
}
