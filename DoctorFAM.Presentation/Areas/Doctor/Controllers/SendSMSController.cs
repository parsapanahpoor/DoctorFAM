using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.ParsaSystem;
using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    public class SendSMSController : DoctorBaseController
    {
        #region Ctor

        private readonly IFamilyDoctorService _familyDoctorService;

        public SendSMSController(IFamilyDoctorService familyDoctorService)
        {
            _familyDoctorService= familyDoctorService;
        }

        #endregion

        #region Manage Links

        public async Task<IActionResult> ManageLinks()
        {
            return View();
        }

        #endregion

        #region Choose Users For Send SMS

        [HttpGet]
        public async Task<IActionResult> ChooseUsersForSendSMS()
        {
            return View(await _familyDoctorService.ListOfCurrentDoctorPopulationCoveredUsersWithoutBasePaging(User.GetUserId()));
        }

        #endregion

        #region Write SMS Text

        [HttpGet]
        public async Task<IActionResult> WriteSMSText(List<ulong> usersId)
        {
            #region Validation 

            if (usersId.Count() == 0)
            {
                TempData[ErrorMessage] = "لطفا بیماران خود را انتخاب کنید.";
                return RedirectToAction(nameof(usersId));
            }

            #endregion

            #region Create Model 

            SendSMSToPatientViewModel model = new SendSMSToPatientViewModel()
            {
                PatientId = usersId
            };

            #endregion

            return View(model);
        }

        #endregion
    }
}
