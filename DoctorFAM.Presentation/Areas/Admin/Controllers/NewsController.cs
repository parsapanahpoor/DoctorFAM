using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;

using DoctorFAM.Domain.ViewModels.Admin.News;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class NewsController : AdminBaseController
    {
        #region Constructor

        private readonly INewsService _NewsService;
        private readonly IUserService _userService;

        public NewsController(INewsService NewsService, IUserService userService)
        {
            _NewsService = NewsService;
            _userService = userService;
        }

        #endregion

        #region List OF News

        [HttpGet]
        public async Task<IActionResult> Index(FilterNewsAdminSideViewModel filter)
        {
            var result = await _NewsService.FilterNewsAdminSideViewModel(filter);

            return View(result);
        }

        #endregion

        #region Create News

        [HttpGet]
        public async Task<IActionResult> CreateNews()
        {
            ViewData["MianCategory"] = await _NewsService.GetAllMainCategories();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNews(CreateNewsAdminViewModel model, IFormFile NewsImage)
        {
            var result = await _NewsService.CreateNewsFromAdminPanel(model, NewsImage);

            switch (result)
            {
                case CreateNewsFromAdminPanelResponse.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                    return RedirectToAction("Index", "News");

                case CreateNewsFromAdminPanelResponse.Faild:
                    TempData[ErrorMessage] = "درج مقاله با مشکل مواجه شده است ";
                    break;

                case CreateNewsFromAdminPanelResponse.ImageNotUploaded:
                    TempData[ErrorMessage] = "مقاله باید دارای تصویر باشد  ";
                    break;

                case CreateNewsFromAdminPanelResponse.AuthorNotFound:
                    TempData[ErrorMessage] = "نویسنده ی مقاله یافت نشده است  ";
                    break;

                case CreateNewsFromAdminPanelResponse.DescriptionNotFound:
                    TempData[ErrorMessage] = "لطفا توضیحات کامل را وراد کنید  ";
                    break;

                case CreateNewsFromAdminPanelResponse.MainCategoryNotFound:
                    TempData[ErrorMessage] = "لطفا گروه مقاله ی خود را انتخاب کنید  ";
                    break;

                case CreateNewsFromAdminPanelResponse.ImageNotFound:
                    TempData[ErrorMessage] = "لطفا تصویر مقاله ی خود را انتخاب کنید  ";
                    break;
            }

            ViewData["MianCategory"] = await _NewsService.GetAllMainCategories();
            ViewData["SubCategoryCategory"] = await _NewsService.GetCategoriesChildrent(model.MainCategory);

            return View(model);
        }

        #endregion

        #region Edit News

        [HttpGet]
        public async Task<IActionResult> EditNews(ulong Id)
        {
            var News = await _NewsService.GetNewsByIdAsync(Id);

            if (News == null)
            {
                TempData[ErrorMessage] = "مقاله ای یافت نشده است   ";
                return RedirectToAction("Index", "News", new { Areas = "Admin" });
            }

            var model = await _NewsService.FillEditNewsAdminSideViewModel(News);

            ViewData["MianCategory"] = await _NewsService.GetAllMainCategories();
            ViewData["SubCategoryCategory"] = await _NewsService.GetCategoriesChildrent(model.MainCategory);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNews(EditNewsAdminSideViewModel model, IFormFile? NewsImage)
        {
            var result = await _NewsService.EditNewsFromAdminPanel(model, NewsImage);

            switch (result)
            {
                case EditNewsFromAdminPanelResponse.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                    return RedirectToAction("Index", "News");

                case EditNewsFromAdminPanelResponse.Faild:
                    TempData[ErrorMessage] = "درج مقاله با مشکل مواجه شده است ";
                    break;

                case EditNewsFromAdminPanelResponse.ImageNotUploaded:
                    TempData[ErrorMessage] = "مقاله باید دارای تصویر باشد  ";
                    break;

                case EditNewsFromAdminPanelResponse.AuthorNotFound:
                    TempData[ErrorMessage] = "نویسنده ی مقاله یافت نشده است  ";
                    break;

                case EditNewsFromAdminPanelResponse.DescriptionNotFound:
                    TempData[ErrorMessage] = "لطفا توضیحات کامل را وراد کنید  ";
                    break;

                case EditNewsFromAdminPanelResponse.MainCategoryNotFound:
                    TempData[ErrorMessage] = "لطفا گروه مقاله ی خود را انتخاب کنید  ";
                    break;

                case EditNewsFromAdminPanelResponse.ImageNotFound:
                    TempData[ErrorMessage] = "لطفا تصویر مقاله ی خود را انتخاب کنید  ";
                    break;

                case EditNewsFromAdminPanelResponse.NewsNotFound:
                    TempData[ErrorMessage] = "مقاله ای یافت نشده است   ";
                    break;
            }

            ViewData["MianCategory"] = await _NewsService.GetAllMainCategories();
            ViewData["SubCategoryCategory"] = await _NewsService.GetCategoriesChildrent(model.MainCategory);

            return View(model);
        }

        #endregion

        #region Delete News

        [PermissionChecker("DeleteNews")]
        public async Task<IActionResult> DeleteNews(ulong Id)
        {
            var result = await _NewsService.DeleteNewsFromAdminPanel(Id);

            if (result)
            {
                return JsonResponseStatus.Success();
            }

            return JsonResponseStatus.Error();
        }

        #endregion
    }
}
