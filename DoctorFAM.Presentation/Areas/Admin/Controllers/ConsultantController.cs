using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Consultant;
using DoctorFAM.Domain.ViewModels.Admin.Doctor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class ConsultantController : AdminBaseController
    {
        #region Ctor

        private readonly IConsultantService _consultantService;
        private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;
        private readonly IUserService _userService;

        public ConsultantController(IConsultantService consultantService, IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer
                                    , IUserService userService)
        {
            _consultantService = consultantService;
            _sharedLocalizer = sharedLocalizer;
            _userService = userService;
        }

        #endregion

        #region Consultant Infos

        #region List Of Consultant Info

        public async Task<IActionResult> ListOfConsultantInfoViewModel(ListOfConsultantInfoViewModel filter)
        {
            return View(await _consultantService.FilterConsultantInfoAdminSide(filter));
        }

        #endregion

        #region Edit Consoltant Infos

        [HttpGet]
        public async Task<IActionResult> ConsultantInfoDetail(ulong userId)
        {
            #region Get Consoltant By User Id 

            var nurse = await _consultantService.GetConsultantByUserId(userId);
            if (nurse == null) return NotFound();

            #endregion

            #region Get Consultant Info

            var info = await _consultantService.FillConsultantInfoDetailViewModel(nurse.Id);
            if (info == null) return NotFound();

            #endregion

            return View(info);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ConsultantInfoDetail(ConsultantInfoDetailViewModel model)
        {
            #region Get Consultant By User Id 

            var consultant = await _consultantService.GetConsultantByUserId(model.UserId);
            if (consultant == null) return NotFound();

            #endregion

            #region Get Consultant Info

            var info = await _consultantService.FillConsultantInfoDetailViewModel(consultant.Id);
            if (info == null) return NotFound();

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                return View(info);
            }

            #endregion

            #region Edit Method

            var result = await _consultantService.EditConsultantInfoAdminSide(model);

            switch (result)
            {
                case EditConsultantInfoResult.faild:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شده است ";
                    return RedirectToAction("ConsultantInfoDetail", "Consultant", new { area = "Admin", userId = model.UserId });

                case EditConsultantInfoResult.success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                    return RedirectToAction("ConsultantInfoDetail", "Consultant", new { area = "Admin", userId = model.UserId });
            }

            #endregion

            return View(info);
        }

        #endregion

        #region Show Consultant Info Detail

        public async Task<IActionResult> ShowConsultantInfoDetail(ulong userId)
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
