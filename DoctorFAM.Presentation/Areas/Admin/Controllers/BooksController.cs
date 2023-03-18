using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Article.Admin;

using DoctorFAM.Domain.ViewModels.Admin.Books;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class BooksController : AdminBaseController
    {
        #region Constructor

        private readonly IBookService _BookService;
        private readonly IUserService _userService;

        public BooksController(IBookService BookService, IUserService userService)
        {
            _BookService = BookService;
            _userService = userService;
        }

        #endregion

        #region List OF Books

        [HttpGet]
        public async Task<IActionResult> Index(FilterBookAdminSideViewModel filter)
        {
            var result = await _BookService.FilterBookAdminSideViewModel(filter);

            return View(result);
        }

        #endregion

        #region Create Books

        [HttpGet]
        public async Task<IActionResult> CreateBook()
        {
            #region Categories

            ViewData["MianCategory"] = await _BookService.GetAllMainCategories();

            #endregion

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBook(CreateBookAdminViewModel model,IFormFile Image,  IFormFile BookFile )
        {
            #region Model State Validation 

            if (!ModelState.IsValid)
            {
                #region Categories

                ViewData["MianCategory"] = await _BookService.GetAllMainCategories();
                ViewData["SubCategoryCategory"] = await _BookService.GetCategoriesChildrent(model.MainCategory);

                #endregion

                return View(model);
            }

            #endregion

            #region Create Book 

            var result = await _BookService.CreateBookFromAdminPanel(model, Image, BookFile);

            switch (result)
            {
                case CreateBookFromAdminPanelResponse.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                    return RedirectToAction("Index", "Books");

                case CreateBookFromAdminPanelResponse.Faild:
                    TempData[ErrorMessage] = "درج کتاب با مشکل مواجه شده است ";
                    break;

                case CreateBookFromAdminPanelResponse.ImageNotUploaded:
                    TempData[ErrorMessage] = "کتاب باید دارای تصویر باشد  ";
                    break;

                case CreateBookFromAdminPanelResponse.WriterNotFound:
                    TempData[ErrorMessage] = "نویسنده ی کتاب وارد نشده است  ";
                    break;

                case CreateBookFromAdminPanelResponse.TitleNotFound:
                    TempData[ErrorMessage] = "لطفا عنوان کامل کتاب را وارد کنید  ";
                    break;

                case CreateBookFromAdminPanelResponse.ImageNotFound:
                    TempData[ErrorMessage] = "لطفا تصویر کتاب را انتخاب کنید  ";
                    break;
            }

            #endregion

            #region Categories

            ViewData["MianCategory"] = await _BookService.GetAllMainCategories();
            ViewData["SubCategoryCategory"] = await _BookService.GetCategoriesChildrent(model.MainCategory);

            #endregion

            return View(model);
        }

        #endregion

        #region Edit News

        [HttpGet]
        public async Task<IActionResult> EditBook(ulong Id)
        {
            var Book = await _BookService.GetBookByIdAsync(Id);

            if (Book == null)
            {
                TempData[ErrorMessage] = "کتاب مورد نظر یافت نشده است   ";
                return RedirectToAction("Index", "Book", new { Areas = "Admin" });
            }

            var model = await _BookService.FillEditBookAdminSideViewModel(Book);

            ViewData["MianCategory"] = await _BookService.GetAllMainCategories();
            ViewData["SubCategoryCategory"] = await _BookService.GetCategoriesChildrent(model.MainCategory);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBook(EditBookAdminSideViewModel model, IFormFile? Image, IFormFile? BookFile)
        {
            var result = await _BookService.EditBookFromAdminPanel(model, Image, BookFile);

            switch (result)
            {
                case EditBookFromAdminPanelResponse.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                    return RedirectToAction("Index", "News");

                case EditBookFromAdminPanelResponse.Faild:
                    TempData[ErrorMessage] = "درج کتاب با مشکل مواجه شده است ";
                    break;

                case EditBookFromAdminPanelResponse.ImageNotUploaded:
                    TempData[ErrorMessage] = "کتاب باید دارای تصویر باشد  ";
                    break;

                case EditBookFromAdminPanelResponse.WriterNotFound:
                    TempData[ErrorMessage] = "نویسنده ی کتاب یافت نشده است  ";
                    break;

                case EditBookFromAdminPanelResponse.TitleNotFound:
                    TempData[ErrorMessage] = "لطفا عنوان کامل را وارد کنید  ";
                    break;

                case EditBookFromAdminPanelResponse.MainCategoryNotFound:
                    TempData[ErrorMessage] = "لطفا گروه کتاب خود را انتخاب کنید  ";
                    break;

                case EditBookFromAdminPanelResponse.ImageNotFound:
                    TempData[ErrorMessage] = "لطفا تصویر کتاب خود را انتخاب کنید  ";
                    break;

                case EditBookFromAdminPanelResponse.BookFileNotFound:
                    TempData[ErrorMessage] = "کتاب مورد نظر یافت نشده است   ";
                    break;
            }

            ViewData["MianCategory"] = await _BookService.GetAllMainCategories();
            ViewData["SubCategoryCategory"] = await _BookService.GetCategoriesChildrent(model.MainCategory);

            return View(model);
        }

        #endregion

        #region Delete News

        [PermissionChecker("DeleteBook")]
        public async Task<IActionResult> DeleteBook(ulong Id)
        {
            var result = await _BookService.DeleteBookFromAdminPanel(Id);

            if (result)
            {
                return JsonResponseStatus.Success();
            }

            return JsonResponseStatus.Error();
        }

        #endregion
    }
}
