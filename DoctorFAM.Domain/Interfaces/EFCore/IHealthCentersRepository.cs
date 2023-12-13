using DoctorFAM.Domain.Entities.HealthCenters;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.ViewModels.DoctorPanel.HealthCenters;
using DoctorFAM.Domain.ViewModels.HealthCenters.HealthCenterMembers;
using DoctorFAM.Domain.ViewModels.HealthCenters.SideBar;

namespace DoctorFAM.Domain.Interfaces.EFCore;

public interface IHealthCentersRepository
{
    #region General

    Task<ulong> GetHealthCenterOwnerUserIdByHealthCenterId(ulong healthCenterId);

    Task<bool> IsExistAnyHealthCenterById(ulong id);

    Task AddDoctorSelectedHealthCenter(DoctorSelectedHealthCenter doctorSelectedHealth);

    Task SaveChanges();

    Task<bool> IsExistAnyDoctorSelectedHealthCenterRecordByDoctorUserIdAndHealthCenterId(ulong healthCenterId, ulong doctorUserId);

    Task<string?> GetHealthCenterNameByHealthCenterId(ulong healthCenterId);

    #endregion

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
    IQueryable<HealthCenter?> GetHealthCenterById(ulong id);

    //Get Health Center By Health Center Id
    Task<HealthCenter?> GetHealthCenterByIdAsync(ulong id);

    //Get Health Center By Health Center User Id
    Task<HealthCenter?> GetHealthCenterByUserId(ulong userId);

    //Update Method 
    void UpdateHealthCenterInfo(HealthCentersInfo model);

    //Is Exist Any Health Center Info By UserId
    IQueryable<HealthCentersInfo> IsExistAnyHealthCenterInfoByUserId(ulong userId);

    //Get Health Centers Information By UserId
    IQueryable<HealthCentersInfo?> GetHealthCentersInformationByUserId(ulong userId);

    //Update Method 
    Task AddHealthCenterInfo(HealthCentersInfo model);

    //Add Health Center With Returning Id 
    Task<ulong> AddHealthCenterWithReturningId(HealthCenter healthCenter);

    Task<FilterHealthcenterMembersDTO> FilterHealthcenterMembers(FilterHealthcenterMembersDTO model, ulong healthCenterId, CancellationToken cancellationToken);

    Task<EditMemberInfoDTO?> FillEditMemberInfoDTO(ulong id, CancellationToken cancellation);

    Task<DoctorSelectedHealthCenter?> GetDoctorSelectedHealthCenterById(ulong id, CancellationToken cancellationToken);

    void UpdateDoctorSelectedHealthCenterRequest(DoctorSelectedHealthCenter model);

    #endregion

    #region Doctor Panel

    Task<List<ulong>> GetListOfHealthCentersIdFromDoctorSelectedHealthCentersByDoctorUserId(ulong doctorUserId);

    Task<FilterHealthCentersInDoctorPanelDTO> ListOfHealthCenters(FilterHealthCentersInDoctorPanelDTO model);

    Task<FilterOfDoctorSelectedHealthCentersDoctorSide> FilterOfDoctorSelectedHealthCentersDoctorSide(FilterOfDoctorSelectedHealthCentersDoctorSide filter);

    #endregion
}
