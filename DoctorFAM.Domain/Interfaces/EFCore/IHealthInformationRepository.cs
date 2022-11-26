using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces.EFCore
{
    public interface IHealthInformationRepository 
    {
        #region TV FAM

        #region Category 

        #region Admin Side 

        //List Of TV FAM Category 
        Task<FilterTVFAMCategoryViewModel> FilterTVFAMCategory(FilterTVFAMCategoryViewModel filter);

        //Get Health Information Category By Health Information Category Id 
        Task<TVFAMCategory?> GetHealthInformationCategoryByHealthInformationCategoryId(ulong tvFAMCategoryId);

        //Is Exist TV FAM Category By Unique Name
        Task<bool> IsExistTVFAMCategoryByUniqueName(string uniqueName);

        //Is Exist Any TV FAM Category By Id 
        Task<bool> IsExistTVFAMCategoryById(ulong tvFAMCategoryId);

        //Add TV FAM Categories
        Task<ulong> AddTVFAMCategory(TVFAMCategory tvFAMCategory);

        //Add TV FAM Category Info
        Task AddTVFAMCategoryInfo(List<TVFAMCategoryInfo> tvFAMCategoryInfos);

        //Fill Edit TV FAM Category Info
        Task<EditTVFAMCategoryViewModel?> FillTVFAMCategoryViewModel(ulong tvFAMCategoryId);

        //Get Tv FAM Category By Tv FAM Category Id 
        Task<TVFAMCategory?> GetTVFAMCategoryById(ulong setvFAMCategoryId);

        //Update TV FAM Category
         void UpdateTVFAMCategory(TVFAMCategory tvFAMCategory);

        //Save Changes 
        Task SaveChanges();

        //Update TV FAM Category Info
        void UpdateTVFAMCategoryInfo(TVFAMCategoryInfo tvFAMCategoryInfo);

        //Delete TV FAM Category Info
        Task DeleteTVFAMCategoryInfo(ulong tvFAMCategoryId);

        //Delete TV FAM Category And TVFAM Category Info
        Task DeleteServiceCategory(TVFAMCategory tvFAMCategory);

        #endregion

        #endregion

        #region TV FAM

        #endregion

        #endregion

        #region Radio FAM

        #region Category 



        #endregion

        #region Radio FAM

        #endregion

        #endregion
    }
}
