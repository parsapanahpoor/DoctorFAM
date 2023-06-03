﻿#region Usings

using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Dentist;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Dentist;
using DoctorFAM.Domain.ViewModels.Dentist.DentistsInfo;
using DoctorFAM.Domain.ViewModels.Dentist.NavBar;
using DoctorFAM.Domain.ViewModels.Dentist.SideBar;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;


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

    #endregion
}