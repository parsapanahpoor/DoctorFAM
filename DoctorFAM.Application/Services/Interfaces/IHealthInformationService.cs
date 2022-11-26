using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IHealthInformationService
    {
        #region TV FAM

        #region Category 

        #region Admin Side 

        //List Of TV FAM Category 
        Task<FilterTVFAMCategoryViewModel> FilterTVFAMCategory(FilterTVFAMCategoryViewModel filter);

        //Get Health Information Category By Health Information Category Id 
        Task<TVFAMCategory?> GetHealthInformationCategoryByHealthInformationCategoryId(ulong tvFAMCategoryId);

        //Create TV FAM Category 
        Task<CreateTVFAMCategoryResult> CreateTVFAMCategory(CreateTVFAMCategoryViewModel model);

        //Fill Edit TV FAM Category Info
        Task<EditTVFAMCategoryViewModel?> FillTVFAMCategoryViewModel(ulong tvFAMCategoryId);

        //Get Tv FAM Category By Tv FAM Category Id 
        Task<TVFAMCategory?> GetTVFAMCategoryById(ulong setvFAMCategoryId);

        //Edit TV FAM Category
        Task<EditTVFAMCategoryResult> EditService(EditTVFAMCategoryViewModel tvFAMCategory);

        //Delete Tv FAM Category
        Task<bool> DeleteTVFAMCategory(ulong tvFAMCategoryId);

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
