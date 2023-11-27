using DoctorFAM.Domain.Entities.HealthCenters;
using DoctorFAM.Domain.Entities.Organization;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Domain.Interfaces.EFCore;

public interface IHealthCentersRepository
{
    #region Health Center

    //Get Member Of Health Center With User Id 
    Task<OrganizationMember?> GetMemberOfHealthCenterWithUserId(ulong userId);

    //Is Exist Any Health Center By User Id
    Task<bool> IsExistAnyHealthCenterByUserId(ulong userId);

    //Add Health Center Without Save Changes
    Task AddHealthCenterWithoutSaveChanges(HealthCenter healthCenter)

    //Save Changes
    Task SaveChangesAsync();

    #endregion
}
