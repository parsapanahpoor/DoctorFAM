using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.MarketCategory;
using DoctorFAM.Domain.Entities.Product;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Product;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.MarketPanel.Product;
using DoctorFAM.Domain.ViewModels.Site.Shop.Cosmetic;
using DoctorFAM.Domain.ViewModels.Site.Shop.Medical_Equipment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public ProductRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Admin

        public async Task<FilterProductAdminSideViewModel> FilterProductAdminSide(FilterProductAdminSideViewModel filter)
        {
            var query = _context.Products
                .Where(s => !s.IsDelete)
                .Include(p => p.Users)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region State

            switch (filter.ProductsState)
            {
                case Domain.Enums.Products.ProductsStateForFilterInPanel.All:
                    break;

                case Domain.Enums.Products.ProductsStateForFilterInPanel.WaitingForConfirm:
                    query = query.Where(s => s.ProductsState == Domain.Enums.Products.ProductsState.WaitingForConfirm);
                    break;

                case Domain.Enums.Products.ProductsStateForFilterInPanel.Accept:
                    query = query.Where(s => s.ProductsState == Domain.Enums.Products.ProductsState.Accept);
                    break;

                case Domain.Enums.Products.ProductsStateForFilterInPanel.Reject:
                    query = query.Where(s => s.ProductsState == Domain.Enums.Products.ProductsState.Reject);
                    break;
            }

            switch (filter.ProductSaleType)
            {
                case Domain.Enums.Products.ProductSaleTypeForFilterInPanel.All:
                    break;

                case Domain.Enums.Products.ProductSaleTypeForFilterInPanel.Single:
                    query = query.Where(s => s.ProductSaleType == Domain.Enums.Products.ProductSaleType.Single);
                    break;

                case Domain.Enums.Products.ProductSaleTypeForFilterInPanel.Packed:
                    query = query.Where(s => s.ProductSaleType == Domain.Enums.Products.ProductSaleType.Packed);
                    break;
            }

            switch (filter.FilterProductOrder)
            {
                case Domain.Enums.Products.FilterProductOrder.CreateDate_Des:
                    break;

                case Domain.Enums.Products.FilterProductOrder.CreateDate_Asc:
                    query = query.OrderBy(s => s.CreateDate);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(s => EF.Functions.Like(s.ProductTitle, $"%{filter.Title}%"));
            }

            if (filter.Price != null && filter.Price != 0)
            {
                query = query.Where(p => p.Price == filter.Price);
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        #endregion

        #region Market Panel Side

        public async Task<FilterProductMarketSideViewModel> FilterProductMarketSide(FilterProductMarketSideViewModel filter)
        {
            var query = _context.Products
                .Where(s => !s.IsDelete && s.UserId == filter.UserId)
                .Include(p => p.Users)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region State

            switch (filter.ProductsState)
            {
                case Domain.Enums.Products.ProductsStateForFilterInPanel.All:
                    break;

                case Domain.Enums.Products.ProductsStateForFilterInPanel.WaitingForConfirm:
                    query = query.Where(s => s.ProductsState == Domain.Enums.Products.ProductsState.WaitingForConfirm);
                    break;

                case Domain.Enums.Products.ProductsStateForFilterInPanel.Accept:
                    query = query.Where(s => s.ProductsState == Domain.Enums.Products.ProductsState.Accept);
                    break;

                case Domain.Enums.Products.ProductsStateForFilterInPanel.Reject:
                    query = query.Where(s => s.ProductsState == Domain.Enums.Products.ProductsState.Reject);
                    break;
            }

            switch (filter.ProductSaleType)
            {
                case Domain.Enums.Products.ProductSaleTypeForFilterInPanel.All:
                    break;

                case Domain.Enums.Products.ProductSaleTypeForFilterInPanel.Single:
                    query = query.Where(s => s.ProductSaleType == Domain.Enums.Products.ProductSaleType.Single);
                    break;

                case Domain.Enums.Products.ProductSaleTypeForFilterInPanel.Packed:
                    query = query.Where(s => s.ProductSaleType == Domain.Enums.Products.ProductSaleType.Packed);
                    break;
            }

            switch (filter.FilterProductOrder)
            {
                case Domain.Enums.Products.FilterProductOrder.CreateDate_Des:
                    break;

                case Domain.Enums.Products.FilterProductOrder.CreateDate_Asc:
                    query = query.OrderBy(s => s.CreateDate);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(s => EF.Functions.Like(s.ProductTitle, $"%{filter.Title}%"));
            }

            if (filter.Price != null && filter.Price != 0)
            {
                query = query.Where(p => p.Price == filter.Price);
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        public async Task<List<SelectListViewModel>> GetAllFirstProductCategories()
        {
            return await _context.CategoryInfos.Include(p => p.Category).Where(s => s.Category.ParentId == null && !s.Category.IsDelete)
               .Select(s => new SelectListViewModel
               {
                   Id = s.Category.Id,
                   Title = s.Title
               }).ToListAsync();
        }

        public async Task<List<SelectListViewModel>> GetSubProductCategories(ulong mainCategoryId)
        {
            return await _context.CategoryInfos.Include(p => p.Category).Where(s => s.Category.ParentId.HasValue && s.Category.ParentId.Value == mainCategoryId && !s.Category.IsDelete)
               .Select(s => new SelectListViewModel
               {
                   Id = s.Category.Id,
                   Title = s.Title
               }).ToListAsync();
        }

        public async Task CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task EditProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task AddProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task AddProductTags(ProductsTags productsTags)
        {
            await _context.ProductsTags.AddAsync(productsTags);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task AddProductCategories(ProductSelectedCategory productSelectedCategory)
        {
            await _context.ProductSelectedCategories.AddAsync(productSelectedCategory);
        }

        public async Task<Product?> GetProductById(ulong productId)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<List<ProductsTags>?> GetProductTagsByProductId(ulong productId)
        {
            return await _context.ProductsTags.Where(p => !p.IsDelete && p.ProductId == productId).ToListAsync();
        }

        public async Task<ulong> GetPRoductFirstCategoryByProductId(ulong productId)
        {
            return await _context.ProductSelectedCategories
                        .Include(p => p.ProductCategory)
                        .Where(p => p.ProductID == productId && !p.IsDelete && p.ProductCategory.ParentId == null)
                        .Select(p => p.ProductCategory.Id).FirstOrDefaultAsync();
        }

        public async Task<ulong> GetProductCategoryByProductIdAndParentId(ulong productId , ulong? parentId)
        {
            return await _context.ProductSelectedCategories
                        .Include(p => p.ProductCategory)
                        .Where(p => p.ProductID == productId && !p.IsDelete && p.ProductCategory.ParentId == parentId)
                        .Select(p => p.ProductCategoryId).FirstOrDefaultAsync();
        }

        public async Task<List<SelectListViewModel>> GetCategoriesByParentId(ulong? parentId)
        {
            return await _context.CategoryInfos.Include(p => p.Category).Where(s => !s.Category.IsDelete && s.Category.ParentId == parentId)
                .Select(s => new SelectListViewModel
                {
                    Id = s.Category.Id,
                    Title = s.Title
                }).ToListAsync();
        }

        public async Task<List<SelectListViewModel>> GetAllMainCategories()
        {
            return await _context.CategoryInfos.Include(p => p.Category).Where(s => s.Category.ParentId == null && !s.Category.IsDelete)
                .Select(s => new SelectListViewModel
                {
                    Id = s.Category.Id,
                    Title = s.Title
                }).ToListAsync();
        }

        public async Task<List<ProductsTags>> GetProdcutTagsByProductId(ulong Id)
        {
            return await _context.ProductsTags.Where(p => p.ProductId == Id && !p.IsDelete).ToListAsync();
        }

        public async Task DeleteProductTags(List<ProductsTags> productsTags)
        {
            _context.ProductsTags.RemoveRange(productsTags);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllPRoductCategoriesById(ulong productId)
        {
            var categories = await _context.ProductSelectedCategories.Where(p => !p.IsDelete && p.ProductID == productId).ToListAsync();

            _context.ProductSelectedCategories.RemoveRange(categories);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductGallery>?> GetProductGalleryByProductId(ulong productId)
        {
            return await _context.ProductGalleries.Where(p => !p.IsDelete && p.ProductID == productId).ToListAsync();
        }

        public async Task<List<ProductFeature>?> GetProductFeatureByProductId(ulong productId)
        {
            return await _context.ProductFeatures.Where(p => !p.IsDelete && p.ProductID == productId).ToListAsync();
        }

        public async Task AddProductGallery(ProductGallery productGallery)
        {
            await _context.ProductGalleries.AddAsync(productGallery);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductGallery?> GetProductGalleryById(ulong productGalleryId)
        {
            return await _context.ProductGalleries.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == productGalleryId);
        }

        public async Task DeleteProductGallery(ProductGallery productGallery)
        {
            _context.ProductGalleries.Update(productGallery);
            await _context.SaveChangesAsync();
        }

        public async Task AddProductFeature(ProductFeature productFeature)
        {
            await _context.ProductFeatures.AddAsync(productFeature);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductFeature(ProductFeature productFeature)
        {
            _context.ProductFeatures.Update(productFeature);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductFeature?> GetProductFeatureById(ulong productFeatureId)
        {
            return await _context.ProductFeatures.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == productFeatureId);
        }

        #endregion

        #region Site Side

        public async Task<FilterMedicalEquipmentViewModel> FilterMedicalEquipment(FilterMedicalEquipmentViewModel filter)
        {
            var query = _context.ProductSelectedCategories.Include(p => p.Product)
                .Where(p => !p.Product.IsDelete && !p.IsDelete && p.ProductCategoryId == 2 && p.Product.ProductsState == Domain.Enums.Products.ProductsState.Accept)
                .Select(p => p.Product)
                .OrderByDescending(p=> p.CreateDate)
                .AsQueryable();

            #region Filter


            #endregion

            await filter.Paging(query);

            return filter;
        }

        public async Task<FilterCosmeticViewModel> FilterCosmetic(FilterCosmeticViewModel filter)
        {
            var query = _context.ProductSelectedCategories.Include(p => p.Product)
                .Where(p => !p.Product.IsDelete && !p.IsDelete && p.ProductCategoryId == 1 && p.Product.ProductsState == Domain.Enums.Products.ProductsState.Accept)
                .Select(p => p.Product)
                .OrderByDescending(p => p.CreateDate)
                .AsQueryable();

            #region Filter


            #endregion

            await filter.Paging(query);

            return filter;
        }


        #endregion
    }
}
