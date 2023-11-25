using DoctorFAM.Domain.Entities.Organization;

namespace DoctorFAM.Domain.Interfaces.EFCore;

public interface IHealthCentersRepository
{
    #region Health Center

    //Get Member Of Health Center With User Id 
    Task<OrganizationMember?> GetMemberOfHealthCenterWithUserId(ulong userId);

    #endregion
}
