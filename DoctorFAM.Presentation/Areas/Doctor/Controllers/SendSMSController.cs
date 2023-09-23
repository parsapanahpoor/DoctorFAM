using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.ParsaSystem;
using DoctorFAM.Domain.ViewModels.DoctorPanel.SendSMS;
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
        public async Task<IActionResult> WriteSMSText(bool selectedAll,List<ulong>? usersId)
        {
            #region Selected All Users

            if (selectedAll)
            {
                usersId = await _familyDoctorService.SelectAllPopulationCoveredUserIdsForSendSMSToThem(User.GetUserId());
            }

            #endregion

            #region Validation 

            if (usersId == null || !usersId.Any() || usersId.Count() == 0)
            {
                TempData[ErrorMessage] = "لطفا بیماران خود را انتخاب کنید.";
                return RedirectToAction(nameof(ChooseUsersForSendSMS));
            }

            #endregion

            #region Fill View Model 

            var model = await _doctorService.FillSendSMSToPatientViewModel(User.GetUserId() , usersId);
            if (model == null)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return RedirectToAction(nameof(ChooseUsersForSendSMS));
            }

            #endregion

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriteSMSText(SendSMSToPatientViewModel model)
        {
            #region Model State

            if (!ModelState.IsValid)
            {
                var returnModel1 = await _doctorService.FillSendSMSToPatientViewModel(User.GetUserId(), model.PatientId);
                if (returnModel1 == null)
                {
                    TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                    return RedirectToAction(nameof(ChooseUsersForSendSMS));
                }

                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد ";
                return View(returnModel1);
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

            var returnModel = await _doctorService.FillSendSMSToPatientViewModel(User.GetUserId(), model.PatientId);
            if (returnModel == null)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return RedirectToAction(nameof(ChooseUsersForSendSMS));
            }

            return View(returnModel);
        }

        #endregion

        #region List OF Current Doctor SMS Requests

        public async Task<IActionResult> ListOFCurrentDoctorSMSRequests()
        {
            return View(await _doctorService.ListOfDoctorSendSMSRequestDoctorSideViewModel(User.GetUserId()));
        }

        #endregion

        #region Show Request Detail

        [HttpGet]
        public async Task<IActionResult> ShowRequestDetail(ulong id)
        {
            #region Fill View Model 

            var model = await _doctorService.SendSMSToPatientDetailDoctorPanelViewModel(id , User.GetUserId());
            if (model == null)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return RedirectToAction(nameof(ListOFCurrentDoctorSMSRequests));
            }

            #endregion

            return View(model);
        }

        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> ShowRequestDetail(SendSMSToPatientDetailDoctorPanelViewModel model)
        {
            #region Model State

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد ";
                return View(model);
            }

            #endregion

            #region Send Request To The Admin 

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
                    TempData[ErrorMessage] = "موجودی ارسال پیامک شما به پایان رسیده است.";
                    break;
            }

            #endregion

            return View(model);
        }

        #endregion
    }
}
