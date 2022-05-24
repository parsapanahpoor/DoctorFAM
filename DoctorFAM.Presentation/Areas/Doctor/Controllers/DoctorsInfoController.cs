using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;
using DoctorFAM.Web.Doctor.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    public class DoctorsInfoController : DoctorBaseController
    {
        #region Ctor

        public IDoctorsService _doctorService;

        public DoctorsInfoController(IDoctorsService doctorService)
        {
            _doctorService = doctorService;
        }

        #endregion

        #region Manage Doctors Info

        [HttpGet]
        public async Task<IActionResult> ManageDoctorsInfo()
        {
            #region Fill Model 

            var model = await _doctorService.FillManageDoctorsInfoViewModel(User.GetUserId());

            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageDoctorsInfo(ManageDoctorsInfoViewModel model, IFormFile? MediacalFile)
        {
            #region Fill Model 

            var returnModel = await _doctorService.FillManageDoctorsInfoViewModel(User.GetUserId());

            if (returnModel == null) return NotFound();

            #endregion

            #region Erorr

            //If Users Id Are Confilited with each other 
            if (model.UserId != returnModel.UserId)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده با یکدیگر مغایرت دارند ";
                return View(returnModel);
            }

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "مقادیر ورودی معتبر نمی باشد .";
                return View(returnModel);
            }

            #endregion

            #region Add Or Edit Doctors Information

            var result = await _doctorService.AddOrEditDoctorInfoDoctorsPanel(model, MediacalFile);

            switch (result)
            {
                case AddOrEditDoctorInfoResult.FileNotUploaded:
                    TempData[ErrorMessage] = "لطفا پرونده ی پزشکی یا پرونده ی مطب را وارد کنید ";
                    break;

                case AddOrEditDoctorInfoResult.Faild:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شده است ";
                    return RedirectToAction("ManageDoctorsInfo", "DoctorsInfo", new { area = "Doctor" });

                case AddOrEditDoctorInfoResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                    return RedirectToAction("Index", "Home", new { area = "Doctor" });
            }

            #endregion

            return View(returnModel);
        }

        #endregion
    }
}
