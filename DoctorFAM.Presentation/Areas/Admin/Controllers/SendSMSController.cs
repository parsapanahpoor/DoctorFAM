using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.SendSMS;
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

        #region Show Request Detail

        [HttpGet]
        public async Task<IActionResult> ShowRequestDetail(ulong id)
        {
            #region Get Request By Id 

            var request = await _doctorService.FillShowRequestForSendSMSDetailViewModel(id);
            if (request == null)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return RedirectToAction(nameof(ListOfRequestForSendSMSFromDoctor));
            }

            #endregion

            return View(request);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ShowRequestDetail(ShowRequestForSendSMSDetailAdminSideViewModel model)
        {
            #region Model State Validation

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return RedirectToAction(nameof(ListOfRequestForSendSMSFromDoctor));
            }

            #endregion

            #region Update Request And Send SMS

            var res = await _doctorService.ManageRequestForSendSMSFromDoctorToPatientAdminSide(model);
            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
                return RedirectToAction(nameof(ListOfRequestForSendSMSFromDoctor));
            }

            #endregion

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return RedirectToAction(nameof(ListOfRequestForSendSMSFromDoctor));
        }

        #endregion
    }
}
