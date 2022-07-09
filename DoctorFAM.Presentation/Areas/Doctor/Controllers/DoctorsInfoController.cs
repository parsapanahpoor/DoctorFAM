using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;
using DoctorFAM.Web.Doctor.Controllers;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    public class DoctorsInfoController : DoctorBaseController
    {
        #region Ctor

        public IDoctorsService _doctorService;

        public IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;

        public DoctorsInfoController(IDoctorsService doctorService , IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer)
        {
            _doctorService = doctorService;
            _sharedLocalizer = sharedLocalizer;
        }

        #endregion

        #region Page of Manage Doctor Infos

        public async Task<IActionResult> PageOfManageDoctorInfo()
        {
            return View(await _doctorService.GetDoctorByUserId(User.GetUserId()));
        }

        #endregion

        #region Manage Doctors Personal Info

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
                TempData[ErrorMessage] = _sharedLocalizer["The input values ​​are not valid"].Value;
                return View(returnModel);
            }

            #endregion

            #region Add Or Edit Doctors Information

            var result = await _doctorService.AddOrEditDoctorInfoDoctorsPanel(model, MediacalFile);

            switch (result)
            {
                case AddOrEditDoctorInfoResult.FileNotUploaded:
                    TempData[ErrorMessage] = _sharedLocalizer["Please upload your educational certificate or license"].Value;
                    break;

                case AddOrEditDoctorInfoResult.Faild:
                    TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
                    return RedirectToAction("ManageDoctorsInfo", "DoctorsInfo", new { area = "Doctor" });

                case AddOrEditDoctorInfoResult.Success:
                    TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                    return RedirectToAction("Index", "Home", new { area = "Doctor" });
            }

            #endregion

            return View(returnModel);
        }

        #endregion

        #region Doctor Interests 

        public async Task<IActionResult> DoctorInterests()
        {
            #region Fill Page Model 

            var model = await _doctorService.FillDoctorInterestViewModelFromDoctorPanel(User.GetUserId());

            #endregion

            return View(model);
        }

        #endregion

        #region Add Interest To Doctor

        public async Task<IActionResult> AddInterestToDoctor(ulong interestId)
        {
            var result = await _doctorService.AddDoctorSelectedInterest(interestId , User.GetUserId());

            switch (result)
            {
                case Domain.Entities.Doctors.DoctorSelectedInterestResult.Success:
                    TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                    return RedirectToAction(nameof(DoctorInterests));

                case Domain.Entities.Doctors.DoctorSelectedInterestResult.Faild:
                    TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
                    return RedirectToAction(nameof(DoctorInterests));

                case Domain.Entities.Doctors.DoctorSelectedInterestResult.ItemIsExist:
                    TempData[WarningMessage] = _sharedLocalizer["You have selected this item."].Value;
                    return RedirectToAction(nameof(DoctorInterests));
            }

            TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
            return RedirectToAction(nameof(DoctorInterests));
        }

        #endregion

        #region Delete Interest To Doctor

        public async Task<IActionResult> DeleteDoctorSelectedInfo(ulong interestId)
        {
            var result = await _doctorService.DeleteDoctorSelectedInterestDoctorPanel(interestId, User.GetUserId());

            switch (result)
            {
                case Domain.Entities.Doctors.DoctorSelectedInterestResult.Success:
                    TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                    return RedirectToAction(nameof(DoctorInterests));

                case Domain.Entities.Doctors.DoctorSelectedInterestResult.Faild:
                    TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
                    return RedirectToAction(nameof(DoctorInterests));

                case Domain.Entities.Doctors.DoctorSelectedInterestResult.ItemNotExist:
                    TempData[WarningMessage] = _sharedLocalizer["You have not selected this item."].Value;
                    return RedirectToAction(nameof(DoctorInterests));
            }

            TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
            return RedirectToAction(nameof(DoctorInterests));
        }

        #endregion
    }
}
