using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Market.Controllers
{
    public class HomeController : MarketBaseController
    {
        #region Ctor

        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region Index

        public IActionResult Index()
        {
            return View();
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
