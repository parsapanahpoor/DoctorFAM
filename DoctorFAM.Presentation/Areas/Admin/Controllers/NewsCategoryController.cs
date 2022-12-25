using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.News.Admin;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class NewsCategoryController : AdminBaseController
    {
        #region Constructor

        private readonly INewsService _newsService;

        public NewsCategoryController(INewsService newsService)
        {
            _newsService = newsService;
        }

        #endregion

        #region List Of News Categories

        public async Task<IActionResult> Index(FilterNewsCategoryViewModel filter)
        {
            return View(await _newsService.FilterNewsCategoryViewModel(filter));
        }

        #endregion

        #region Create Main News Category

        [HttpGet]
        public async Task<IActionResult> CreateMainNewsCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMainNewsCategory(CreateNewsCategoryViewModel cat)
        {
            if (ModelState.IsValid)
            {
                var result = await _newsService.AddMainNewsCategory(cat);

                switch (result)
                {
                    case CreateNewsCategoryResult.success:
                        TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                        return RedirectToAction("Index", "NewsCategory");

                    case CreateNewsCategoryResult.Fiald:
                        TempData[ErrorMessage] = "درج مقاله با مشکل مواجه شده است ";
                        break;

                    case CreateNewsCategoryResult.CategoryIsExist:
                        TempData[ErrorMessage] = "عنوان انتخاب شده تکراری است  ";
                        break;
                }
            }
            return View(cat);
        }

        #endregion

        #region Edit News Main Category

        [HttpGet]
        public async Task<IActionResult> EditNewsCategory(ulong Id)
        {
            var cat = await _newsService.GetNewsCategoryById((ulong)Id);

            if (cat == null) return NotFound();

            var model = await _newsService.FillEditNewsCategoryViewModel(cat);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNewsCategory(EditNewsCategoryViewModel cat)
        {
            if (ModelState.IsValid)
            {
                var category = await _newsService.GetNewsCategoryById((ulong)cat.NewsCategoryId);

                if (category == null) return NotFound();

                var result = await _newsService.EditNewsCategoryResult(cat, category);

                switch (result)
                {
                    case EditNewsCategoryResult.success:
                        TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                        return RedirectToAction("Index", "NewsCategory");

                    case EditNewsCategoryResult.Fiald:
                        TempData[ErrorMessage] = "درج مقاله با مشکل مواجه شده است ";
                        break;

                    case EditNewsCategoryResult.CategoryIsExist:
                        TempData[ErrorMessage] = "عنوان انتخاب شده تکراری است  ";
                        break;
                }
            }

            return View(cat);
        }
        #endregion

        #region Delete News Category

        public async Task<IActionResult> DeleteNewsCategory(ulong Id)
        {
            var category = await _newsService.GetNewsCategoryById((ulong)Id);

            if (category == null) return JsonResponseStatus.Error();

            await _newsService.DeleteNewsCategory(category);

            return JsonResponseStatus.Success();
        }

        #endregion

        #region Create Sub News Category

        [HttpGet]
        public async Task<IActionResult> CreateSubCategory(ulong ParentId)
        {
            var MainCat = await _newsService.GetNewsCategoryById((ulong)ParentId);

            if (MainCat == null) return NotFound();

            ViewBag.ParentId = ParentId;
            ViewBag.ParentTitle = MainCat.Title;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubCategory(CreateNewsCategoryViewModel cat)
        {
            if (ModelState.IsValid)
            {
                var MainCat = await _newsService.GetNewsCategoryById(cat.ParentId.Value);

                if (MainCat == null)
                {
                    ViewBag.ParentId = cat.ParentId;
                    return NotFound();
                }

                var result = await _newsService.AddMainNewsCategory(cat);

                switch (result)
                {
                    case CreateNewsCategoryResult.success:
                        TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                        return RedirectToAction("ListOfSubCategories", "NewsCategory", new { ParentId = cat.ParentId });

                    case CreateNewsCategoryResult.Fiald:
                        TempData[ErrorMessage] = "درج مقاله با مشکل مواجه شده است ";
                        break;

                    case CreateNewsCategoryResult.CategoryIsExist:
                        TempData[ErrorMessage] = "عنوان انتخاب شده تکراری است  ";
                        break;
                }

            }

            ViewBag.ParentId = cat.ParentId;
            return View(cat);
        }
        #endregion

        #region List Of News Categories

        public async Task<IActionResult> ListOfSubCategories(FilterNewsCategoryViewModel filter)
        {
            if (filter.ParentId == null) return NotFound();

            var MainCat = await _newsService.GetNewsCategoryById(filter.ParentId.Value);

            if (MainCat == null) return NotFound();

            ViewBag.ParentTitle = MainCat.Title;

            return View(await _newsService.FilterNewsCategoryViewModel(filter));
        }

        #endregion

        #region Edit News Sub Category

        [HttpGet]
        public async Task<IActionResult> EditSubNewsCategory(ulong Id)
        {
            var cat = await _newsService.GetNewsCategoryById((ulong)Id);

            if (cat == null) return NotFound();

            var model = await _newsService.FillEditNewsCategoryViewModel(cat);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSubNewsCategory(EditNewsCategoryViewModel cat)
        {
            if (ModelState.IsValid)
            {
                var category = await _newsService.GetNewsCategoryById((ulong)cat.NewsCategoryId);
                var MainCategory = await _newsService.GetNewsCategoryById((ulong)cat.ParentId);

                if (category == null) return NotFound();

                if (MainCategory == null) return NotFound();

                var result = await _newsService.EditNewsCategoryResult(cat, category);

                switch (result)
                {
                    case EditNewsCategoryResult.success:
                        TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                        return RedirectToAction("ListOfSubCategories", "NewsCategory", new { ParentId = cat.ParentId });

                    case EditNewsCategoryResult.Fiald:
                        TempData[ErrorMessage] = "درج مقاله با مشکل مواجه شده است ";
                        break;

                    case EditNewsCategoryResult.CategoryIsExist:
                        TempData[ErrorMessage] = "عنوان انتخاب شده تکراری است  ";
                        break;
                }
            }

            return View(cat);
        }

        #endregion
    }
}
