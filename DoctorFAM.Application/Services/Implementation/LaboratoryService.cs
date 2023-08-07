#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FamilyDoctor.ParsaSystem;
using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.SendSMS.FromDoctrors;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeLabratory;
using DoctorFAM.Domain.ViewModels.Admin.Laboratory;
using DoctorFAM.Domain.ViewModels.DoctorPanel.ParsaSystem;
using DoctorFAM.Domain.ViewModels.DoctorPanel.SendSMS;
using DoctorFAM.Domain.ViewModels.Laboratory.Employee;
using DoctorFAM.Domain.ViewModels.Laboratory.HomeLaboratory;
using DoctorFAM.Domain.ViewModels.Laboratory.LaboratoryInfo;
using DoctorFAM.Domain.ViewModels.Laboratory.LaboratorySideBar;
using Microsoft.IdentityModel.Tokens;
using System.Net.WebSockets;

#endregion

namespace DoctorFAM.Application.Services.Implementation;

public class LaboratoryService : ILaboratoryService
{
    #region Ctor

    private readonly ILaboratoryRepository _laboratoryRepository;
    private readonly IOrganizationService _organizationService;
    private readonly IUserService _userService;
    private readonly IWorkAddressService _workAddressService;
    private readonly IRequestService _requestService;
    private readonly IPatientService _patientService;
    private readonly IHomeLaboratoryServices _homeLaboratoryServices;
    private readonly ISiteSettingService _siteSettingService;

    public LaboratoryService(ILaboratoryRepository laboratoryRepository, IOrganizationService organizationService, IUserService userService, IWorkAddressService workAddressService
                                , IRequestService requestService, IPatientService patientService, IHomeLaboratoryServices homeLaboratoryServices
                                        , ISiteSettingService siteSettingService)
    {
        _laboratoryRepository = laboratoryRepository;
        _organizationService = organizationService;
        _userService = userService;
        _workAddressService = workAddressService;
        _requestService = requestService;
        _patientService = patientService;
        _homeLaboratoryServices = homeLaboratoryServices;
        _siteSettingService = siteSettingService;
    }

    #endregion

    #region Laboratory Side 

    //Send Request For Send SMS From Laboratory Panel To Admin 
    public async Task<SendRequestOfSMSFromDoctorsToThePatientResult> SendRequestForSendSMSFromLaboratoryPanelToAdmin(SendSMSToPatientDetailDoctorPanelViewModel model)
    {
        #region Get Organization

        var organization = await _organizationService.GetLaboratoryOrganizationByUserId(model.DoctorUserId);
        if (organization == null || organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.Labratory)
        {
            return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;
        }

        #endregion

        #region Get Laboratory

        var laboratory = await _laboratoryRepository.GetLaboratoryByUserId(organization.OwnerId);
        if (laboratory == null) return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;

        #endregion

        #region Model State Validation 

        if (string.IsNullOrEmpty(model.SMSBody))
        {
            return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;
        }

        #endregion

        #region Check laboratory Send SMS Count

        //Get laboratory Free SMS Count
        var laboratoryFreeSMSCount = await _laboratoryRepository.GetCountOfLaboratorySMS(organization.OwnerId);
        if (laboratoryFreeSMSCount == null) return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;

        //Get Count Of laboratory Free SMS Sent 
        var countOFlaboratoryFreeSentSMS = await _laboratoryRepository.GetCountOfLaboratoryFreeSMSSent(organization.OwnerId);

        if (countOFlaboratoryFreeSentSMS.HasValue && countOFlaboratoryFreeSentSMS.Value >= laboratoryFreeSMSCount)
        {
            return SendRequestOfSMSFromDoctorsToThePatientResult.HigherThanDoctorFreePercentage;
        }

        //Insert Free SMS From laboratory 
        if (countOFlaboratoryFreeSentSMS.HasValue && countOFlaboratoryFreeSentSMS.Value <= laboratoryFreeSMSCount)
        {
            #region Get Request For Send SMS From laboratory

            var request = await _laboratoryRepository.GetRequestForSendSMSFromLaboratoryToPatientByRequestId(model.RequestId);
            if (request == null) return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;

            var requestDetail = await _laboratoryRepository.GetRequestDetailForSendSMSFromLaboratoryToPatientByRequestId(request.Id);
            if (requestDetail == null) return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;

            #endregion

            //Check Incoming SMS Right Now
            if (requestDetail.Count > laboratoryFreeSMSCount)
            {
                return SendRequestOfSMSFromDoctorsToThePatientResult.HigherThanDoctorFreePercentage;
            }

            #region Update SMS 

            request.SendSMSFromDoctorState = Domain.Enums.SendSMS.FromDoctors.SendSMSFromDoctorState.WaitingForConfirm;

            #endregion

            //Add Request To The Data Base 
            await _laboratoryRepository.UpdateRequestForSendSMSFromLaboratoryToPatient(request);

            #region Reduce Percentage laboratory Free SMS Count

            await _laboratoryRepository.ReduceLaboratoryFreeSMSPercentageWithoutSaveChanges(laboratory.Id, requestDetail.Count());

            #endregion

            await _laboratoryRepository.Savechanges();
        }

        #endregion

        return SendRequestOfSMSFromDoctorsToThePatientResult.RequestSentSuccesfully;
    }

    //Fill Send SMS To Patient Detail Laboratory Panel View Model
    public async Task<SendSMSToPatientDetailDoctorPanelViewModel?> SendSMSToPatientDetailLaboratoryPanelViewModel(ulong requestId, ulong currentUserId)
    {
        #region Get Organization

        var organization = await _organizationService.GetLaboratoryOrganizationByUserId(currentUserId);
        if (organization == null || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.Labratory
            || organization.OrganizationInfoState != OrganizationInfoState.Accepted)
        {
            return null;
        }

        #endregion

        #region Get Request For Send SMS From Laboratory

        var request = await _laboratoryRepository.GetRequestForSendSMSFromLaboratoryToPatientByRequestId(requestId);
        if (request == null) return null;

        #endregion

        #region Get Doctor By User Id

        var laboratory = await GetLaboratoryByUserId(organization.OwnerId);
        if (laboratory == null) return null;

        #endregion

        #region Get Doctor SMS Percentage

        var smsCount = await _laboratoryRepository.GetCountOfLaboratorySMS(organization.OwnerId);

        #endregion

        #region Fill Instance

        SendSMSToPatientDetailDoctorPanelViewModel returnModel = new SendSMSToPatientDetailDoctorPanelViewModel()
        {
            RejectSMSDescription = request.DeclineDescription,
            RequestId = request.Id,
            DoctorUserId = request.DoctorUserId,
            PatientId = await _laboratoryRepository.GetListUserThatLaboratoryWantToSendThemSMS(requestId),
            SMSBody = request.SMSText,
            CountOfUserPercentageSMS = smsCount,
            SendSMSFromDoctorState = request.SendSMSFromDoctorState
        };

        #endregion

        return returnModel;
    }

    //List Of Laboratory Send SMS Request Laboratory Side View Model
    public async Task<List<ListOfDoctorSendSMSRequestDoctorSideViewModel>?> ListOfLaboratorySendSMSRequestLaboratorySideViewModel(ulong userId)
    {
        #region Get Organization

        var organization = await _organizationService.GetLaboratoryOrganizationByUserId(userId);
        if (organization == null || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.Labratory
            || organization.OrganizationInfoState != OrganizationInfoState.Accepted)
        {
            return null;
        }

        #endregion

        return await _laboratoryRepository.ListOfLaboratorySendSMSRequestLaboratorySideViewModel(organization.OwnerId);
    }

    //Send Request For Send SMS From Laboratory Panel To Admin 
    public async Task<SendRequestOfSMSFromDoctorsToThePatientResult> SendRequestForSendSMSFromLaboratoryPanelToAdmin(SendSMSToPatientViewModel model)
    {
        #region Get Organization

        var organization = await _organizationService.GetLaboratoryOrganizationByUserId(model.DoctorUserId);
        if (organization == null || organization.OrganizationInfoState != OrganizationInfoState.Accepted 
            || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.Labratory)
        {
            return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;
        }

        #endregion

        #region Get Laboratory

        var laboratory = await _laboratoryRepository.GetLaboratoryByUserId(organization.OwnerId);
        if (laboratory == null) return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;

        #endregion

        #region Model State Validation 

        if (model == null || model.PatientId.Count() == 0 || !model.PatientId.Any())
        {
            return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;
        }

        if (string.IsNullOrEmpty(model.SMSBody))
        {
            return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;
        }

        //Check Patients Id That Exist In Doctor Population
        foreach (var item in model.PatientId)
        {
            if (!await _userService.IsExistUserById(item))
            {
                return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;
            }
        }

        #endregion

        #region Check Laboratory Send SMS Count

        //Get Count Of SMS For Send
        int smsCount = ((model.SMSBody.Count() / 70) + 1) * model.PatientId.Count;

        //Get Laboratory Free SMS Count
        var laboratoryFreeSMSCount = await _laboratoryRepository.GetCountOfLaboratorySMS(organization.OwnerId);
        if (laboratoryFreeSMSCount == null) return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;

        //Check Incoming SMS Right Now
        if (smsCount > laboratoryFreeSMSCount)
        {
            return SendRequestOfSMSFromDoctorsToThePatientResult.HigherThanDoctorFreePercentage;
        }

        //Insert Free SMS From Doctor 
        if (smsCount <= laboratoryFreeSMSCount)
        {
            #region Create SMS 

            //Create Main Request
            SendRequestOfSMSFromDoctorsToThePatient mainRequest = new SendRequestOfSMSFromDoctorsToThePatient()
            {
                CreateDate = DateTime.Now,
                DoctorUserId = organization.OwnerId,
                IsDelete = false,
                SendSMSFromDoctorState = Domain.Enums.SendSMS.FromDoctors.SendSMSFromDoctorState.WaitingForConfirm,
                SMSText = model.SMSBody,
            };

            #endregion

            //Add Request To The Data Base 
            await _laboratoryRepository.AddSendRequestOfSMSFromLaboratoryToThePatient(mainRequest);

            #region Create SMS Detail 

            foreach (var userId in model.PatientId)
            {
                SendRequestOfSMSFromDoctorsToThePatientDetail detailRequest = new SendRequestOfSMSFromDoctorsToThePatientDetail()
                {
                    CreateDate = DateTime.Now,
                    UserId = userId,
                    SendRequestOfSMSFromDoctorsToThePatientId = mainRequest.Id
                };

                //Add Request Detail To The Data Base
                await _laboratoryRepository.AddSendRequestOfSMSFromLaboratorysToThePatientDetailToTheDataBase(detailRequest);
            }

            #endregion

            #region Reduce Percentage Laboratory Free SMS Count

            await _laboratoryRepository.ReduceLaboratoryFreeSMSPercentageWithoutSaveChanges(laboratory.Id, smsCount);

            #endregion

            await _laboratoryRepository.Savechanges();
        }

        #endregion

        return SendRequestOfSMSFromDoctorsToThePatientResult.RequestSentSuccesfully;
    }

    //Fill Send SMS To Patient View Model
    public async Task<SendSMSToPatientViewModel?> FillSendSMSToPatientViewModel(ulong userId, List<ulong> usersId)
    {
        #region Get Organization

        var organization = await _organizationService.GetLaboratoryOrganizationByUserId(userId);
        if (organization == null || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.Labratory
            || organization.OrganizationInfoState != OrganizationInfoState.Accepted)
        {
            return null;
        }

        #endregion

        #region Get Doctor SMS Percentage

        var smsCount = await _laboratoryRepository.GetCountOfLaboratorySMS(organization.OwnerId);

        #endregion

        return new SendSMSToPatientViewModel()
        {
            DoctorUserId = userId,
            CountOfUserPercentageSMS = smsCount,
            PatientId = usersId
        };
    }

    //List Of Current Laboratory Population Covered Users 
    public async Task<List<ChooseUsersForSendSMSViewModel>?> ListOfCurrentLaboratoryPopulationCoveredUsers(ulong laboratoryUserId)
    {
        #region Get List Of Users Id 

        var patientsUser = await _laboratoryRepository.ListOfLaboratoryUserExcelFileUploaded(laboratoryUserId);
        if (patientsUser == null) return null;

        #endregion

        #region Fill View Model 

        List<ChooseUsersForSendSMSViewModel> returnModel = new List<ChooseUsersForSendSMSViewModel>();

        if (patientsUser is not null)
        {
            foreach (var patientUser in patientsUser)
            {
                if (!string.IsNullOrEmpty(patientUser.PatientMobile))
                {
                    var userInSystem = await _userService.GetUserByMobile(patientUser.PatientMobile.Trim());
                    if (userInSystem is not null)
                    {
                        //Create Instance
                        ChooseUsersForSendSMSViewModel user = new ChooseUsersForSendSMSViewModel();

                        user.Mobile = patientUser.PatientMobile;
                        user.UserId = null;
                        user.Username = patientUser.PatientFirstName + " " + patientUser.PatientLastName;
                        user.FirstName = patientUser.PatientFirstName;
                        user.LastName = patientUser.PatientLastName;
                        user.UserId = userInSystem.Id;
                        user.UserAvatar = userInSystem.Avatar;

                        returnModel.Add(user);
                    }
                }

            }
        }

        #endregion

        return returnModel;
    }

    //Request For Epload Excel File From Site
    public async Task<bool> RequestForEploadExcelFileFromSite(RequestForUploadExcelFileFromDoctorsToSiteViewModel model, ulong userId)
    {
        #region Validation 

        if (model.ExcelFile == null)
        {
            return false;
        }

        #endregion

        #region Get Doctor Organization 

        var organization = await _organizationService.GetLaboratoryOrganizationByUserId(userId);
        if (organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.Labratory)
        {
            return false;
        }

        #endregion

        #region Fill Entity

        RequestForUploadExcelFileFromDoctorsToSite instance = new RequestForUploadExcelFileFromDoctorsToSite()
        {
            DoctorId = organization.OwnerId,
            CreateDate = DateTime.Now,
            IsPending = true,
        };

        if (model.ExcelFile != null)
        {
            var excelFile = CodeGenerator.GenerateUniqCode() + Path.GetExtension(model.ExcelFile.FileName);
            model.ExcelFile.AddFileToServer(excelFile, PathTools.RequestExcelFilePathServer);
            instance.ExcelFile = excelFile;
        }

        #endregion

        #region Add To The Data Base 

        await _laboratoryRepository.CreateRequestExcelFileForCompeleteFromAdmin(instance);

        #endregion

        return true;
    }

    //Fill Laboratory Side Bar Panel
    public async Task<LaboratorySideBarViewModel> GetLaboratorySideBarInfo(ulong userId)
    {
        return await _laboratoryRepository.GetLaboratorySideBarInfo(userId);
    }

    //Is Exist Any Laboratory By This User Id 
    public async Task<bool> IsExistAnyLaboratoryByUserId(ulong userId)
    {
        return await _laboratoryRepository.IsExistAnyLaboratoryByUserId(userId);
    }

    //Add Laboratory For First Time Loging To Laboratory Panel 
    public async Task AddLaboratoryForFirstTime(ulong userId)
    {
        #region Laboratory Entity

        #region Fill Laboratory Model

        Laboratory laboratory = new Laboratory()
        {
            UserId = userId,
            CreateDate = DateTime.Now,
            IsDelete = false,
        };

        #endregion

        #region Add Methods 

        await _laboratoryRepository.AddLaboratory(laboratory);

        #endregion

        #endregion

        #region Organization Entity

        #region Fill Organization Model

        Organization organization = new Organization()
        {
            CreateDate = DateTime.Now,
            IsDelete = false,
            OrganizationInfoState = OrganizationInfoState.JustRegister,
            OrganizationType = Domain.Enums.Organization.OrganizationType.Labratory,
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

    //Get Laboratory By User Id
    public async Task<Laboratory?> GetLaboratoryByUserId(ulong userId)
    {
        return await _laboratoryRepository.GetLaboratoryByUserId(userId);
    }

    //Get Laboratory Information By User Id
    public async Task<LaboratoryInfo?> GetLaboratoryInformationByUserId(ulong userId)
    {
        return await _laboratoryRepository.GetLaboratoryInformationByUserId(userId);
    }

    //Check Is Exist Laboratory Info By User ID
    public async Task<bool> IsExistAnyLaboratoryInfoByUserId(ulong userId)
    {
        return await _laboratoryRepository.IsExistAnyLaboratoryInfoByUserId(userId);
    }

    //Fill Laboratory Info View Model
    public async Task<ManageLaboratoryInfoViewModel?> FillManageLaboratoryInfoViewModel(ulong userId)
    {
        #region Check Is User Exist 

        var user = await _userService.GetUserById(userId);
        if (user == null) return null;

        #endregion

        #region Get Current Laboratory Office

        var laboartoryOffice = await _organizationService.GetLaboratoryOrganizationByUserId(userId);
        if (laboartoryOffice == null) return null;
        if (laboartoryOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Labratory) return null;

        #endregion

        #region Get User Office Address

        var workAddress = await _workAddressService.GetUserWorkAddressById(userId);

        #endregion

        #region Exist Laboratory Information

        //Is Exist Laboratory Informations
        if (await IsExistAnyLaboratoryByUserId(userId))
        {
            //Get Current Consultant Information
            var consultantInfo = await GetLaboratoryInformationByUserId(userId);

            //Fill Model For return Value
            ManageLaboratoryInfoViewModel model = new ManageLaboratoryInfoViewModel()
            {
                UserId = userId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                LaboratoryInfosType = laboartoryOffice.OrganizationInfoState,
                Education = ((consultantInfo != null) ? consultantInfo.Education : null),
                NationalCode = ((consultantInfo != null) ? consultantInfo.NationalCode : "0"),
                RejectDescription = laboartoryOffice.RejectDescription
            };

            //Fill Consultant Address
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

        #region Not Exist Consultant Information

        else
        {
            //This Is First Time For Come in To This Action 
            ManageLaboratoryInfoViewModel model = new ManageLaboratoryInfoViewModel()
            {
                UserId = userId
            };

            return model;
        }

        #endregion

        return null;
    }

    //Add Or Edit Laboratory Info From Laboratory Panel
    public async Task<AddOrEditLaboratoryInfoResult> AddOrEditLaboratoryInfoNursePanel(ManageLaboratoryInfoViewModel model)
    {
        #region Get User By User Id

        var user = await _userService.GetUserById(model.UserId);
        if (user == null) return AddOrEditLaboratoryInfoResult.Faild;

        #endregion

        #region Get Current Laboratory Office

        var LaboratoryOffice = await _organizationService.GetLaboratoryOrganizationByUserId(model.UserId);
        if (LaboratoryOffice == null) return AddOrEditLaboratoryInfoResult.Faild;
        if (LaboratoryOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Labratory) return AddOrEditLaboratoryInfoResult.Faild;

        #endregion

        #region Get Laboratory By User Id 

        //Get Laboratory By UserId
        var Laboratory = await GetLaboratoryByUserId(user.Id);

        #endregion

        #region Is Exist Informations

        var existInfo = await IsExistAnyLaboratoryInfoByUserId(model.UserId);

        #endregion

        #region Edit Info

        if (existInfo == true)
        {
            #region Update Properties

            //Get Laboratory Informations By User Id
            var info = await GetLaboratoryInformationByUserId(model.UserId);

            //Edit Properties 
            info.Education = model.Education.SanitizeText();
            info.NationalCode = model.NationalCode;

            //Update Laboratory Office State 
            LaboratoryOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

            #region Update First Name And Last Name 

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            await _userService.UpdateUser(user);

            #endregion

            #endregion

            #region Update Laboratory Address

            var LaboratoryAddress = await _workAddressService.GetUserWorkAddressById(model.UserId);

            if (LaboratoryAddress != null && !string.IsNullOrEmpty(model.WorkAddress))
            {
                LaboratoryAddress.Address = model.WorkAddress;
                LaboratoryAddress.CountryId = model.CountryId.Value;
                LaboratoryAddress.StateId = model.StateId.Value;
                LaboratoryAddress.CityId = model.CityId.Value;

                await _workAddressService.UpdateUserWorkAddress(LaboratoryAddress);
            }

            if (LaboratoryAddress == null && !string.IsNullOrEmpty(model.WorkAddress))
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

                await _workAddressService.AddWorkAddress(workAddress);
            }

            #endregion

            #region Update Methods

            await _laboratoryRepository.UpdateLaboratoryInfo(info);

            await _organizationService.UpdateOrganization(LaboratoryOffice);

            #endregion
        }

        #endregion

        #region Add Info

        if (existInfo == false)
        {
            if (Laboratory != null)
            {
                #region Fill View Model

                LaboratoryInfo manageLaboratoryInfoViewModel1 = new LaboratoryInfo()
                {
                    LaboratoryId = Laboratory.Id,
                    Education = model.Education.SanitizeText(),
                    NationalCode = model.NationalCode,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CountOFFreeSMSForLaboratory = await _laboratoryRepository.GetLaboratoryFreeSMSCount()
                };

                #endregion

                #region Update First Name And Last Name 

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                await _userService.UpdateUser(user);

                #endregion

                #region Add Laboratory Address

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

                    await _workAddressService.AddWorkAddress(workAddress);
                }

                #endregion

                #region Update Laboratory Office

                LaboratoryOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

                #endregion

                #region Update Methods

                await _laboratoryRepository.AddLaboratoryInfo(manageLaboratoryInfoViewModel1);

                await _organizationService.UpdateOrganization(LaboratoryOffice);

                #endregion
            }
            else
            {
                #region Add Laboratory

                Laboratory newLaboratory = new Laboratory()
                {
                    CreateDate = DateTime.Now,
                    UserId = user.Id,
                    IsDelete = false
                };

                var newNurseId = await _laboratoryRepository.AddLaboratory(newLaboratory);

                #endregion

                #region Add Laboratory Address

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

                    await _workAddressService.AddWorkAddress(workAddress);
                }

                #endregion

                #region Organization Entity

                #region Fill Organization Model

                Organization organization = new Organization()
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    OrganizationInfoState = OrganizationInfoState.JustRegister,
                    OrganizationType = Domain.Enums.Organization.OrganizationType.Labratory,
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

                LaboratoryInfo manageLaboratoryInfoViewModel = new LaboratoryInfo()
                {
                    LaboratoryId = newLaboratory.Id,
                    Education = model.Education.SanitizeText(),
                    NationalCode = model.NationalCode,
                    CountOFFreeSMSForLaboratory = await _laboratoryRepository.GetLaboratoryFreeSMSCount()
                };

                #endregion

                #region Update First Name And Last Name 

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                await _userService.UpdateUser(user);

                #endregion

                #region Update Methods

                await _laboratoryRepository.AddLaboratoryInfo(manageLaboratoryInfoViewModel);

                #endregion
            }
        }

        #endregion

        return AddOrEditLaboratoryInfoResult.Success;
    }

    //Filter Laboratory Office Employees
    public async Task<FilterLaboratoryOfficeEmployeesViewmodel> FilterLaboratoryOfficeEmployees(FilterLaboratoryOfficeEmployeesViewmodel filter)
    {
        return await _laboratoryRepository.FilterLaboratoryOfficeEmployees(filter);
    }

    //Add Exist User To The Laboratory Organization 
    public async Task<bool> AddExistUserToTheLaboratoryOrganization(ulong userId, List<ulong> UserRoles, ulong laboratoryId)
    {
        #region Check Is Exist Any User By This User Id

        var user = await _userService.GetUserById(userId);
        if (user == null) return false;

        #endregion

        #region Check That Has User Any Organization 

        var userOrganization = await _organizationService.GetOrganizationByUserId(userId);
        if (userOrganization != null) return false;

        #endregion

        #region Get Current Laboratory Organization

        var organization = await _organizationService.GetLaboratoryOrganizationByUserId(laboratoryId);
        if (organization == null) return false;

        #endregion

        #region Add User To The Laboratory Organization 

        #region Add New Organization Member

        OrganizationMember member = new OrganizationMember()
        {
            UserId = user.Id,
            OrganizationId = organization.Id
        };

        await _organizationService.AddOrganizationMember(member);

        #endregion

        #region Add User Role

        var userRole1 = new UserRole()
        {
            RoleId = 17,
            UserId = user.Id
        };

        await _laboratoryRepository.AddUserLaboratoryMemberRoleWithoutSaveChanges(userRole1);

        if (UserRoles != null && UserRoles.Any())
        {
            foreach (var roleId in UserRoles)
            {
                var userRole = new UserRole()
                {
                    RoleId = roleId,
                    UserId = user.Id
                };
                await _laboratoryRepository.AddUserLaboratoryMemberRoleWithoutSaveChanges(userRole);
            }

            await _laboratoryRepository.Savechanges();
        }

        #endregion

        #endregion

        return true;
    }

    //Filter List Of Home Laboratory Request ViewModel From User Or Supporter Panel 
    public async Task<FilterListOfHomeLaboratoryRequestViewModel> FilterListOfHomeLaboratoryRequestViewModel(FilterListOfHomeLaboratoryRequestViewModel filter)
    {
        #region Get Organization 

        var organization = await _organizationService.GetLaboratoryOrganizationByUserId(filter.UserId);
        if (organization == null) return null;

        filter.LaboratoryOwnerId = organization.OwnerId;

        #endregion

        return await _laboratoryRepository.FilterListOfHomeLaboratoryRequestViewModel(filter);
    }

    //Get List Of Home Laboratory Request Detail By Request Id 
    public async Task<List<HomeLaboratoryRequestDetail>> GetHomeLaboratoryRequestDetailByRequestId(ulong requestId)
    {
        return await _laboratoryRepository.GetHomeLaboratoryRequestDetailByRequestId(requestId);
    }

    //Show Home Laboratory Request Detail In Laboratory Panel
    public async Task<HomeLaboratoryRequestViewModel?> FillHomePharmacyRequestViewModel(ulong requestId, ulong userId)
    {
        #region Get Organization By User Id

        var organization = await _organizationService.GetOrganizationByUserId(userId);
        if (organization == null) return null;

        #endregion

        #region Get Request By Request Id

        var request = await _requestService.GetRequestById(requestId);

        if (request == null) return null;
        if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeLab) return null;
        if (request.OperationId.HasValue && request.OperationId.Value != organization.OwnerId) return null;
        if (!request.PatientId.HasValue) return null;

        #endregion

        #region Fill Model 

        HomeLaboratoryRequestViewModel model = new HomeLaboratoryRequestViewModel()
        {
            Patient = await _patientService.GetPatientById(request.PatientId.Value),
            User = await _userService.GetUserById(request.UserId),
            HomeLaboratoryRequestDetail = await GetHomeLaboratoryRequestDetailByRequestId(request.Id),
            PatientRequestDetail = await _laboratoryRepository.GetRequestPatientDetailByRequestId(request.Id),
            PatientRequestDateTimeDetail = await _laboratoryRepository.GetRequestDateTimeDetailByRequestDetailId(request.Id),
            Request = request,
        };

        if (model.Patient is not null && model.Patient.SupplementaryInsuranceId.HasValue)
        {
            model.SupplementaryInsurance = await _siteSettingService.GetSupplementaryInsuranceNameById(model.Patient.SupplementaryInsuranceId.Value);
        }

        #endregion

        return model;
    }

    #endregion

    #region Admin Side 

    //Filter Laboratory Info Admin Side
    public async Task<ListOfLaboratoryInfoViewModel> FilterListOfLaboratoryInfoViewModel(ListOfLaboratoryInfoViewModel filter)
    {
        return await _laboratoryRepository.FilterListOfLaboratoryInfoViewModel(filter);
    }

    //Get Laboratory By Consultant Id
    public async Task<Laboratory?> GetLaboratoryById(ulong laboratoryId)
    {
        return await _laboratoryRepository.GetLaboratoryById(laboratoryId);
    }

    //Fill Laboratory Info Detail ViewModel
    public async Task<LaboratoryInfoDetailAdminSideViewModel?> FillLaboratoryInfoDetailAdminSideViewModel(ulong ConsultantId)
    {
        #region Get Laboratory Info

        //Get Laboratory Info By Id
        var info = await _laboratoryRepository.GetLaboratoryInfoByLaboratoryId(ConsultantId);
        if (info == null) return null;

        #endregion

        #region Get Laboratory Info

        var laboratory = await GetLaboratoryById(info.LaboratoryId);
        if (laboratory == null) return null;

        #endregion

        #region Get Current Laboratory Office

        var laboratoryOffice = await _organizationService.GetLaboratoryOrganizationByUserId(laboratory.UserId);
        if (laboratoryOffice == null) return null;
        if (laboratoryOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Labratory) return null;

        #endregion

        #region Fill View Model

        LaboratoryInfoDetailAdminSideViewModel model = new LaboratoryInfoDetailAdminSideViewModel()
        {
            UserId = laboratory.UserId,
            NationalCode = info.NationalCode,
            Education = info.Education,
            RejectDescription = laboratoryOffice.RejectDescription,
            LaboratoryInfosType = laboratoryOffice.OrganizationInfoState,
            Id = info.Id,
            LaboratoryId = laboratory.Id,
            CountOfFreeSMSForSend = info.CountOFFreeSMSForLaboratory
        };

        #endregion

        #region Get Laboratory Work Addresses

        model.WorkAddresses = await _workAddressService.GetUserWorkAddressesByUserId(laboratory.UserId);

        #endregion

        return model;
    }

    //Edit Laboratory Info From Admin Panel
    public async Task<EditLaboratoryInfoResult> EditLaboratoryInfoAdminSide(LaboratoryInfoDetailAdminSideViewModel model)
    {
        #region Get Laboratory Info By Id

        //Get Laboratory Info By Id
        var info = await _laboratoryRepository.GetLaboratoryInfoById(model.Id);
        if (info == null) return EditLaboratoryInfoResult.faild;

        #endregion

        #region Get Laboratory By Id 

        var laboratory = await GetLaboratoryById(model.LaboratoryId);
        if (laboratory == null) return EditLaboratoryInfoResult.faild;

        #endregion

        #region Get Current Laboratory Office

        var laboratoryOffice = await _organizationService.GetLaboratoryOrganizationByUserId(laboratory.UserId);
        if (laboratoryOffice == null) return EditLaboratoryInfoResult.faild;
        if (laboratoryOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Labratory) return EditLaboratoryInfoResult.faild;

        #endregion

        #region Update Laboratory 

        laboratoryOffice.OrganizationInfoState = model.LaboratoryInfosType;
        laboratoryOffice.RejectDescription = model.RejectDescription;

        if (model.LaboratoryInfosType == OrganizationInfoState.Accepted)
        {
            laboratoryOffice.RejectDescription = null;
        }

        await _organizationService.UpdateOrganization(laboratoryOffice);

        #endregion

        #region Edit Laboratory Info 

        #region Edit Properties

        info.Education = model.Education;
        info.NationalCode = model.NationalCode;
        info.CountOFFreeSMSForLaboratory = model.CountOfFreeSMSForSend;

        #endregion

        #region Update Method

        await _laboratoryRepository.UpdateLaboratoryInfo(info);

        #endregion

        #endregion

        return EditLaboratoryInfoResult.success;
    }

    //Show Home Laboratory Request Detail In Admin And Supporter Panel
    public async Task<HomeLabratoryRequestDetailViewModel?> FillHomePharmacyRequestDetailAdminSide(ulong requestId, ulong userId)
    {
        #region Get Request By Request Id

        var request = await _requestService.GetRequestById(requestId);

        if (request == null) return null;
        if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeLab) return null;
        if (!request.PatientId.HasValue) return null;

        #endregion

        #region Fill Model 

        HomeLabratoryRequestDetailViewModel model = new HomeLabratoryRequestDetailViewModel()
        {
            Patient = await _patientService.GetPatientById(request.PatientId.Value),
            User = await _userService.GetUserById(request.UserId),
            HomeLaboratoryRequestDetail = await GetHomeLaboratoryRequestDetailByRequestId(request.Id),
            PatientRequestDetail = await _laboratoryRepository.GetRequestPatientDetailByRequestId(request.Id),
            PatientRequestDateTimeDetail = await _laboratoryRepository.GetRequestDateTimeDetailByRequestDetailId(request.Id),
            Request = request
        };

        #endregion

        return model;
    }

    #endregion
}
