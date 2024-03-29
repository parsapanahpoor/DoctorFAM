﻿using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using DoctorFAM.Web.Areas.Supporter.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Supporter.Controllers
{
    public class DoctorsController : SupporterBaseController
    {
        #region Ctor

        private readonly IDoctorsService _doctorsService;
        private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;
        private readonly IUserService _userService;

        public DoctorsController(IDoctorsService doctorsService , IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer
                                    , IUserService userService)
        {
            _doctorsService = doctorsService;
            _sharedLocalizer = sharedLocalizer;
            _userService = userService;
        }

        #endregion

        #region Doctors Infos

        #region List Of Doctors Info

        public async Task<IActionResult> ListOfDoctorsInfo(ListOfDoctorsInfoViewModel filter)
        {
            return View(await _doctorsService.FilterDoctorsInfoAdminSide(filter));
        }

        #endregion

        #region Edit Doctors Infos

        [HttpGet]
        public async Task<IActionResult> DoctorsInfoDetail(ulong userId)
        {
            #region Get Doctor By User Id 

            var doctor = await _doctorsService.GetDoctorByUserId(userId);

            #endregion

            #region Get Doctor Info

            var info = await _doctorsService.FillDoctorsInfoDetailViewModel(doctor.Id);

            if (info == null) return NotFound();

            #endregion

            return View(info);
        }

        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> DoctorsInfoDetail(DoctorsInfoDetailViewModel model , IFormFile? MediacalFile)
        {
            #region Get Doctor By User Id 

            var doctor = await _doctorsService.GetDoctorByUserId(model.UserId);

            #endregion

            #region Get Doctor Info

            var info = await _doctorsService.FillDoctorsInfoDetailViewModel(doctor.Id);

            if (info == null) return NotFound();

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                return View(info);
            }

            #endregion

            #region Edit Method

            var result = await _doctorsService.EditDoctorInfoAdminSide(model, MediacalFile);

            switch (result)
            {
                case EditDoctorInfoResult.faild:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شده است ";
                    return RedirectToAction("DoctorsInfoDetail", "Doctors", new { area = "Supporter" , userId = model.UserId });

                case EditDoctorInfoResult.success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                    return RedirectToAction("ListOfDoctorsInfo", "Doctors", new { area = "Supporter" });
            }

            #endregion

            return View(info);
        }

        #endregion

        #region Delete Interest To Doctor

        public async Task<IActionResult> DeleteDoctorSelectedInfo(ulong interestId , ulong doctorId , ulong doctorInfoId)
        {
            #region Get Doctor By Id

            var doctor = await _doctorsService.GetDoctorById(doctorId);

            #endregion

            var result = await _doctorsService.DeleteDoctorSelectedInterestDoctorPanel(interestId, doctor.UserId);

            switch (result)
            {
                case Domain.Entities.Doctors.DoctorSelectedInterestResult.Success:
                    TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                    return RedirectToAction(nameof(DoctorsInfoDetail) , new { userId = doctor.UserId });

                case Domain.Entities.Doctors.DoctorSelectedInterestResult.Faild:
                    TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
                    return RedirectToAction(nameof(DoctorsInfoDetail) , new { userId = doctor.UserId });

                case Domain.Entities.Doctors.DoctorSelectedInterestResult.ItemNotExist:
                    TempData[WarningMessage] = _sharedLocalizer["You have not selected this item."].Value;
                    return RedirectToAction(nameof(DoctorsInfoDetail) , new { userId = doctor.UserId });
            }

            TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
            return RedirectToAction(nameof(DoctorsInfoDetail) , new { userId = doctor.UserId });
        }

        #endregion

        #region Show Doctor Info Detail

        public async Task<IActionResult> ShowDoctorInfoDetail(ulong userId)
        {
            #region Get User By Id 

            var user = await _userService.GetUserById(userId);
            if (user == null) return NotFound(); 

            #endregion

            return View(user);
        }

        #endregion

        #endregion
    }
}
