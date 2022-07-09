using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        #region Ctor

        private readonly IProductService _productService;

        private readonly IDashboardsService _boardsService;

        public HomeController(IProductService productService , IDashboardsService boardsService)
        {
            _productService = productService;
            _boardsService = boardsService;
        }

        #endregion

        #region Admin Dashboard

        public async Task<IActionResult> Index()
        {
            return View(await _boardsService.FillAdminDashboardViewModel());
        }

        #endregion

        #region Load Article Sub Categories

        public async Task<IActionResult> LoadSubCategories(ulong MainCategoryId)
        {
            var result = await _productService.GetSubProductCategories(MainCategoryId);

            return JsonResponseStatus.Success(result);
        }

        #endregion
    }
}
