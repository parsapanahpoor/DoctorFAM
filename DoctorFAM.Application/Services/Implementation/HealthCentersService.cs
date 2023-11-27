using DoctorFAM.Application.DTOs.HealthCenters.HealthCentersInfos;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.Repository;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.HealthCenters;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Doctor;
using DoctorFAM.Domain.ViewModels.Admin.HealthCenter;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Application.Services.Implementation;

public class HealthCentersService : IHealthCentersService
{
    #region Ctor

    private readonly IHealthCentersRepository _healthCentersRepository;
    private readonly IOrganizationService _organizationService;
    private readonly IWorkAddressRepository _workAddressRepository;

    public HealthCentersService(IHealthCentersRepository healthCentersRepository, 
                                IOrganizationService organizationService , 
                                IWorkAddressRepository workAddressRepository)
    {
        _healthCentersRepository = healthCentersRepository;
        _organizationService = organizationService;
        _workAddressRepository = workAddressRepository;
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

    //Fill Health Center Side Bar Panel 
    public async Task<Domain.ViewModels.HealthCenters.SideBar.HealthCenterSideBarViewModel> GetHealthCenterSideBarInfo(ulong userId)
    {
        return await _healthCentersRepository.GetHealthCenterSideBarInfo(userId);
    }

    //Filter Health Center Info Admin Side
    public async Task<ListOfHealthCenterInfoViewModel> FilterHealthCenterInfoAdminSide(ListOfHealthCenterInfoViewModel filter)
    {
        var query = _healthCentersRepository.GetQueryAbleOFHealthCenters();

        #region State

        switch (filter.HealthCentersState)
        {
            case HealthCentersState.All:
                break;
            case HealthCentersState.Accepted:
                query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.Accepted);
                break;
            case HealthCentersState.WaitingForConfirm:
                query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.WatingForConfirm);
                break;
            case HealthCentersState.Rejected:
                query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.Rejected);
                break;
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.Email))
        {
            query = query.Where(s => EF.Functions.Like(s.User.Email, $"%{filter.Email}%"));
        }

        if (!string.IsNullOrEmpty(filter.Mobile))
        {
            query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.Mobile}%"));
        }

        if (!string.IsNullOrEmpty(filter.FullName))
        {
            query = query.Where(s => s.User.Username.Contains(filter.FullName));
        }

        if (!string.IsNullOrEmpty(filter.NationalCode))
        {
            query = query.Where(s => s.User.NationalId.Contains(filter.NationalCode));
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    //Fill Health Center Info Detail ViewModel
    public async Task<HealthCenterInfoDetailViewModel?> FillHealthCenterInfoDetailViewModel(ulong userId)
    {
        #region Get Health Center By User Id 

        var healthCenter = await _healthCentersRepository.GetHealthCenterByUserIdAsQueryAble(userId)
                                                         .FirstOrDefaultAsync();
        if (healthCenter == null) return null;

        #endregion

        #region Get Health Center Info

        //Get Health Center Info By Id
        var info = await _healthCentersRepository.GetHealthCenterInfoByHealthCenterIdAsQueryAble(healthCenter.Id)
                                                 .FirstOrDefaultAsync();
        if (info == null) return null;

        #endregion

        #region Get Current Health Center Office

        var healthCenterOffice = await _organizationService.GetHealthCenterOrganizationByUserId(healthCenter.UserId);
        if (healthCenterOffice == null) return null;
        if (healthCenterOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Nurse) return null;

        #endregion

        #region Fill View Model

        HealthCenterInfoDetailViewModel model = new HealthCenterInfoDetailViewModel()
        {
            UserId = healthCenter.UserId,
            NationalCode = info.NationalCode,
            RejectDescription = healthCenterOffice.RejectDescription,
            HealthCenterInfosType= healthCenterOffice.OrganizationInfoState,
            Id = info.Id,
            HealthCenterId = healthCenter.Id,
        };

        #endregion

        #region Get Health Center Work Addresses

        model.WorkAddresses = await _workAddressRepository.GetUserWorkAddressesByUserId(healthCenter.UserId);

        #endregion

        return model;
    }

    //Edit HealthCenter Info From Admin Panel
    public async Task<EditHealthCenterInfoResult> EditHealthCenterInfoAdminSide(HealthCenterInfoDetailViewModel model)
    {
        #region Get HealthCenter Info By Id

        //Get HealthCenter Info By Id
        var info = await _healthCentersRepository.GetHealthCenterInfoByHealthCenterIdAsQueryAble(model.Id)
                                                 .FirstOrDefaultAsync();

        if (info == null) return EditHealthCenterInfoResult.faild;

        #endregion

        #region Get HealthCenter By Id 

        var healthCenter = await _healthCentersRepository.GetHealthCenterById(model.HealthCenterId)
                                                         .FirstOrDefaultAsync();

        if (healthCenter == null) return EditHealthCenterInfoResult.faild;

        #endregion

        #region Get Current HealthCenter Office

        var healthCenterOffice = await _organizationService.GetHealthCenterOrganizationByUserId(healthCenter.UserId);
        if (healthCenterOffice == null) return EditHealthCenterInfoResult.faild;
        if (healthCenterOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Nurse) return EditHealthCenterInfoResult.faild;

        #endregion

        #region Update Health Center

        healthCenterOffice.OrganizationInfoState = model.HealthCenterInfosType;
        healthCenterOffice.RejectDescription = model.RejectDescription;

        if (model.HealthCenterInfosType == OrganizationInfoState.Accepted)
        {
            healthCenterOffice.RejectDescription = null;
        }

        await _organizationService.UpdateOrganization(healthCenterOffice);

        #endregion

        #region Edit Health Center Info 

        #region Edit Properties

        info.NationalCode = model.NationalCode;

        #endregion

        #region Update Method

        _healthCentersRepository.UpdateHealthCenterInfo(info);
        await _healthCentersRepository.SaveChangesAsync();

        #endregion

        #endregion

        return EditHealthCenterInfoResult.success;
    }

    #endregion
}
