using DoctorFAM.Application.DTOs.HealthCenters.HealthCentersInfos;
using DoctorFAM.Domain.Entities.Organization;

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

    #endregion
}
