using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.UserPanel;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers;

public class HomeController : AdminBaseController
{
    #region Ctor

    private readonly IProductService _productService;
    private readonly IUserService _userService;
    private readonly IDashboardsService _boardsService;
    private readonly INewsService _newsService;
    private readonly IBookService _bookService;

    public HomeController(IProductService productService, IDashboardsService boardsService, IUserService userService
                            , INewsService newsService, IBookService bookService)
    {
        _productService = productService;
        _boardsService = boardsService;
        _userService = userService;
        _newsService = newsService;
        _bookService = bookService;
    }

    #endregion

    #region Admin Dashboard

    public async Task<IActionResult> Index()
    {
        return View(await _boardsService.FillAdminDashboardViewModel());
    }

    #endregion

    #region Load Products Sub Categories

    //public async Task<IActionResult> LoadSubCategories(ulong MainCategoryId)
    //{
    //    var result = await _productService.GetSubProductCategories(MainCategoryId);

    //    return JsonResponseStatus.Success(result);
    //}

    #endregion

    #region SearchUserModal

    public async Task<IActionResult> SearchUserModal(FilterUserViewModel filter, string baseName)
    {
        filter.TakeEntity = 5;

        var result = await _userService.FilterUsersInModal(filter);

        ViewBag.BaseName = baseName;

        return PartialView("_FilterUsersModalPartial", result);
    }

    #endregion

    #region Load News Sub Categories

    public async Task<IActionResult> LoadSubCategories(ulong MainCategoryId)
    {
        var result = await _newsService.GetCategoriesChildrent(MainCategoryId);

        return JsonResponseStatus.Success(result);
    }

    #endregion

    #region Load Books Sub Categories

    public async Task<IActionResult> LoadBooksSubCategories(ulong MainCategoryId)
    {
        var result = await _bookService.GetCategoriesChildrent(MainCategoryId);

        return JsonResponseStatus.Success(result);
    }

    #endregion
}
