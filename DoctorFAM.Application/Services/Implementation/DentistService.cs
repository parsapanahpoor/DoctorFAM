#region Usings

using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Dentist;
using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Dentist;
using DoctorFAM.Domain.ViewModels.Dentist.DentistsInfo;
using DoctorFAM.Domain.ViewModels.Dentist.Employees;
using DoctorFAM.Domain.ViewModels.Dentist.NavBar;
using DoctorFAM.Domain.ViewModels.Dentist.SideBar;
using DoctorFAM.Domain.ViewModels.Site;
using DoctorFAM.Domain.ViewModels.Site.Dentist;
using DoctorFAM.Domain.ViewModels.Site.Doctor;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Certificate;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Education;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Gallery;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Honor;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Service;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.WorkHistory;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.WorkingAddress;
using Microsoft.AspNetCore.Http;


#endregion

namespace DoctorFAM.Application.Services.Implementation;

public class DentistService : IDentistService
{
    #region Ctor 

    private readonly IDentistRepoistory _dentistRepository;
    private readonly IOrganizationService _organizationService;
    private readonly IUserService _userService;
    private readonly IWorkAddressService _workAddressService;
    private readonly ISiteSettingService _siteSetting;
    private readonly IReservationService _reservationService;
    private readonly ILocationRepository _locationRepository;
    private readonly IResumeService _resumeService;

    public DentistService(IDentistRepoistory dentistRepoistory, IOrganizationService organizationService, IUserService userService
                            , IWorkAddressService workAddressService, ISiteSettingService siteSetting, IReservationService reservationService , 
                                ILocationRepository locationRepository , IResumeService resumeService)
    {
        _dentistRepository = dentistRepoistory;
        _organizationService = organizationService;
        _userService = userService;
        _workAddressService = workAddressService;
        _siteSetting = siteSetting;
        _reservationService = reservationService;
        _locationRepository = locationRepository;
        _resumeService = resumeService;
    }

    #endregion

    #region Dentist Panel 

    //Add Or Edit Dentist Reservation Tariff Dentist Side 
    public async Task<DentistReservationTariffDentistPanelSideViewModelResult> AddOrEditDoctorReservationTariffDoctorSide(DentistReservationTariffDentistPanelSideViewModel inCommingModel)
    {
        #region Check Is User Exist 

        var user = await _userService.GetUserById(inCommingModel.DoctorUserId);

        if (user == null) return DentistReservationTariffDentistPanelSideViewModelResult.failure;

        #endregion

        #region Get Current Dentist Office

        var dentistOffice = await _organizationService.GetDentistOrganizationByUserId(inCommingModel.DoctorUserId);
        if (dentistOffice == null ) return DentistReservationTariffDentistPanelSideViewModelResult.failure;

        #endregion

        #region Add Or Edit Dentist Reservation Tariff

        //Get Dentist Reservation Tariff
        var tariffs = await _dentistRepository.GetDentistReservationTariffByDentistUserId(dentistOffice.OwnerId);

        #region Edit Dentist Organization State 

        dentistOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

        await _organizationService.UpdateOrganization(dentistOffice);

        #endregion

        #region Add For The First Time

        #region Check Tarrifs From Doctor By Site Percentages

        if (await _siteSetting.CheckDoctorInsertedTarrifBySiteInFieldInPersonReservationTariffForDoctorPopulationCovered(inCommingModel.InPersonReservationTariffForDoctorPopulationCovered))
        {
            return DentistReservationTariffDentistPanelSideViewModelResult.InpersonReservationPopluationCoveredLessThanSiteShare;
        }

        if (await _siteSetting.CheckDoctorInsertedTarrifBySiteInFieldOnlineReservationTariffForDoctorPopulationCovered(inCommingModel.OnlineReservationTariffForDoctorPopulationCovered))
        {
            return DentistReservationTariffDentistPanelSideViewModelResult.OnlineReservationPopluationCoveredLessThanSiteShare;
        }

        if (await _siteSetting.CheckDoctorInsertedTarrifBySiteInFieldInPersonReservationTariffForAnonymousPersons(inCommingModel.InPersonReservationTariffForAnonymousPersons))
        {
            return DentistReservationTariffDentistPanelSideViewModelResult.InpersonReservationAnonymousePersoneLessThanSiteShare;
        }

        if (await _siteSetting.CheckDoctorInsertedTarrifBySiteInFieldOnlineReservationTariffForAnonymousPersons(inCommingModel.OnlineReservationTariffForAnonymousPersons))
        {
            return DentistReservationTariffDentistPanelSideViewModelResult.OnlineReservationAnonymousePersoneLessThanSiteShare;
        }

        #endregion

        if (tariffs == null)
        {
            //Create Instance
            DoctorsReservationTariffs model = new DoctorsReservationTariffs()
            {
                DoctorUserId = dentistOffice.OwnerId,
                InPersonReservationTariffForAnonymousPersons = inCommingModel.InPersonReservationTariffForAnonymousPersons,
                InPersonReservationTariffForDoctorPopulationCovered = inCommingModel.InPersonReservationTariffForDoctorPopulationCovered,
                OnlineReservationTariffForAnonymousPersons = inCommingModel.OnlineReservationTariffForAnonymousPersons,
                OnlineReservationTariffForDoctorPopulationCovered = inCommingModel.OnlineReservationTariffForDoctorPopulationCovered
            };

            //Add Data To The Data Base 
            await _dentistRepository.AddDentistsReservationTariffToTheDataBase(model);
        }

        #endregion

        #region Edit Reservation Tarrif 

        if (tariffs != null)
        {
            tariffs.InPersonReservationTariffForAnonymousPersons = inCommingModel.InPersonReservationTariffForAnonymousPersons;
            tariffs.InPersonReservationTariffForDoctorPopulationCovered = inCommingModel.InPersonReservationTariffForDoctorPopulationCovered;
            tariffs.OnlineReservationTariffForAnonymousPersons = inCommingModel.OnlineReservationTariffForAnonymousPersons;
            tariffs.OnlineReservationTariffForDoctorPopulationCovered = inCommingModel.OnlineReservationTariffForDoctorPopulationCovered;

            //Update Dentist Reservation Tariffs
            await _dentistRepository.UpdateDentistReservationTariffs(tariffs);
        }

        #endregion

        #endregion

        return DentistReservationTariffDentistPanelSideViewModelResult.success;
    }

    //Fill Dentist Reservation Tariff Dentist Panel Side ViewModel
    public async Task<DentistReservationTariffDentistPanelSideViewModel?> FillDentistReservationTariffDentistPanelSideViewModel(ulong userId)
    {
        #region Check Is User Exist 

        var user = await _userService.GetUserById(userId);

        if (user == null) return null;

        #endregion

        #region Get Current Dentist Office

        var dentistOffice = await _organizationService.GetDentistOrganizationOwnerIdByUserId(userId);
        if (dentistOffice == null || dentistOffice == 0) return null;

        #endregion

        #region Fill Return Model

        //Get Doctor Reservation Tariff
        var tariffs = await _dentistRepository.GetDentistReservationTariffByDentistUserId(dentistOffice);

        #region For The First Time

        if (tariffs == null)
        {
            DentistReservationTariffDentistPanelSideViewModel returnModel = new DentistReservationTariffDentistPanelSideViewModel()
            {
                DoctorUserId = dentistOffice,
                OnlineReservationTariffForDoctorPopulationCovered = await _siteSetting.GetOnlineReservationTariffForDoctorPopulationCoveredSiteShare() + 1000,
                InPersonReservationTariffForDoctorPopulationCovered = await _siteSetting.GetInPersonReservationTariffForDoctorPopulationCoveredSiteShare() + 1000,
            };

            return returnModel;
        }

        #endregion

        #region After First Time 

        if (tariffs != null)
        {
            DentistReservationTariffDentistPanelSideViewModel returnModel = new DentistReservationTariffDentistPanelSideViewModel()
            {
                DoctorUserId = dentistOffice,
                InPersonReservationTariffForAnonymousPersons = tariffs.InPersonReservationTariffForAnonymousPersons,
                InPersonReservationTariffForDoctorPopulationCovered = tariffs.InPersonReservationTariffForDoctorPopulationCovered,
                OnlineReservationTariffForAnonymousPersons = tariffs.OnlineReservationTariffForAnonymousPersons,
                OnlineReservationTariffForDoctorPopulationCovered = tariffs.OnlineReservationTariffForDoctorPopulationCovered
            };

            return returnModel;
        }

        #endregion

        #endregion

        return null;
    }

    //Add Exist User To The Dentist Organization 
    public async Task<bool> AddExistUserToTheDentistOrganization(ulong userId, ulong doctorId)
    {
        #region Check Is Exist Any User By This User Id

        var user = await _userService.GetUserById(userId);
        if (user == null) return false;

        #endregion

        #region Check That Has User Any Organization 

        var userOrganization = await _organizationService.GetOrganizationByUserId(userId);
        if (userOrganization != null) return false;

        #endregion

        #region Get Current Doctor Organization

        var organization = await _organizationService.GetDentistOrganizationByUserId(doctorId);
        if (organization == null) return false;

        #endregion

        #region Add User To The Doctor Organization 

        #region Add New Organization Member

        OrganizationMember member = new OrganizationMember()
        {
            UserId = user.Id,
            OrganizationId = organization.Id
        };

        await _organizationService.AddOrganizationMember(member);

        #endregion

        #region Add User Role

        UserRole userRole = new UserRole()
        {
            RoleId = 20,
            UserId = user.Id,
        };

        await _userService.AddUserRole(userRole);

        #endregion

        #endregion

        return true;
    }

    //Filter Dentist Office Employees 
    public async Task<FilterDentistOfficeEmployeesViewmodel> FilterDentistOfficeEmployees(FilterDentistOfficeEmployeesViewmodel filter)
    {
        return await _dentistRepository.FilterDentistOfficeEmployees(filter);
    }

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

            #region Get Dentist Skill By Doctor Id

            if (doctorInfo != null)
            {
                var dentistSkills = await _dentistRepository.GetListOfDentistSkillsByDentistUserId(doctorInfo.UserId);

                if (dentistSkills != null) model.DoctorSkills = string.Join(",", dentistSkills.Select(p => p.DentistSkill).ToList());
            }

            #endregion

            //Fill Dentist Cilinic Address
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

        #region Not Exist Dentist Information

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
    }

    //Get Dentist Id By User Id
    public async Task<ulong> GetDentistIdByUserId(ulong userId)
    {
        return await _dentistRepository.GetDentistIdByUserId(userId);
    }

    //Get List Of Dentist Skills By Dentist Id
    public async Task<List<DentistsSkills>> GetListOfDentistSkillsByDentistUserId(ulong dentistUserID)
    {
        return await _dentistRepository.GetListOfDentistSkillsByDentistUserId(dentistUserID);
    }

    //Add Or Edit Dentist Info Dentist Panel 
    public async Task<AddOrEditDentitstInfoResult> AddOrEditDentistInfoDentistsPanel(ManageDentistsInfoViewModel model, IFormFile? MediacalFile, IFormFile? UserAvatar)
    {
        #region Get User By User Id

        var user = await _userService.GetUserById(model.UserId);

        if (user == null) return AddOrEditDentitstInfoResult.Faild;
        if (model.UserId != model.UserId) return AddOrEditDentitstInfoResult.Faild;
        if (UserAvatar != null && !UserAvatar.IsImage())return AddOrEditDentitstInfoResult.NotValidImage;
        if (UserAvatar != null)
        {
            if (!string.IsNullOrEmpty(user.Avatar))
            {
                user.Avatar.DeleteImage(PathTools.UserAvatarPathServer, PathTools.UserAvatarPathThumbServer);
            }

            var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(UserAvatar.FileName);
            UserAvatar.AddImageToServer(imageName, PathTools.UserAvatarPathServer, 270, 270, PathTools.UserAvatarPathThumbServer);
            user.Avatar = imageName;
        }
        if (!string.IsNullOrEmpty(model.Email))
        {
            if (!await _userService.IsValidEmailForUserEditByAdmin(model.Email, user.Id))
            {
                return AddOrEditDentitstInfoResult.NotValidEmail;
            }
        }
        if (string.IsNullOrEmpty(model.NationalCode))
        {
            return AddOrEditDentitstInfoResult.NationalId;
        }
        if (!string.IsNullOrEmpty(model.NationalCode) && !await _userService.IsValidNationalIdForUserEditByAdmin(model.NationalCode, user.Id))
        {
            return AddOrEditDentitstInfoResult.NotValidNationalId;
        }

        #endregion

        #region Get Current Dentist Office

        var doctorOffice = await _organizationService.GetDentistOrganizationByUserId(model.UserId);
        if (doctorOffice == null) return AddOrEditDentitstInfoResult.Faild;

        #endregion

        #region Get Dentist By User Id 

        //Get Dentist By UserId
        var dentist = await GetDentistIdByUserId(user.Id);

        #endregion

        #region Is Exist Informations

        var existInfo = await IsExistAnyDentistInfoByUserId(model.UserId);

        #endregion

        #region Image Not Found 

        if (existInfo == false && MediacalFile == null) return AddOrEditDentitstInfoResult.FileNotUploaded;

        if (MediacalFile != null && !MediacalFile.IsImage()) return AddOrEditDentitstInfoResult.FileNotUploaded;

        #endregion

        #region Edit Info

        if (existInfo == true)
        {
            #region Update Properties

            //Get Dentist Informations By Doctor Id
            var info = await GetDentistsInformationByUserId(model.UserId);

            //Edit Properties 
            info.Specialty = model.Specialty.SanitizeText();
            info.Education = model.Education.SanitizeText();
            info.NationalCode = model.NationalCode;
            info.MedicalSystemCode = model.MedicalSystemCode;
            info.Gender = model.Gender;
            info.GeneralPhone = model.GeneralPhone;
            info.ClinicPhone = model.ClinicPhone;

            //Update Doctor Office State 
            doctorOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

            #region Update User

            user.FirstName = model.FirstName.SanitizeText();
            user.LastName = model.LastName.SanitizeText();
            user.FatherName = model.FatherName.SanitizeText();
            user.Email = model.Email.SanitizeText();
            user.BithDay = model.BithDay.ToMiladiDateTime();
            user.NationalId = model.NationalCode.SanitizeText();
            user.ExtraPhoneNumber = model.GeneralPhone.SanitizeText();
            user.Username = model.username;
            user.HomePhoneNumber = model.HomePhoneNumber;

            await _userService.UpdateUserWithoutSaveChanges(user);

            #endregion

            #endregion

            #region Medical File 

            if (MediacalFile != null)
            {
                if (!string.IsNullOrEmpty(info.MediacalFile))
                {
                    info.MediacalFile.DeleteImage(PathTools.MediacalFilePathServer, PathTools.MediacalFilePathThumbServer);
                }

                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(MediacalFile.FileName);
                MediacalFile.AddImageToServer(imageName, PathTools.MediacalFilePathServer, 270, 270, PathTools.MediacalFilePathThumbServer);
                info.MediacalFile = imageName;
            }

            #endregion

            #region Update Doctor Address

            var doctorAddress = await _workAddressService.GetUserWorkAddressByIdWithAsNoTracking(model.UserId);

            if (doctorAddress != null && !string.IsNullOrEmpty(model.WorkAddress))
            {
                doctorAddress.Address = model.WorkAddress;
                doctorAddress.CountryId = model.CountryId.Value;
                doctorAddress.StateId = model.StateId.Value;
                doctorAddress.CityId = model.CityId.Value;

                await _workAddressService.UpdateUserWorkAddressWithoutSaveChanges(doctorAddress);
            }

            if (doctorAddress == null && !string.IsNullOrEmpty(model.WorkAddress))
            {
                WorkAddress workAddress = new WorkAddress()
                {
                    Address = model.WorkAddress,
                    CountryId = model.CountryId.Value,
                    CityId = model.CityId.Value,
                    StateId = model.StateId.Value,
                    UserId = model.UserId,
                    CreateDate = DateTime.Now,
                };

                await _workAddressService.AddWorkAddressWithoutSaveChanges(workAddress);
            }

            #endregion

            #region Dentist Selected Skils

            var doctorSkills = await GetListOfDentistSkillsByDentistUserId(model.UserId);

            if (doctorSkills.Any())
            {
                 _dentistRepository.RemoveDentistSkillsWithoutSaveChanges(doctorSkills);
            }

            if (!string.IsNullOrEmpty(model.DoctorSkills))
            {
                var skills = model.DoctorSkills.Split(',').ToList();

                foreach (var item in skills)
                {
                    var skill = new DentistsSkills
                    {
                        UserId = model.UserId,
                        DentistSkill = item
                    };
                    await _dentistRepository.AddDentistSkillsWithoutSaveChanges(skill);
                }
            }

            #endregion

            #region Update Methods

            _dentistRepository.UpdateDentistInfosWithoutSaveChanges(info);

            //The Last Save Changes In This Method 
            await _organizationService.UpdateOrganization(doctorOffice);

            #endregion
        }

        #endregion

        #region Add Info

        if (existInfo == false)
        {
            if (dentist != null || dentist != 0)
            {
                #region Fill View Model

                DentistsInfo manageDentistsInfoViewModel1 = new DentistsInfo()
                {
                    DentistId = dentist,
                    UserId = model.UserId,
                    Education = model.Education.SanitizeText(),
                    MedicalSystemCode = model.MedicalSystemCode,
                    NationalCode = model.NationalCode,
                    Specialty = model.Specialty.SanitizeText(),
                    Gender = model.Gender,
                    GeneralPhone = model.GeneralPhone,
                    ClinicPhone = model.ClinicPhone,
                    CountOFFreeSMSForDoctors = await _dentistRepository.GetDentistsFreeSMSCount()
                };

                #endregion

                #region Update User Infos 

                user.FatherName = model.FatherName.SanitizeText();
                user.Email = model.Email.SanitizeText();
                user.BithDay = model.BithDay.ToMiladiDateTime();
                user.NationalId = model.NationalCode.SanitizeText();
                user.ExtraPhoneNumber = model.GeneralPhone.SanitizeText();
                user.Username = model.username;
                user.HomePhoneNumber = model.HomePhoneNumber;

                await _userService.UpdateUserWithoutSaveChanges(user);

                #endregion

                #region Medical File 

                if (MediacalFile != null)
                {
                    var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(MediacalFile.FileName);
                    MediacalFile.AddImageToServer(imageName, PathTools.MediacalFilePathServer, 270, 270, PathTools.MediacalFilePathThumbServer);
                    manageDentistsInfoViewModel1.MediacalFile = imageName;
                }

                #endregion

                #region Add Doctor Address

                if (model.WorkAddress != null)
                {
                    WorkAddress workAddress = new WorkAddress()
                    {
                        Address = model.WorkAddress,
                        CountryId = model.CountryId.Value,
                        CityId = model.CityId.Value,
                        StateId = model.StateId.Value,
                        UserId = model.UserId,
                        CreateDate = DateTime.Now,
                    };

                    await _workAddressService.AddWorkAddressWithoutSaveChanges(workAddress);
                }

                #endregion

                #region Update Dentist Office

                doctorOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

                #endregion

                #region Doctor Selected Skils

                if (!string.IsNullOrEmpty(model.DoctorSkills))
                {
                    var skills = model.DoctorSkills.Split(',').ToList();

                    foreach (var item in skills)
                    {
                        var skill = new DentistsSkills
                        {
                            UserId = model.UserId,
                            DentistSkill = item
                        };
                        await _dentistRepository.AddDentistSkillsWithoutSaveChanges(skill);
                    }
                }

                #endregion

                #region Update Methods

                await _dentistRepository.AddDentistInfoWithoutSaveChanges(manageDentistsInfoViewModel1);

                //Last Save Changes 
                await _organizationService.UpdateOrganization(doctorOffice);

                #endregion
            }
            else
            {
                #region Add Dentist

                Dentist newDentist = new Dentist()
                {
                    CreateDate = DateTime.Now,
                    UserId = user.Id,
                    IsDelete = false
                };

                var newDentistId = await _dentistRepository.AddDentist(newDentist);

                #endregion

                #region Add Dentist Address

                if (model.WorkAddress != null)
                {
                    WorkAddress workAddress = new WorkAddress()
                    {
                        Address = model.WorkAddress,
                        CountryId = model.CountryId.Value,
                        CityId = model.CityId.Value,
                        StateId = model.StateId.Value,
                        UserId = model.UserId,
                        CreateDate = DateTime.Now,
                    };

                    await _workAddressService.AddWorkAddressWithoutSaveChanges(workAddress);
                }

                #endregion

                #region Organization Entity

                #region Fill Organization Model

                Organization organization = new Organization()
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    OrganizationInfoState = OrganizationInfoState.JustRegister,
                    OrganizationType = Domain.Enums.Organization.OrganizationType.DentistOffice,
                    OwnerId = model.UserId,
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
                    UserId = model.UserId,
                };

                #endregion

                #region Add Organization Member

                await _organizationService.AddOrganizationMember(member);

                #endregion

                #endregion

                #region Fill View Model

                DentistsInfo manageDentistsInfoViewModel = new DentistsInfo()
                {
                    DentistId = newDentist.Id,
                    UserId = model.UserId,
                    Education = model.Education.SanitizeText(),
                    MedicalSystemCode = model.MedicalSystemCode,
                    NationalCode = model.NationalCode,
                    Specialty = model.Specialty.SanitizeText(),
                    GeneralPhone = model.GeneralPhone,
                    ClinicPhone = model.ClinicPhone,
                    CountOFFreeSMSForDoctors = await _dentistRepository.GetDentistsFreeSMSCount()
                };

                #endregion

                #region Update User Info 

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.FatherName = model.FatherName.SanitizeText();
                user.Email = model.Email.SanitizeText();
                user.BithDay = model.BithDay.ToMiladiDateTime();
                user.NationalId = model.NationalCode.SanitizeText();
                user.ExtraPhoneNumber = model.GeneralPhone.SanitizeText();
                user.Username = model.username;
                user.HomePhoneNumber = model.HomePhoneNumber;

                await _userService.UpdateUserWithoutSaveChanges(user);

                #endregion

                #region Medical File 

                if (MediacalFile != null)
                {
                    var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(MediacalFile.FileName);
                    MediacalFile.AddImageToServer(imageName, PathTools.MediacalFilePathServer, 270, 270, PathTools.MediacalFilePathThumbServer);
                    manageDentistsInfoViewModel.MediacalFile = imageName;
                }

                #endregion

                #region Doctor Selected Skils

                if (!string.IsNullOrEmpty(model.DoctorSkills))
                {
                    var skills = model.DoctorSkills.Split(',').ToList();

                    foreach (var item in skills)
                    {
                        var skill = new DentistsSkills
                        {
                            UserId = model.UserId,
                            DentistSkill = item
                        };
                        await _dentistRepository.AddDentistSkillsWithoutSaveChanges(skill);
                    }
                }

                #endregion

                #region Update Methods

                await _dentistRepository.AddDentistInfoWithoutSaveChanges(manageDentistsInfoViewModel);
                await _dentistRepository.SaveChanges();

                #endregion
            }
        }

        #endregion

        return AddOrEditDentitstInfoResult.Success;
    }

    #endregion

    #region Admin Side 

    //Get List Of Dentist For Show Admin Panel 
    public async Task<List<ListOfDentistAdminSideViewModel>?> GetListOfDentistForShowAdminPanel()
    {
        return await _dentistRepository.GetListOfDentistForShowAdminPanel();
    }

    //Get Dentist Reservation Tariff By User Id 
    public async Task<DoctorsReservationTariffs?> GetDentistReservationTariffByDentistUserId(ulong DentistUserId)
    {
        return await _dentistRepository.GetDentistReservationTariffByDentistUserId(DentistUserId);
    }

    //Fill Dentists Info Detail View Model
    public async Task<DentistsInfoDetailViewModel?> FillDentistsInfoDetailViewModel(ulong userId)
    {
        #region Get Dentist Info

        //Get Dentist Info By Id
        var info = await _dentistRepository.GetDentistsInformationByUserId(userId);
        if (info == null) return null;

        #endregion

        #region Get Dentist Info

        var dentistId = await GetDentistIdByUserId(info.UserId);
        if (dentistId == 0) return null;

        #endregion

        #region Get Current Dentist Office

        var dentistOffice = await _organizationService.GetDentistOrganizationByUserId(info.UserId);
        if (dentistOffice == null) return null;

        #endregion

        #region Get Dentist Skill By Doctor Id

        var dentistSkills = await _dentistRepository.GetListOfDentistSkillsByDentistUserId(info.UserId);

        #endregion

        #region Fill View Model

        DentistsInfoDetailViewModel model = new DentistsInfoDetailViewModel()
        {
            UserId = info.UserId,
            NationalCode = info.NationalCode,
            MedicalSystemCode = info.MedicalSystemCode,
            Education = info.Education,
            Specialty = info.Specialty,
            MediacalFile = info.MediacalFile,
            RejectDescription = dentistOffice.RejectDescription,
            DoctorsInfosType = dentistOffice.OrganizationInfoState,
            Id = info.Id,
            DentistId = dentistId,
            Gender = info.Gender,
            GeneralPhone = info.GeneralPhone,
            ClinicPhone = info.ClinicPhone,
            DoctorSkills = string.Join(",", dentistSkills.Select(p => p.DentistSkill).ToList()),
            CountOFFreeSMSForDoctors = info.CountOFFreeSMSForDoctors
        };

        #endregion

        #region Get Dentist Work Addresses

        model.WorkAddresses = await _workAddressService.GetUserWorkAddressesByUserId(info.UserId);

        #endregion

        #region Get Doctor Reservation Tariff By doctor UserId

        var reservationTariff = await GetDentistReservationTariffByDentistUserId(dentistOffice.OwnerId);

        if (reservationTariff != null)
        {
            model.InPersonReservationTariffForDoctorPopulationCovered = reservationTariff.InPersonReservationTariffForDoctorPopulationCovered;
            model.OnlineReservationTariffForDoctorPopulationCovered = reservationTariff.OnlineReservationTariffForDoctorPopulationCovered;
            model.InPersonReservationTariffForAnonymousPersons = reservationTariff.InPersonReservationTariffForAnonymousPersons;
            model.OnlineReservationTariffForAnonymousPersons = reservationTariff.OnlineReservationTariffForAnonymousPersons;
        }
        else
        {
            model.InPersonReservationTariffForDoctorPopulationCovered = null;
            model.OnlineReservationTariffForDoctorPopulationCovered = null;
            model.InPersonReservationTariffForAnonymousPersons = null;
            model.OnlineReservationTariffForAnonymousPersons = null;
        }

        #endregion

        return model;
    }

    //Edit Doctor Info Admin Side
    public async Task<EditDentistInfoResult> EditDoctorInfoAdminSide(DentistsInfoDetailViewModel model, IFormFile? MediacalFile)
    {
        #region Get User By User Id

        var user = await _userService.GetUserById(model.UserId);

        if (user == null) return EditDentistInfoResult.faild;
        if (string.IsNullOrEmpty(model.NationalCode))return EditDentistInfoResult.NationalId;
        if (!string.IsNullOrEmpty(model.NationalCode) && !await _userService.IsValidNationalIdForUserEditByAdmin(model.NationalCode, user.Id))
        {
            return EditDentistInfoResult.NationalId;
        }

        #endregion

        #region Get Dentist Info By Id

        //Get Dentist Info By Id
        var info = await _dentistRepository.GetDentistsInformationByUserId(model.UserId);
        if (info == null) return EditDentistInfoResult.faild;

        #endregion

        #region Get Dentist By Id 

        var dentistId = await GetDentistIdByUserId(model.UserId);

        #endregion

        #region Get Current Dentist Office

        var dentistOffice = await _organizationService.GetDentistOrganizationByUserId(model.UserId);
        if (dentistOffice == null) return EditDentistInfoResult.faild;

        #endregion

        #region Update Doctor 

        dentistOffice.OrganizationInfoState = model.DoctorsInfosType;
        dentistOffice.RejectDescription = model.RejectDescription;

        if (model.DoctorsInfosType == OrganizationInfoState.Accepted)
        {
            dentistOffice.RejectDescription = null;
        }

        await _organizationService.UpdateOrganization(dentistOffice);

        #endregion

        #region Edit Doctor Info 

        #region Edit Properties

        info.MedicalSystemCode = model.MedicalSystemCode;
        info.Specialty = model.Specialty;
        info.Education = model.Education;
        info.NationalCode = model.NationalCode;
        info.Gender = model.Gender;
        info.GeneralPhone = model.GeneralPhone;
        info.ClinicPhone = model.ClinicPhone;
        info.CountOFFreeSMSForDoctors = model.CountOFFreeSMSForDoctors;

        #endregion

        #region Update User

        user.NationalId = model.NationalCode.SanitizeText();
        user.ExtraPhoneNumber = model.GeneralPhone.SanitizeText();

        await _userService.UpdateUser(user);

        #endregion

        #region Doctor Selected Skils

        var doctorSkills = await GetListOfDentistSkillsByDentistUserId(model.UserId);

        if (doctorSkills.Any())
        {
             _dentistRepository.RemoveDentistSkillsWithoutSaveChanges(doctorSkills);
        }

        if (!string.IsNullOrEmpty(model.DoctorSkills))
        {
            var skills = model.DoctorSkills.Split(',').ToList();

            foreach (var item in skills)
            {
                var skill = new DentistsSkills
                {
                    UserId = model.UserId,
                    DentistSkill = item
                };
                await _dentistRepository.AddDentistSkillsWithoutSaveChanges(skill);
            }
        }

        #endregion

        #region Edit Medical File 

        if (MediacalFile != null)
        {
            if (!string.IsNullOrEmpty(info.MediacalFile))
            {
                info.MediacalFile.DeleteImage(PathTools.MediacalFilePathServer, PathTools.MediacalFilePathThumbServer);
            }

            var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(MediacalFile.FileName);
            MediacalFile.AddImageToServer(imageName, PathTools.MediacalFilePathServer, 270, 270, PathTools.MediacalFilePathThumbServer);
            info.MediacalFile = imageName;
        }

        #endregion

        #region Update Method

         _dentistRepository.UpdateDentistInfosWithoutSaveChanges(info);
        await _dentistRepository.SaveChanges();

        #endregion

        #region Edit Dentist Reservation Tariff

        if (model.InPersonReservationTariffForDoctorPopulationCovered.HasValue && await _siteSetting.CheckDoctorInsertedTarrifBySiteInFieldInPersonReservationTariffForDoctorPopulationCovered(model.InPersonReservationTariffForDoctorPopulationCovered.Value))
        {
            return EditDentistInfoResult.InpersonReservationPopluationCoveredLessThanSiteShare;
        }

        if (model.OnlineReservationTariffForDoctorPopulationCovered.HasValue && await _siteSetting.CheckDoctorInsertedTarrifBySiteInFieldOnlineReservationTariffForDoctorPopulationCovered(model.OnlineReservationTariffForDoctorPopulationCovered.Value))
        {
            return EditDentistInfoResult.OnlineReservationPopluationCoveredLessThanSiteShare;
        }

        if (model.InPersonReservationTariffForAnonymousPersons.HasValue && await _siteSetting.CheckDoctorInsertedTarrifBySiteInFieldInPersonReservationTariffForAnonymousPersons(model.InPersonReservationTariffForAnonymousPersons.Value))
        {
            return EditDentistInfoResult.InpersonReservationAnonymousePersoneLessThanSiteShare;
        }

        if (model.OnlineReservationTariffForAnonymousPersons.HasValue && await _siteSetting.CheckDoctorInsertedTarrifBySiteInFieldOnlineReservationTariffForAnonymousPersons(model.OnlineReservationTariffForAnonymousPersons.Value))
        {
            return EditDentistInfoResult.OnlineReservationAnonymousePersoneLessThanSiteShare;
        }

        //Get Doctor Reservation Tariff
        var reservation = await GetDentistReservationTariffByDentistUserId(dentistOffice.OwnerId);
        if (reservation != null)
        {
            reservation.InPersonReservationTariffForDoctorPopulationCovered = model.InPersonReservationTariffForDoctorPopulationCovered.Value;
            reservation.OnlineReservationTariffForDoctorPopulationCovered = model.OnlineReservationTariffForDoctorPopulationCovered.Value;
            reservation.OnlineReservationTariffForAnonymousPersons = model.OnlineReservationTariffForAnonymousPersons.Value;
            reservation.InPersonReservationTariffForAnonymousPersons = model.InPersonReservationTariffForAnonymousPersons.Value;

            //Update Reservation Data 
            await _dentistRepository.UpdateDentistReservationTariffs(reservation);
        }

        #endregion

        #endregion

        return EditDentistInfoResult.success;
    }

    #endregion

    #region Site Side 

    //List Of Dentist Site Side 
    public async Task<List<ListOfDentistShowSiteSideViewModel>> ListOfDentistSiteSide()
    {
        return await _dentistRepository.ListOfDentistSiteSide();
    }

    //Fill Dentist Reservation Detail For Show Site Side View Model
    public async Task<ShowDentistReservationDetailViewModel?> FillDentistReservationDetailForShowSiteSide(ulong userId, string? loggedDateTime)
    {
        #region Get Doctor User By User Id

        User user = await _userService.GetUserById(userId);
        if (user == null) { return null; }

        #endregion

        #region Validate Doctor 

        var organization = await _organizationService.GetOrganizationByUserId(userId);
        if (organization == null) return null;
        if (organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DentistOffice) return null;
        if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return null;

        #endregion

        #region Get Doctor Personal Info 

        var doctorPersonalInfo = await _dentistRepository.GetDentistsInformationByUserId(user.Id);
        if (doctorPersonalInfo == null) return null;

        #endregion

        #region Fill Model 

        ShowDentistReservationDetailViewModel model = new ShowDentistReservationDetailViewModel()
        {
            UserId = userId,
            LoggedDateTime = loggedDateTime,
            DoctorReservationDate = ((!string.IsNullOrEmpty(loggedDateTime) ? await _reservationService.GetDoctorReservationDateByReservationDateAndUserId(loggedDateTime, userId) : null)),
            DoctorReservationDateTimes = ((!string.IsNullOrEmpty(loggedDateTime) ? await _reservationService.GetDoctorReservationDateByReservationDateTimeAndUserId(loggedDateTime, userId) : null)),
            ListOfReservationDateAndReservationDateTime = await _reservationService.GetListOfDoctorReservationDateAndDoctorReservationDateTimeForShowSiteSide(organization.OwnerId)
        };

        DoctorPageInReservationViewModel childModel = new DoctorPageInReservationViewModel()
        {
            UserId = userId,
            Username = user.Username,
            UserAvatar = user.Avatar,
            Education = doctorPersonalInfo.Education,
            Specialist = doctorPersonalInfo.Specialty,
        };

        model.DoctorPageInReservationViewModel = childModel;

        #endregion

        return model;
    }

    //Fill Dentist Page In Reservation Page 
    public async Task<DentistPageInReservationViewModel?> FillDentistPageDetailInReservationPage(ulong userId)
    {
        #region Get Doctor User By User Id

        User user = await _userService.GetUserById(userId);
        if (user == null) { return null; }

        #endregion

        #region Validate Doctor 

        var organization = await _organizationService.GetOrganizationByUserId(userId);
        if (organization == null) return null;
        if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return null;

        #endregion

        #region Get Doctor Personal Info 

        var doctorPersonalInfo = await _dentistRepository.GetDentistsInformationByUserId(user.Id);
        if (doctorPersonalInfo == null) return null;

        #endregion

        #region Fill Model 

        DentistPageInReservationViewModel model = new DentistPageInReservationViewModel()
        {
            UserId = userId,
            Username = user.Username,
            UserAvatar = user.Avatar,
            Education = doctorPersonalInfo.Education,
            Specialist = doctorPersonalInfo.Specialty,
        };

        #endregion

        #region Get User Office Address

        var workAddress = await _workAddressService.GetUserWorkAddressByIdWithAsNoTracking(userId);

        if (workAddress != null)
        {
            var country = await _locationRepository.GetLocationById(workAddress.CountryId);
            if (country == null) return null;

            var state = await _locationRepository.GetLocationById(workAddress.StateId);
            if (state == null) return null;

            var city = await _locationRepository.GetLocationById(workAddress.CityId);
            if (city == null) return null;

            model.CountryName = country.UniqueName;
            model.StateName = state.UniqueName;
            model.CityName = city.UniqueName;
            model.WorkAddress = workAddress.Address;
        }

        #endregion

        #region Get Resume By Id

        var resume = await _resumeService.GetResumeByUserId(organization.OwnerId);
        if (resume != null)
        {
            model.Resume = resume;
        }

        #endregion

        #region Fill Resume Model 

        if (resume != null)
        {
            #region Fill User Property 

            model.User = user;

            #endregion

            #region Fill About Me 

            var aboutMe = await _resumeService.GetUserAboutMeResumeByResumeId(resume.Id);

            //Create New Instance 
            model.ResumeAboutMeSitePanelViewModel = new ResumeAboutMeSitePanelViewModel()
            {
                AboutMeId = ((aboutMe == null) ? null : aboutMe.Id),
                Text = ((aboutMe == null) ? null : aboutMe.AboutMeText),
                ResumeId = resume.Id,
            };

            #endregion

            #region Fill Education 

            var education = await _resumeService.GetEducationResumeByResumeId(resume.Id);

            var returnEducation = new List<EducationResumeInSitePanelViewModel>();

            //Create New Instance
            if (education != null && education.Any())
            {
                foreach (var item in education)
                {
                    EducationResumeInSitePanelViewModel ed = (new EducationResumeInSitePanelViewModel()
                    {
                        CityName = ((string.IsNullOrEmpty(item.CityName)) ? null : item.CityName),
                        CountryName = ((string.IsNullOrEmpty(item.CountryName)) ? null : item.CountryName),
                        EndDate = ((item.EndDate == null) ? null : item.EndDate),
                        FieldOfStudy = ((string.IsNullOrEmpty(item.FieldOfStudy)) ? null : item.FieldOfStudy),
                        Orientation = ((string.IsNullOrEmpty(item.Orientation)) ? null : item.Orientation),
                        StartDate = ((item.StartDate == null) ? null : item.StartDate),
                        UnivercityName = ((string.IsNullOrEmpty(item.UnivercityName)) ? null : item.UnivercityName),
                        CreateDate = item.CreateDate,
                        Id = item.Id,
                    });

                    returnEducation.Add(ed);
                }
            }

            model.EducationResume = returnEducation;

            #endregion

            #region Fill Work Address

            var workHistory = await _resumeService.GetWorkHistoryResumeByResumeId(resume.Id);

            var returnWorkHistory = new List<WorkHistoryResumeInSitePanelViewModel>();

            //Create New Instance
            if (workHistory != null && workHistory.Any())
            {
                foreach (var item in workHistory)
                {
                    WorkHistoryResumeInSitePanelViewModel work = (new WorkHistoryResumeInSitePanelViewModel()
                    {
                        WorkAddress = ((string.IsNullOrEmpty(item.WorkAddress)) ? null : item.WorkAddress),
                        JobPosition = ((string.IsNullOrEmpty(item.JobPosition)) ? null : item.JobPosition),
                        EndDate = ((item.EndDate == null) ? null : item.EndDate),
                        StartDate = ((item.StartDate == null) ? null : item.StartDate),
                        Id = item.Id,
                    });

                    returnWorkHistory.Add(work);
                }
            }

            model.WorkHistoryResume = returnWorkHistory;

            #endregion

            #region Fill Honor

            var honor = await _resumeService.GetHonorResumeByResumeId(resume.Id);

            var returnHonor = new List<HonorResumeInSitePanelViewModel>();

            //Create New Instance
            if (honor != null && honor.Any())
            {
                foreach (var item in honor)
                {
                    HonorResumeInSitePanelViewModel hr = (new HonorResumeInSitePanelViewModel()
                    {
                        HonorTitle = ((string.IsNullOrEmpty(item.HonorTitle)) ? null : item.HonorTitle),
                        ImageName = ((string.IsNullOrEmpty(item.ImageName)) ? null : item.ImageName),
                        Description = ((string.IsNullOrEmpty(item.Description)) ? null : item.Description),
                        HonorDate = item.HonorDate,
                        Id = item.Id,
                    });

                    returnHonor.Add(hr);
                }
            }

            model.HonorResume = returnHonor;

            #endregion

            #region Fill Service

            var service = await _resumeService.GetServiceResumeByResumeId(resume.Id);

            var returnService = new List<ServiceResumeInSitePanelViewModel>();

            //Create New Instance
            if (service != null && service.Any())
            {
                foreach (var item in service)
                {
                    ServiceResumeInSitePanelViewModel sr = (new ServiceResumeInSitePanelViewModel()
                    {
                        ServiceTitle = ((string.IsNullOrEmpty(item.ServiceTitle)) ? null : item.ServiceTitle),
                        Id = item.Id,
                    });

                    returnService.Add(sr);
                }
            }

            model.ServiceResume = returnService;

            #endregion

            #region Fill Working Address

            var workingAddress = await _resumeService.GetWorkingAddressResumeByResumeId(resume.Id);

            var returnWorkingAddress = new List<WorkingAddressResumeInSitePanelViewModel>();

            //Create New Instance
            if (workingAddress != null && workingAddress.Any())
            {
                foreach (var item in workingAddress)
                {
                    WorkingAddressResumeInSitePanelViewModel wr = (new WorkingAddressResumeInSitePanelViewModel()
                    {
                        WorkingAddress = ((string.IsNullOrEmpty(item.WorkingAddress)) ? null : item.WorkingAddress),
                        WorkingAddressTitle = ((string.IsNullOrEmpty(item.WorkingAddressTitle)) ? null : item.WorkingAddressTitle),
                        Days = ((string.IsNullOrEmpty(item.Days)) ? null : item.Days),
                        Times = ((string.IsNullOrEmpty(item.Times)) ? null : item.Times),
                        Id = item.Id,
                    });

                    returnWorkingAddress.Add(wr);
                }
            }

            model.WorkingAddressResume = returnWorkingAddress;

            #endregion

            #region Fill Certificate

            var certificate = await _resumeService.GetCertificateResumeByResumeId(resume.Id);

            var returnCertificate = new List<CertificateResumeInSitePanelViewModel>();

            //Create New Instance
            if (certificate != null && certificate.Any())
            {
                foreach (var item in certificate)
                {
                    CertificateResumeInSitePanelViewModel cr = (new CertificateResumeInSitePanelViewModel()
                    {
                        CertificateTitle = ((string.IsNullOrEmpty(item.CertificateTitle)) ? null : item.CertificateTitle),
                        ImageName = ((string.IsNullOrEmpty(item.ImageName)) ? null : item.ImageName),
                        ExporterRefrence = ((string.IsNullOrEmpty(item.ExporterRefrence)) ? null : item.ExporterRefrence),
                        Id = item.Id,
                    });

                    returnCertificate.Add(cr);
                }
            }

            model.CertificateResume = returnCertificate;

            #endregion

            #region Fill Gallery

            var gallery = await _resumeService.GetGalleryResumeByResumeId(resume.Id);

            var returnGallery = new List<GalleryResumeInSitePanelViewModel>();

            //Create New Instance
            if (gallery != null && gallery.Any())
            {
                foreach (var item in gallery)
                {
                    GalleryResumeInSitePanelViewModel gal = (new GalleryResumeInSitePanelViewModel()
                    {
                        Title = ((string.IsNullOrEmpty(item.Title)) ? null : item.Title),
                        ImageName = ((string.IsNullOrEmpty(item.ImageName)) ? null : item.ImageName),
                        Id = item.Id,
                    });

                    returnGallery.Add(gal);
                }
            }

            model.GalleryResume = returnGallery;

            #endregion
        }

        #endregion

        return model;
    }

    #endregion
}
