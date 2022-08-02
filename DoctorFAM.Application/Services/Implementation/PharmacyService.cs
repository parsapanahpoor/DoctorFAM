using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Pharmacy;
using DoctorFAM.Domain.ViewModels.Pharmacy.PharmacyInfo;
using DoctorFAM.Domain.ViewModels.Pharmacy.PharmacySideBar;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DoctorFAM.Domain.ViewModels.Pharmacy.PharmacyInfo.ManagePharmacyInfoViewModel;

namespace DoctorFAM.Application.Services.Implementation
{
    public class PharmacyService : IPharmacyService
    {
        #region Ctor

        private readonly IPharmacyRepository _pharmacy;

        private readonly IOrganizationService _organizationService;

        private readonly IUserService _userService;

        private readonly IWorkAddressService _workAddress;

        public PharmacyService(IPharmacyRepository pharmacy , IOrganizationService organizationService , IUserService userService , IWorkAddressService workAddress)
        {
            _pharmacy = pharmacy;
            _organizationService = organizationService;
            _userService = userService;
            _workAddress = workAddress;
        }

        #endregion

        #region Pharmacy Panel Side

        public async Task AddPharmacyForFirstTime(ulong userId)
        {
            #region Pharmacy Entity

            #region Fill Pharmacy Model

            Pharmacy pharmacy = new Pharmacy()
            {
                UserId = userId,
                CreateDate = DateTime.Now,
                IsDelete = false,
            };

            #endregion

            #region Add Pharmacy

            await _pharmacy.AddPharmacy(pharmacy);

            #endregion

            #endregion

            #region Organization Entity

            #region Fill Organization Model

            Organization organization = new Organization()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                OrganizationInfoState = OrganizationInfoState.JustRegister,
                OrganizationType = Domain.Enums.Organization.OrganizationType.Pharmacy,
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

        public async Task<bool> IsExistAnyPharmacyByUserId(ulong userId)
        {
            return await _pharmacy.IsExistAnyPharmacyByUserId(userId);
        }

        public async Task<Pharmacy?> GetPharmacyByUserId(ulong userId)
        {
            return await _pharmacy.GetPharmacyByUserId(userId);
        }

        public async Task<PharmacySideBarViewModel> GetPharmacySideBarInfo(ulong userId)
        {
            return await _pharmacy.GetPharmacySideBarInfo(userId);
        }

        public async Task<bool> IsExistAnyPharmacyInfoByUserId(ulong userId)
        {
            return await _pharmacy.IsExistAnyPharmacyInfoByUserId(userId);
        }

        public async Task<PharmacyInfo?> GetPharmacyInformationByUserId(ulong userId)
        {
            return await _pharmacy.GetPharmacyInformationByUserId(userId);
        }

        public async Task<ManagePharmacyInfoViewModel?> FillManagePharmacyInfoViewModel(ulong userId)
        {
            #region Check Is User Exist 

            var user = await _userService.GetUserById(userId);

            if (user == null) return null;

            #endregion

            #region Get Current Pharmacy Office

            var pharmacyOffice = await _organizationService.GetPharmacyOrganizationByUserId(userId);
            if (pharmacyOffice == null) return null;
            if (pharmacyOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Pharmacy) return null;

            #endregion

            #region Get User Office Address

            var workAddress = await _workAddress.GetUserWorkAddressById(userId);

            #endregion

            #region Exist Pharmacy Information

            //Is Exist Pharmacy Informations
            if (await IsExistAnyPharmacyInfoByUserId(userId))
            {
                //Get Current Pharmacy Information
                var pharmacyInfo = await GetPharmacyInformationByUserId(userId);

                //Fill Model For return Value
                ManagePharmacyInfoViewModel model = new ManagePharmacyInfoViewModel()
                {
                    UserId = userId,
                    PharmacyInfosType = pharmacyOffice.OrganizationInfoState,
                    NationalCode = pharmacyInfo.NationalCode,
                    RejectDescription = pharmacyOffice.RejectDescription,
                };

                //Fill Pharmacy Cilinic Address
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
                ManagePharmacyInfoViewModel model = new ManagePharmacyInfoViewModel()
                {
                    UserId = userId
                };

                return model;
            }

            #endregion

            return null;
        }

        public async Task<AddOrEditPharmcyInfoResult> AddOrEditPharmacyInfoPharmacyPanel(ManagePharmacyInfoViewModel model)
        {
            #region Get User By User Id

            var user = await _userService.GetUserById(model.UserId);

            if (user == null) return AddOrEditPharmcyInfoResult.Faild;

            #endregion

            #region Get Current Pharmacy Office

            var pharmacyOffice = await _organizationService.GetPharmacyOrganizationByUserId(model.UserId);
            if (pharmacyOffice == null) return AddOrEditPharmcyInfoResult.Faild;
            if (pharmacyOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Pharmacy) return AddOrEditPharmcyInfoResult.Faild;

            #endregion

            #region Get Pharmacy By User Id 

            //Get Pharmacy By UserId
            var pharmacy = await GetPharmacyByUserId(user.Id);

            #endregion

            #region Is Exist Informations

            var existInfo = await IsExistAnyPharmacyInfoByUserId(model.UserId);

            #endregion

            #region Edit Info

            if (existInfo == true)
            {
                #region Update Properties

                //Get Pharmacy Informations By Pharmacy Id
                var info = await GetPharmacyInformationByUserId(model.UserId);

                //Edit Fields 
                info.NationalCode = model.NationalCode;

                //Update Pharmacy Office Organization State 
                pharmacyOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

                #endregion

                #region Update Pharmacy Address

                var pharmacyAddress = await _workAddress.GetUserWorkAddressById(model.UserId);

                if (pharmacyAddress != null)
                {
                    pharmacyAddress.Address = model.WorkAddress;
                    pharmacyAddress.CountryId = model.CountryId.Value;
                    pharmacyAddress.StateId = model.StateId.Value;
                    pharmacyAddress.CityId = model.CityId.Value;

                    await _workAddress.UpdateUserWorkAddress(pharmacyAddress);
                }

                if (pharmacyAddress == null && model.WorkAddress != null)
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

                    await _workAddress.AddWorkAddress(workAddress);
                }

                #endregion

                #region Update Methods

                await _pharmacy.UpdatePharmacyInfo(info);

                await _organizationService.UpdateOrganization(pharmacyOffice);

                #endregion
            }

            #endregion

            #region Add Info

            if (existInfo == false)
            {
                if (pharmacy != null)
                {
                    #region Fill View Model

                    PharmacyInfo managePharmacyInfoViewModel1 = new PharmacyInfo()
                    {
                        PharmacyId = pharmacy.Id,
                        NationalCode = model.NationalCode,
                    };

                    #endregion

                    #region Add Pharmacy Address

                    if (model.WorkAddress != null)
                    {
                        WorkAddress workAddress = new WorkAddress()
                        {
                            UserId = model.UserId,
                            Address = model.WorkAddress
                        };

                        await _workAddress.AddWorkAddress(workAddress);
                    }

                    #endregion

                    #region Update Pharmacy Office

                    pharmacyOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

                    #endregion

                    #region Update Methods

                    await _pharmacy.AddPharmacyInfo(managePharmacyInfoViewModel1);

                    await _organizationService.UpdateOrganization(pharmacyOffice);

                    #endregion
                }
                else
                {
                    #region Add Doctor

                    Pharmacy newPharmacy = new Pharmacy()
                    {
                        CreateDate = DateTime.Now,
                        UserId = user.Id,
                        IsDelete = false
                    };

                    var newDoctorId = await _pharmacy.AddPharmacy(newPharmacy);

                    #endregion

                    #region Add Pharmacy Address

                    if (model.WorkAddress != null)
                    {
                        WorkAddress workAddress = new WorkAddress()
                        {
                            UserId = model.UserId,
                            Address = model.WorkAddress
                        };

                        await _workAddress.AddWorkAddress(workAddress);
                    }

                    #endregion

                    #region Organization Entity

                    #region Fill Organization Model

                    Organization organization = new Organization()
                    {
                        CreateDate = DateTime.Now,
                        IsDelete = false,
                        OrganizationInfoState = OrganizationInfoState.JustRegister,
                        OrganizationType = Domain.Enums.Organization.OrganizationType.DoctorOffice,
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

                    PharmacyInfo managePharmacyInfoViewModel = new PharmacyInfo()
                    {
                        PharmacyId = newPharmacy.Id,
                        NationalCode = model.NationalCode,
                    };

                    #endregion

                    #region Update Methods

                    await _pharmacy.AddPharmacyInfo(managePharmacyInfoViewModel);

                    #endregion
                }
            }

            #endregion

            return AddOrEditPharmcyInfoResult.Success;
        }

        //Filter Pharmacys Informations In Admin Panels 
        public async Task<ListOfPharmacyInfoViewModel> FilterPharmacyInfoAdminSide(ListOfPharmacyInfoViewModel filter)
        {
            return await _pharmacy.FilterPharmacyInfoAdminSide(filter);
        }

        #endregion
    }
}
