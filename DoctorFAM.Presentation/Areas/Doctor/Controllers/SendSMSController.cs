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

        private readonly IDoctorsService _doctorService;

        public SendSMSController(IFamilyDoctorService familyDoctorService, IDoctorsService doctorService)
        {
            _familyDoctorService = familyDoctorService;
            _doctorService = doctorService;
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
                return RedirectToAction(nameof(ChooseUsersForSendSMS));
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

        [HttpPost]
        public async Task<IActionResult> WriteSMSText(SendSMSToPatientViewModel model)
        {
            #region Model State

            model.DoctorUserId = User.GetUserId();

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد ";
                return View(model);
            }

            #endregion

            #region Send SMS

            var res = await _doctorService.SendRequestForSendSMSFromDoctorPanelToAdmin(model);

            switch (res)
            {
                case SendRequestOfSMSFromDoctorsToThePatientResult.RequestSentSuccesfully:
                    TempData[SuccessMessage] = "درخواست باموفقیت ثبت شده است.";
                    return RedirectToAction("Index", "Home", new { area = "Doctor" });

                case SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation:
                    TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                    break;

                case SendRequestOfSMSFromDoctorsToThePatientResult.HigherThanDoctorFreePercentage:
                    TempData[ErrorMessage] = "موجودی ارسال پیامک رایگان شما به پایان رسیده است.";
                    break;
            }

            #endregion

            return View(model);
        }

        #endregion
    }
}
