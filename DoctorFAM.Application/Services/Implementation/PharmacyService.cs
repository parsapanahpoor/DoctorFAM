﻿using DoctorFAM.Application.Services.Interfaces;
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

        //Fill Finally Invoice From Pharmacy View Model
        public async Task<FinallyInvoiceViewModel?> FinallyInvoiceViewModel(ulong requestId , ulong userId)
        {
            #region Get Organization By User Id

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return null;
            if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeDrog) return null;
            if (request.OperationId.HasValue && request.OperationId.Value != organization.OwnerId) return null;
            if (!request.PatientId.HasValue) return null;

            #endregion

            #region Get Patient 

            var patient = await _userService.GetUserById(request.UserId);
            if (patient == null) return null;

            #endregion

            #region Home Pharamcy Request Detail 

            var pharmacyDetail = await _homePharmacyService.GetHomePharmacyRequestDetailByRequestId(request.Id);

            #endregion

            #region Fill Page Model

            List<HomePharmacyInvoiceViewModel> priceModel = new List<HomePharmacyInvoiceViewModel>();

            foreach (var item in pharmacyDetail)
            {
                //Is Exist Invoice Pricing For This Drug Get This Price 
                var price = await GetHomePharmacyRequestDetailPriceByPharmacyIdAndRequestDetailId(organization.OwnerId, item.Id);

                //Is Exist Any Drug For This Drug With Drug Tracking Code 
                if (!string.IsNullOrEmpty(item.DrugTrakingCode))
                {
                    var childDrugs = await _pharmacy.GetDrugPricingChildWithDrugTrackingCodeAndSellerID(item.Id, organization.OwnerId);

                    //Add Parent Pricing
                    HomePharmacyInvoiceViewModel parent = new HomePharmacyInvoiceViewModel()
                    {
                        HomePharmacyRequestDetail = item,
                        Price = ((childDrugs == null) ? 0 : ((price != null) ? price.Price : null)),
                        DrugNameFromPharmacy = null,
                        PricingId = null
                    };
                    priceModel.Add(parent);

                    //Add Child Pricing
                    if (childDrugs != null && childDrugs.Any())
                    {
                        foreach (var child in childDrugs.Where(p => p.DrugNameFromPharmacy != null))
                        {
                            HomePharmacyInvoiceViewModel childPricing = new HomePharmacyInvoiceViewModel()
                            {
                                HomePharmacyRequestDetail = item,
                                Price = ((child != null) ? child.Price : null),
                                DrugNameFromPharmacy = child.DrugNameFromPharmacy,
                                PricingId = child.Id
                            };
                            priceModel.Add(childPricing);
                        }
                    }
                }

                //Any Drugs Without Drug Tracking Code 
                else
                {
                    HomePharmacyInvoiceViewModel returnModel = new HomePharmacyInvoiceViewModel()
                    {
                        HomePharmacyRequestDetail = item,
                        Price = ((price != null) ? price.Price : null),
                        DrugNameFromPharmacy = null,
                        PricingId = null
                    };

                    priceModel.Add(returnModel);
                }
            }

            #endregion


            #region Fill View Model 

            FinallyInvoiceViewModel model = new FinallyInvoiceViewModel()
            {
                Pharmacy = organization.User,
                Patient = patient,
                Request = request,
                HomePharmacyInvoiceViewModels = priceModel
            };

            #endregion

            return model;
        }

        //Get Request Id By Home Pharmacy Request Detail Pricing Id And Seller Id
        public async Task<ulong> GetRequestIdByHomePharmacyRequestDetailPricingId(ulong requestDetailPricingId, ulong userId)
        {
            return await _pharmacy.GetRequestIdByHomePharmacyRequestDetailPricingId(requestDetailPricingId,userId);
        }

        //Fill Add Drug From Pharamcy In Invoice Modal
        public async Task<AddDrugFromPharmacyInInvoice> AddDrugFromPharamcyIntoInvoice(ulong requestDetailId)
        {
            return new AddDrugFromPharmacyInInvoice()
            {
                RequestDetailId = requestDetailId,
            };
        }

        //Filter List Of Yours Accepted  Home Pharmacy Request ViewModel  
        public async Task<FilterListOfHomePharmacyRequestViewModel> FilterListOfYourAcceptedHomePharmacyRequest(FilterListOfHomePharmacyRequestViewModel filter)
        {
            return await _pharmacy.FilterListOfYourAcceptedHomePharmacyRequest(filter);
        }

        //Show Home Pharmacy Request Detail In Pharmacy Panel
        public async Task<HomePharmacyRequestViewModel?> FillHomePharmacyRequestViewModel(ulong requestId, ulong userId)
        {
            #region Get Organization By User Id

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return null;
            if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeDrog) return null;
            if (request.OperationId.HasValue && request.OperationId.Value != organization.OwnerId) return null;
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

        //Fill Home Pharmacy Invoice Page Model
        public async Task<List<HomePharmacyInvoiceViewModel>> FillHomePharmcyInvoicePageModel(ulong requestId, ulong userId)
        {
            #region Get Organization By User Id

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return null;
            if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeDrog) return null;
            if (request.OperationId.HasValue && request.OperationId.Value != organization.OwnerId) return null;
            if (!request.PatientId.HasValue) return null;

            #endregion

            #region Update Request For Fill Operaiting 

            request.OperationId = organization.OwnerId;
            request.RequestState = Domain.Enums.Request.RequestState.ConfirmFromDestinationAndWaitingForIssuanceOfDraftInvoice;

            await _requestService.UpdateRequest(request);

            #endregion

            #region Home Pharamcy Request Detail 

            var pharmacyDetail = await _homePharmacyService.GetHomePharmacyRequestDetailByRequestId(request.Id);

            #endregion

            #region Fill Page Model

            List<HomePharmacyInvoiceViewModel> model = new List<HomePharmacyInvoiceViewModel>();

            foreach (var item in pharmacyDetail)
            {
                //Is Exist Invoice Pricing For This Drug Get This Price 
                var price = await GetHomePharmacyRequestDetailPriceByPharmacyIdAndRequestDetailId(organization.OwnerId, item.Id);

                //Is Exist Any Drug For This Drug With Drug Tracking Code 
                if (!string.IsNullOrEmpty(item.DrugTrakingCode))
                {
                    var childDrugs = await _pharmacy.GetDrugPricingChildWithDrugTrackingCodeAndSellerID(item.Id , organization.OwnerId);

                    //Add Parent Pricing
                    HomePharmacyInvoiceViewModel parent = new HomePharmacyInvoiceViewModel()
                    {
                        HomePharmacyRequestDetail = item,
                        Price = ((childDrugs == null) ? 0 : ((price != null) ? price.Price : null)),
                        DrugNameFromPharmacy = null,
                        PricingId = null
                    };
                    model.Add(parent);

                    //Add Child Pricing
                    if (childDrugs != null && childDrugs.Any())
                    {
                        foreach (var child in childDrugs.Where(p=> p.DrugNameFromPharmacy != null))
                        {
                            HomePharmacyInvoiceViewModel childPricing = new HomePharmacyInvoiceViewModel()
                            {
                                HomePharmacyRequestDetail = item,
                                Price = ((child != null) ? child.Price : null),
                                DrugNameFromPharmacy = child.DrugNameFromPharmacy,
                                PricingId = child.Id
                            };
                            model.Add(childPricing);
                        }
                    }
                }

                //Any Drugs Without Drug Tracking Code 
                else
                {
                    HomePharmacyInvoiceViewModel returnModel = new HomePharmacyInvoiceViewModel()
                    {
                        HomePharmacyRequestDetail = item,
                        Price = ((price != null) ? price.Price : null),
                        DrugNameFromPharmacy = null,
                        PricingId = null
                    };

                    model.Add(returnModel);
                }
            }

            #endregion

            return model;
        }

        //Get Home Pharmacy Request Detail Price By Pahramcy Id And Request Detail Id 
        public async Task<HomePharmacyRequestDetailPrice?> GetHomePharmacyRequestDetailPriceByPharmacyIdAndRequestDetailId(ulong pharamcyId, ulong requestDetailId)
        {
            return await _pharmacy.GetHomePharmacyRequestDetailPriceByPharmacyIdAndRequestDetailId(pharamcyId, requestDetailId);
        }

        //Add Picing For Drug In Invoivcing Home Pharmacy Request
        public async Task<bool> AddPricingFromPharmacyForDrugInInvoicingHomePhamracyRequest(ulong homePhramcyRequestDetailId, int price, ulong userId)
        {
            #region Get Home Pharmacy Request Detail By Id 

            var requestDetail = await GetHomePhamracyRequestDetailById(homePhramcyRequestDetailId);
            if (requestDetail == null) return false;

            #endregion

            #region Get Organization By User Id

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestDetail.RequestId);

            if (request == null) return false;
            if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeDrog) return false;
            if (request.OperationId.HasValue && request.OperationId.Value != organization.OwnerId) return false;
            if (!request.PatientId.HasValue) return false;

            #endregion

            #region Check Is Exist Any Price For This Drug From This Pharmacy 

            var pricing = await GetHomePharmacyRequestDetailPriceByPharmacyIdAndRequestDetailId(organization.OwnerId, homePhramcyRequestDetailId);

            //Add Price For This Drug From This Pharmacy
            if (pricing == null)
            {
                HomePharmacyRequestDetailPrice addModel = new HomePharmacyRequestDetailPrice()
                {
                    Price = price,
                    HomePharmacyRequestDetailId = requestDetail.Id,
                    SellerId = organization.OwnerId,
                };

                //Add Method 
                await _pharmacy.AddPricingForDrugFromHomePharmacyRequestDetail(addModel);
            }

            //Update Price For This Drug From This Pharmacy
            if (pricing != null)
            {
                //Update Price 
                pricing.Price = price;

                //Update Method 
                await _pharmacy.UpdatePricingForDrugFromHomePharmacyRequestDetail(pricing);
            }

            #endregion

            return true;
        }

        //Add Drug Pricing From Pharmacy Into Invoicing
        public async Task<bool> AddDrugPricingFromPharmacyIntoInvoic(ulong homePhramcyRequestDetailId, int price, ulong userId, string? drugNameFromPharmacy)
        {
            #region Get Home Pharmacy Request Detail By Id 

            var requestDetail = await GetHomePhamracyRequestDetailById(homePhramcyRequestDetailId);
            if (requestDetail == null) return false;

            #endregion

            #region Get Organization By User Id

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestDetail.RequestId);

            if (request == null) return false;
            if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeDrog) return false;
            if (request.OperationId.HasValue && request.OperationId.Value != organization.OwnerId) return false;
            if (!request.PatientId.HasValue) return false;

            #endregion

            #region Check Is Exist Any Price For This Drug From This Pharmacy 

            var pricing = await GetHomePharmacyRequestDetailPriceByPharmacyIdAndRequestDetailId(organization.OwnerId, homePhramcyRequestDetailId);

            HomePharmacyRequestDetailPrice addModel = new HomePharmacyRequestDetailPrice()
            {
                Price = price,
                HomePharmacyRequestDetailId = requestDetail.Id,
                SellerId = organization.OwnerId,
                DrugNameFromPharmacy = drugNameFromPharmacy,
            };

            //Add Method 
            await _pharmacy.AddPricingForDrugFromHomePharmacyRequestDetail(addModel);

            #endregion

            #region Remove Parent Price 

            await _pharmacy.RemoveParentDrugPricingWhenAddChildDrugPricing(organization.OwnerId, homePhramcyRequestDetailId);

            #endregion

            return true;
        }

        //Get Home Phrmacy Request Detail By Id 
        public async Task<HomePharmacyRequestDetail?> GetHomePhamracyRequestDetailById(ulong requestDetailId)
        {
            return await _pharmacy.GetHomePhamracyRequestDetailById(requestDetailId);
        }

        //Delete Home Drug Request Detail Pricing Child From Pharmacy
        public async Task<bool> DeleteHomeDrugRequestDetailPricingChildFromPharmacy(ulong requestDetailPricingId, ulong userId)
        {
            #region Get Organization By User Id

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            return await _pharmacy.DeleteHomeDrugRequestDetailPricingChildFromPharmacy(requestDetailPricingId , organization.OwnerId);
        }

        //Get Sum Of Invoice From Home Pharmacy Request Detail Pricing Fields
        public async Task<int> GetSumOfInvoiceHomePharmacyRequestDetailPricing(ulong requestId, ulong sellerId)
        {
            return await _pharmacy.GetSumOfInvoiceHomePharmacyRequestDetailPricing(requestId, sellerId);
        }

        //Update Request To Delivary By Courier
        public async Task<bool> DeliveryByCourier(ulong requestId , ulong pharmacyId)
        {
            #region Get Organization By User Id

            var organization = await _organizationService.GetOrganizationByUserId(pharmacyId);
            if (organization == null) return false;

            #endregion

            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return false;
            if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeDrog) return false;
            if (request.OperationId.HasValue && request.OperationId.Value != organization.OwnerId) return false;
            if (!request.PatientId.HasValue) return false;

            #endregion

            #region Update Request State 

            request.RequestState = Domain.Enums.Request.RequestState.DeliveryToCourierAndSending;

            await _requestService.UpdateRequest(request);

            #endregion

            return true;
        }

        #endregion

        #region Admin Side 

        //Fill Finally Invoice From Admin Panel View Model
        public async Task<DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomePharmacy.FinallyInvoiceViewModel?> FinallyInvoiceFromAdminViewModel(ulong requestId)
        {
            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return null;
            if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeDrog) return null;
            if (request.RequestState == Domain.Enums.Request.RequestState.Paid
              || request.RequestState == Domain.Enums.Request.RequestState.WaitingForConfirmFromDestination
              || request.RequestState == Domain.Enums.Request.RequestState.ConfirmFromDestinationAndWaitingForIssuanceOfDraftInvoice
              || request.RequestState == Domain.Enums.Request.RequestState.TramsferringToTheBankingPortal
              || request.RequestState == Domain.Enums.Request.RequestState.PreparingTheOrder
              || request.RequestState == Domain.Enums.Request.RequestState.unpaid
              || request.RequestState == Domain.Enums.Request.RequestState.TramsferringToTheBankingPortal) return null;
            if (!request.PatientId.HasValue) return null;

            #endregion

            #region Get Patient 

            var patient = await _userService.GetUserById(request.UserId);
            if (patient == null) return null;

            #endregion

            #region Home Pharamcy Request Detail 

            var pharmacyDetail = await _homePharmacyService.GetHomePharmacyRequestDetailByRequestId(request.Id);

            #endregion

            #region Fill Page Model

            List<HomePharmacyInvoiceViewModel> priceModel = new List<HomePharmacyInvoiceViewModel>();

            foreach (var item in pharmacyDetail)
            {
                //Is Exist Invoice Pricing For This Drug Get This Price 
                var price = await GetHomePharmacyRequestDetailPriceByPharmacyIdAndRequestDetailId(request.OperationId.Value, item.Id);

                //Is Exist Any Drug For This Drug With Drug Tracking Code 
                if (!string.IsNullOrEmpty(item.DrugTrakingCode))
                {
                    var childDrugs = await _pharmacy.GetDrugPricingChildWithDrugTrackingCodeAndSellerID(item.Id, request.OperationId.Value);

                    //Add Parent Pricing
                    HomePharmacyInvoiceViewModel parent = new HomePharmacyInvoiceViewModel()
                    {
                        HomePharmacyRequestDetail = item,
                        Price = ((childDrugs == null) ? 0 : ((price != null) ? price.Price : null)),
                        DrugNameFromPharmacy = null,
                        PricingId = null
                    };
                    priceModel.Add(parent);

                    //Add Child Pricing
                    if (childDrugs != null && childDrugs.Any())
                    {
                        foreach (var child in childDrugs.Where(p => p.DrugNameFromPharmacy != null))
                        {
                            HomePharmacyInvoiceViewModel childPricing = new HomePharmacyInvoiceViewModel()
                            {
                                HomePharmacyRequestDetail = item,
                                Price = ((child != null) ? child.Price : null),
                                DrugNameFromPharmacy = child.DrugNameFromPharmacy,
                                PricingId = child.Id
                            };
                            priceModel.Add(childPricing);
                        }
                    }
                }

                //Any Drugs Without Drug Tracking Code 
                else
                {
                    HomePharmacyInvoiceViewModel returnModel = new HomePharmacyInvoiceViewModel()
                    {
                        HomePharmacyRequestDetail = item,
                        Price = ((price != null) ? price.Price : null),
                        DrugNameFromPharmacy = null,
                        PricingId = null
                    };

                    priceModel.Add(returnModel);
                }
            }

            #endregion


            #region Fill View Model 

            DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomePharmacy.FinallyInvoiceViewModel model = new DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomePharmacy.FinallyInvoiceViewModel()
            {
                Patient = patient,
                Request = request,
                HomePharmacyInvoiceViewModels = priceModel
            };

            #endregion

            return model;
        }

        //Show Home Pharmacy Request Detail In Admin Panel
        public async Task<HomePharmacyRequestViewModel?> FillHomePharmacyRequestAdminPanelViewModel(ulong requestId)
        {
            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return null;
            if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeDrog) return null;
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

        #region User Panel 

        //Filter User Home Nurse Requests
        public async Task<Domain.ViewModels.UserPanel.HealthHouse.HomeNurse.FilterHomeNurseViewModel> FilterListOfUserHomeNurseRequest(Domain.ViewModels.UserPanel.HealthHouse.HomeNurse.FilterHomeNurseViewModel filter)
        {
            return await _pharmacy.FilterListOfUserHomeNurseRequest(filter);
        }

        //Filter User Home Pharmacy Requests
        public async Task<Domain.ViewModels.UserPanel.HealthHouse.FilterHomePharmacyViewModel> FilterListOfUserHomePhamracyRequest(Domain.ViewModels.UserPanel.HealthHouse.FilterHomePharmacyViewModel filter)
        {
            return await _pharmacy.FilterListOfUserHomePhamracyRequest(filter);
        }

        //Show Home Pharmacy Request Detail In User Panel
        public async Task<Domain.ViewModels.UserPanel.HealthHouse.HomePharmacyRequestViewModel?> FillHomePharmacyRequestInUserPanelViewModel(ulong requestId, ulong userId)
        {
            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return null;
            if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeDrog) return null;
            if (request.UserId != userId) return null;
            if (!request.PatientId.HasValue) return null;

            #endregion

            #region Fill Model 

            Domain.ViewModels.UserPanel.HealthHouse.HomePharmacyRequestViewModel model = new Domain.ViewModels.UserPanel.HealthHouse.HomePharmacyRequestViewModel()
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

        //Fill Finally Invoice From User Panel View Model
        public async Task<Domain.ViewModels.UserPanel.HealthHouse.FinallyInvoiceViewModel?> FinallyInvoiceFromUserPanelViewModel(ulong requestId, ulong userId)
        {
            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return null;
            if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeDrog) return null;
            if (request.RequestState == Domain.Enums.Request.RequestState.Paid
              || request.RequestState == Domain.Enums.Request.RequestState.WaitingForConfirmFromDestination
              || request.RequestState == Domain.Enums.Request.RequestState.ConfirmFromDestinationAndWaitingForIssuanceOfDraftInvoice
              || request.RequestState == Domain.Enums.Request.RequestState.TramsferringToTheBankingPortal
              || request.RequestState == Domain.Enums.Request.RequestState.PreparingTheOrder
              || request.RequestState == Domain.Enums.Request.RequestState.unpaid
              || request.RequestState == Domain.Enums.Request.RequestState.TramsferringToTheBankingPortal) return null;
            if (request.UserId != userId) return null;
            if (!request.PatientId.HasValue) return null;

            #endregion

            #region Get Patient 

            var patient = await _userService.GetUserById(request.UserId);
            if (patient == null) return null;

            #endregion

            #region Home Pharamcy Request Detail 

            var pharmacyDetail = await _homePharmacyService.GetHomePharmacyRequestDetailByRequestId(request.Id);

            #endregion

            #region Fill Page Model

            List<HomePharmacyInvoiceViewModel> priceModel = new List<HomePharmacyInvoiceViewModel>();

            foreach (var item in pharmacyDetail)
            {
                //Is Exist Invoice Pricing For This Drug Get This Price 
                var price = await GetHomePharmacyRequestDetailPriceByPharmacyIdAndRequestDetailId(request.OperationId.Value, item.Id);

                //Is Exist Any Drug For This Drug With Drug Tracking Code 
                if (!string.IsNullOrEmpty(item.DrugTrakingCode))
                {
                    var childDrugs = await _pharmacy.GetDrugPricingChildWithDrugTrackingCodeAndSellerID(item.Id, request.OperationId.Value);

                    //Add Parent Pricing
                    HomePharmacyInvoiceViewModel parent = new HomePharmacyInvoiceViewModel()
                    {
                        HomePharmacyRequestDetail = item,
                        Price = ((childDrugs == null) ? 0 : ((price != null) ? price.Price : null)),
                        DrugNameFromPharmacy = null,
                        PricingId = null
                    };
                    priceModel.Add(parent);

                    //Add Child Pricing
                    if (childDrugs != null && childDrugs.Any())
                    {
                        foreach (var child in childDrugs.Where(p => p.DrugNameFromPharmacy != null))
                        {
                            HomePharmacyInvoiceViewModel childPricing = new HomePharmacyInvoiceViewModel()
                            {
                                HomePharmacyRequestDetail = item,
                                Price = ((child != null) ? child.Price : null),
                                DrugNameFromPharmacy = child.DrugNameFromPharmacy,
                                PricingId = child.Id
                            };
                            priceModel.Add(childPricing);
                        }
                    }
                }

                //Any Drugs Without Drug Tracking Code 
                else
                {
                    HomePharmacyInvoiceViewModel returnModel = new HomePharmacyInvoiceViewModel()
                    {
                        HomePharmacyRequestDetail = item,
                        Price = ((price != null) ? price.Price : null),
                        DrugNameFromPharmacy = null,
                        PricingId = null
                    };

                    priceModel.Add(returnModel);
                }
            }

            #endregion


            #region Fill View Model 

            Domain.ViewModels.UserPanel.HealthHouse.FinallyInvoiceViewModel model = new Domain.ViewModels.UserPanel.HealthHouse.FinallyInvoiceViewModel()
            {
                Patient = patient,
                Request = request,
                HomePharmacyInvoiceViewModels = priceModel
            };

            #endregion

            return model;
        }

        //Accept Request From User
        public async Task<bool> AcceptRequestFromUser(ulong requestId , ulong userId)
        {
            #region Get Request By Id

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return false;
            if (request.UserId != userId) return false;
            if(request.OperationId.HasValue == false) return false;

            #endregion

            #region Check Request State 

            if (request.RequestState != Domain.Enums.Request.RequestState.WaitingForAcceptFromCustomer)
            {
                return false;
            }

            #endregion

            #region Update Request State 

            request.RequestState = Domain.Enums.Request.RequestState.AcceptFromCustomer;

            await _requestService.UpdateRequest(request);

            #endregion

            return true;
        }

        //Received By The Customer From User
        public async Task<bool> ReceivedByTheCustomerFromUserPanel(ulong requestId, ulong userId)
        {
            #region Get Request By Id

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return false;
            if (request.UserId != userId) return false;
            if (request.OperationId.HasValue == false) return false;

            #endregion

            #region Check Request State 

            if (request.RequestState != Domain.Enums.Request.RequestState.DeliveryToCourierAndSending)
            {
                return false;
            }

            #endregion

            #region Update Request State 

            request.RequestState = Domain.Enums.Request.RequestState.Finalized;

            await _requestService.UpdateRequest(request);

            #endregion

            return true;
        }

        #endregion
    }
}
