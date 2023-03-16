using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Books;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class BookCategoryController : AdminBaseController
    {
        #region Constructor

        private readonly IBookService _BookService;

        public BookCategoryController(IBookService BookService)
        {
            _BookService = BookService;
        }

        #endregion

        #region List Of Book Categories

        public async Task<IActionResult> Index(FilterBookCategoryViewModel filter)
        {
            return View(await _BookService.FilterBookCategoryViewModel(filter));
        }

        #endregion

        #region Create Main Book Category

        [HttpGet]
        public async Task<IActionResult> CreateMainBookCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMainBookCategory(CreateBookCategoryViewModel cat)
        {
            if (ModelState.IsValid)
            {
                var result = await _BookService.AddMainBookCategory(cat);

                switch (result)
                {
                    case CreateBookCategoryResult.success:
                        TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                        return RedirectToAction("Index", "BookCategory");

                    case CreateBookCategoryResult.Fiald:
                        TempData[ErrorMessage] = "درج کتاب با مشکل مواجه شده است ";
                        break;

                    case CreateBookCategoryResult.CategoryIsExist:
                        TempData[ErrorMessage] = "عنوان انتخاب شده تکراری است  ";
                        break;
                }
            }
            return View(cat);
        }

        #endregion

        #region Edit Book Main Category

        [HttpGet]
        public async Task<IActionResult> EditBookCategory(ulong Id)
        {
            var cat = await _BookService.GetBookCategoryById((ulong)Id);

            if (cat == null) return NotFound();

            var model = await _BookService.FillEditBookCategoryViewModel(cat);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBookCategory(EditBookCategoryViewModel cat)
        {
            if (ModelState.IsValid)
            {
                var category = await _BookService.GetBookCategoryById((ulong)cat.BookCategoryId);

                if (category == null) return NotFound();

                var result = await _BookService.EditBookCategoryResult(cat, category);

                switch (result)
                {
                    case EditBookCategoryResult.success:
                        TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                        return RedirectToAction("Index", "BookCategory");

                    case EditBookCategoryResult.Fiald:
                        TempData[ErrorMessage] = "درج کتاب با مشکل مواجه شده است ";
                        break;

                    case EditBookCategoryResult.CategoryIsExist:
                        TempData[ErrorMessage] = "عنوان انتخاب شده تکراری است  ";
                        break;
                }
            }

            return View(cat);
        }
        #endregion

        #region Delete Book Category

        public async Task<IActionResult> DeleteBookCategory(ulong Id)
        {
            var category = await _BookService.GetBookCategoryById((ulong)Id);

            if (category == null) return JsonResponseStatus.Error();

            await _BookService.DeleteBookCategory(category);

            return JsonResponseStatus.Success();
        }

        #endregion

        #region Create Sub Book Category

        [HttpGet]
        public async Task<IActionResult> CreateSubCategory(ulong ParentId)
        {
            var MainCat = await _BookService.GetBookCategoryById((ulong)ParentId);

            if (MainCat == null) return NotFound();

            ViewBag.ParentId = ParentId;
            ViewBag.ParentTitle = MainCat.Title;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubCategory(CreateBookCategoryViewModel cat)
        {
            if (ModelState.IsValid)
            {
                var MainCat = await _BookService.GetBookCategoryById(cat.ParentId.Value);

                if (MainCat == null)
                {
                    ViewBag.ParentId = cat.ParentId;
                    return NotFound();
                }

                var result = await _BookService.AddMainBookCategory(cat);

                switch (result)
                {
                    case CreateBookCategoryResult.success:
                        TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                        return RedirectToAction("ListOfSubCategories", "BookCategory", new { ParentId = cat.ParentId });

                    case CreateBookCategoryResult.Fiald:
                        TempData[ErrorMessage] = "درج کتاب با مشکل مواجه شده است ";
                        break;

                    case CreateBookCategoryResult.CategoryIsExist:
                        TempData[ErrorMessage] = "عنوان انتخاب شده تکراری است  ";
                        break;
                }

            }

            ViewBag.ParentId = cat.ParentId;
            return View(cat);
        }
        #endregion

        #region List Of Book Categories

        public async Task<IActionResult> ListOfSubCategories(FilterBookCategoryViewModel filter)
        {
            if (filter.ParentId == null) return NotFound();

            var MainCat = await _BookService.GetBookCategoryById(filter.ParentId.Value);

            if (MainCat == null) return NotFound();

            ViewBag.ParentTitle = MainCat.Title;

            return View(await _BookService.FilterBookCategoryViewModel(filter));
        }

        #endregion

        #region Edit Book Sub Category

        [HttpGet]
        public async Task<IActionResult> EditSubBookCategory(ulong Id)
        {
            var cat = await _BookService.GetBookCategoryById((ulong)Id);

            if (cat == null) return NotFound();

            var model = await _BookService.FillEditBookCategoryViewModel(cat);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSubBookCategory(EditBookCategoryViewModel cat)
        {
            if (ModelState.IsValid)
            {
                var category = await _BookService.GetBookCategoryById((ulong)cat.BookCategoryId);
                var MainCategory = await _BookService.GetBookCategoryById((ulong)cat.ParentId);

                if (category == null) return NotFound();

                if (MainCategory == null) return NotFound();

                var result = await _BookService.EditBookCategoryResult(cat, category);

                switch (result)
                {
                    case EditBookCategoryResult.success:
                        TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                        return RedirectToAction("ListOfSubCategories", "BookCategory", new { ParentId = cat.ParentId });

                    case EditBookCategoryResult.Fiald:
                        TempData[ErrorMessage] = "درج کتاب با مشکل مواجه شده است ";
                        break;

                    case EditBookCategoryResult.CategoryIsExist:
                        TempData[ErrorMessage] = "عنوان انتخاب شده تکراری است  ";
                        break;
                }
            }

            return View(cat);
        }

        #endregion
    }
}
