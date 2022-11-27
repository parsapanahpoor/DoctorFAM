using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.RadioFAM.Category;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Category;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Video;
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

        //List OF TV FAM Category 
        Task<List<TVFAMCategoryViewModel>> ListOFTVFAMCategory();

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

        #region Admin Side 

        //Create TV FAM video From Admin Side
        Task<bool> CreateTVFAMvideoFromAdminSide(CreateTVFAMVideViewModel model);

        //Filter Health Information (Video FAM) From Admin Side 
        Task<List<HealthInformation>> FilterTVFAMAdminSide();

        #endregion

        #endregion

        #endregion

        #region Radio FAM

        #region Category 

        #region Admin Side 

        //Get Radio FAM Category By Health Information Category Id 
        Task<RadioFAMCategory?> GetRadioFAMCategoryByHealthInformationCategoryId(ulong RadioFAMCategoryId);

        //Create Radio FAM Category 
        Task<CreateRadioFAMCategoryResult> CreateRadioFAMCategory(CreateRadioFAMCategoryViewModel model);

        //Fill Edit Radio FAM Category Info
        Task<EditRadioFAMCategoryViewModel?> FillRadioFAMCategoryViewModel(ulong RadioFAMCategoryId);

        //Get Radio FAM Category By Radio FAM Category Id 
        Task<RadioFAMCategory?> GetRadioFAMCategoryById(ulong seRadioFAMCategoryId);

        //Edit Radio FAM Category
        Task<EditRadioFAMCategoryResult> EditService(EditRadioFAMCategoryViewModel RadioFAMCategory);

        //Delete Radio FAM Category
        Task<bool> DeleteRadioFAMCategory(ulong RadioFAMCategoryId);

        //List Of Radio FAM Category 
        Task<FilterRadioFAMCategoryViewModel> FilterRadioFAMCategory(FilterRadioFAMCategoryViewModel filter);

        #endregion

        #endregion

        #region Radio FAM

        #endregion

        #endregion
    }
}
