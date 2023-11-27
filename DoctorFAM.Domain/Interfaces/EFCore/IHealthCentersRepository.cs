using DoctorFAM.Domain.Entities.HealthCenters;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.ViewModels.HealthCenters.SideBar;

namespace DoctorFAM.Domain.Interfaces.EFCore;

public interface IHealthCentersRepository
{
    #region Health Center

    //Get Member Of Health Center With User Id 
    Task<OrganizationMember?> GetMemberOfHealthCenterWithUserId(ulong userId);

    //Is Exist Any Health Center By User Id
    Task<bool> IsExistAnyHealthCenterByUserId(ulong userId);

    //Add Health Center Without Save Changes
    Task AddHealthCenterWithoutSaveChanges(HealthCenter healthCenter);

    //Save Changes
    Task SaveChangesAsync();

    //Fill Health Center Side Bar Panel 
    Task<HealthCenterSideBarViewModel> GetHealthCenterSideBarInfo(ulong userId);

    //Get QueryAble OF Health Centers
    IQueryable<Organization> GetQueryAbleOFHealthCenters();

    //Get Health Center By User Id
    IQueryable<HealthCenter> GetHealthCenterByUserIdAsQueryAble(ulong userId);

    //Get Health Center Info By Health Center Id
    IQueryable<HealthCentersInfo>? GetHealthCenterInfoByHealthCenterIdAsQueryAble(ulong HealthCenterId);

    //Get Health Center By Health Center Id 
    IQueryable<HealthCenter> GetHealthCenterByHealthCenterId(ulong healthCenterId);

    //Get Health Center By Health Center Id
    IQueryable<HealthCenter?> GetHealthCenterById(ulong nurseId);

    //Update Method 
    void UpdateHealthCenterInfo(HealthCentersInfo model);

    #endregion
}
