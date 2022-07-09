using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Product;
using DoctorFAM.Domain.ViewModels.MarketPanel.Product;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        #region Ctor

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region Products List 

        public async Task<IActionResult> FilterProducts(FilterProductAdminSideViewModel filter)
        {
            return View(await _productService.FilterProductMarketSide(filter));
        }

        #endregion

        #region Edit Product

        [HttpGet]
        public async Task<IActionResult> EditProduct(ulong id)
        {
            #region Get Product

            var model = await _productService.FillEditProductInAdminViewModel(id);
            if (model == null) return NotFound();

            #endregion

            #region Get Categories

            ViewData["FirstCategory"] = await _productService.GetAllMainCategories();
            ViewData["SecondeCategory"] = await _productService.GetCategoriesByParentId(model.FirstCategory);
            ViewData["ThirdCategory"] = await _productService.GetCategoriesByParentId(model.SecondeCategory);
            ViewData["FourthCategory"] = await _productService.GetCategoriesByParentId(model.ThirdCategory);

            #endregion

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(EditProductAdminViewModel model , IFormFile? ProductImage)
        {
            #region Get Product

            var product = await _productService.FillEditProductInAdminViewModel(model.ProductId);
            if (product == null) return NotFound();

            #endregion

            #region Get Categories

            ViewData["FirstCategory"] = await _productService.GetAllMainCategories();
            ViewData["SecondeCategory"] = await _productService.GetCategoriesByParentId(model.FirstCategory);
            ViewData["ThirdCategory"] = await _productService.GetCategoriesByParentId(model.SecondeCategory);
            ViewData["FourthCategory"] = await _productService.GetCategoriesByParentId(model.ThirdCategory);

            #endregion

            #region Model State Validation

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            #region Edit Product 

            var result = await _productService.EditProductFromAdminPanel(model, ProductImage);

            switch (result)
            {
                case EditProductSellerPanelResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است .";
                    return RedirectToAction(nameof(FilterProducts));

                case EditProductSellerPanelResult.ImageName:
                    TempData[ErrorMessage] = "تصویر محصول باید وارد شود .";
                    break;

                case EditProductSellerPanelResult.LongDescription:
                    TempData[ErrorMessage] = "توضیح کامل محصول باید وارد شود .";
                    break;

                case EditProductSellerPanelResult.UserNotFound:
                    TempData[ErrorMessage] = "کابر موردئ نظر یافت نشده است .";
                    break;

                case EditProductSellerPanelResult.Categories:
                    TempData[ErrorMessage] = "دسته بندی های محصول یافت نشده است .";
                    break;

                case EditProductSellerPanelResult.Faild:
                    TempData[ErrorMessage] = "عملیات با موفقیت شکست مواجه شده است . .";
                    break;

                case EditProductSellerPanelResult.PackedNote:
                    TempData[ErrorMessage] = "شما فروش دسته ای را انتخال کرده اید و باید توضیح آن را وارد کنید ";
                    break;
            };

            #endregion

            return View(model);
        }

        #endregion

        #region Delete Product

        public async Task<IActionResult> DeleteProduct(ulong id)
        {
            var result = await _productService.DeleteProduct(id);

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "غملیات با موفقیت به پایان رسیده است .");
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات با شکست مواجه شده است .");
        }

        #endregion

        #region Product Galleries

        [HttpGet]
        public async Task<ActionResult> ProductGalleries(ulong productId)
        {
            #region Fill View Model

            var model = await _productService.FillProductGalleryViewModel(productId);

            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductGalleries(ProductGalleryViewModel model)
        {
            #region Fill View Model

            var product = await _productService.FillProductGalleryViewModel(model.ProductId);

            if (product == null) return NotFound();

            #endregion

            #region Add Product Gallery

            var result = await _productService.AddProductGallery(model);

            switch (result)
            {
                case AddProductGalleryResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است .";
                    return RedirectToAction(nameof(ProductGalleries) , new { productId = model.ProductId });

                case AddProductGalleryResult.TitleNotFound:
                    TempData[ErrorMessage] = "عنوان تصویر یافت نشده است .";
                    break;

                case AddProductGalleryResult.ImageNotFound:
                    TempData[ErrorMessage] = "تصویر یافت نشده است .";
                    break;

                case AddProductGalleryResult.ProductNotFound:
                    TempData[ErrorMessage] = "محصول یافت نشده است .";
                    break;
            }

            #endregion

            return View(product);
        }

        #endregion

        #region Delete Product Gallery

        public async Task<IActionResult> DeleteProductGallery(ulong productGalleryId)
        {
            var result = await _productService.DeleteProductGallery(productGalleryId);

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "غملیات با موفقیت به پایان رسیده است .");
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات با شکست مواجه شده است .");
        }

        #endregion

        #region Product Features

        [HttpGet]
        public async Task<ActionResult> ProductFeatures(ulong productId)
        {
            #region Fill View Model

            var model = await _productService.FillProductFeatureViewModel(productId);

            if (model == null) return NotFound();

            #endregion

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductFeatures(ProductFeatureViewModel model)
        {
            #region Fill View Model

            var product = await _productService.FillProductFeatureViewModel(model.ProductID);

            if (product == null) return NotFound();

            #endregion

            #region Add Product Gallery

            var result = await _productService.AddProductFeature(model);

            switch (result)
            {
                case AddProductFeatureResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است .";
                    return RedirectToAction(nameof(ProductFeatures), new { productId = model.ProductID });

                case AddProductFeatureResult.TitleNotFound:
                    TempData[ErrorMessage] = "عنوان یافت نشده است .";
                    break;

                case AddProductFeatureResult.ValueNotFound:
                    TempData[ErrorMessage] = "مقدار یافت نشده است .";
                    break;

                case AddProductFeatureResult.ProductNotFound:
                    TempData[ErrorMessage] = "محصول یافت نشده است .";
                    break;
            }

            #endregion

            return View(product);
        }

        #endregion

        #region Delete Product Feature

        public async Task<IActionResult> DeleteProductFeature(ulong productFeatureId)
        {
            var result = await _productService.DeleteProductFeature(productFeatureId);

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "غملیات با موفقیت به پایان رسیده است .");
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات با شکست مواجه شده است .");
        }

        #endregion

    }
}
