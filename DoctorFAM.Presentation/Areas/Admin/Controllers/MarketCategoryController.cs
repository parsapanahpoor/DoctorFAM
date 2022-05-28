using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.MarketCategory;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class MarketCategoryController : AdminBaseController
    {
        #region Ctor

        private readonly IMarketCategoryService _categoryService;

        private readonly IStringLocalizer<MarketCategoryController> _localizer;

        public MarketCategoryController(IMarketCategoryService categoryService , IStringLocalizer<MarketCategoryController> localizer)
        {
            _categoryService = categoryService;
            _localizer = localizer;
        }

        #endregion

        #region Market Category List

        public async Task<IActionResult> FilterMarketCategory(FilterMarketCategoryViewModel filter)
        {
            var result = await _categoryService.FilterMarketCategory(filter);
            return View(result);
        }

        #endregion

        #region Create Market Category

        [HttpGet]
        public async Task<IActionResult> CreateMarketCategory(ulong? parentId)
        {
            ViewBag.parentId = parentId;

            if (parentId != null)
            {
                ViewBag.parentMarketCategory = await _categoryService.GetMarketCategoryById(parentId.Value);
            }

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMarketCategory(CreateMarketCategoryViewModel createMarketCategory)
        {
            #region Model State

            if (!ModelState.IsValid)
            {
                ViewBag.parentId = createMarketCategory.ParentId;

                if (createMarketCategory.ParentId != null)
                {
                    ViewBag.parentMarketCategory = await _categoryService.GetMarketCategoryById(createMarketCategory.ParentId.Value);
                }

                return View(createMarketCategory);
            }

            #endregion

            #region Add Market Category 

            var result = await _categoryService.CreateMarketCategory(createMarketCategory);

            switch (result)
            {
                case CreateMarketCategoryResult.Success:
                    TempData[SuccessMessage] = _localizer["Mission Accomplished"].Value;
                    if (createMarketCategory.ParentId.HasValue)
                    {
                        return RedirectToAction("FilterMarketCategory", new { ParentId = createMarketCategory.ParentId.Value });
                    }
                    return RedirectToAction("FilterMarketCategory");

                case CreateMarketCategoryResult.UniqNameIsExist:
                    TempData[ErrorMessage] = _localizer["The unique name is duplicate"].Value;
                    break;

                case CreateMarketCategoryResult.Fail:
                    TempData[ErrorMessage] = _localizer["The operation failed"].Value;
                    break;
            }

            ViewBag.parentId = createMarketCategory.ParentId;

            if (createMarketCategory.ParentId != null)
            {
                ViewBag.parentMarketCategory = await _categoryService.GetMarketCategoryById(createMarketCategory.ParentId.Value);
            }

            return View(createMarketCategory);

            #endregion
        }

        #endregion

        #region Edit Market Category

        [HttpGet]
        public async Task<IActionResult> EditMarketCategory(ulong categoryId)
        {
            var result = await _categoryService.FillEditMarketCategoryViewModel(categoryId);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMarketCategory(EditMarketCategoryViewModel category)
        {
            #region Is Exist category By Id

            var model = await _categoryService.FillEditMarketCategoryViewModel(category.Id);

            if (model == null)
            {
                return NotFound();
            }

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = _localizer["The information entered is not valid"].Value;

                return View(model);
            }

            #endregion

            #region Edit Location

            var result = await _categoryService.EditMarketCategory(category);

            switch (result)
            {
                case EditMArketCategoryResult.Success:
                    TempData[SuccessMessage] = _localizer["Mission Accomplished"].Value;
                    if (category.ParentId.HasValue)
                    {
                        return RedirectToAction("FilterMarketCategory", new { ParentId = category.ParentId.Value });
                    }
                    return RedirectToAction("FilterMarketCategory");

                case EditMArketCategoryResult.UniqNameIsExist:
                    TempData[ErrorMessage] = _localizer["The unique name is duplicate"].Value;
                    break;

                case EditMArketCategoryResult.Fail:
                    TempData[ErrorMessage] = _localizer["The operation failed"].Value;
                    break;
            }

            return View(model);

            #endregion
        }

        #endregion

        #region Delete Market Category and Market Category Info

        public async Task<IActionResult> DeleteMarketCategory(ulong marketCategoryId)
        {
            var result = await _categoryService.DeleteMarketCategory(marketCategoryId);

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, _localizer["Mission Accomplished"].Value);
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, _localizer["The operation failed"].Value);
        }

        #endregion

    }
}
