using DoctorFAM.Domain.Entities.MarketCategory;
using DoctorFAM.Domain.ViewModels.Admin.MarketCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IMarketCategoryRepository
    {
        #region Admin Side

        Task<FilterMarketCategoryViewModel> FilterMarketCategory(FilterMarketCategoryViewModel filter);

        Task<Category?> GetMarketCategoryById(ulong categoryId);

        Task<bool> IsExistMarketCategoryByUniqueName(string uniqueName);

        Task<bool> IsExistMarketCategoryBycategoryId(ulong marketCategoryId);

        Task<ulong> AddMarketCategory(Category category);

        Task AddMarketCategoryInfo(List<CategoryInfo> categoryInfo);

        Task<EditMarketCategoryViewModel?> FillEditMarketCategoryViewModel(ulong marketCategoryId);

        void UpdateMarketCategory(Category category);

        void UpdateMarketCategoryInfo(CategoryInfo categoryInfo);

        Task SaveChanges();

        Task DeleteMarketCategoryInfo(ulong categoryId);

        Task<List<Category>> GetChildMarketCategoryByParentId(ulong parentId);

        Task DeleteMArketCategory(Category category);

        #endregion
    }
}
