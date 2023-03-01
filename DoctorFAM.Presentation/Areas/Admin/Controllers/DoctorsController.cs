using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class DoctorsController : AdminBaseController
    {
        #region Ctor

        private readonly IDoctorsService _doctorsService;
        private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;
        private readonly IUserService _userService;
        private readonly IPopulationCoveredService _populationCovered;

        public DoctorsController(IDoctorsService doctorsService, IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer
                                    , IUserService userService, IPopulationCoveredService populationCovered)
        {
            _doctorsService = doctorsService;
            _sharedLocalizer = sharedLocalizer;
            _userService = userService;
            _populationCovered = populationCovered;
        }

        #endregion

        #region Doctors Infos

        #region List Of Doctors Info

        public async Task<IActionResult> ListOfDoctorsInfo(ListOfDoctorsInfoViewModel filter)
        {
            return View(await _doctorsService.FilterDoctorsInfoAdminSide(filter));
        }

        #endregion

        #region List Of Doctors For Export Excel File 

        public async Task<IActionResult> ListOfDoctorsForExportExcelFile(ListOfDoctorsInfoForExportExcelFileViewModel filter)
        {
            ViewBag.selectedState = (int?)filter.SelectStateFromAdmin;

            return View(await _doctorsService.ListOfDoctorsForExportExcelFile(filter));
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

            //if (info == null) return NotFound();

            #endregion

            return View(info);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DoctorsInfoDetail(DoctorsInfoDetailViewModel model, IFormFile? MediacalFile)
        {
            #region Get Doctor By User Id 

            var doctor = await _doctorsService.GetDoctorByUserId(model.UserId);

            #endregion

            #region Get Doctor Info

            var info = await _doctorsService.FillDoctorsInfoDetailViewModel(doctor.Id);

            //if (info == null) return NotFound();

            if (info == null && model.DoctorsInfosType == Domain.Entities.Doctors.OrganizationInfoState.Accepted)
            {
                TempData[ErrorMessage] = "پزشک جاری فاقد اطلاعاتی برای تایید است.";
                return View(info);
            }

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
                return View(info);
            }

            #endregion

            #region Edit Method

            var result = await _doctorsService.EditDoctorInfoAdminSide(model, MediacalFile);

            switch (result)
            {
                case EditDoctorInfoResult.faild:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شده است ";
                    return RedirectToAction("DoctorsInfoDetail", "Doctors", new { area = "Admin", userId = model.UserId });

                case EditDoctorInfoResult.NationalId:
                    TempData[ErrorMessage] = "شماره ملی وارد شده در سامانه موجود است. ";
                    return RedirectToAction("DoctorsInfoDetail", "Doctors", new { area = "Admin", userId = model.UserId });

                case EditDoctorInfoResult.success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                    return RedirectToAction("ListOfDoctorsInfo", "Doctors", new { area = "Admin" });
            }

            #endregion

            return View(info);
        }

        #endregion

        #region Delete Interest To Doctor

        public async Task<IActionResult> DeleteDoctorSelectedInfo(ulong interestId, ulong doctorId, ulong doctorInfoId)
        {
            #region Get Doctor By Id

            var doctor = await _doctorsService.GetDoctorById(doctorId);

            #endregion

            var result = await _doctorsService.DeleteDoctorSelectedInterestDoctorPanel(interestId, doctor.UserId);

            switch (result)
            {
                case Domain.Entities.Doctors.DoctorSelectedInterestResult.Success:
                    TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                    return RedirectToAction(nameof(DoctorsInfoDetail), new { userId = doctor.UserId });

                case Domain.Entities.Doctors.DoctorSelectedInterestResult.Faild:
                    TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
                    return RedirectToAction(nameof(DoctorsInfoDetail), new { userId = doctor.UserId });

                case Domain.Entities.Doctors.DoctorSelectedInterestResult.ItemNotExist:
                    TempData[WarningMessage] = _sharedLocalizer["You have not selected this item."].Value;
                    return RedirectToAction(nameof(DoctorsInfoDetail), new { userId = doctor.UserId });
            }

            TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
            return RedirectToAction(nameof(DoctorsInfoDetail), new { userId = doctor.UserId });
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

        #region Decline Doctor Informations

        public async Task<IActionResult> DeclineDoctorInformation(ulong userId)
        {
            var res = await _doctorsService.DeclineDoctorInformationByOneClick(userId);

            if (res)
            {
                TempData[SuccessMessage] = "عملیات باموقفیت انجام شده است.";
                return RedirectToAction(nameof(ListOfDoctorsInfo));
            }

            TempData[ErrorMessage] = "اطلاعاتی از پزشک جاری یافت نشده است.";
            return RedirectToAction(nameof(ListOfDoctorsInfo));
        }

        #endregion

        #region Doctor Diabet Consultant Resume 

        [HttpGet]
        public async Task<IActionResult> ShowDiabetConsultantResume(ulong userId)
        {
            #region Fill Model 

            var model = await _doctorsService.GetDiabetConsultanResumesByUserIdAdminSide(userId);
            if (model == null)
            {
                TempData[ErrorMessage] = "اطلاعاتی برای نمایش یافت نشده است.";
                return RedirectToAction(nameof(DoctorsInfoDetail), new { userId = userId });
            }

            #endregion

            return View(model);
        }

        #endregion

        #region Doctor Blood Pressure Consultant Resume 

        [HttpGet]
        public async Task<IActionResult> ShowBloodPressureConsultantResume(ulong userId)
        {
            #region Fill Model 

            var model = await _doctorsService.GetBloodPressureConsultanResumesByUserIdAdminSide(userId);
            if (model == null)
            {
                TempData[ErrorMessage] = "اطلاعاتی برای نمایش یافت نشده است.";
                return RedirectToAction(nameof(DoctorsInfoDetail), new { userId = userId });
            }

            #endregion

            return View(model);
        }

        #endregion

        #endregion

        #region List Of Doctors Population Covered Count Detail

        [HttpGet]
        public async Task<IActionResult> ListOfDoctorsPopulationCoveredCountDetail()
        {
            #region View Bags

            ViewBag.AllOfUsersCount = await _userService.CountOfUsers();
            ViewBag.AllOfPopulationCovered = await _populationCovered.CountOfAllPopulationCovered();
            ViewBag.AllOfDoctors = await _doctorsService.CountOfAllDoctors();

            #endregion

            return View(await _doctorsService.ListOfDoctorsPopulationCoveredCountDetail());
        }

        #endregion

        #region Count Of Users in Doctor Population Covered 

        public async Task<IActionResult> CountOfUsersinDoctorPopulationCovered()
        {
            return View();
        }

        #endregion
    }
}
