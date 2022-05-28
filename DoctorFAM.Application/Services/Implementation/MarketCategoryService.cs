using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.MarketCategory;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.MarketCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class MarketCategoryService : IMarketCategoryService
    {
        #region Ctor

        private readonly IMarketCategoryRepository _categoryRepository;

        public MarketCategoryService(IMarketCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #endregion

        #region Admin Side

        public async Task<FilterMarketCategoryViewModel> FilterMarketCategory(FilterMarketCategoryViewModel filter)
        {
            return await _categoryRepository.FilterMarketCategory(filter);
        }

        public async Task<Category?> GetMarketCategoryById(ulong categoryId)
        {
            return await _categoryRepository.GetMarketCategoryById(categoryId);
        }

        public async Task<bool> IsExistMarketCategoryByUniqueName(string uniqueName)
        {
            return await _categoryRepository.IsExistMarketCategoryByUniqueName(uniqueName);
        }

        public async Task<bool> IsExistMarketCategoryBycategoryId(ulong marketCategoryId)
        {
            return await _categoryRepository.IsExistMarketCategoryBycategoryId(marketCategoryId);
        }

        public async Task<ulong> AddMarketCategory(Category category)
        {
            return await _categoryRepository.AddMarketCategory(category);
        }

        public async Task<CreateMarketCategoryResult> CreateMarketCategory(CreateMarketCategoryViewModel category)
        {
            #region Is Exist Market Category By Unique Name

            if (await IsExistMarketCategoryByUniqueName(category.UniqueName))
            {
                return CreateMarketCategoryResult.UniqNameIsExist;
            }

            #endregion

            #region Add category

            var mainCategory = new Category()
            {
                UniqueName = category.UniqueName.SanitizeText(),
                IsDelete = false
            };

            if (category.ParentId != null && category.ParentId != 0)
            {
                if (await _categoryRepository.IsExistMarketCategoryBycategoryId(category.ParentId.Value))
                {
                    mainCategory.ParentId = category.ParentId;
                }
                else
                {
                    return CreateMarketCategoryResult.Fail;
                }
            }

            var categoryId = await _categoryRepository.AddMarketCategory(mainCategory);

            #endregion

            #region Add LocationInfo

            var categoryInfo = new List<CategoryInfo>();

            foreach (var culture in category.MarketCategoryInfo)
            {
                var categoryInfos = new CategoryInfo
                {
                    CategoryId = categoryId,
                    LanguageId = culture.Culture,
                    Title = culture.Title.SanitizeText(),
                    CreateDate = DateTime.Now,
                };

                categoryInfo.Add(categoryInfos);
            }

            await _categoryRepository.AddMarketCategoryInfo(categoryInfo);

            #endregion

            return CreateMarketCategoryResult.Success;
        }

        public async Task<EditMarketCategoryViewModel?> FillEditMarketCategoryViewModel(ulong marketCategoryId)
        {
            return await _categoryRepository.FillEditMarketCategoryViewModel(marketCategoryId);
        }

        public async Task<EditMArketCategoryResult> EditMarketCategory(EditMarketCategoryViewModel marketCategoryViewModel)
        {
            #region Get Location By Id

            var category = await GetMarketCategoryById(marketCategoryViewModel.Id);

            if (category == null) return EditMArketCategoryResult.Fail;

            #endregion

            #region Is Exist Market Category By Unique Name

            if (category.UniqueName != marketCategoryViewModel.UniqueName)
            {
                if (await IsExistMarketCategoryByUniqueName(marketCategoryViewModel.UniqueName))
                {
                    return EditMArketCategoryResult.UniqNameIsExist;
                }
            }

            #endregion

            #region Is Exist Market Category By Parent Id

            if (marketCategoryViewModel.ParentId != null && marketCategoryViewModel.ParentId != 0)
            {
                if (!await _categoryRepository.IsExistMarketCategoryBycategoryId(marketCategoryViewModel.ParentId.Value))
                {
                    return EditMArketCategoryResult.Fail;
                }
            }

            #endregion

            #region Update Market Category

            category.UniqueName = marketCategoryViewModel.UniqueName.SanitizeText();

            _categoryRepository.UpdateMarketCategory(category);

            #endregion

            #region Market Category Info

            foreach (var categoryInfo in category.CategoryInfo)
            {
                var updatedInfo = marketCategoryViewModel.MarketCategoryInfo.FirstOrDefault(p => p.Culture == categoryInfo.LanguageId);

                if (updatedInfo != null)
                {
                    categoryInfo.Title = updatedInfo.Title.SanitizeText();
                }

                _categoryRepository.UpdateMarketCategoryInfo(categoryInfo);
            }

            #endregion

            await _categoryRepository.SaveChanges();

            return EditMArketCategoryResult.Success;
        }

        public async Task<bool> DeleteMarketCategory(ulong marketCategoryId)
        {
            //Get Market Category By Id
            var category = await _categoryRepository.GetMarketCategoryById(marketCategoryId);

            if (category == null) return false;

            //Delete Market Category and Market Category Info 
            await _categoryRepository.DeleteMArketCategory(category);

            return true;
        }

        #endregion
    }
}
