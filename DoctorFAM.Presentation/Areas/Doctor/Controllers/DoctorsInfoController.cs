using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.UserPanel.Account;
using DoctorFAM.Web.Areas.Doctor.ActionFilterAttributes;
using DoctorFAM.Web.Doctor.Controllers;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    [IsUserDoctor]
    public class DoctorsInfoController : DoctorBaseController
    {
        #region Ctor

        public IDoctorsService _doctorService;

        public IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;

        private readonly IOrganizationService _organization;

        private readonly ILocationService _locationService;

        public DoctorsInfoController(IDoctorsService doctorService , IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer 
                                    , IOrganizationService organization , ILocationService locationService)
        {
            _doctorService = doctorService;
            _sharedLocalizer = sharedLocalizer;
            _organization = organization;
            _locationService = locationService;
        }

        #endregion

        #region Page of Manage Doctor Infos

        public async Task<IActionResult> PageOfManageDoctorInfo()
        {
            ViewBag.DoctorOffice = await _organization.GetDoctorOrganizationByUserId(User.GetUserId());

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

            ViewData["Countries"] = await _locationService.GetAllCountries();

            if (model.CityId.HasValue && model.StateId.HasValue && model.CountryId.HasValue)
            {
                ViewData["States"] = await _locationService.GetStateChildren(model.CountryId.Value);
                ViewData["Cities"] = await _locationService.GetStateChildren(model.StateId.Value);
            }

            #endregion

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageDoctorsInfo(ManageDoctorsInfoViewModel model, IFormFile? MediacalFile, IFormFile? UserAvatar)
        {
            #region Fill Model 

            var returnModel = await _doctorService.FillManageDoctorsInfoViewModel(User.GetUserId());

            ViewData["Countries"] = await _locationService.GetAllCountries();

            if (returnModel.CityId.HasValue && returnModel.StateId.HasValue && returnModel.CountryId.HasValue)
            {
                ViewData["States"] = await _locationService.GetStateChildren(returnModel.CountryId.Value);
                ViewData["Cities"] = await _locationService.GetStateChildren(returnModel.StateId.Value);
            }

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

            if (!string.IsNullOrEmpty(model.WorkAddress) && (!model.CountryId.HasValue || !model.StateId.HasValue || !model.CityId.HasValue) )
            {
                TempData[ErrorMessage] = _sharedLocalizer["You Must enter All Of Address Fields"].Value;
                return View(returnModel);
            }

            if ((model.CountryId.HasValue || model.CityId.HasValue || model.StateId.HasValue) && string.IsNullOrEmpty(model.WorkAddress))
            {
                TempData[ErrorMessage] = _sharedLocalizer["You Must enter All Of Address Fields"].Value;
                return View(returnModel);
            }

            if ((model.CountryId.HasValue || model.CityId.HasValue || model.StateId.HasValue) && string.IsNullOrEmpty(model.WorkAddress))
            {
                TempData[ErrorMessage] = _sharedLocalizer["You Must enter All Of Address Fields"].Value;
                return View(returnModel);
            }

            #endregion

            #region Add Or Edit Doctors Information

            var result = await _doctorService.AddOrEditDoctorInfoDoctorsPanel(model, MediacalFile , UserAvatar);

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

                case AddOrEditDoctorInfoResult.NotValidImage:
                    TempData[ErrorMessage] = _sharedLocalizer["Image Is Not Valid ."].Value;
                    break;

                case AddOrEditDoctorInfoResult.NationalId:
                    TempData[ErrorMessage] = _sharedLocalizer["National Id Is Not Valid"].Value;
                    break;

                case AddOrEditDoctorInfoResult.NotValidNationalId:
                    TempData[ErrorMessage] = _sharedLocalizer["The entered National is already available on the site"].Value;
                    break;

                case AddOrEditDoctorInfoResult.NotValidEmail:
                    TempData[ErrorMessage] = _sharedLocalizer["The entered email is already available on the site"].Value;
                    break;
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

                case Domain.Entities.Doctors.DoctorSelectedInterestResult.YouMustInsertLocationAndAddress:
                    TempData[ErrorMessage] = _sharedLocalizer["To choose a family doctor, you must specify the address of your practice or activity in the doctor's information section."].Value;
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

        #region Speciality

        #region List OF Specialities

        [HttpGet]
        public async Task<IActionResult> ListOFSpecialities()
        {
            return View(await _doctorService.FillListOFDoctorsSpeciality(User.GetUserId()));
        }

        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> ListOFSpecialities(List<ulong>? Permissions)
        {
            #region Update Doctor Speciality Info

            var res = await _doctorService.UpdateDoctorSpecialitySelected(Permissions, User.GetUserId());
            if (res)
            {
                TempData[SuccessMessage] = "تغییرات باموفقیت ثبت شده است.";
                TempData[WarningMessage] = "لطفا تا تایید اطلاعات ارسالی خود شکیبا باشید.";

                return RedirectToAction(nameof(PageOfManageDoctorInfo));
            }

            #endregion

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";

            return View(await _doctorService.FillListOFDoctorsSpeciality(User.GetUserId()));
        }

        #endregion

        #endregion
    }
}
