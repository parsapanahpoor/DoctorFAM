using DoctorFAM.Application.DTOs.HealthCenters.HealthCentersInfos;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DosctorSideBarInfo;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Application.Services.Implementation;

public class HealthCentersService : IHealthCentersService
{
    #region Ctor

    private readonly IHealthCentersRepository _healthCentersRepository;

    public HealthCentersService(IHealthCentersRepository healthCentersRepository)
    {
        _healthCentersRepository = healthCentersRepository;
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

    #endregion
}
