using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Product;
using DoctorFAM.Domain.Interfaces;
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

namespace DoctorFAM.Application.Services.Implementation
{
    public class ProductService : IProductService
    {
        #region Ctor

        private readonly IProductRepository _productRepository;

        private readonly IMarketCategoryService _marketCategoryService;

        private readonly IUserService _userService;

        public ProductService(IProductRepository productRepository, IMarketCategoryService marketCategoryService, IUserService userService)
        {
            _productRepository = productRepository;
            _marketCategoryService = marketCategoryService;
            _userService = userService;
        }

        #endregion

        #region Admin 

        public async Task<FilterProductAdminSideViewModel> FilterProductMarketSide(FilterProductAdminSideViewModel filter)
        {
            return await _productRepository.FilterProductAdminSide(filter);
        }

        public async Task<EditProductAdminViewModel?> FillEditProductInAdminViewModel(ulong productId)
        {
            #region Get Product 

            var product = await _productRepository.GetProductById(productId);

            if (product == null) return null;

            #endregion

            #region Product Tags

            var productTags = await _productRepository.GetProductTagsByProductId(product.Id);

            if (productTags == null) return null;

            #endregion

            #region Product Categories

            var firstCategory = await _productRepository.GetProductCategoryByProductIdAndParentId(product.Id, null);
            if (firstCategory == null) return null;

            var secondeCategory = await _productRepository.GetProductCategoryByProductIdAndParentId(product.Id, firstCategory);
            if (secondeCategory == null) return null;

            var thirdCategory = await _productRepository.GetProductCategoryByProductIdAndParentId(product.Id, secondeCategory);
            if (thirdCategory == null) return null;

            var fourthCategory = await _productRepository.GetProductCategoryByProductIdAndParentId(product.Id, thirdCategory);
            if (fourthCategory == null) return null;

            #endregion

            #region Fill View Model

            EditProductAdminViewModel model = new EditProductAdminViewModel
            {
                ProductImage = product.ProductImageName,
                ProductTitle = product.ProductTitle,
                ShortDescription = product.ShortDescription,
                LongDescription = product.LongDescription,
                Price = Convert.ToInt32(product.Price),
                RejectedNote = product.RejectedNote,
                ProductSaleType = product.ProductSaleType,
                ProductsCount = product.ProductsCount,
                PackedProductsDescription = product.PackedProductsDescription,
                ProductTag = string.Join(",", productTags.Select(p => p.TagTitle).ToList()),
                FirstCategory = firstCategory,
                SecondeCategory = secondeCategory,
                ThirdCategory = thirdCategory,
                FourthCategory = fourthCategory,
                ProductId = productId,
                ProductsState = product.ProductsState,
            };

            #endregion

            return model;
        }

        public async Task<EditProductSellerPanelResult> EditProductFromAdminPanel(EditProductAdminViewModel model, IFormFile? productImage)
        {
            #region Model State Validation

            //Is Exist Firs Category By Category Id
            if (!await _marketCategoryService.IsExistMarketCategoryBycategoryId(model.FirstCategory))
            {
                return EditProductSellerPanelResult.Categories;
            }

            //Is Exist Seconde Category By Category Id
            if (!await _marketCategoryService.IsExistMarketCategoryBycategoryId(model.SecondeCategory))
            {
                return EditProductSellerPanelResult.Categories;
            }

            //Is Exist Third Category By Category Id
            if (!await _marketCategoryService.IsExistMarketCategoryBycategoryId(model.ThirdCategory))
            {
                return EditProductSellerPanelResult.Categories;
            }

            //Is Exist Fourth Category By Category Id
            if (!await _marketCategoryService.IsExistMarketCategoryBycategoryId(model.FourthCategory))
            {
                return EditProductSellerPanelResult.Categories;
            }

            if (string.IsNullOrEmpty(model.LongDescription))
            {
                return EditProductSellerPanelResult.LongDescription;
            }

            if (productImage != null && !productImage.IsImage())
            {
                return EditProductSellerPanelResult.ImageName;
            }

            if (model.ProductSaleType == Domain.Enums.Products.ProductSaleType.Packed && string.IsNullOrEmpty(model.PackedProductsDescription))
            {
                return EditProductSellerPanelResult.PackedNote;
            }

            #endregion

            #region Get Product 

            var product = await _productRepository.GetProductById(model.ProductId);

            if (product == null) return EditProductSellerPanelResult.prodcutNotFound;

            #endregion

            #region Update Fields

            product.ShortDescription = model.ShortDescription;
            product.LongDescription = model.LongDescription;
            product.ProductTitle = model.ProductTitle;
            product.PackedProductsDescription = model.PackedProductsDescription;
            product.Price = (decimal)model.Price;
            product.ProductsCount = model.ProductsCount;
            product.ProductSaleType = model.ProductSaleType;
            product.ProductsState = model.ProductsState;
            product.RejectedNote = model.RejectedNote;

            #endregion

            #region Image Name

            if (productImage != null)
            {
                var imageName = Guid.NewGuid() + Path.GetExtension(productImage.FileName);
                productImage.AddImageToServer(imageName, PathTools.ProductsPathServer, 400, 300, PathTools.ProductsPathThumbServer);

                if (!string.IsNullOrEmpty(product.ProductImageName))
                {
                    product.ProductImageName.DeleteImage(PathTools.ProductsPathServer, PathTools.ProductsPathThumbServer);
                }

                product.ProductImageName = imageName;
            }

            #endregion

            #region Update Product Method

            await _productRepository.EditProduct(product);

            #endregion

            #region Article Tags

            var productTags = await _productRepository.GetProdcutTagsByProductId(product.Id);

            if (productTags.Any())
            {
                await _productRepository.DeleteProductTags(productTags);
            }

            if (!string.IsNullOrEmpty(model.ProductTag))
            {
                var tags = model.ProductTag.Split(',').ToList();

                foreach (var item in tags)
                {
                    var tag = new ProductsTags
                    {
                        ProductId = product.Id,
                        TagTitle = item
                    };
                    await _productRepository.AddProductTags(tag);
                }
                await _productRepository.SaveChanges();
            }

            #endregion

            #region Add Product Categories

            #region Delete All Current Product Categories

            await _productRepository.DeleteAllPRoductCategoriesById(product.Id);

            #endregion

            #region Add New Product Categories

            if (model.FirstCategory != null && model.FirstCategory != 0)
            {
                ProductSelectedCategory productCategory = new ProductSelectedCategory
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    ProductCategoryId = model.FirstCategory,
                    ProductID = product.Id,
                };

                await _productRepository.AddProductCategories(productCategory);
            }

            if (model.SecondeCategory != null && model.SecondeCategory != 0)
            {
                ProductSelectedCategory productCategory = new ProductSelectedCategory
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    ProductCategoryId = model.SecondeCategory,
                    ProductID = product.Id,
                };

                await _productRepository.AddProductCategories(productCategory);
            }

            if (model.ThirdCategory != null && model.ThirdCategory != 0)
            {
                ProductSelectedCategory productCategory = new ProductSelectedCategory
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    ProductCategoryId = model.ThirdCategory,
                    ProductID = product.Id,
                };

                await _productRepository.AddProductCategories(productCategory);
            }

            if (model.FourthCategory != null && model.FourthCategory != 0)
            {
                ProductSelectedCategory productCategory = new ProductSelectedCategory
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    ProductCategoryId = model.FourthCategory,
                    ProductID = product.Id,
                };

                await _productRepository.AddProductCategories(productCategory);
            }

            await _productRepository.SaveChanges();

            #endregion

            #endregion

            return EditProductSellerPanelResult.Success;
        }


        #endregion

        #region Seller

        public async Task<FilterProductMarketSideViewModel> FilterProductMarketSide(FilterProductMarketSideViewModel filter)
        {
            return await _productRepository.FilterProductMarketSide(filter);
        }

        public async Task<List<SelectListViewModel>> GetAllFirstProductCategories()
        {
            return await _productRepository.GetAllFirstProductCategories();
        }

        public async Task<List<SelectListViewModel>> GetSubProductCategories(ulong mainCategoryId)
        {
            return await _productRepository.GetSubProductCategories(mainCategoryId);
        }

        public async Task<CreateProductSellerPanelResult> CreateProductFromSellerPanel(CreateProductsViewModel model, IFormFile ProductImage)
        {
            #region Model State Validation

            //Is Exist Firs Category By Category Id
            if (!await _marketCategoryService.IsExistMarketCategoryBycategoryId(model.FirstCategory))
            {
                return CreateProductSellerPanelResult.Categories;
            }

            //Is Exist Seconde Category By Category Id
            if (!await _marketCategoryService.IsExistMarketCategoryBycategoryId(model.SecondeCategory))
            {
                return CreateProductSellerPanelResult.Categories;
            }

            //Is Exist Third Category By Category Id
            if (!await _marketCategoryService.IsExistMarketCategoryBycategoryId(model.ThirdCategory))
            {
                return CreateProductSellerPanelResult.Categories;
            }

            //Is Exist Fourth Category By Category Id
            if (!await _marketCategoryService.IsExistMarketCategoryBycategoryId(model.FourthCategory))
            {
                return CreateProductSellerPanelResult.Categories;
            }

            if (model.UserId == null || !await _userService.IsExistUserById(model.UserId))
            {
                return CreateProductSellerPanelResult.UserNotFound;
            }

            if (string.IsNullOrEmpty(model.LongDescription))
            {
                return CreateProductSellerPanelResult.LongDescription;
            }

            if (ProductImage == null || !ProductImage.IsImage())
            {
                return CreateProductSellerPanelResult.ImageName;
            }

            if (model.ProductSaleType == Domain.Enums.Products.ProductSaleType.Packed && string.IsNullOrEmpty(model.PackedProductsDescription))
            {
                return CreateProductSellerPanelResult.PackedNote;
            }

            #endregion

            #region Add Product

            #region Fill Entity

            Product product = new Product
            {
                LongDescription = model.LongDescription,
                ProductTitle = model.ProductTitle,
                ShortDescription = model.ShortDescription,
                CreateDate = DateTime.Now,
                IsDelete = false,
                IsInOffer = false,
                OfferPercent = null,
                PackedProductsDescription = model.PackedProductsDescription,
                Price = model.Price,
                ProductSaleType = model.ProductSaleType,
                ProductsCount = model.ProductsCount,
                ProductsState = Domain.Enums.Products.ProductsState.WaitingForConfirm,
                RejectedNote = null,
                UserId = model.UserId,
            };

            #endregion

            #region Product Image

            var imageName = Guid.NewGuid() + Path.GetExtension(ProductImage.FileName);
            ProductImage.AddImageToServer(imageName, PathTools.ProductsPathServer, 400, 300, PathTools.ProductsPathThumbServer);
            product.ProductImageName = imageName;

            #endregion

            #region Add Product Method 

            await _productRepository.AddProduct(product);

            #endregion

            #endregion

            #region Product Tags

            if (!string.IsNullOrEmpty(model.ProductTag))
            {
                var tags = model.ProductTag.Split(',').ToList();

                foreach (var item in tags)
                {
                    var tag = new ProductsTags
                    {
                        ProductId = product.Id,
                        TagTitle = item
                    };
                    await _productRepository.AddProductTags(tag);
                }
                await _productRepository.SaveChanges();
            }

            #endregion

            #region Add Product Categories

            if (model.FirstCategory != null && model.FirstCategory != 0)
            {
                ProductSelectedCategory productCategory = new ProductSelectedCategory
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    ProductCategoryId = model.FirstCategory,
                    ProductID = product.Id,
                };

                await _productRepository.AddProductCategories(productCategory);
            }

            if (model.SecondeCategory != null && model.SecondeCategory != 0)
            {
                ProductSelectedCategory productCategory = new ProductSelectedCategory
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    ProductCategoryId = model.SecondeCategory,
                    ProductID = product.Id,
                };

                await _productRepository.AddProductCategories(productCategory);
            }

            if (model.ThirdCategory != null && model.ThirdCategory != 0)
            {
                ProductSelectedCategory productCategory = new ProductSelectedCategory
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    ProductCategoryId = model.ThirdCategory,
                    ProductID = product.Id,
                };

                await _productRepository.AddProductCategories(productCategory);
            }

            if (model.FourthCategory != null && model.FourthCategory != 0)
            {
                ProductSelectedCategory productCategory = new ProductSelectedCategory
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    ProductCategoryId = model.FourthCategory,
                    ProductID = product.Id,
                };

                await _productRepository.AddProductCategories(productCategory);
            }

            await _productRepository.SaveChanges();

            #endregion

            return CreateProductSellerPanelResult.Success;
        }

        public async Task<EditProductViewModel?> FillEditProductInSellerPanelViewModel(ulong productId, ulong userId)
        {
            #region Get Product 

            var product = await _productRepository.GetProductById(productId);

            if (product == null) return null;

            if (product.UserId != userId) return null;

            #endregion

            #region Product Tags

            var productTags = await _productRepository.GetProductTagsByProductId(product.Id);

            if (productTags == null) return null;

            #endregion

            #region Product Categories

            var firstCategory = await _productRepository.GetProductCategoryByProductIdAndParentId(product.Id, null);
            if (firstCategory == null) return null;

            var secondeCategory = await _productRepository.GetProductCategoryByProductIdAndParentId(product.Id, firstCategory);
            if (secondeCategory == null) return null;

            var thirdCategory = await _productRepository.GetProductCategoryByProductIdAndParentId(product.Id, secondeCategory);
            if (thirdCategory == null) return null;

            var fourthCategory = await _productRepository.GetProductCategoryByProductIdAndParentId(product.Id, thirdCategory);
            if (fourthCategory == null) return null;

            #endregion

            #region Fill View Model

            EditProductViewModel model = new EditProductViewModel
            {
                ProductId = product.Id,
                ProductImage = product.ProductImageName,
                UserId = product.UserId,
                ProductTitle = product.ProductTitle,
                ShortDescription = product.ShortDescription,
                LongDescription = product.LongDescription,
                Price = Convert.ToInt32(product.Price),
                RejectedNote = product.RejectedNote,
                ProductSaleType = product.ProductSaleType,
                ProductsCount = product.ProductsCount,
                PackedProductsDescription = product.PackedProductsDescription,
                ProductTag = string.Join(",", productTags.Select(p => p.TagTitle).ToList()),
                FirstCategory = firstCategory,
                SecondeCategory = secondeCategory,
                ThirdCategory = thirdCategory,
                FourthCategory = fourthCategory,
                ProductsState = product.ProductsState,
            };

            #endregion

            return model;
        }

        public async Task<List<SelectListViewModel>> GetCategoriesByParentId(ulong? parentId)
        {
            return await _productRepository.GetCategoriesByParentId(parentId);
        }

        public async Task<List<SelectListViewModel>> GetAllMainCategories()
        {
            return await _productRepository.GetAllMainCategories();
        }

        public async Task<EditProductSellerPanelResult> EditProductFromSellerPanel(EditProductViewModel model, IFormFile? productImage)
        {
            #region Model State Validation

            //Is Exist Firs Category By Category Id
            if (!await _marketCategoryService.IsExistMarketCategoryBycategoryId(model.FirstCategory))
            {
                return EditProductSellerPanelResult.Categories;
            }

            //Is Exist Seconde Category By Category Id
            if (!await _marketCategoryService.IsExistMarketCategoryBycategoryId(model.SecondeCategory))
            {
                return EditProductSellerPanelResult.Categories;
            }

            //Is Exist Third Category By Category Id
            if (!await _marketCategoryService.IsExistMarketCategoryBycategoryId(model.ThirdCategory))
            {
                return EditProductSellerPanelResult.Categories;
            }

            //Is Exist Fourth Category By Category Id
            if (!await _marketCategoryService.IsExistMarketCategoryBycategoryId(model.FourthCategory))
            {
                return EditProductSellerPanelResult.Categories;
            }

            if (model.UserId == null || !await _userService.IsExistUserById(model.UserId))
            {
                return EditProductSellerPanelResult.UserNotFound;
            }

            if (string.IsNullOrEmpty(model.LongDescription))
            {
                return EditProductSellerPanelResult.LongDescription;
            }

            if (productImage != null && !productImage.IsImage())
            {
                return EditProductSellerPanelResult.ImageName;
            }

            if (model.ProductSaleType == Domain.Enums.Products.ProductSaleType.Packed && string.IsNullOrEmpty(model.PackedProductsDescription))
            {
                return EditProductSellerPanelResult.PackedNote;
            }

            #endregion

            #region Get Product 

            var product = await _productRepository.GetProductById(model.ProductId);

            if (product == null) return EditProductSellerPanelResult.prodcutNotFound;

            if (product.UserId != model.UserId) return EditProductSellerPanelResult.UserNotFound;

            #endregion

            #region Update Fields

            product.ShortDescription = model.ShortDescription;
            product.LongDescription = model.LongDescription;
            product.ProductTitle = model.ProductTitle;
            product.PackedProductsDescription = model.PackedProductsDescription;
            product.Price = (decimal)model.Price;
            product.ProductsCount = model.ProductsCount;
            product.ProductSaleType = model.ProductSaleType;

            #endregion

            #region Image Name

            if (productImage != null)
            {
                var imageName = Guid.NewGuid() + Path.GetExtension(productImage.FileName);
                productImage.AddImageToServer(imageName, PathTools.ProductsPathServer, 400, 300, PathTools.ProductsPathThumbServer);

                if (!string.IsNullOrEmpty(product.ProductImageName))
                {
                    product.ProductImageName.DeleteImage(PathTools.ProductsPathServer, PathTools.ProductsPathThumbServer);
                }

                product.ProductImageName = imageName;
            }

            #endregion

            #region Update Product Method

            await _productRepository.EditProduct(product);

            #endregion

            #region Article Tags

            var productTags = await _productRepository.GetProdcutTagsByProductId(product.Id);

            if (productTags.Any())
            {
                await _productRepository.DeleteProductTags(productTags);
            }

            if (!string.IsNullOrEmpty(model.ProductTag))
            {
                var tags = model.ProductTag.Split(',').ToList();

                foreach (var item in tags)
                {
                    var tag = new ProductsTags
                    {
                        ProductId = product.Id,
                        TagTitle = item
                    };
                    await _productRepository.AddProductTags(tag);
                }
                await _productRepository.SaveChanges();
            }

            #endregion

            #region Add Product Categories

            #region Delete All Current Product Categories

            await _productRepository.DeleteAllPRoductCategoriesById(product.Id);

            #endregion

            #region Add New Product Categories

            if (model.FirstCategory != null && model.FirstCategory != 0)
            {
                ProductSelectedCategory productCategory = new ProductSelectedCategory
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    ProductCategoryId = model.FirstCategory,
                    ProductID = product.Id,
                };

                await _productRepository.AddProductCategories(productCategory);
            }

            if (model.SecondeCategory != null && model.SecondeCategory != 0)
            {
                ProductSelectedCategory productCategory = new ProductSelectedCategory
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    ProductCategoryId = model.SecondeCategory,
                    ProductID = product.Id,
                };

                await _productRepository.AddProductCategories(productCategory);
            }

            if (model.ThirdCategory != null && model.ThirdCategory != 0)
            {
                ProductSelectedCategory productCategory = new ProductSelectedCategory
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    ProductCategoryId = model.ThirdCategory,
                    ProductID = product.Id,
                };

                await _productRepository.AddProductCategories(productCategory);
            }

            if (model.FourthCategory != null && model.FourthCategory != 0)
            {
                ProductSelectedCategory productCategory = new ProductSelectedCategory
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    ProductCategoryId = model.FourthCategory,
                    ProductID = product.Id,
                };

                await _productRepository.AddProductCategories(productCategory);
            }

            await _productRepository.SaveChanges();

            #endregion

            #endregion

            return EditProductSellerPanelResult.Success;
        }

        public async Task<ProductGalleryViewModel?> FillProductGalleryViewModel(ulong productId)
        {
            #region Get Product From Id

            var product = await _productRepository.GetProductById(productId);

            if (product == null) return null;

            #endregion

            #region Get Product Gallery

            var productGallery = await _productRepository.GetProductGalleryByProductId(productId);

            #endregion

            #region Fill View Model

            ProductGalleryViewModel gallery = new ProductGalleryViewModel
            {
                ProductId = productId,
                ProductGallery = productGallery
            };

            #endregion

            return gallery;
        }

        public async Task<AddProductGalleryResult> AddProductGallery(ProductGalleryViewModel productGallery)
        {
            #region Get Product

            var product = await _productRepository.GetProductById(productGallery.ProductId);

            if (product == null) return AddProductGalleryResult.ProductNotFound;

            #endregion

            #region Model Validation 

            if (productGallery.ImageName == null || !productGallery.ImageName.IsImage())
            {
                return AddProductGalleryResult.ImageNotFound;
            }

            if (string.IsNullOrEmpty(productGallery.Title))
            {
                return AddProductGalleryResult.TitleNotFound;
            }

            #endregion

            #region Add Product Gallery

            ProductGallery gallery = new ProductGallery
            {
                Title = productGallery.Title,
                ProductID = productGallery.ProductId,
            };

            #endregion

            #region Product Gallery Image 

            var imageName = Guid.NewGuid() + Path.GetExtension(productGallery.ImageName.FileName);
            productGallery.ImageName.AddImageToServer(imageName, PathTools.ProductsGalleryPathServer, 400, 300, PathTools.ProductsGalleryPathThumbServer);
            gallery.ImageName = imageName;

            #endregion

            #region Add Product Gallery Method

            await _productRepository.AddProductGallery(gallery);

            #endregion

            return AddProductGalleryResult.Success;
        }

        public async Task<bool> DeleteProductGallery(ulong productGalleryId)
        {
            #region Get Product Gallery 

            var productGallery = await _productRepository.GetProductGalleryById(productGalleryId);

            if (productGallery == null) return false;

            #endregion

            #region Delete Product Gallery

            productGallery.IsDelete = true;

            await _productRepository.DeleteProductGallery(productGallery);

            #endregion

            return true;
        }

        public async Task<bool> DeleteProduct(ulong productId)
        {
            #region Get Product Id

            var product = await _productRepository.GetProductById(productId);

            if (product == null) return false;

            #endregion

            #region Delete Product

            product.IsDelete = true;

            await _productRepository.EditProduct(product);

            #endregion

            return true;
        }

        public async Task<ProductFeatureViewModel?> FillProductFeatureViewModel(ulong productId)
        {
            #region Get Product From Id

            var product = await _productRepository.GetProductById(productId);

            if (product == null) return null;

            #endregion

            #region Get Product Feature

            var productFeature = await _productRepository.GetProductFeatureByProductId(productId);

            #endregion

            #region Fill View Model

            ProductFeatureViewModel feature = new ProductFeatureViewModel
            {
                ProductID = productId,
                ProductFeature = productFeature,
            };

            #endregion

            return feature;
        }

        public async Task<AddProductFeatureResult> AddProductFeature(ProductFeatureViewModel productFeature)
        {
            #region Get Product

            var product = await _productRepository.GetProductById(productFeature.ProductID);

            if (product == null) return AddProductFeatureResult.ProductNotFound;

            #endregion

            #region Model Validation 

            if (string.IsNullOrEmpty(productFeature.FeatureTitle))
            {
                return AddProductFeatureResult.TitleNotFound;
            }

            if (string.IsNullOrEmpty(productFeature.FeatureValue))
            {
                return AddProductFeatureResult.ValueNotFound;
            }

            #endregion

            #region Add Product Feature

            ProductFeature feature = new ProductFeature
            {
                FeatureTitle = productFeature.FeatureTitle,
                FeatureValue = productFeature.FeatureValue,
                ProductID = productFeature.ProductID,
            };

            #endregion

            #region Add Product Feature Method

            await _productRepository.AddProductFeature(feature);

            #endregion

            return AddProductFeatureResult.Success;
        }

        public async Task<bool> DeleteProductFeature(ulong productFeatureId)
        {
            #region Get Product Feature 

            var feature = await _productRepository.GetProductFeatureById(productFeatureId);

            if (feature == null) return false;

            #endregion

            #region Delete Feature 

            feature.IsDelete = true;

            await _productRepository.DeleteProductFeature(feature);

            #endregion

            return true;
        }

        #endregion

        #region Site Side

        public async Task<FilterMedicalEquipmentViewModel> FilterMedicalEquipment(FilterMedicalEquipmentViewModel filter)
        {
            return await _productRepository.FilterMedicalEquipment(filter);
        }

        public async Task<FilterCosmeticViewModel> FilterCosmetic(FilterCosmeticViewModel filter)
        {
            return await _productRepository.FilterCosmetic(filter);
        }

        #endregion
    }
}
