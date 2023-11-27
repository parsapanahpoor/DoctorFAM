using DoctorFAM.Application.DTOs.HealthCenters.HealthCentersInfos;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.HealthCenters;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces.EFCore;

namespace DoctorFAM.Application.Services.Implementation;

public class HealthCentersService : IHealthCentersService
{
    #region Ctor

    private readonly IHealthCentersRepository _healthCentersRepository;
    private readonly IOrganizationService _organizationService;

    public HealthCentersService(IHealthCentersRepository healthCentersRepository, IOrganizationService organizationService)
    {
        _healthCentersRepository = healthCentersRepository;
        _organizationService = organizationService;
    }

    #endregion

    #region Health Center

    //Get Member Of Health Center With User Id 
    public async Task<OrganizationMember?> GetMemberOfHealthCenterWithUserId(ulong userId)
    {
        return await _healthCentersRepository.GetMemberOfHealthCenterWithUserId(userId);
    }

    //Fill Health Center Side Bar Panel 
    public async Task<HealthCenterSideBarViewModel> GetHealthCentersSideBarInfo(ulong userId)
    {
        #region Get Health Center Office

        var OrganitionMember = await GetMemberOfHealthCenterWithUserId(userId);

        #endregion

        HealthCenterSideBarViewModel model = new HealthCenterSideBarViewModel();

        #region Health Center State 

        //If Health Center Registers Now
        if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.JustRegister) model.HealthCenterInfoState = "NewUser";

        //If Health Center State Is WatingForConfirm
        if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.WatingForConfirm) model.HealthCenterInfoState = "WatingForConfirm";

        //If Health Center State Is Rejected
        if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Rejected) model.HealthCenterInfoState = "Rejected";

        //If Health Center State Is Accepted
        if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Accepted) model.HealthCenterInfoState = "Accepted";

        #endregion

        return model;
    }

    //Is Exist Any Health Center By User Id
    public async Task<bool> IsExistAnyHealthCenterByUserId(ulong userId)
    {
        return await _healthCentersRepository.IsExistAnyHealthCenterByUserId(userId);
    }

    //Add Health Center For First Time
    public async Task AddHealthCenterForFirstTime(ulong userId)
    {
        #region Health Center Entity

        #region Fill Health Center Model

        HealthCenter healthCenter = new HealthCenter()
        {
            UserId = userId,
            CreateDate = DateTime.Now,
            IsDelete = false,
        };

        #endregion

        #region Add Methods 

        await _healthCentersRepository.AddHealthCenterWithoutSaveChanges(healthCenter);

        #endregion

        #endregion

        #region Organization Entity

        #region Fill Organization Model

        Organization organization = new Organization()
        {
            CreateDate = DateTime.Now,
            IsDelete = false,
            OrganizationInfoState = OrganizationInfoState.JustRegister,
            OrganizationType = Domain.Enums.Organization.OrganizationType.HealthCenter,
            OwnerId = userId,
        };

        #endregion

        #region Add Method

        var organizationId = await _organizationService.AddOrganizationWithReturnId(organization);

        #endregion

        #endregion

        #region Organization Member

        #region Fill Model 

        OrganizationMember member = new OrganizationMember()
        {
            CreateDate = DateTime.Now,
            IsDelete = false,
            OrganizationId = organizationId,
            UserId = userId
        };

        #endregion

        #region Add Organization Member

        await _organizationService.AddOrganizationMember(member);

        #endregion

        #endregion
    }

    #endregion
}
