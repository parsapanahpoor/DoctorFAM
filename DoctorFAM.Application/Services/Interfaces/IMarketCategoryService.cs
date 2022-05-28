using DoctorFAM.Domain.Entities.MarketCategory;
using DoctorFAM.Domain.ViewModels.Admin.MarketCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IMarketCategoryService
    {
        #region Admin Side

        Task<FilterMarketCategoryViewModel> FilterMarketCategory(FilterMarketCategoryViewModel filter);

        Task<Category?> GetMarketCategoryById(ulong categoryId);

        Task<bool> IsExistMarketCategoryByUniqueName(string uniqueName);

        Task<bool> IsExistMarketCategoryBycategoryId(ulong marketCategoryId);

        Task<ulong> AddMarketCategory(Category category);

        Task<CreateMarketCategoryResult> CreateMarketCategory(CreateMarketCategoryViewModel category);

        Task<EditMarketCategoryViewModel?> FillEditMarketCategoryViewModel(ulong marketCategoryId);

        Task<EditMArketCategoryResult> EditMarketCategory(EditMarketCategoryViewModel marketCategoryViewModel);

        Task<bool> DeleteMarketCategory(ulong marketCategoryId);

        #endregion
    }
}
