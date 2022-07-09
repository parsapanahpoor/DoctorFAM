using DoctorFAM.Domain.Entities.Product;
using DoctorFAM.Domain.ViewModels.Admin.Product;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.MarketPanel.Product;
using DoctorFAM.Domain.ViewModels.Site.Shop.Cosmetic;
using DoctorFAM.Domain.ViewModels.Site.Shop.Medical_Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IProductRepository
    {
        #region Admin

        Task<FilterProductAdminSideViewModel> FilterProductAdminSide(FilterProductAdminSideViewModel filter);

        #endregion

        #region Seller Panel

        Task<FilterProductMarketSideViewModel> FilterProductMarketSide(FilterProductMarketSideViewModel filter);

        Task<List<SelectListViewModel>> GetAllFirstProductCategories();

        Task<List<SelectListViewModel>> GetSubProductCategories(ulong mainCategoryId);

        Task CreateProduct(Product product);

        Task EditProduct(Product product);

        Task AddProduct(Product product);

        Task AddProductTags(ProductsTags productsTags);

        Task SaveChanges();

        Task AddProductCategories(ProductSelectedCategory productSelectedCategory);

        Task<Product?> GetProductById(ulong productId);

        Task<List<ProductsTags>?> GetProductTagsByProductId(ulong productId);

        Task<ulong> GetPRoductFirstCategoryByProductId(ulong productId);

        Task<ulong> GetProductCategoryByProductIdAndParentId(ulong productId, ulong? parentId);

        Task<List<SelectListViewModel>> GetCategoriesByParentId(ulong? parentId);

        Task<List<SelectListViewModel>> GetAllMainCategories();

        Task<List<ProductsTags>> GetProdcutTagsByProductId(ulong Id);

        Task DeleteProductTags(List<ProductsTags> productsTags);

        Task DeleteAllPRoductCategoriesById(ulong productId);

        Task<List<ProductGallery>?> GetProductGalleryByProductId(ulong productId);

        Task AddProductGallery(ProductGallery productGallery);

        Task<ProductGallery?> GetProductGalleryById(ulong productGalleryId);

        Task DeleteProductGallery(ProductGallery productGallery);

        Task<List<ProductFeature>?> GetProductFeatureByProductId(ulong productId);

        Task AddProductFeature(ProductFeature productFeature);

        Task DeleteProductFeature(ProductFeature productFeature);

        Task<ProductFeature?> GetProductFeatureById(ulong productFeatureId);

        #endregion

        #region Site Side 

        Task<FilterMedicalEquipmentViewModel> FilterMedicalEquipment(FilterMedicalEquipmentViewModel filter);

        Task<FilterCosmeticViewModel> FilterCosmetic(FilterCosmeticViewModel filter);

        #endregion
    }
}
