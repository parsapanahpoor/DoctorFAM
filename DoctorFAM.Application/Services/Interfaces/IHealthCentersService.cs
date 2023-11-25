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

    #endregion
}
