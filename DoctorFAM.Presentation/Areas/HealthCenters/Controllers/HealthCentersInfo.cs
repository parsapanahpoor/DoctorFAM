using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.HealthCenters.HealthCentersInfo;
using DoctorFAM.Web.Areas.Dentist.ActionFilterAttributes;
using DoctorFAM.Web.HealthCenters.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.HealthCenters.Controllers;

[IsUserHealthCenterMember]
public class HealthCentersInfoController : HealthCentersBaseController
{
    #region Ctor

    private readonly IHealthCentersService _healthCentersService;
    private readonly IOrganizationService _organizationService;
    private readonly ILocationService _locationService;

    public HealthCentersInfoController(IHealthCentersService healthCentersService, 
                             IOrganizationService organizationService, 
                             ILocationService locationService)
    {
        _healthCentersService = healthCentersService;
        _organizationService = organizationService;
        _locationService = locationService;
    }

    #endregion

    #region Page of Manage Health House Infos

    public async Task<IActionResult> PageOfManageHealthCentersInfo()
    {
        #region Fill Model 

        var model = await _organizationService.GetHealthCenterOrganizationByUserId(User.GetUserId());
        if (model is null) { return NotFound(); }

        #endregion

        return View(model);
    }

    #endregion

    #region Manage Health Center Personal Info

    [HttpGet]
    public async Task<IActionResult> ManageHealthCentersInfo()
    {
        #region Fill Model 

        var model = await _healthCentersService.FillManageHealthCentersInfoViewModel(User.GetUserId());
        if (model == null) return NotFound();

        #endregion

        #region View Bages

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
    public async Task<IActionResult> ManageHealthCentersInfo(ManageHealthCentersInfoViewModel model, IFormFile? UserAvatar, IFormFile? HealthCenterImage)
    {
        #region Model State Validation

        if (!ModelState.IsValid)
        {
            #region Fill Model 

            var returnModel1 = await _healthCentersService.FillManageHealthCentersInfoViewModel(User.GetUserId());
            if (returnModel1 == null) return NotFound();

            ViewData["Countries"] = await _locationService.GetAllCountries();

            if (returnModel1.CityId.HasValue && returnModel1.StateId.HasValue && returnModel1.CountryId.HasValue)
            {
                ViewData["States"] = await _locationService.GetStateChildren(returnModel1.CountryId.Value);
                ViewData["Cities"] = await _locationService.GetStateChildren(returnModel1.StateId.Value);
            }

            #endregion

            TempData[ErrorMessage] = "اطلاعات وارد شده صحیح نمی باشد.";
            return View(returnModel1);
        }

        if (!string.IsNullOrEmpty(model.WorkAddress) && (!model.CountryId.HasValue || !model.StateId.HasValue || !model.CityId.HasValue))
        {
            #region Fill Model 

            var returnModel2 = await _healthCentersService.FillManageHealthCentersInfoViewModel(User.GetUserId());
            if (returnModel2 == null) return NotFound();

            ViewData["Countries"] = await _locationService.GetAllCountries();

            if (returnModel2.CityId.HasValue && returnModel2.StateId.HasValue && returnModel2.CountryId.HasValue)
            {
                ViewData["States"] = await _locationService.GetStateChildren(returnModel2.CountryId.Value);
                ViewData["Cities"] = await _locationService.GetStateChildren(returnModel2.StateId.Value);
            }

            #endregion

            TempData[ErrorMessage] = "خواهشمندیم اطلاعات آدرس را به طور کامل وارد نمایید.";
            return View(returnModel2);
        }

        if ((model.CountryId.HasValue || model.CityId.HasValue || model.StateId.HasValue) && string.IsNullOrEmpty(model.WorkAddress))
        {
            #region Fill Model 

            var returnModel3 = await _healthCentersService.FillManageHealthCentersInfoViewModel(User.GetUserId());
            if (returnModel3 == null) return NotFound();

            ViewData["Countries"] = await _locationService.GetAllCountries();

            if (returnModel3.CityId.HasValue && returnModel3.StateId.HasValue && returnModel3.CountryId.HasValue)
            {
                ViewData["States"] = await _locationService.GetStateChildren(returnModel3.CountryId.Value);
                ViewData["Cities"] = await _locationService.GetStateChildren(returnModel3.StateId.Value);
            }

            #endregion

            TempData[ErrorMessage] = "خواهشمندیم اطلاعات آدرس را به طور کامل وارد نمایید.";
            return View(returnModel3);
        }

        #endregion

        #region Add Or Edit Health Center Information

        var result = await _healthCentersService.AddOrEditHealthCenterInfoDentistsPanel(model, UserAvatar, HealthCenterImage);

        switch (result)
        {
            case AddOrEditHealthCenterstInfoResult.FileNotUploaded:
                TempData[ErrorMessage] = "لطفا مدرک تحصیلی خود را آپلود کنید.";
                break;

            case AddOrEditHealthCenterstInfoResult.Faild:
                TempData[ErrorMessage] = "عملیات شکست خورده است";
                return RedirectToAction(nameof(ManageHealthCentersInfo));

            case AddOrEditHealthCenterstInfoResult.Success:
                TempData[SuccessMessage] = "عملیات با موفقیت";
                return RedirectToAction("Index", "Home", new { area = "HealthCenters" });

            case AddOrEditHealthCenterstInfoResult.NotValidImage:
                TempData[ErrorMessage] = "تصویر معتبر نیست";
                break;

            case AddOrEditHealthCenterstInfoResult.NationalId:
                TempData[ErrorMessage] = "شناسه ملی معتبر نیست";
                break;

            case AddOrEditHealthCenterstInfoResult.NotValidNationalId:
                TempData[ErrorMessage] = "ملی وارد شده در حال حاضر در سایت موجود است";
                break;

            case AddOrEditHealthCenterstInfoResult.NotValidEmail:
                TempData[ErrorMessage] = "ایمیل وارد شده از قبل در سایت موجود است";
                break;
        }

        #endregion

        #region Fill Model 

        var returnModel = await _healthCentersService.FillManageHealthCentersInfoViewModel(User.GetUserId());
        if (returnModel == null) return NotFound();

        ViewData["Countries"] = await _locationService.GetAllCountries();

        if (returnModel.CityId.HasValue && returnModel.StateId.HasValue && returnModel.CountryId.HasValue)
        {
            ViewData["States"] = await _locationService.GetStateChildren(returnModel.CountryId.Value);
            ViewData["Cities"] = await _locationService.GetStateChildren(returnModel.StateId.Value);
        }

        #endregion

        return View(returnModel);
    }

    #endregion
}
