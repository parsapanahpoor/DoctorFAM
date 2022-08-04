using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Pharmacy;
using DoctorFAM.Domain.ViewModels.Pharmacy.HomePharmacy;
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

        private readonly IRequestService _requestService;

        private readonly IPatientService _patientService;

        private readonly IHomePharmacyServicec _homePharmacyService;

        public PharmacyService(IPharmacyRepository pharmacy, IOrganizationService organizationService, IUserService userService
                        , IPatientService patientService, IWorkAddressService workAddress, IRequestService requestService, IHomePharmacyServicec homePharmacyService)
        {
            _pharmacy = pharmacy;
            _organizationService = organizationService;
            _userService = userService;
            _workAddress = workAddress;
            _requestService = requestService;
            _patientService = patientService;
            _homePharmacyService = homePharmacyService;
        }

        #endregion

        #region Pharmacy Panel Side

        //Show Home Pharmacy Request Detail
        public async Task<HomePharmacyRequestViewModel?> FillHomePharmacyRequestViewModel(ulong requestId)
        {
            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return null;
            if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeDrog) return null;
            if (request.RequestState !=  Domain.Enums.Request.RequestState.Paid) return null;
            if (request.OperationId.HasValue) return null;
            if (!request.PatientId.HasValue) return null;

            #endregion

            #region Fill Model 

            HomePharmacyRequestViewModel model = new HomePharmacyRequestViewModel()
            {
                Patient = await _patientService.GetPatientById(request.PatientId.Value),
                User = await _userService.GetUserById(request.UserId),
                HomePharmacyRequestDetails = await _homePharmacyService.GetHomePharmacyRequestDetailByRequestId(request.Id),
                PatientRequestDetail = await _homePharmacyService.GetRequestPatientDetailByRequestId(request.Id),
                PatientRequestDateTimeDetail = await _homePharmacyService.GetRequestDateTimeDetailByRequestDetailId(request.Id),
                Request = request
            };

            #endregion

            return model;
        }

        //Get List Of Pharmacy Interests
        public async Task<List<PharmacyInterestInfo>> GetPharmacyInterestsInfo()
        {
            return await _pharmacy.GetPharmacyInterestsInfo();
        }

        //Fill Pharmacy Ineterest In Doctor Panel
        public async Task<PharmacyInterestsViewModel> FillPharmacyInterestViewModelFromPharmacyPanel(ulong userId)
        {
            PharmacyInterestsViewModel model = new PharmacyInterestsViewModel();

            #region Get Pharmacy Interests List 

            model.PharmacyInterests = await GetPharmacyInterestsInfo();

            #endregion

            #region Get Pharmacy Selected Interests 

            var doctor = await GetPharmacyByUserId(userId);

            model.PharmacySelectedInterests = await _pharmacy.GetPharmacySelectedInterests(doctor.Id);

            #endregion

            return model;
        }

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

                if (pharmacyAddress != null && model.WorkAddress != null)
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

        //Get Pharmacy Information By Pharmacy Id 
        public async Task<PharmacyInfo?> GetPharmacyInfoByPharmacyId(ulong pharmacyId)
        {
            return await _pharmacy.GetPharmacyInfoByPharmacyId(pharmacyId);
        }

        //Get Pharmacy By Pharmacy Id 
        public async Task<Pharmacy?> GetPharmacyById(ulong pharmacyId)
        {
            return await _pharmacy.GetPharmacyById(pharmacyId);
        }

        //Get Pharamcy Selected Ineterests
        public async Task<List<PharmacyInterestInfo>> GetPharmacySelectedInterests(ulong pharmacyId)
        {
            return await _pharmacy.GetPharmacySelectedInterests(pharmacyId);
        }

        //Delete Pharmacy Selected Interests
        public async Task DeletePharmacySelectedInterest(PharmacySelectedInterests item)
        {
            await _pharmacy.DeletePharmacySelectedInterest(item);
        }

        //Is Exist Any Pharmacy Selected Interests By Pharmacy Id And Interests Id
        async Task<bool> IsExistInterestForPharmacy(ulong interestId, ulong pharmacyId)
        {
            return await _pharmacy.IsExistInterestForPharmacy(interestId, pharmacyId);
        }

        //Is Exist This Current Interest
        public async Task<bool> IsExistInterestById(ulong interestId)
        {
            return await _pharmacy.IsExistInterestById(interestId);
        }

        //Add Selected Interest To Pharmacy Selected Interests
        public async Task<PharmacySelectedInterestResult> AddPharmacySelectedInterest(ulong interestId, ulong userId)
        {
            #region Gett Pharmacy

            var pharmacy = await _pharmacy.GetPharmacyByUserId(userId);
            if (pharmacy == null) return PharmacySelectedInterestResult.Faild;

            #endregion

            #region Get Current Pharmacy Office

            var pharmacyOffice = await _organizationService.GetPharmacyOrganizationByUserId(userId);
            if (pharmacyOffice == null) return PharmacySelectedInterestResult.Faild;
            if (pharmacyOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Pharmacy) return PharmacySelectedInterestResult.Faild;

            #endregion

            #region Is Exist Iterest For Pharmacy

            if (await _pharmacy.IsExistInterestForPharmacy(interestId, pharmacy.Id))
            {
                return PharmacySelectedInterestResult.ItemIsExist;
            }

            #endregion

            #region Is Exist Interest By Id

            if (!await _pharmacy.IsExistInterestById(interestId))
            {
                return PharmacySelectedInterestResult.Faild;
            }

            #endregion

            #region Fill Entity

            PharmacySelectedInterests model = new PharmacySelectedInterests
            {
                PharmacyId = pharmacy.Id,
                InterestId = interestId
            };

            #endregion

            #region Add Method

            await _pharmacy.AddPharmacySelectedInterest(model);

            #endregion

            #region Update Pharmacy Office State 

            //Update Pharmacy Office State 
            pharmacyOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

            await _organizationService.UpdateOrganization(pharmacyOffice);

            #endregion

            return PharmacySelectedInterestResult.Success;
        }

        //Delete Inetrest From Pharmacy Selected Interest 
        public async Task<PharmacySelectedInterestResult> DeletePharmacySelectedInterestPharmacyPanel(ulong interestId, ulong userId)
        {
            #region Get Pharmacy

            var pharmacy = await GetPharmacyByUserId(userId);
            if (pharmacy == null) return PharmacySelectedInterestResult.Faild;

            #endregion

            #region Get Interest 

            var interest = await _pharmacy.GetPharmacySelectedInterestByPharmacyIdAndInetestId(interestId, pharmacy.Id);
            if (interest == null) return PharmacySelectedInterestResult.ItemNotExist;

            #endregion

            #region Get Pharmacy Selected Interest

            var selectedItem = await _pharmacy.GetPharmacySelectedInterestByPharmacyIdAndInetestId(interestId, pharmacy.Id);
            if (selectedItem == null) return PharmacySelectedInterestResult.ItemNotExist;

            #endregion

            #region Remove item

            await _pharmacy.DeletePharmacySelectedInterest(selectedItem);

            #endregion

            return PharmacySelectedInterestResult.Success;
        }

        #endregion

        #region Admin Side 

        //Show Pharmacy Information Detial For Admin Or Supporter
        public async Task<PharmacyInfoDetailViewModel?> FillPharmacyInfoDetailViewModel(ulong pharmacyInfoId)
        {
            #region Get Pharmacy Info

            //Get Pharmacy Info By Id
            var info = await _pharmacy.GetPharmacyInfoByPharmacyId(pharmacyInfoId);

            if (info == null) return null;

            #endregion

            #region Get Pharmacy Info

            var pharmacy = await GetPharmacyById(info.PharmacyId);

            if (pharmacy == null) return null;

            #endregion

            #region Get Current Pharmacy Office

            var pharmacyOffice = await _organizationService.GetPharmacyOrganizationByUserId(pharmacy.UserId);
            if (pharmacyOffice == null) return null;
            if (pharmacyOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Pharmacy) return null;

            #endregion

            #region Fill View Model

            PharmacyInfoDetailViewModel model = new PharmacyInfoDetailViewModel()
            {
                UserId = pharmacy.UserId,
                NationalCode = info.NationalCode,
                RejectDescription = pharmacyOffice.RejectDescription,
                PharmacyInfosType = pharmacyOffice.OrganizationInfoState,
                Id = info.Id,
                PharmacyId = pharmacy.Id,
                PharmacyInterests = await _pharmacy.GetPharmacySelectedInterests(pharmacy.Id),
            };

            #endregion

            #region Get Pharmacy Work Addresses

            model.WorkAddresses = await _workAddress.GetUserWorkAddressesByUserId(pharmacy.UserId);

            #endregion

            return model;
        }

        //Filter Pharmacys Informations In Admin Panels 
        public async Task<ListOfPharmacyInfoViewModel> FilterPharmacyInfoAdminSide(ListOfPharmacyInfoViewModel filter)
        {
            return await _pharmacy.FilterPharmacyInfoAdminSide(filter);
        }

        //Edit And Check Pharmacy Information In Admin Or Supporter Side
        public async Task<EditPharmacyInfoResult> EditPharmacyInfoAdminSide(PharmacyInfoDetailViewModel model)
        {
            #region Get Pharmacy Info By Id

            //Get Pharmacy Info By Id
            var info = await _pharmacy.GetPharmacyInfoByPharmacyId(model.PharmacyId);

            if (info == null) return EditPharmacyInfoResult.faild;

            #endregion

            #region Get Pharmacy By Id 

            var pharmacy = await GetPharmacyById(model.PharmacyId);

            #endregion

            #region Get Current Pharmacy Office

            var pharmacyOffice = await _organizationService.GetPharmacyOrganizationByUserId(pharmacy.UserId);
            if (pharmacyOffice == null) return EditPharmacyInfoResult.faild;
            if (pharmacyOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Pharmacy) return EditPharmacyInfoResult.faild;

            #endregion

            #region Update Pharmacy 

            pharmacyOffice.OrganizationInfoState = model.PharmacyInfosType;
            pharmacyOffice.RejectDescription = model.RejectDescription;

            if (model.PharmacyInfosType == OrganizationInfoState.Accepted)
            {
                pharmacyOffice.RejectDescription = null;
            }

            await _organizationService.UpdateOrganization(pharmacyOffice);

            #endregion

            #region Edit Pharmacy Info 

            #region Edit Properties

            info.NationalCode = model.NationalCode;

            #endregion
         
            #region Update Method

            await _pharmacy.UpdatePharmacyInfo(info);

            #endregion

            #endregion

            return EditPharmacyInfoResult.success;
        }

        //Delete Pharmacy Selected Ineterest From Pharmacy Selected Items 
        public async Task<PharmacySelectedInterestResult> DeletePharmacySelectedInterestDoctorPanel(ulong interestId, ulong userId)
        {
            #region Get Pharmacy

            var pharmacy = await GetPharmacyByUserId(userId);
            if (pharmacy == null) return PharmacySelectedInterestResult.Faild;

            #endregion

            #region Get Interest 

            var interest = await _pharmacy.GetPharmacySelectedInterestByPharmacyIdAndInetestId(interestId, pharmacy.Id);
            if (interest == null) return PharmacySelectedInterestResult.ItemNotExist;

            #endregion

            #region Remove item

            await _pharmacy.DeletePharmacySelectedInterest(interest);

            #endregion

            return PharmacySelectedInterestResult.Success;
        }

        //Filter List Of Home Pharmacy Request ViewModel From User Or Supporter Panel 
        public async Task<FilterListOfHomePharmacyRequestViewModel> FilterListOfHomePharmacyRequestViewModel(FilterListOfHomePharmacyRequestViewModel filter)
        {
            return await _pharmacy.FilterListOfHomePharmacyRequestViewModel(filter);
        }

        #endregion
    }
}
