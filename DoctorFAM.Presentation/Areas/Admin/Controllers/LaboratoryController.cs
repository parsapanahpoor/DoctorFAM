using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.Admin.Laboratory;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class LaboratoryController : AdminBaseController
    {
        #region Ctor

        private readonly ILaboratoryService _laboratoryService;
        private readonly IUserService _userService;

        public LaboratoryController(ILaboratoryService laboratoryService, IUserService userService)
        {
            _laboratoryService = laboratoryService;
            _userService = userService;
        }

        #endregion

        #region Laboratory Infos

        #region Filter Laboratory 

        public async Task<IActionResult> ListOfLaboratoryInfoViewModel(ListOfLaboratoryInfoViewModel filter)
        {
            return View(await _laboratoryService.FilterListOfLaboratoryInfoViewModel(filter));
        }

        #endregion

        #region Edit Laboratory Infos

        [HttpGet]
        public async Task<IActionResult> LaboratoryInfoDetail(ulong userId)
        {
            #region Get Laboratory By User Id 

            var Laboratory = await _laboratoryService.GetLaboratoryByUserId(userId);
            if (Laboratory == null) return NotFound();

            #endregion

            #region Get Laboratory Info

            var info = await _laboratoryService.FillLaboratoryInfoDetailAdminSideViewModel(Laboratory.Id);
            if (info == null) return NotFound();

            #endregion

            return View(info);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> LaboratoryInfoDetail(LaboratoryInfoDetailAdminSideViewModel model)
        {
            #region Get Laboratory By User Id 

            var Laboratory = await _laboratoryService.GetLaboratoryByUserId(model.UserId);
            if (Laboratory == null) return NotFound();

            #endregion

            #region Get Laboratory Info

            var info = await _laboratoryService.FillLaboratoryInfoDetailAdminSideViewModel(Laboratory.Id);
            if (info == null) return NotFound();

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                return View(info);
            }

            #endregion

            #region Edit Method

            var result = await _laboratoryService.EditLaboratoryInfoAdminSide(model);

            switch (result)
            {
                case EditLaboratoryInfoResult.faild:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شده است ";
                    return RedirectToAction("LaboratoryInfoDetail", "Laboratory", new { area = "Admin", userId = model.UserId });

                case EditLaboratoryInfoResult.success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                    return RedirectToAction("LaboratoryInfoDetail", "Laboratory", new { area = "Admin", userId = model.UserId });
            }

            #endregion

            return View(info);
        }

        #endregion

        #region Show Laboratory Info Detail

        public async Task<IActionResult> ShowLaboratoryInfoDetail(ulong userId)
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
