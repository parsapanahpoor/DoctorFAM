using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.RadioFAM.Category;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Category;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Video;
using DoctorFAM.Domain.ViewModels.DoctorPanel.HealthInformation.TVFAM;
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

        //Get Health Information By Id
        Task<HealthInformation?> GetHealthInformationById(ulong healthId);

        //Get Healt Informations Tags
        Task<List<HealthInformationTag>> GetHealtInformationsTags(ulong Id);

        #endregion

        #region Doctor Panel 

        //Filter Health Information (Video FAM) From Doctor Panel Side  
        Task<List<HealthInformation>> FilterTVFAMDoctorPanelSide(ulong ownerId);

        //Create TV FAM video From Doctor Side
        Task<bool> CreateTVFAMvideoFromDoctorSide(CreateTVFAMVideDoctorPanelViewModel model, ulong userId);

        //Edit TV FAM Video Doctor Side 
        Task<bool> EditTVFAMVideoDoctorSide(EditTVFAMVideoDoctorPanelViewModel model, ulong ownerId);

        //Fill Edit TVFAM Video Model Doctor Side
        Task<EditTVFAMVideoDoctorPanelViewModel?> FillEditTVFAMVideoModelDoctorSide(ulong tvFAMId, ulong ownerId);

        //Delete Health Information Doctor Panel 
        Task<bool> DeleteTVFAMDoctorPanel(ulong healthInfoId, ulong userId);

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

        //Fill Edit TVFAM Video Model Admin Side
        Task<EditTVFAMVideoModel?> FillEditTVFAMVideoModelAdminSide(ulong tvFAMId);

        //Edit TV FAM Video Admin Side 
        Task<bool> EditTVFAMVideoAdminSide(EditTVFAMVideoModel model);

        //Delete Health Information 
        Task<bool> DeleteTVFAM(ulong healthInfoId);

        #endregion

        #endregion

        #region Radio FAM

        #region Admin Side

        //Filter Podcasts From Admin Side 
        Task<List<HealthInformation>> FilterPodcastsAdminSide();

        //Create Podcasts From Admin Side
        Task<bool> CreatePodcastsFromAdminSide(CreateTVFAMVideViewModel model);

        //List OF Podcast Category 
        Task<List<TVFAMCategoryViewModel>> ListOFPodcastsCategory();

        //Fill Edit Podcasts Model Admin Side
        Task<EditTVFAMVideoModel?> FillEditPodcastsModelAdminSide(ulong podcastId);

        //Edit Podcast Admin Side 
        Task<bool> EditPodcastAdminSide(EditTVFAMVideoModel model);

        //Delete Podcast 
        Task<bool> DeletePodcast(ulong healthInfoId);

        #endregion

        #region Doctor Panel 

        //Filter Podcast From Doctor Panel Side  
        Task<List<HealthInformation>> FilterPodcastDoctorPanelSide(ulong ownerId);

        //Create Podcast From Doctor Side
        Task<bool> CreatePodcastFromDoctorSide(CreateTVFAMVideDoctorPanelViewModel model, ulong userId);

        //Fill Edit Podcast Model Doctor Side
        Task<EditTVFAMVideoDoctorPanelViewModel?> FillEditPodcastModelDoctorSide(ulong tvFAMId, ulong ownerId);

        //Edit Podcast Doctor Side 
        Task<bool> EditPodcastDoctorSide(EditTVFAMVideoDoctorPanelViewModel model, ulong ownerId);

        //Delete Podcast Doctor Panel 
        Task<bool> DeletePodcastDoctorPanel(ulong healthInfoId, ulong userId);

        #endregion

        #endregion

        #endregion
    }
}
