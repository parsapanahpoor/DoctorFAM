using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.DTOs.HealthCenters.HealthCentersInfos;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.HealthCenters;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.HealthCenter;
using DoctorFAM.Domain.ViewModels.DoctorPanel.HealthCenters;
using DoctorFAM.Domain.ViewModels.HealthCenters.HealthCentersInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Application.Services.Implementation;

public class HealthCentersService : IHealthCentersService
{
    #region Ctor

    private readonly IHealthCentersRepository _healthCentersRepository;
    private readonly IOrganizationService _organizationService;
    private readonly IWorkAddressRepository _workAddressRepository;
    private readonly IUserService _userService;
    private readonly IDoctorsService _doctorsService;

    public HealthCentersService(IHealthCentersRepository healthCentersRepository, 
                                IOrganizationService organizationService,
                                IWorkAddressRepository workAddressRepository,
                                IUserService userService ,
                                IDoctorsService doctorsService)
    {
        _healthCentersRepository = healthCentersRepository;
        _organizationService = organizationService;
        _workAddressRepository = workAddressRepository;
        _userService = userService;
        _doctorsService = doctorsService;
    }

    #endregion

    #region General

    public async Task<bool> IsExistAnyHealthCenterById(ulong id)
    {
        return await IsExistAnyHealthCenterById(id);
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
        if (healthCenterOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.HealthCenter) return null;

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
            HealthCenterFile = info.HealthCenterImage,
            HealthCenterName = info.HealthCenterName
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
        if (healthCenterOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.HealthCenter) return EditHealthCenterInfoResult.faild;

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

    //Fill Manage Health Center Info ViewModel
    public async Task<ManageHealthCentersInfoViewModel?> FillManageHealthCentersInfoViewModel(ulong userId)
    {
        #region Check Is User Exist 

        var user = await _userService.GetUserByIdWithAsNoTracking(userId);
        if (user == null) return null;

        #endregion

        #region Get Current Health Center Office

        var healthCenterOffice = await _organizationService.GetHealthCenterOrganizationByUserId(userId);
        if (healthCenterOffice == null) return null;

        #endregion

        #region Get User Office Address

        var workAddress = await _workAddressRepository.GetUserWorkAddressByIdWithAsNoTracking(userId);

        #endregion

        #region Exist Health Center Information

        //Is Exist Health Center Informations
        if (await _healthCentersRepository.IsExistAnyHealthCenterInfoByUserId(userId).AnyAsync())
        {
            //Get Current Health Center Information
            var doctorInfo = await _healthCentersRepository.GetHealthCentersInformationByUserId(userId)
                                                           .FirstOrDefaultAsync();

            //Fill Model For return Value
            ManageHealthCentersInfoViewModel model = new ManageHealthCentersInfoViewModel()
            {
                UserId = userId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                HealthCentersInfosType = healthCenterOffice.OrganizationInfoState,
                Education = doctorInfo.Education,
                NationalCode = doctorInfo.NationalCode,
                Gender = doctorInfo.Gender,
                RejectDescription = healthCenterOffice.RejectDescription,
                GeneralPhone = doctorInfo.GeneralPhone,
                FatherName = user.FatherName,
                username = user.Username,
                Mobile = user.Mobile,
                Email = user.Email,
                HomePhoneNumber = user.HomePhoneNumber,
                AvatarName = user.Avatar,
                HealthCenterFile = doctorInfo.HealthCenterImage,
                HealthCenterName = doctorInfo.HealthCenterName
            };

            if (user.BithDay != null && user.BithDay.HasValue)
            {
                model.BithDay = user.BithDay.Value.ToShamsi();
            }

            //Fill Health Center Cilinic Address
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
            ManageHealthCentersInfoViewModel model = new ManageHealthCentersInfoViewModel()
            {
                UserId = userId
            };

            return model;
        }

        #endregion
    }

    //Add Or Edit Health Center Info Health Center Panel 
    public async Task<AddOrEditHealthCenterstInfoResult> AddOrEditHealthCenterInfoDentistsPanel(ManageHealthCentersInfoViewModel model, IFormFile? UserAvatar, IFormFile? HealthCenterImage)
    {
        #region Get User By User Id

        var user = await _userService.GetUserById(model.UserId);

        if (user == null) return AddOrEditHealthCenterstInfoResult.Faild;
        if (model.UserId != model.UserId) return AddOrEditHealthCenterstInfoResult.Faild;
        if (UserAvatar != null && !UserAvatar.IsImage()) return AddOrEditHealthCenterstInfoResult.NotValidImage;
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
                return AddOrEditHealthCenterstInfoResult.NotValidEmail;
            }
        }
        if (string.IsNullOrEmpty(model.NationalCode))
        {
            return AddOrEditHealthCenterstInfoResult.NationalId;
        }
        if (!string.IsNullOrEmpty(model.NationalCode) && !await _userService.IsValidNationalIdForUserEditByAdmin(model.NationalCode, user.Id))
        {
            return AddOrEditHealthCenterstInfoResult.NotValidNationalId;
        }

        #endregion

        #region Get Current Health Center Office

        var HealthCenterOffice = await _organizationService.GetHealthCenterOrganizationByUserId(model.UserId);
        if (HealthCenterOffice == null) return AddOrEditHealthCenterstInfoResult.Faild;

        #endregion

        #region Get Health Center By User Id 

        //Get Health Center By UserId
        var healthCenter= await _healthCentersRepository.GetHealthCenterByUserId(user.Id)
                                                    .FirstOrDefaultAsync();

        if (healthCenter == null) return AddOrEditHealthCenterstInfoResult.Faild;

        #endregion

        #region Is Exist Informations

        var existInfo = await _healthCentersRepository.IsExistAnyHealthCenterInfoByUserId(model.UserId)
                                                      .AnyAsync();

        #endregion

        #region Image Not Found 

        if (existInfo == false && HealthCenterImage == null) return AddOrEditHealthCenterstInfoResult.FileNotUploaded;

        if (HealthCenterImage != null && !HealthCenterImage.IsImage()) return AddOrEditHealthCenterstInfoResult.FileNotUploaded;

        #endregion

        #region Edit Info

        if (existInfo == true)
        {
            #region Update Properties

            //Get Current Health Center Information
            var info = await _healthCentersRepository.GetHealthCentersInformationByUserId(model.UserId)
                                                           .FirstOrDefaultAsync();

            //Edit Properties 
            info.Education = model.Education.SanitizeText();
            info.NationalCode = model.NationalCode;
            info.Gender = model.Gender;
            info.GeneralPhone = model.GeneralPhone;
            info.HealthCenterName = model.HealthCenterName;

            //Update Doctor Office State 
            HealthCenterOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

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

            #region HealthCenter File 

            if (HealthCenterImage != null)
            {
                if (!string.IsNullOrEmpty(info.HealthCenterImage))
                {
                    info.HealthCenterImage.DeleteImage(PathTools.MediacalFilePathServer, PathTools.MediacalFilePathThumbServer);
                }

                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(HealthCenterImage.FileName);
                HealthCenterImage.AddImageToServer(imageName, PathTools.HealthCenterFilePathServer, 270, 270, PathTools.HealthCenterFilePathThumbServer);
                info.HealthCenterImage = imageName;
            }

            #endregion

            #region Update Doctor Address

            var doctorAddress = await _workAddressRepository.GetUserWorkAddressByIdWithAsNoTracking(model.UserId);

            if (doctorAddress != null && !string.IsNullOrEmpty(model.WorkAddress))
            {
                doctorAddress.Address = model.WorkAddress;
                doctorAddress.CountryId = model.CountryId.Value;
                doctorAddress.StateId = model.StateId.Value;
                doctorAddress.CityId = model.CityId.Value;

                await _workAddressRepository.UpdateUserWorkAddressWithoutSaveChanges(doctorAddress);
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

                await _workAddressRepository.AddWorkAddressWithoutSaveChanges(workAddress);
            }

            #endregion

            #region Update Methods

            _healthCentersRepository.UpdateHealthCenterInfo(info);

            //The Last Save Changes In This Method 
            await _organizationService.UpdateOrganization(HealthCenterOffice);

            #endregion
        }

        #endregion

        #region Add Info

        if (existInfo == false)
        {
            if (healthCenter != null )
            {
                #region Fill View Model

                HealthCentersInfo manageHealthCentersInfoViewModel1 = new HealthCentersInfo()
                {
                    HealthCenterId = healthCenter.Id,
                    UserId = model.UserId,
                    Education = model.Education.SanitizeText(),
                    NationalCode = model.NationalCode,
                    Gender = model.Gender,
                    GeneralPhone = model.GeneralPhone,
                    HealthCenterName = model.HealthCenterName,
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

                #region HealthCenter File 

                if (HealthCenterImage != null)
                {

                    var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(HealthCenterImage.FileName);
                    HealthCenterImage.AddImageToServer(imageName, PathTools.HealthCenterFilePathServer, 270, 270, PathTools.HealthCenterFilePathThumbServer);
                    manageHealthCentersInfoViewModel1.HealthCenterImage = imageName;
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

                    await _workAddressRepository.AddWorkAddressWithoutSaveChanges(workAddress);
                }

                #endregion

                #region Update Dentist Office

                HealthCenterOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

                #endregion

                #region Update Methods

                await _healthCentersRepository.AddHealthCenterInfo(manageHealthCentersInfoViewModel1);

                //Last Save Changes 
                await _organizationService.UpdateOrganization(HealthCenterOffice);

                #endregion
            }
            else
            {
                #region Add HealthCenter

                HealthCenter newHealthCenter = new HealthCenter()
                {
                    CreateDate = DateTime.Now,
                    UserId = user.Id,
                    IsDelete = false
                };

                var newHealthCenterId = await _healthCentersRepository.AddHealthCenterWithReturningId(newHealthCenter);

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

                    await _workAddressRepository.AddWorkAddressWithoutSaveChanges(workAddress);
                }

                #endregion

                #region Organization Entity

                #region Fill Organization Model

                Organization organization = new Organization()
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    OrganizationInfoState = OrganizationInfoState.JustRegister,
                    OrganizationType = Domain.Enums.Organization.OrganizationType.HealthCenter,
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

                HealthCentersInfo manageHealthCentersInfoViewModel = new HealthCentersInfo()
                {
                    HealthCenterId = newHealthCenter.Id,
                    UserId = model.UserId,
                    Education = model.Education.SanitizeText(),
                    NationalCode = model.NationalCode,
                    GeneralPhone = model.GeneralPhone,
                    HealthCenterName = model.HealthCenterName
                };

                #endregion

                #region HealthCenter File 

                if (HealthCenterImage != null)
                {
                    var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(HealthCenterImage.FileName);
                    HealthCenterImage.AddImageToServer(imageName, PathTools.HealthCenterFilePathServer, 270, 270, PathTools.HealthCenterFilePathThumbServer);
                    manageHealthCentersInfoViewModel.HealthCenterImage = imageName;
                }

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

                #region Update Methods

                await _healthCentersRepository.AddHealthCenterInfo(manageHealthCentersInfoViewModel);
                await _healthCentersRepository.SaveChangesAsync();

                #endregion
            }
        }

        #endregion

        return AddOrEditHealthCenterstInfoResult.Success;
    }

    #endregion

    #region Doctor Panel 

    public async Task<FilterHealthCentersInDoctorPanelDTO> ListOfHealthCenters(FilterHealthCentersInDoctorPanelDTO model)
    {
        return await _healthCentersRepository.ListOfHealthCenters(model);
    }

    public async Task<FilterOfDoctorSelectedHealthCentersDoctorSide> FilterOfDoctorSelectedHealthCentersDoctorSide(FilterOfDoctorSelectedHealthCentersDoctorSide filter)
    {
        return await _healthCentersRepository.FilterOfDoctorSelectedHealthCentersDoctorSide( filter);
    }

    public async Task<bool> SendRequestForCoopratetoHealthCenter(ulong healthCenterId , ulong doctorUserId)
    {
        #region Get Health Center By Id

        var healthCenter = await IsExistAnyHealthCenterById(healthCenterId);
        if (!healthCenter) return false;

        #endregion

        #region Get Doctor By Doctor UserId

        var doctor = await _doctorsService.IsExistAnyDoctorByUserId(doctorUserId);
        if (!doctor) return false;

        #endregion

        #region Fill Doctor Selected Health Center

        DoctorSelectedHealthCenter model = new()
        {
            CreateDate = DateTime.Now,
            DoctorSelectedHealthCenterState = Domain.Enums.HealthCenter.DoctorSelectedHealthCenterState.Accept,
            DoctorUserId = doctorUserId,
            HealthCenterId = healthCenterId
        };

        #endregion

        #region Add Ddoctor Selected Health Center To The Data Base

        await _healthCentersRepository.AddDoctorSelectedHealthCenter(model);
        await _healthCentersRepository.SaveChangesAsync();

        #endregion

        return true;
    }

    #endregion
}
