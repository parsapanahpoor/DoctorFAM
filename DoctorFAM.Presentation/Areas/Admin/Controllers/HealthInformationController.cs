using AngleSharp.Css;
using CRM.Web.Areas.Admin.Controllers;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.RadioFAM.Category;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Category;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class HealthInformationController : AdminBaseController
    {
        #region Ctor 

        private readonly IHealthInformationService _healthInformationService;

        private readonly IStringLocalizer<LocationController> _localizer;

        public HealthInformationController(IHealthInformationService healthInformationService , IStringLocalizer<LocationController> localizer)
        {
            _healthInformationService = healthInformationService;
            _localizer = localizer;
        }

        #endregion

        #region Video FAM

        #region Vide Category 

        #region List Of Vide FAM Category

        public async Task<IActionResult> ListOfVideFAMCategoryList(FilterTVFAMCategoryViewModel filter)
        {
            return View(await _healthInformationService.FilterTVFAMCategory(filter));
        }

        #endregion

        #region Create Video FAM Category

        [HttpGet]
        public async Task<IActionResult> CreateVideoFAMCategory(ulong? parentId)
        {
            #region Send Category View Bag

            ViewBag.parentId = parentId;

            if (parentId != null)
            {
                ViewBag.parentCategory = await _healthInformationService.GetHealthInformationCategoryByHealthInformationCategoryId(parentId.Value);
            }

            #endregion

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVideoFAMCategory(CreateTVFAMCategoryViewModel model)
        {
            #region Model State

            if (!ModelState.IsValid)
            {
                #region Send Category View Bag

                ViewBag.parentId = model.ParentId;

                if (model.ParentId != null)
                {
                    ViewBag.parentCategory = await _healthInformationService.GetHealthInformationCategoryByHealthInformationCategoryId(model.ParentId.Value);
                }

                #endregion

                return View(model);
            }

            #endregion

            #region Add Location 

            var result = await _healthInformationService.CreateTVFAMCategory(model);

            switch (result)
            {
                case CreateTVFAMCategoryResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است .";
                    if (model.ParentId.HasValue)
                    {
                        return RedirectToAction("ListOfVideFAMCategoryList", new { ParentId = model.ParentId.Value });
                    }
                    return RedirectToAction("ListOfVideFAMCategoryList");

                case CreateTVFAMCategoryResult.UniqNameIsExist:
                    TempData[ErrorMessage] = "عنوان انتخاب شده تکراری است .";
                    break;

                case CreateTVFAMCategoryResult.Fail:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شده است .";
                    break;
            }

            #region Send Category View Bag

            ViewBag.parentId = model.ParentId;

            if (model.ParentId != null)
            {
                ViewBag.parentCategory = await _healthInformationService.GetHealthInformationCategoryByHealthInformationCategoryId(model.ParentId.Value);
            }

            #endregion

            return View(model);

            #endregion
        }

        #endregion

        #region Edit Vide FAM Category 

        [HttpGet]
        public async Task<IActionResult> EditVideFAMCategory(ulong? tvFAMCategoryId)
        {
            #region Get Vide FAM Category 

            if (tvFAMCategoryId == null) return NotFound();

            var result = await _healthInformationService.FillTVFAMCategoryViewModel(tvFAMCategoryId.Value);

            if (result == null) return NotFound();

            #endregion

            return View(result);
        }

        [HttpPost , ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVideFAMCategory(EditTVFAMCategoryViewModel tvFAMCategory)
        {
            #region Is Exist Tv FAM Category By Id

            if (tvFAMCategory.Id == null) return NotFound();

            var model = await _healthInformationService.FillTVFAMCategoryViewModel(tvFAMCategory.Id);

            if (model == null) return NotFound();

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده مورد تایید نمی باشد.";

                return View(model);
            }

            #endregion

            #region Edit Tv FAM Category

            var result = await _healthInformationService.EditService(tvFAMCategory);

            switch (result)
            {
                case EditTVFAMCategoryResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است.";
                    if (tvFAMCategory.ParentId.HasValue)
                    {
                        return RedirectToAction("ListOfVideFAMCategoryList", new { ParentId = tvFAMCategory.ParentId.Value });
                    }
                    return RedirectToAction("ListOfVideFAMCategoryList");

                case EditTVFAMCategoryResult.UniqNameIsExist:
                    TempData[ErrorMessage] = "عنوان وارد شده تکراری است .";
                    break;

                case EditTVFAMCategoryResult.Fail:
                    TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";
                    break;
            }

            return View(model);

            #endregion
        }

        #endregion

        #region Delete Vide FAM Category 

        public async Task<IActionResult> DeleteVideFAMCategegory(ulong id)
        {
            var result = await _healthInformationService.DeleteTVFAMCategory(id);

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, _localizer["Mission Accomplished"].Value);
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, _localizer["The operation failed"].Value);
        }

        #endregion

        #endregion

        #endregion

        #region Radio FAM 

        #region Radio FAM CAtegory

        #region List Of Radio FAM Category

        public async Task<IActionResult> ListOfRadioFAMCategoryList(FilterRadioFAMCategoryViewModel filter)
        {
            return View(await _healthInformationService.FilterRadioFAMCategory(filter));
        }

        #endregion

        #region Create Video FAM Category

        [HttpGet]
        public async Task<IActionResult> CreateRadioFAMCategory(ulong? parentId)
        {
            #region Send Category View Bag

            ViewBag.parentId = parentId;

            if (parentId != null)
            {
                ViewBag.parentCategory = await _healthInformationService.GetRadioFAMCategoryByHealthInformationCategoryId(parentId.Value);
            }

            #endregion

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRadioFAMCategory(CreateRadioFAMCategoryViewModel model)
        {
            #region Model State

            if (!ModelState.IsValid)
            {
                #region Send Category View Bag

                ViewBag.parentId = model.ParentId;

                if (model.ParentId != null)
                {
                    ViewBag.parentCategory = await _healthInformationService.GetRadioFAMCategoryByHealthInformationCategoryId(model.ParentId.Value);
                }

                #endregion

                return View(model);
            }

            #endregion

            #region Add Location 

            var result = await _healthInformationService.CreateRadioFAMCategory(model);

            switch (result)
            {
                case CreateRadioFAMCategoryResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است .";
                    if (model.ParentId.HasValue)
                    {
                        return RedirectToAction("ListOfRadioFAMCategoryList", new { ParentId = model.ParentId.Value });
                    }
                    return RedirectToAction("ListOfRadioFAMCategoryList");

                case CreateRadioFAMCategoryResult.UniqNameIsExist:
                    TempData[ErrorMessage] = "عنوان انتخاب شده تکراری است .";
                    break;

                case CreateRadioFAMCategoryResult.Fail:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شده است .";
                    break;
            }

            #region Send Category View Bag

            ViewBag.parentId = model.ParentId;

            if (model.ParentId != null)
            {
                ViewBag.parentCategory = await _healthInformationService.GetRadioFAMCategoryByHealthInformationCategoryId(model.ParentId.Value);
            }

            #endregion

            return View(model);

            #endregion
        }

        #endregion

        #region Edit Radio FAM Category 

        [HttpGet]
        public async Task<IActionResult> EditRadioFAMCategory(ulong? radioFAMCategoryId)
        {
            #region Get Radio FAM Category 

            if (radioFAMCategoryId == null) return NotFound();

            var result = await _healthInformationService.FillRadioFAMCategoryViewModel(radioFAMCategoryId.Value);

            if (result == null) return NotFound();

            #endregion

            return View(result);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRadioFAMCategory(EditRadioFAMCategoryViewModel radioFAMCategory)
        {
            #region Is Exist Tv FAM Category By Id

            if (radioFAMCategory.Id == null) return NotFound();

            var model = await _healthInformationService.FillRadioFAMCategoryViewModel(radioFAMCategory.Id);

            if (model == null) return NotFound();

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "اطلاعات وارد شده مورد تایید نمی باشد.";

                return View(model);
            }

            #endregion

            #region Edit Tv FAM Category

            var result = await _healthInformationService.EditService(radioFAMCategory);

            switch (result)
            {
                case EditRadioFAMCategoryResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است.";
                    if (radioFAMCategory.ParentId.HasValue)
                    {
                        return RedirectToAction("ListOfRadioFAMCategoryList", new { ParentId = radioFAMCategory.ParentId.Value });
                    }
                    return RedirectToAction("ListOfRadioFAMCategoryList");

                case EditRadioFAMCategoryResult.UniqNameIsExist:
                    TempData[ErrorMessage] = "عنوان وارد شده تکراری است .";
                    break;

                case EditRadioFAMCategoryResult.Fail:
                    TempData[ErrorMessage] = "عملیات باشکست مواجه شده است.";
                    break;
            }

            return View(model);

            #endregion
        }

        #endregion

        #region Delete Radio FAM Category 

        public async Task<IActionResult> DeleteRadioFAMCategegory(ulong id)
        {
            var result = await _healthInformationService.DeleteRadioFAMCategory(id);

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, _localizer["Mission Accomplished"].Value);
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, _localizer["The operation failed"].Value);
        }

        #endregion

        #endregion

        #endregion
    }
}
