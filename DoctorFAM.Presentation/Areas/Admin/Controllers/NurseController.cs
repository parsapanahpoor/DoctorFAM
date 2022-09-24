using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Doctor;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class NurseController : AdminBaseController
    {
        #region Ctor

        private readonly INurseService _nurseService;
        private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;
        private readonly IUserService _userService;

        public NurseController(INurseService nurseService, IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer
                                    , IUserService userService)
        {
            _nurseService = nurseService;
            _sharedLocalizer = sharedLocalizer;
            _userService = userService;
        }

        #endregion

        #region Nurse Infos

        #region List Of Nurse Info

        public async Task<IActionResult> ListOfNurseInfo(ListOfNurseInfoViewModel filter)
        {
            return View(await _nurseService.FilterNurseInfoAdminSide(filter));
        }

        #endregion

        #region Edit Nurse Infos

        [HttpGet]
        public async Task<IActionResult> NurseInfoDetail(ulong userId)
        {
            #region Get Nurse By User Id 

            var nurse = await _nurseService.GetNurseByUserId(userId);
            if (nurse == null) return NotFound();

            #endregion

            #region Get Nurse Info

            var info = await _nurseService.FillNurseInfoDetailViewModel(nurse.Id);
            if (info == null) return NotFound();

            #endregion

            return View(info);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> NurseInfoDetail(NurseInfoDetailViewModel model)
        {
            #region Get Nurse By User Id 

            var doctor = await _nurseService.GetNurseByUserId(model.UserId);
            if (doctor == null) return NotFound();

            #endregion

            #region Get Nurse Info

            var info = await _nurseService.FillNurseInfoDetailViewModel(doctor.Id);
            if (info == null) return NotFound();

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                return View(info);
            }

            #endregion

            #region Edit Method

            var result = await _nurseService.EditNurseInfoAdminSide(model);

            switch (result)
            {
                case EditNurseInfoResult.faild:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شده است ";
                    return RedirectToAction("NurseInfoDetail", "Nurse", new { area = "Admin", userId = model.UserId });

                case EditNurseInfoResult.success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                    return RedirectToAction("NurseInfoDetail", "Nurse", new { area = "Admin", userId = model.UserId });
            }

            #endregion

            return View(info);
        }

        #endregion

        #region Show Nurse Info Detail

        public async Task<IActionResult> ShowNurseInfoDetail(ulong userId)
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
