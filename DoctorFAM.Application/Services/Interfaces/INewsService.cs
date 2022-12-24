using DoctorFAM.Domain.Entities.News;
using DoctorFAM.Domain.ViewModels.News;
using DoctorFAM.Domain.ViewModels.News.Admin;
using DoctorFAM.Domain.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Academy.Domain.ViewModels.News.Admin;
using DoctorFAM.Domain.ViewModels.Article.Admin;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface INewsService
    {
        #region Main Methodes

        Task SaveChangesAsync();

        void UpdateNews(News News);

        Task<News> GetNewsByIdAsync(ulong NewsId);

        Task<bool> IsExistAnyNews();

        #endregion

        #region Admin Side

        Task<FilterNewsAdminSideViewModel> FilterNewsAdminSideViewModel(FilterNewsAdminSideViewModel filter);

        Task<CreateNewsFromAdminPanelResponse> CreateNewsFromAdminPanel(CreateNewsAdminViewModel model, IFormFile NewsImage);

        Task<EditNewsAdminSideViewModel> FillEditNewsAdminSideViewModel(News News);

        Task<EditNewsFromAdminPanelResponse> EditNewsFromAdminPanel(EditNewsAdminSideViewModel model, IFormFile NewsImage);

        Task<bool> DeleteNewsFromAdminPanel(ulong NewsId);

        #endregion

        #region News Tags

        Task<bool> IsExistAnyTagForThisNews(ulong Id);

        Task<List<NewsTag>> GetNewsTagsByNewsId(ulong Id);

        void RemoveNewsTags(NewsTag NewsTag);

        #endregion

        #region News Category

        Task<FilterNewsCategoryViewModel> FilterNewsCategoryViewModel(FilterNewsCategoryViewModel filter);

        Task<bool> IsDuplicatedNewsCategory(string UniqueName);

        Task<CreateNewsCategoryResult> AddMainNewsCategory(CreateNewsCategoryViewModel cat);

        Task<EditNewsCategoryViewModel> FillEditNewsCategoryViewModel(NewsCategory model);

        Task<NewsCategory> GetNewsCategoryById(ulong Id);

        Task<EditNewsCategoryResult> EditNewsCategoryResult(EditNewsCategoryViewModel category , NewsCategory News);

        Task DeleteNewsCategory(NewsCategory cat);

        Task<List<NewsCategory>> GetSubCategoriesOfMAinCategory(ulong MainCategoryId);

        Task<List<SelectListViewModel>> GetAllMainCategories();

        Task<List<SelectListViewModel>> GetCategoriesChildrent(ulong MainCategoryId);

        Task<List<NewsCategory>> GetAllParentCategories();

        Task<List<NewsCategory>> GetLastestNewsCategories(int countNumber);

        #endregion
    }
}
