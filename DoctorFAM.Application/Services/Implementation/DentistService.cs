#region Usings

using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Dentist;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Dentist.DentistsInfo;
using DoctorFAM.Domain.ViewModels.Dentist.NavBar;
using DoctorFAM.Domain.ViewModels.Dentist.SideBar;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;


#endregion

namespace DoctorFAM.Application.Services.Implementation;

public class DentistService : IDentistService
{
    #region Ctor 

    private readonly IDentistRepoistory _dentistRepository;
    private readonly IOrganizationService _organizationService;
    private readonly IUserService _userService;
    private readonly IWorkAddressService _workAddressService;

    public DentistService(IDentistRepoistory dentistRepoistory, IOrganizationService organizationService, IUserService userService
                            , IWorkAddressService workAddressService)
    {
        _dentistRepository = dentistRepoistory;
        _organizationService = organizationService;
        _userService = userService;
        _workAddressService = workAddressService;
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

    //Is Exist Any Dentist Info By UserId
    public async Task<bool> IsExistAnyDentistInfoByUserId(ulong userId)
    {
        return await _dentistRepository.IsExistAnyDentistInfoByUserId(userId);
    }

    //Get Doctors Information By UserId
    public async Task<DentistsInfo?> GetDentistsInformationByUserId(ulong userId)
    {
        return await _dentistRepository.GetDentistsInformationByUserId(userId);
    }

    //Fill Manage Dentists Info ViewModel
    public async Task<ManageDentistsInfoViewModel?> FillManageDentistsInfoViewModel(ulong userId)
    {
        #region Check Is User Exist 

        var user = await _userService.GetUserByIdWithAsNoTracking(userId);
        if (user == null) return null;

        #endregion

        #region Get Current Doctor Office

        var doctorOffice = await _organizationService.GetDentistOrganizationByUserId(userId);
        if (doctorOffice == null) return null;

        #endregion

        #region Get User Office Address

        var workAddress = await _workAddressService.GetUserWorkAddressByIdWithAsNoTracking(userId);

        #endregion

        #region Exist Dentist Information

        //Is Exist Dentist Informations
        if (await IsExistAnyDentistInfoByUserId(userId))
        {
            //Get Current Dentist Information
            var doctorInfo = await GetDentistsInformationByUserId(userId);

            //Fill Model For return Value
            ManageDentistsInfoViewModel model = new ManageDentistsInfoViewModel()
            {
                UserId = userId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DoctorsInfosType = doctorOffice.OrganizationInfoState,
                Education = doctorInfo.Education,
                MediacalFile = doctorInfo.MediacalFile,
                MedicalSystemCode = doctorInfo.MedicalSystemCode,
                NationalCode = doctorInfo.NationalCode,
                Gender = doctorInfo.Gender,
                RejectDescription = doctorOffice.RejectDescription,
                Specialty = doctorInfo.Specialty,
                ClinicPhone = doctorInfo.ClinicPhone,
                GeneralPhone = doctorInfo.GeneralPhone,
                FatherName = user.FatherName,
                username = user.Username,
                Mobile = user.Mobile,
                Email = user.Email,
                HomePhoneNumber = user.HomePhoneNumber,
                AvatarName = user.Avatar
            };

            if (user.BithDay != null && user.BithDay.HasValue)
            {
                model.BithDay = user.BithDay.Value.ToShamsi();
            }

            #region Get Doctor Skill By Doctor Id

            //if (doctorInfo != null)
            //{
            //    var doctorSkills = await _doctorRepository.GetListOfDoctorSkillsByDoctorId(doctorInfo.DoctorId);

            //    if (doctorSkills != null)
            //    {
            //        model.DoctorSkills = string.Join(",", doctorSkills.Select(p => p.DoctorSkil).ToList());
            //    }
            //}

            #endregion

            //Fill Doctor Cilinic Address
            if (workAddress != null)
            {
                model.WorkAddress = workAddress.Address;
                model.CountryId = workAddress.CountryId;
                model.StateId = workAddress.StateId;
                model.CityId = workAddress.CityId;
            }

            return model;
        }

        #endregion

        #region Not Exist Doctor Information

        else
        {
            //This Is First Time For Come in To This Action 
            ManageDentistsInfoViewModel model = new ManageDentistsInfoViewModel()
            {
                UserId = userId
            };

            return model;
        }

        #endregion

        return null;
    }

    #endregion
}
