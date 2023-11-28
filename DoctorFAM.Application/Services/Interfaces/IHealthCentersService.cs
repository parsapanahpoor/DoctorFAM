using DoctorFAM.Application.DTOs.HealthCenters.HealthCentersInfos;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.ViewModels.Admin.HealthCenter;
using DoctorFAM.Domain.ViewModels.HealthCenters.HealthCentersInfo;
using Microsoft.AspNetCore.Http;

namespace DoctorFAM.Application.Services.Interfaces;

public interface IHealthCentersService
{
    #region Health Center

    //Get Member Of Health Center With User Id 
    Task<OrganizationMember?> GetMemberOfHealthCenterWithUserId(ulong userId);

    //Fill Health Center Side Bar Panel 
    Task<HealthCenterSideBarViewModel> GetHealthCentersSideBarInfo(ulong userId);

    //Is Exist Any Health Center By User Id
    Task<bool> IsExistAnyHealthCenterByUserId(ulong userId);

    //Add Health Center For First Time
    Task AddHealthCenterForFirstTime(ulong userId);

    //Fill Health Center Side Bar Panel 
    Task<Domain.ViewModels.HealthCenters.SideBar.HealthCenterSideBarViewModel> GetHealthCenterSideBarInfo(ulong userId);

    //Filter Health Center Info Admin Side
    Task<ListOfHealthCenterInfoViewModel> FilterHealthCenterInfoAdminSide(ListOfHealthCenterInfoViewModel filter);

    //Fill Health Center Info Detail ViewModel
    Task<HealthCenterInfoDetailViewModel?> FillHealthCenterInfoDetailViewModel(ulong userId);

    //Edit HealthCenter Info From Admin Panel
    Task<EditHealthCenterInfoResult> EditHealthCenterInfoAdminSide(HealthCenterInfoDetailViewModel model);

    //Fill Manage Health Center Info ViewModel
    Task<ManageHealthCentersInfoViewModel?> FillManageHealthCentersInfoViewModel(ulong userId);

    //Add Or Edit Health Center Info Health Center Panel 
    Task<AddOrEditHealthCenterstInfoResult> AddOrEditHealthCenterInfoDentistsPanel(ManageHealthCentersInfoViewModel model, IFormFile? UserAvatar);

    #endregion
}
