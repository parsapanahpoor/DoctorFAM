using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Pharmacy.PharmacyInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using static DoctorFAM.Domain.ViewModels.Pharmacy.PharmacyInfo.ManagePharmacyInfoViewModel;

namespace DoctorFAM.Web.Areas.Pharmacy.Controllers
{
    public class PharmacyController : PharmacyBaseController
    {
        #region Ctor

        private readonly IPharmacyService _pharmacyService;

        private readonly IOrganizationService _organization;

        private readonly ILocationService _locationService;

        private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;

        public PharmacyController(IPharmacyService pharmacyService, IOrganizationService organization, ILocationService locationService
                                        , IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer)
        {
            _pharmacyService = pharmacyService;
            _organization = organization;
            _sharedLocalizer = sharedLocalizer;
            _locationService = locationService;
        }

        #endregion

        #region Page of Manage Pharmacy Infos

        public async Task<IActionResult> PageOfManagePharmacyInfo()
        {
            ViewBag.PharmacyOffice = await _organization.GetPharmacyOrganizationByUserId(User.GetUserId());

            return View(await _pharmacyService.GetPharmacyByUserId(User.GetUserId()));
        }

        #endregion

        #region Manage Pharmacys Personal Info

        [HttpGet]
        public async Task<IActionResult> ManagePharmacyInfo()
        {
            #region Fill Model 

            var model = await _pharmacyService.FillManagePharmacyInfoViewModel(User.GetUserId());

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
        public async Task<IActionResult> ManagePharmacyInfo(ManagePharmacyInfoViewModel model)
        {
            #region Fill Model 

            var returnModel = await _pharmacyService.FillManagePharmacyInfoViewModel(User.GetUserId());

            ViewData["Countries"] = await _locationService.GetAllCountries();

            if (returnModel == null) return NotFound();

            #endregion

            #region Erorr

            //If National Id Is 0
            if (model.NationalCode == 0)
            {
                TempData[ErrorMessage] = _sharedLocalizer["The input values ​​are not valid"].Value;
                return View(returnModel);
            }

            //If Users Id Are Confilited with each other 
            if (model.UserId != returnModel.UserId)
            {
                TempData[ErrorMessage] = _sharedLocalizer["The input values ​​are not valid"].Value;
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

            #endregion

            #region Add Or Edit Pharmacy Information

            var result = await _pharmacyService.AddOrEditPharmacyInfoPharmacyPanel(model);

            switch (result)
            {
                case AddOrEditPharmcyInfoResult.FileNotUploaded:
                    TempData[ErrorMessage] = _sharedLocalizer["Please upload your educational certificate or license"].Value;
                    break;

                case AddOrEditPharmcyInfoResult.Faild:
                    TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
                    return RedirectToAction("ManagePharmacyInfo", "Pharmacy", new { area = "Pharmacy" });

                case AddOrEditPharmcyInfoResult.Success:
                    TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                    return RedirectToAction("Index", "Home", new { area = "Pharmacy" });
            }

            #endregion

            if (returnModel.CityId.HasValue && returnModel.StateId.HasValue && returnModel.CountryId.HasValue)
            {
                ViewData["States"] = await _locationService.GetStateChildren(returnModel.CountryId.Value);
                ViewData["Cities"] = await _locationService.GetStateChildren(returnModel.StateId.Value);
            }

            return View(returnModel);
        }

        #endregion

        #region Pharmacy Interests 

        public async Task<IActionResult> PharmacyInterests()
        {
            #region Fill Page Model 

            var model = await _pharmacyService.FillPharmacyInterestViewModelFromPharmacyPanel(User.GetUserId());

            #endregion

            return View(model);
        }

        #endregion

        #region Add Interest To Pharmacy

        public async Task<IActionResult> AddInterestToPharmacy(ulong interestId)
        {
            var result = await _pharmacyService.AddPharmacySelectedInterest(interestId, User.GetUserId());

            switch (result)
            {
                case Domain.Entities.Pharmacy.PharmacySelectedInterestResult.Success:
                    TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                    return RedirectToAction(nameof(PharmacyInterests));

                case Domain.Entities.Pharmacy.PharmacySelectedInterestResult.Faild:
                    TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
                    return RedirectToAction(nameof(PharmacyInterests));

                case Domain.Entities.Pharmacy.PharmacySelectedInterestResult.ItemIsExist:
                    TempData[WarningMessage] = _sharedLocalizer["You have selected this item."].Value;
                    return RedirectToAction(nameof(PharmacyInterests));
            }

            TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
            return RedirectToAction(nameof(PharmacyInterests));
        }

        #endregion

        #region Delete Interest To Doctor

        public async Task<IActionResult> DeletePharmacySelectedInfo(ulong interestId)
        {
            var result = await _pharmacyService.DeletePharmacySelectedInterestPharmacyPanel(interestId, User.GetUserId());

            switch (result)
            {
                case Domain.Entities.Pharmacy.PharmacySelectedInterestResult.Success:
                    TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                    return RedirectToAction(nameof(PharmacyInterests));

                case Domain.Entities.Pharmacy.PharmacySelectedInterestResult.Faild:
                    TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
                    return RedirectToAction(nameof(PharmacyInterests));

                case Domain.Entities.Pharmacy.PharmacySelectedInterestResult.ItemNotExist:
                    TempData[WarningMessage] = _sharedLocalizer["You have not selected this item."].Value;
                    return RedirectToAction(nameof(PharmacyInterests));
            }

            TempData[ErrorMessage] = _sharedLocalizer["The operation has failed"].Value;
            return RedirectToAction(nameof(PharmacyInterests));
        }

        #endregion

    }
}
