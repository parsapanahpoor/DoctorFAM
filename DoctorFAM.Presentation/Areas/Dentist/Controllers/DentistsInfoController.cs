#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Web.Areas.Dentist.ActionFilterAttributes;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace DoctorFAM.Web.Areas.Dentist.Controllers;

[IsUserDentist]
public class DentistsInfoController : DentistBaseController
{
    #region Ctor

    private readonly IDentistService _dentistService;
    private readonly IOrganizationService _organizationService;

    public DentistsInfoController(IDentistService dentistService, IOrganizationService organizationService)
    {
        _dentistService = dentistService;
        _organizationService = organizationService;
    }

    #endregion

    #region Page of Manage Dentist Infos

    public async Task<IActionResult> PageOfManageDentistInfo()
    {
        #region Fill Model 

        var model = await _organizationService.GetDentistOrganizationByUserId(User.GetUserId());
        if (model is null) { return NotFound(); }

        #endregion

        return View(model);
    }

    #endregion

    #region Manage Dentist Personal Info

    [HttpGet]
    public async Task<IActionResult> ManageDentistsInfo()
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
    public async Task<IActionResult> ManageDentistsInfo(ManageDoctorsInfoViewModel model, IFormFile? MediacalFile, IFormFile? UserAvatar)
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

        if (!string.IsNullOrEmpty(model.WorkAddress) && (!model.CountryId.HasValue || !model.StateId.HasValue || !model.CityId.HasValue))
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

        var result = await _doctorService.AddOrEditDoctorInfoDoctorsPanel(model, MediacalFile, UserAvatar);

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
}
