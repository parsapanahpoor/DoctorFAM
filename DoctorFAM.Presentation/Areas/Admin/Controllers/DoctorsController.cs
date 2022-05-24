using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class DoctorsController : AdminBaseController
    {
        #region Ctor

        public IDoctorsService _doctorsService;

        public DoctorsController(IDoctorsService doctorsService)
        {
            _doctorsService = doctorsService;
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
        public async Task<IActionResult> DoctorsInfoDetail(ulong doctorsInfoId)
        {
            #region Get Doctor Info

            var info = await _doctorsService.FillDoctorsInfoDetailViewModel(doctorsInfoId);

            if (info == null) return NotFound();

            #endregion

            return View(info);
        }

        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> DoctorsInfoDetail(DoctorsInfoDetailViewModel model , IFormFile? MediacalFile)
        {
            #region Get Doctor Info

            var info = await _doctorsService.FillDoctorsInfoDetailViewModel(model.Id);

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
                    return RedirectToAction("DoctorsInfoDetail", "Doctors", new { area = "Admin" });

                case EditDoctorInfoResult.success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                    return RedirectToAction("ListOfDoctorsInfo", "Doctors", new { area = "Admin" });
            }
            #endregion

            return View(info);
        }

        #endregion

        #endregion

    }
}
