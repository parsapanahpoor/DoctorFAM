using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Nurse;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Doctor;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.Nurse.NurseInfo;
using DoctorFAM.Domain.ViewModels.Nurse.NurseSideBarInfo;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class NurseService : INurseService
    {
        #region Ctor

        private readonly INurseRepository _nurseRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IWorkAddressRepository _workAddressRepository;
        private readonly IUserService _userService;
        private readonly IRequestService _requestService;

        public NurseService(INurseRepository nurseRepository, IOrganizationRepository organizationRepository,
                                IWorkAddressRepository workAddressRepository, IUserService userService , IRequestService requestService)
        {
            _nurseRepository = nurseRepository;
            _organizationRepository = organizationRepository;
            _workAddressRepository = workAddressRepository;
            _userService = userService;
            _requestService = requestService;
        }

        #endregion

        #region Nurse Side 

        //Fill Nurse Side Bar Panel
        public async Task<NurseSideBarViewModel> GetNurseSideBarInfo(ulong userId)
        {
           return await _nurseRepository.GetNurseSideBarInfo(userId); 
        }

        //Is Exist Any Nurse By This User Id 
        public async Task<bool> IsExistAnyNurseByUserId(ulong userId)
        {
            return await _nurseRepository.IsExistAnyNurseByUserId(userId);
        }

        //Add Nurse For First Time Loging To Nurse Panel 
        public async Task AddNurseForFirstTime(ulong userId)
        {
            #region Nurse Entity

            #region Fill Nurse Model

            Nurse nurse = new Nurse()
            {
                UserId = userId,
                CreateDate = DateTime.Now,
                IsDelete = false,
            };

            #endregion

            #region Add Methods 

            await _nurseRepository.AddNurse(nurse);

            #endregion

            #endregion

            #region Organization Entity

            #region Fill Organization Model

            Organization organization = new Organization()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                OrganizationInfoState = OrganizationInfoState.JustRegister,
                OrganizationType = Domain.Enums.Organization.OrganizationType.Nurse,
                OwnerId = userId,
            };

            #endregion

            #region Add Method

            var organizationId = await _organizationRepository.AddOrganizationWithReturnId(organization);

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

            await _organizationRepository.AddOrganizationMember(member);

            #endregion

            #endregion
        }

        //Get Nurse By User Id
        public async Task<Nurse?> GetNurseByUserId(ulong userId)
        {
            return await _nurseRepository.GetNurseByUserId(userId);
        }

        //Get Nurse Information By User Id
        public async Task<NurseInfo?> GetNurseInformationByUserId(ulong userId)
        {
            return await _nurseRepository.GetNurseInformationByUserId(userId);
        }

        //Fill Nurse Info View Model
        public async Task<ManageNurseInfoViewModel?> FillManageNurseInfoViewModel(ulong userId)
        {
            #region Check Is User Exist 

            var user = await _userService.GetUserById(userId);
            if (user == null) return null;

            #endregion

            #region Get Current Nurse Office

            var nurseOffice = await _organizationRepository.GetNurseOrganizationByUserId(userId);
            if (nurseOffice == null) return null;
            if (nurseOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Nurse) return null;

            #endregion

            #region Get User Office Address

            var workAddress = await _workAddressRepository.GetUserWorkAddressById(userId);

            #endregion

            #region Exist Nurse Information

            //Is Exist Nurse Informations
            if (await IsExistAnyNurseByUserId(userId))
            {
                //Get Current Nurse Information
                var nurseInfo = await GetNurseInformationByUserId(userId);

                //Fill Model For return Value
                ManageNurseInfoViewModel model = new ManageNurseInfoViewModel()
                {
                    UserId = userId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    NurseInfosType = nurseOffice.OrganizationInfoState,
                    Education = ((nurseInfo != null) ? nurseInfo.Education : null),
                    NationalCode = ((nurseInfo != null) ? nurseInfo.NationalCode : 0),
                    RejectDescription = nurseOffice.RejectDescription
                };

                //Fill Nurse Cilinic Address
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

            #region Not Exist Nurse Information

            else
            {
                //This Is First Time For Come in To This Action 
                ManageNurseInfoViewModel model = new ManageNurseInfoViewModel()
                {
                    UserId = userId
                };

                return model;
            }

            #endregion

            return null;
        }

        //Check Is Exist Nurse Info By User ID
        public async Task<bool> IsExistAnyNurseInfoByUserId(ulong userId)
        {
            return await _nurseRepository.IsExistAnyNurseInfoByUserId(userId);
        }

        //Add Or Edit Nurse Info From Nurse Panel
        public async Task<AddOrEditNurseInfoResult> AddOrEditNurseInfoNursePanel(ManageNurseInfoViewModel model)
        {
            #region Get User By User Id

            var user = await _userService.GetUserById(model.UserId);
            if (user == null) return AddOrEditNurseInfoResult.Faild;

            #endregion

            #region Get Current Nurse Office

            var nurseOffice = await _organizationRepository.GetNurseOrganizationByUserId(model.UserId);
            if (nurseOffice == null) return AddOrEditNurseInfoResult.Faild;
            if (nurseOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Nurse) return AddOrEditNurseInfoResult.Faild;

            #endregion

            #region Get Nurse By User Id 

            //Get Nurse By UserId
            var nurse = await GetNurseByUserId(user.Id);

            #endregion

            #region Is Exist Informations

            var existInfo = await IsExistAnyNurseInfoByUserId(model.UserId);

            #endregion

            #region Edit Info

            if (existInfo == true)
            {
                #region Update Properties

                //Get Nurse Informations By User Id
                var info = await GetNurseInformationByUserId(model.UserId);

                //Edit Properties 
                info.Education = model.Education.SanitizeText();
                info.NationalCode = model.NationalCode;

                //Update Nurse Office State 
                nurseOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

                #region Update First Name And Last Name 

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                await _userService.UpdateUser(user);

                #endregion

                #endregion

                #region Update Nurse Address

                var nurseAddress = await _workAddressRepository.GetUserWorkAddressById(model.UserId);

                if (nurseAddress != null && !string.IsNullOrEmpty(model.WorkAddress))
                {
                    nurseAddress.Address = model.WorkAddress;
                    nurseAddress.CountryId = model.CountryId.Value;
                    nurseAddress.StateId = model.StateId.Value;
                    nurseAddress.CityId = model.CityId.Value;

                    await _workAddressRepository.UpdateUserWorkAddress(nurseAddress);
                }

                if (nurseAddress == null && !string.IsNullOrEmpty(model.WorkAddress))
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

                    await _workAddressRepository.AddWorkAddress(workAddress);
                }

                #endregion

                #region Update Methods

                await _nurseRepository.UpdateNurseInfo(info);

                await _organizationRepository.UpdateOrganization(nurseOffice);

                #endregion
            }

            #endregion

            #region Add Info

            if (existInfo == false)
            {
                if (nurse != null)
                {
                    #region Fill View Model

                    NurseInfo manageNurseInfoViewModel1 = new NurseInfo()
                    {
                        NurseId = nurse.Id,
                        Education = model.Education.SanitizeText(),
                        NationalCode = model.NationalCode,
                        FirstName = model.FirstName,
                        LastName = model.LastName
                    };

                    #endregion

                    #region Update First Name And Last Name 

                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;

                    await _userService.UpdateUser(user);

                    #endregion

                    #region Add Nurse Address

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

                        await _workAddressRepository.AddWorkAddress(workAddress);
                    }

                    #endregion

                    #region Update Nurse Office

                    nurseOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

                    #endregion

                    #region Update Methods

                    await _nurseRepository.AddNurseInfo(manageNurseInfoViewModel1);

                    await _organizationRepository.UpdateOrganization(nurseOffice);

                    #endregion
                }
                else
                {
                    #region Add Nurse

                    Nurse newNurse = new Nurse()
                    {
                        CreateDate = DateTime.Now,
                        UserId = user.Id,
                        IsDelete = false
                    };

                    var newNurseId = await _nurseRepository.AddNurse(newNurse);

                    #endregion

                    #region Add Nurse Address

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

                        await _workAddressRepository.AddWorkAddress(workAddress);
                    }

                    #endregion

                    #region Organization Entity

                    #region Fill Organization Model

                    Organization organization = new Organization()
                    {
                        CreateDate = DateTime.Now,
                        IsDelete = false,
                        OrganizationInfoState = OrganizationInfoState.JustRegister,
                        OrganizationType = Domain.Enums.Organization.OrganizationType.Nurse,
                        OwnerId = model.UserId,
                    };

                    #endregion

                    #region Add Method

                    var organizationId = await _organizationRepository.AddOrganizationWithReturnId(organization);

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

                    await _organizationRepository.AddOrganizationMember(member);

                    #endregion

                    #endregion

                    #region Fill View Model

                    NurseInfo manageNurseInfoViewModel = new NurseInfo()
                    {
                        NurseId = newNurse.Id,
                        Education = model.Education.SanitizeText(),
                        NationalCode = model.NationalCode,
                    };

                    #endregion

                    #region Update First Name And Last Name 

                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;

                    await _userService.UpdateUser(user);

                    #endregion

                    #region Update Methods

                    await _nurseRepository.AddNurseInfo(manageNurseInfoViewModel);

                    #endregion
                }
            }

            #endregion

            return AddOrEditNurseInfoResult.Success;
        }

        //Filter Nurse Info Admin Side
        public async Task<ListOfNurseInfoViewModel> FilterNurseInfoAdminSide(ListOfNurseInfoViewModel filter)
        {
            return await _nurseRepository.FilterNurseInfoAdminSide(filter);
        }

        #endregion

        #region Admin Side 

        //Get Nurse Info By Nurse Id
        public async Task<NurseInfo?> GetNurseInfoByNurseId(ulong NurseId)
        {
            return await _nurseRepository.GetNurseInfoByNurseId(NurseId);
        }

        //Get Nurse By Nurse Id
        public async Task<Nurse?> GetNurseById(ulong nurseId)
        {
            return await _nurseRepository.GetNurseById(nurseId);
        }

        //Fill Nurse Info Detail ViewModel
        public async Task<NurseInfoDetailViewModel?> FillNurseInfoDetailViewModel(ulong NurseId)
        {
            #region Get Nurse Info

            //Get Nurse Info By Id
            var info = await _nurseRepository.GetNurseInfoByNurseId(NurseId);
            if (info == null) return null;

            #endregion

            #region Get Nurse Info

            var nurse = await GetNurseById(info.NurseId);
            if (nurse == null) return null;

            #endregion

            #region Get Current Nurse Office

            var nurseOffice = await _organizationRepository.GetNurseOrganizationByUserId(nurse.UserId);
            if (nurseOffice == null) return null;
            if (nurseOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Nurse) return null;

            #endregion

            #region Fill View Model

            NurseInfoDetailViewModel model = new NurseInfoDetailViewModel()
            {
                UserId = nurse.UserId,
                NationalCode = info.NationalCode,
                Education = info.Education,
                RejectDescription = nurseOffice.RejectDescription,
                DoctorsInfosType = nurseOffice.OrganizationInfoState,
                Id = info.Id,
                NurseId = nurse.Id,
            };

            #endregion

            #region Get Nurse Work Addresses

            model.WorkAddresses = await _workAddressRepository.GetUserWorkAddressesByUserId(nurse.UserId);

            #endregion

            return model;
        }

        //Get Nurse Info By Nurse Id
        public async Task<NurseInfo?> GetNurseInfoById(ulong nurseId)
        {
            return await _nurseRepository.GetNurseInfoById(nurseId);
        }

        //Edit Nurse Info From Admin Panel
        public async Task<EditNurseInfoResult> EditNurseInfoAdminSide(NurseInfoDetailViewModel model)
        {
            #region Get Nurse Info By Id

            //Get Nurse Info By Id
            var info = await _nurseRepository.GetNurseInfoById(model.Id);
            if (info == null) return EditNurseInfoResult.faild;

            #endregion

            #region Get Nurse By Id 

            var nurse = await GetNurseById(model.NurseId);
            if (nurse == null) return EditNurseInfoResult.faild;

            #endregion

            #region Get Current Nurse Office

            var nurseOffice = await _organizationRepository.GetNurseOrganizationByUserId(nurse.UserId);
            if (nurseOffice == null) return EditNurseInfoResult.faild;
            if (nurseOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Nurse) return EditNurseInfoResult.faild;

            #endregion

            #region Update Nurse 

            nurseOffice.OrganizationInfoState = model.DoctorsInfosType;
            nurseOffice.RejectDescription = model.RejectDescription;

            if (model.DoctorsInfosType == OrganizationInfoState.Accepted)
            {
                nurseOffice.RejectDescription = null;
            }

            await _organizationRepository.UpdateOrganization(nurseOffice);

            #endregion

            #region Edit Nurse Info 

            #region Edit Properties

            info.Education = model.Education;
            info.NationalCode = model.NationalCode;

            #endregion

            #region Update Method

            await _nurseRepository.UpdateNurseInfo(info);

            #endregion

            #endregion

            return EditNurseInfoResult.success;
        }


        #endregion

        #region Site Side 

        //Get List Of Nurse For Send Notification For Home Nurse Notification 
        public async Task<List<string?>> GetListOfNursesForArrivalsHomeNurseRequests(ulong requestId)
        {
            #region Get Request By Id 

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return null;

            #endregion

            #region Get Request Detail 

            var requetsDetail = await _requestService.GetPatientRequestDetailByRequestId(requestId);
            if (requetsDetail == null) return null;

            #endregion

            #region Get Activated Pharmacy By Home Pharmacy Interests And Location Address

            var returnValue = await _nurseRepository.GetActivatedNurses(requetsDetail.CountryId, requetsDetail.StateId, requetsDetail.CityId);

            #endregion

            return returnValue;
        }

        #endregion
    }
}
