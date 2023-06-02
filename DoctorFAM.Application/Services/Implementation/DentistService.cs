#region Usings

using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Dentist;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Dentist.NavBar;
using DoctorFAM.Domain.ViewModels.Dentist.SideBar;


#endregion

namespace DoctorFAM.Application.Services.Implementation;

public class DentistService : IDentistService
{
	#region Ctor 

	private readonly IDentistRepoistory _dentistRepository;
    private readonly IOrganizationService _organizationService;

	public DentistService(IDentistRepoistory dentistRepoistory , IOrganizationService organizationService)
	{
		_dentistRepository= dentistRepoistory;
        _organizationService = organizationService;
	}

	#endregion

	#region Dentist Panel 

	//Is Exist Any Dentist By User Id
	public async Task<bool> IsExistAnyDentistByUserId(ulong userId)
	{
		return await _dentistRepository.IsExistAnyDentistByUserId(userId);
	}

    //Add Dentist For First Time
    public async Task AddDentistForFirstTime(ulong userId)
    {
        #region Dentist Entity

        #region Fill Dentist Model

        Dentist dentist = new Dentist()
        {
            UserId = userId,
            CreateDate = DateTime.Now,
            IsDelete = false,
        };

        #endregion

        #region Add Methods 

        await _dentistRepository.AddDentistWithoutSaveChanges(dentist);

        #endregion

        #endregion

        #region Organization Entity

        #region Fill Organization Model

        Organization organization = new Organization()
        {
            CreateDate = DateTime.Now,
            IsDelete = false,
            OrganizationInfoState = OrganizationInfoState.JustRegister,
            OrganizationType = Domain.Enums.Organization.OrganizationType.DentistOffice,
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

    //Fill Dentist NavBar Info 
    public async Task<DentistPanelNavNarViewModel?> FillDentistPanelNavNarViewModel(ulong userId)
    {
        return await _dentistRepository.FillDentistPanelNavNarViewModel(userId);
    }

    //Fill Dentist Side Bar Panel 
    public async Task<DentistSideBarViewModel> GetDentistSideBarInfo(ulong userId)
    {
        return await _dentistRepository.GetDentistSideBarInfo(userId);
    }

    #endregion
}
