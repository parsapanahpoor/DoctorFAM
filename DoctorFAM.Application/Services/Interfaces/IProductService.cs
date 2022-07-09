using DoctorFAM.Domain.ViewModels.Admin.Product;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.MarketPanel.Product;
using DoctorFAM.Domain.ViewModels.Site.Shop.Cosmetic;
using DoctorFAM.Domain.ViewModels.Site.Shop.Medical_Equipment;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IProductService
    {
        #region Admin 

        Task<FilterProductAdminSideViewModel> FilterProductMarketSide(FilterProductAdminSideViewModel filter);

        Task<EditProductAdminViewModel?> FillEditProductInAdminViewModel(ulong productId);

        Task<EditProductSellerPanelResult> EditProductFromAdminPanel(EditProductAdminViewModel model, IFormFile? productImage);

        #endregion

        #region Seller Panel

        Task<FilterProductMarketSideViewModel> FilterProductMarketSide(FilterProductMarketSideViewModel filter);

        Task<List<SelectListViewModel>> GetAllFirstProductCategories();

        Task<List<SelectListViewModel>> GetSubProductCategories(ulong mainCategoryId);

        Task<CreateProductSellerPanelResult> CreateProductFromSellerPanel(CreateProductsViewModel model, IFormFile ProductImage);

        Task<EditProductViewModel?> FillEditProductInSellerPanelViewModel(ulong productId, ulong userId);

        Task<List<SelectListViewModel>> GetCategoriesByParentId(ulong? parentId);

        Task<List<SelectListViewModel>> GetAllMainCategories();

        Task<EditProductSellerPanelResult> EditProductFromSellerPanel(EditProductViewModel model, IFormFile? productImage);

        Task<ProductGalleryViewModel?> FillProductGalleryViewModel(ulong productId);

        Task<AddProductGalleryResult> AddProductGallery(ProductGalleryViewModel productGallery);

        Task<bool> DeleteProductGallery(ulong productGalleryId);

        Task<bool> DeleteProduct(ulong productId);

        Task<ProductFeatureViewModel?> FillProductFeatureViewModel(ulong productId);

        Task<AddProductFeatureResult> AddProductFeature(ProductFeatureViewModel productFeature);

        Task<bool> DeleteProductFeature(ulong productFeatureId);

        #endregion

        #region Site Side 

        Task<FilterMedicalEquipmentViewModel> FilterMedicalEquipment(FilterMedicalEquipmentViewModel filter);

        Task<FilterCosmeticViewModel> FilterCosmetic(FilterCosmeticViewModel filter);

        #endregion
    }
}
