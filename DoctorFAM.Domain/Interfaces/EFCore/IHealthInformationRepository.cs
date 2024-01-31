using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.RadioFAM.Category;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Category;
using DoctorFAM.Domain.ViewModels.Site.Doctor;

namespace DoctorFAM.Domain.Interfaces.EFCore
{
    public interface IHealthInformationRepository
    {
        #region TV FAM

        #region Category 

        #region Admin Side 

        //Create TV FAM Selected Catgeories
        Task CreateTVFAMSelectedCatgeories(TVFAMSelectedCategory tVFAM);

        //List OF TV FAM Category 
        Task<List<TVFAMCategoryViewModel>> ListOFTVFAMCategory();

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

        #region Admin Side 

        //Create Health Information 
        Task CreateTVFAMVideo(HealthInformation healthInformation);

        //Create Health Information Tags 
        Task CreateHealthInformationTags(HealthInformationTag tag);

        //Filter Health Information (Video FAM) From Admin Side 
        Task<List<HealthInformation>> FilterTVFAMAdminSide();

        //Get Health Information By Id
        Task<HealthInformation?> GetHealthInformationById(ulong healthId);

        //Get Healt Informations Tags
        Task<List<HealthInformationTag>> GetHealtInformationsTags(ulong Id);

        //Get Health Information Selected Categories
        Task<List<ulong>> GetHealthInformationSelectedCategories(ulong healthId);

        //Remove Health Information Tags 
        Task RemoveHealthInformationTags(List<HealthInformationTag> tags);

        //Remove Health Information Selected Category
        Task RemoveHealthInformationSelectedCategory(List<TVFAMSelectedCategory> tvFAMCategory);

        //Remove Health Information Selected Category
        Task RemoveHealthInformationSelectedCategory(TVFAMSelectedCategory tvFAMCategory);

        //Get List Of Health Information Selected Categories
        Task<List<TVFAMSelectedCategory>> GetListOfHealthInformationSelectedCategories(ulong healthId);

        //Update TV FAM 
        Task UpdateTVFAM(HealthInformation model);

        #endregion

        #region Doctor Panel 

        //Filter Health Information (Video FAM) From Doctor Panel Side  
        Task<List<HealthInformation>> FilterTVFAMDoctorPanelSide(ulong ownerId);

        #endregion

        #region Site Side 

        //Get Lastest 3 TvFAM For Show In Admin Panel 
        Task<List<HealthInformation>?> GetLastest3TvFAMForShowInAdminPanel();

        Task<List<DoctorVideosDTO>> FillDoctorVideosDTO(ulong userId, CancellationToken cancellation);

        #endregion

        #endregion

        #endregion

        #region Radio FAM

        #region Category 

        #region Admin Side 

        //List Of Radio FAM Category 
        Task<FilterRadioFAMCategoryViewModel> FilterRadioFAMCategory(FilterRadioFAMCategoryViewModel filter);

        //Get Health Information Category By Health Information Category Id 
        Task<RadioFAMCategory?> GetRadioFAMCategoryByHealthInformationCategoryId(ulong RadioFAMCategoryId);

        //Is Exist Radio FAM Category By Unique Name
        Task<bool> IsExistRadioFAMCategoryByUniqueName(string uniqueName);

        //Is Exist Any Radio FAM Category By Id 
        Task<bool> IsExistRadioFAMCategoryById(ulong RadioFAMCategoryId);

        //Add Radio FAM Categories
        Task<ulong> AddRadioFAMCategory(RadioFAMCategory RadioFAMCategory);

        //Add Radio FAM Category Info
        Task AddRadioFAMCategoryInfo(List<RadioFAMCategoryInfo> RadioFAMCategoryInfos);

        //Fill Edit Radio FAM Category Info
        Task<EditRadioFAMCategoryViewModel?> FillRadioFAMCategoryViewModel(ulong RadioFAMCategoryId);

        //Get Radio FAM Category By Radio FAM Category Id 
        Task<RadioFAMCategory?> GetRadioFAMCategoryById(ulong seRadioFAMCategoryId);

        //Update Radio FAM Category
        void UpdateRadioFAMCategory(RadioFAMCategory RadioFAMCategory);

        //Update Radio FAM Category Info
        void UpdateRadioFAMCategoryInfo(RadioFAMCategoryInfo RadioFAMCategoryInfo);

        //Delete Radio FAM Category Info
        Task DeleteRadioFAMCategoryInfo(ulong RadioFAMCategoryId);

        //Get Childs Of Radio FAM Category By Parent ID
        Task<List<RadioFAMCategory>> GetChildRadioFAMCategoryByParentId(ulong parentId);

        //Delete RadioFAM Category And RadioFAM Category Info
        Task DeleteServiceCategory(RadioFAMCategory RadioFAMCategory);

        #endregion

        #endregion

        #region Radio FAM

        #region Admin Side 

        //Filter Podcasts From Admin Side 
        Task<List<HealthInformation>> FilterPodcastsAdminSide();

        //Create Radio FAM Selected Catgeories
        Task CreatePodcastsSelectedCatgeories(RadioFAMSelectedCategory radio);

        //List OF Podcast Category 
        Task<List<TVFAMCategoryViewModel>> ListOFPodcastsCategory();

        //Get Podcasts Selected Categories
        Task<List<ulong>> GetPodcastsSelectedCategories(ulong healthId);

        //Get List Of Podcasts Selected Categories
        Task<List<RadioFAMSelectedCategory>> GetListOfPOdcastSelectedCategories(ulong healthId);

        //Remove Podcast Selected Category
        Task RemovePodcastSelectedCategory(List<RadioFAMSelectedCategory> tvFAMCategory);

        //Remove Podcast Selected Category
        Task RemovePodcastSelectedCategory(RadioFAMSelectedCategory tvFAMCategory);

        #endregion

        #region Doctor Panel 

        //Filter Podcast From Doctor Panel Side  
        Task<List<HealthInformation>> FilterPodcastoctorPanelSide(ulong ownerId);

        #endregion

        #region Site Side 

        //Get Lastest 3 Podcast For Show In Admin Panel 
        Task<List<HealthInformation>?> GetLastest3PodcastForShowInAdminPanel();

        //Get Lastest Radio FAM Podcasts For Show In Landing Page
        Task<List<HealthInformation>?> GetLastestRadioFAMPodcastsForShowInLandingPage();

        #endregion

        #endregion

        #endregion

        #region Status

        #region Doctor Panel

        //Filter Status From Doctor Panel Side  
        Task<List<HealthInformation>> FilterStatusDoctorPanelSide(ulong ownerId);

        //Remove All Of Lastest Status From This Current Doctor 
        Task RemoveAllOfLastestStatusFromThisCurrentDoctor(ulong doctorUserId);

        #endregion

        #endregion
    }
}
