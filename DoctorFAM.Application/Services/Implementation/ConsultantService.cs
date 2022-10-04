using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.Migrations;
using DoctorFAM.Data.Repository;
using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FamilyDoctor;
using DoctorFAM.Domain.Entities.Nurse;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.PopulationCovered;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Consultant;
using DoctorFAM.Domain.ViewModels.Admin.Doctor;
using DoctorFAM.Domain.ViewModels.Admin.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantInfo;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantRequest;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantSideBar;
using DoctorFAM.Domain.ViewModels.DoctorPanel.PopulationCovered;
using DoctorFAM.Domain.ViewModels.Nurse.NurseInfo;
using DoctorFAM.Domain.ViewModels.UserPanel.Consultant;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;

namespace DoctorFAM.Application.Services.Implementation
{
    public class ConsultantService : IConsultantService
    {
        #region Ctor

        private readonly IConsultantRepository _consultantRepository;
        private readonly IOrganizationService _organizationService;
        private readonly IUserService _userService;
        private readonly IWorkAddressService _workAddressService;
        private readonly IPopulationCoveredService _populationCoveredService;

        public ConsultantService(IConsultantRepository consultantRepository, IOrganizationService organizationService, IUserService userService
                                    , IWorkAddressService workAddressService, IPopulationCoveredService populationCoveredService)
        {
            _consultantRepository = consultantRepository;
            _organizationService = organizationService;
            _userService = userService;
            _workAddressService = workAddressService;
            _populationCoveredService = populationCoveredService;
        }

        #endregion

        #region Consultant Panel Side

        //List Of Your Consultant Population Covered Users
        public async Task<ListOfConsultantPopulationCoveredViewModel> FilterYourListOfConsultantPopulationCoveredViewModel(ListOfConsultantPopulationCoveredViewModel filter)
        {
            return await _consultantRepository.FilterYourListOfConsultantPopulationCoveredViewModel(filter);
        }

        //Change User Selected Consultant Request From Consultant
        public async Task<bool> ChangeUserSeletedConsultantRequestFromConsultant(UserSelectedConsultant userSelectedRequest, ulong doctorId)
        {
            #region Get Doctor Organization

            var organization = await _organizationService.GetConsultantOrganizationByUserId(doctorId);
            if (organization == null) return false;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return false;

            #endregion

            #region Get User Selected Consultant Request 

            var request = await GetUserSelectedConsultantByRequestId(userSelectedRequest.Id);
            if (request == null) return false;
            if (request.ConsultantId != organization.OwnerId) return false;
            if (request.ConsultantRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Decline) return false;

            #endregion

            #region Update State 

            request.ConsultantRequestState = userSelectedRequest.ConsultantRequestState;
            request.RejectDescription = userSelectedRequest.RejectDescription;

            await _consultantRepository.UpdateUserSelectedConsultant(request);

            #endregion

            return true;
        }

        //Get User Selected Consultant By Request Id
        public async Task<UserSelectedConsultant?> GetUserSelectedConsultantByRequestId(ulong requestId)
        {
            return await _consultantRepository.GetUserSelectedConsultantByRequestId(requestId);
        }

        //Get User Selected Consultant By Patient Id And Consultant Id With Accepted And Waiting State
        public async Task<UserSelectedConsultant?> GetUserSelectedConsultantByPatientIdAndConsultantIdWithAcceptedAndWaitingState(ulong userId, ulong consultant)
        {
            #region Get Consultant Organization

            var organization = await _organizationService.GetConsultantOrganizationByUserId(consultant);
            if (organization == null) return null;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return null;

            #endregion

            return await _consultantRepository.GetUserSelectedConsultantByPatientIdAndConsultantWithAcceptedAndWaitingState(userId, organization.OwnerId);
        }

        //Get Persone Information Detail In Consultant Population Covered
        public async Task<Domain.ViewModels.Consultant.ConsultantRequest.ShowPopulationCoveredDetailViewModel?> GetPersoneInformationDetailInConsultantPopulationCovered(ulong patientId, ulong consultantId)
        {
            #region Get Consultant Organization

            var organization = await _organizationService.GetConsultantOrganizationByUserId(consultantId);
            if (organization == null) return null;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return null;

            #endregion

            #region Get User Selected Consuiltant Request

            var userSelected = await GetUserSelectedConsultantByPatientIdAndConsultantIdWithAcceptedAndWaitingState(patientId, organization.OwnerId);
            if (userSelected == null) return null;
            if (userSelected.ConsultantId != organization.OwnerId) return null;

            #endregion

            #region Get Patient By User Id

            var patient = await _userService.GetUserById(userSelected.PatientId);
            if (patient == null) return null;

            #endregion

            #region Consultant Id

            var consultant = await _userService.GetUserById(organization.OwnerId);
            if (consultant == null) return null;

            #endregion

            #region Fill View Model

            Domain.ViewModels.Consultant.ConsultantRequest.ShowPopulationCoveredDetailViewModel model = new Domain.ViewModels.Consultant.ConsultantRequest.ShowPopulationCoveredDetailViewModel()
            {
                Patient = patient,
                PopulationCovered = await _populationCoveredService.GetUserPopulation(patient.Id),
                UserSelectedConsultant = userSelected
            };

            #endregion

            return model;
        }

        //List Of Consultant Population Covered Users
        public async Task<ListOfConsultantPopulationCoveredViewModel> FilterListOfConsultantPopulationCoveredViewModel(ListOfConsultantPopulationCoveredViewModel filter)
        {
            return await _consultantRepository.FilterListOfConsultantPopulationCoveredViewModel(filter);
        }

        //Fill Consultant Side Bar Panel
        public async Task<ConsultantSideBarViewModel> GetConsultantSideBarInfo(ulong userId)
        {
            return await _consultantRepository.GetConsultantSideBarInfo(userId);
        }

        //Is Exist Any Consultant By This User Id 
        public async Task<bool> IsExistAnyConsultantByUserId(ulong userId)
        {
            return await _consultantRepository.IsExistAnyConsultantByUserId(userId);
        }

        //Add Consultant For First Time Loging To Consultant Panel 
        public async Task AddConsultantForFirstTime(ulong userId)
        {
            #region Consultant Entity

            #region Fill Consultant Model

            Consultant consultant = new Consultant()
            {
                UserId = userId,
                CreateDate = DateTime.Now,
                IsDelete = false,
            };

            #endregion

            #region Add Methods 

            await _consultantRepository.AddConsultant(consultant);

            #endregion

            #endregion

            #region Organization Entity

            #region Fill Organization Model

            Organization organization = new Organization()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                OrganizationInfoState = OrganizationInfoState.JustRegister,
                OrganizationType = Domain.Enums.Organization.OrganizationType.Consultant,
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

        //Get Consultant By User Id
        public async Task<Consultant?> GetConsultantByUserId(ulong userId)
        {
            return await _consultantRepository.GetConsultantByUserId(userId);
        }

        //Get Consultant Information By User Id
        public async Task<ConsultantInfo?> GetConsultantInformationByUserId(ulong userId)
        {
            return await _consultantRepository.GetConsultantInformationByUserId(userId);
        }

        //Fill Consultant Info View Model
        public async Task<ManageConsultantInfoViewModel?> FillManageConsultantInfoViewModel(ulong userId)
        {
            #region Check Is User Exist 

            var user = await _userService.GetUserById(userId);
            if (user == null) return null;

            #endregion

            #region Get Current Consultant Office

            var consultantOffice = await _organizationService.GetConsultantOrganizationByUserId(userId);
            if (consultantOffice == null) return null;
            if (consultantOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Consultant) return null;

            #endregion

            #region Get User Office Address

            var workAddress = await _workAddressService.GetUserWorkAddressById(userId);

            #endregion

            #region Exist Consultant Information

            //Is Exist Consultant Informations
            if (await IsExistAnyConsultantByUserId(userId))
            {
                //Get Current Consultant Information
                var consultantInfo = await GetConsultantInformationByUserId(userId);

                //Fill Model For return Value
                ManageConsultantInfoViewModel model = new ManageConsultantInfoViewModel()
                {
                    UserId = userId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ConsultantInfosType = consultantOffice.OrganizationInfoState,
                    Education = ((consultantInfo != null) ? consultantInfo.Education : null),
                    NationalCode = ((consultantInfo != null) ? consultantInfo.NationalCode : 0),
                    RejectDescription = consultantOffice.RejectDescription
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
                ManageConsultantInfoViewModel model = new ManageConsultantInfoViewModel()
                {
                    UserId = userId
                };

                return model;
            }

            #endregion

            return null;
        }

        //Check Is Exist Consultant Info By User ID
        public async Task<bool> IsExistAnyConsultantInfoByUserId(ulong userId)
        {
            return await _consultantRepository.IsExistAnyConsultantInfoByUserId(userId);
        }

        //Add Or Edit Consultant Info From Consultant Panel
        public async Task<AddOrEditConsultantInfoResult> AddOrEditConsultantInfoNursePanel(ManageConsultantInfoViewModel model)
        {
            #region Get User By User Id

            var user = await _userService.GetUserById(model.UserId);
            if (user == null) return AddOrEditConsultantInfoResult.Faild;

            #endregion

            #region Get Current Consultant Office

            var consultantOffice = await _organizationService.GetConsultantOrganizationByUserId(model.UserId);
            if (consultantOffice == null) return AddOrEditConsultantInfoResult.Faild;
            if (consultantOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Consultant) return AddOrEditConsultantInfoResult.Faild;

            #endregion

            #region Get Consultant By User Id 

            //Get Consultant By UserId
            var consultant = await GetConsultantByUserId(user.Id);

            #endregion

            #region Is Exist Informations

            var existInfo = await IsExistAnyConsultantInfoByUserId(model.UserId);

            #endregion

            #region Edit Info

            if (existInfo == true)
            {
                #region Update Properties

                //Get Consultant Informations By User Id
                var info = await GetConsultantInformationByUserId(model.UserId);

                //Edit Properties 
                info.Education = model.Education.SanitizeText();
                info.NationalCode = model.NationalCode;

                //Update Consultant Office State 
                consultantOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

                #region Update First Name And Last Name 

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

                await _userService.UpdateUser(user);

                #endregion

                #endregion

                #region Update Consultant Address

                var consultantAddress = await _workAddressService.GetUserWorkAddressById(model.UserId);

                if (consultantAddress != null && !string.IsNullOrEmpty(model.WorkAddress))
                {
                    consultantAddress.Address = model.WorkAddress;
                    consultantAddress.CountryId = model.CountryId.Value;
                    consultantAddress.StateId = model.StateId.Value;
                    consultantAddress.CityId = model.CityId.Value;

                    await _workAddressService.UpdateUserWorkAddress(consultantAddress);
                }

                if (consultantAddress == null && !string.IsNullOrEmpty(model.WorkAddress))
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

                await _consultantRepository.UpdateConsultantInfo(info);

                await _organizationService.UpdateOrganization(consultantOffice);

                #endregion
            }

            #endregion

            #region Add Info

            if (existInfo == false)
            {
                if (consultant != null)
                {
                    #region Fill View Model

                    ConsultantInfo manageConsultantInfoViewModel1 = new ConsultantInfo()
                    {
                        ConsultantId = consultant.Id,
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

                    #region Add Consultant Address

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

                    #region Update Consultant Office

                    consultantOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

                    #endregion

                    #region Update Methods

                    await _consultantRepository.AddConsultantInfo(manageConsultantInfoViewModel1);

                    await _organizationService.UpdateOrganization(consultantOffice);

                    #endregion
                }
                else
                {
                    #region Add Consultant

                    Consultant newConsultant = new Consultant()
                    {
                        CreateDate = DateTime.Now,
                        UserId = user.Id,
                        IsDelete = false
                    };

                    var newNurseId = await _consultantRepository.AddConsultant(newConsultant);

                    #endregion

                    #region Add Consultant Address

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
                        OrganizationType = Domain.Enums.Organization.OrganizationType.Consultant,
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

                    ConsultantInfo manageConsultantInfoViewModel = new ConsultantInfo()
                    {
                        ConsultantId = newConsultant.Id,
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

                    await _consultantRepository.AddConsultantInfo(manageConsultantInfoViewModel);

                    #endregion
                }
            }

            #endregion

            return AddOrEditConsultantInfoResult.Success;
        }

        //Filter Consultant Info Admin Side
        public async Task<ListOfConsultantInfoViewModel> FilterConsultantInfoAdminSide(ListOfConsultantInfoViewModel filter)
        {
            return await _consultantRepository.FilterConsultantInfoAdminSide(filter);
        }

        //Get User Selected Consultant By Patient And Consultant Id
        public async Task<UserSelectedConsultant?> GetUserSelectedConsultantByPatientAndConsultantId(ulong patientId, ulong consultantId)
        {
            return await _consultantRepository.GetUserSelectedConsultantByPatientAndConsultantId(patientId , consultantId);
        }

        #endregion

        #region Admin Side 

        //Show Consultant Request Detail Admin Side View Model 
        public async Task<ConsultantRequestDetailAdminSideViewModel?> FillConsultantRequestDetailAdminSideViewModel(ulong requestId)
        {
            #region Get User Selected Consultant By Request Id

            var request = await _consultantRepository.GetUserSelectedConsultantByRequestId(requestId);
            if (request == null) return null;

            #endregion

            #region Fill Model 

            ConsultantRequestDetailAdminSideViewModel model = new ConsultantRequestDetailAdminSideViewModel()
            {
                Patient = await _userService.GetUserById(request.PatientId),
                Consultant = await _userService.GetUserById(request.ConsultantId),
                UserSelectedConsultant = request,
            };

            #endregion

            return model;
        }

        //Get Consultant Info By Nurse Id
        public async Task<ConsultantInfo?> GetConsultantInfoByConsultantId(ulong consultantId)
        {
            return await _consultantRepository.GetConsultantInfoByConsultantId(consultantId);
        }

        //Get Consultant By Consultant Id
        public async Task<Consultant?> GetConsultantById(ulong consultantId)
        {
            return await _consultantRepository.GetConsultantById(consultantId);
        }

        //Fill Consultant Info Detail ViewModel
        public async Task<ConsultantInfoDetailViewModel?> FillConsultantInfoDetailViewModel(ulong ConsultantId)
        {
            #region Get Consultant Info

            //Get Consultant Info By Id
            var info = await _consultantRepository.GetConsultantInfoByConsultantId(ConsultantId);
            if (info == null) return null;

            #endregion

            #region Get Consultant Info

            var consultant = await GetConsultantById(info.ConsultantId);
            if (consultant == null) return null;

            #endregion

            #region Get Current Consultant Office

            var consultantOffice = await _organizationService.GetConsultantOrganizationByUserId(consultant.UserId);
            if (consultantOffice == null) return null;
            if (consultantOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Consultant) return null;

            #endregion

            #region Fill View Model

            ConsultantInfoDetailViewModel model = new ConsultantInfoDetailViewModel()
            {
                UserId = consultant.UserId,
                NationalCode = info.NationalCode,
                Education = info.Education,
                RejectDescription = consultantOffice.RejectDescription,
                ConsultantInfosType = consultantOffice.OrganizationInfoState,
                Id = info.Id,
                ConsultantId = consultant.Id,
            };

            #endregion

            #region Get Nurse Work Addresses

            model.WorkAddresses = await _workAddressService.GetUserWorkAddressesByUserId(consultant.UserId);

            #endregion

            return model;
        }

        //Edit Consultant Info From Admin Panel
        public async Task<EditConsultantInfoResult> EditConsultantInfoAdminSide(ConsultantInfoDetailViewModel model)
        {
            #region Get Consultant Info By Id

            //Get Consultant Info By Id
            var info = await _consultantRepository.GetConsultantInfoById(model.Id);
            if (info == null) return EditConsultantInfoResult.faild;

            #endregion

            #region Get Consultant By Id 

            var consultant = await GetConsultantById(model.ConsultantId);
            if (consultant == null) return EditConsultantInfoResult.faild;

            #endregion

            #region Get Current Consultant Office

            var consultantOffice = await _organizationService.GetConsultantOrganizationByUserId(consultant.UserId);
            if (consultantOffice == null) return EditConsultantInfoResult.faild;
            if (consultantOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Consultant) return EditConsultantInfoResult.faild;

            #endregion

            #region Update Consultant 

            consultantOffice.OrganizationInfoState = model.ConsultantInfosType;
            consultantOffice.RejectDescription = model.RejectDescription;

            if (model.ConsultantInfosType == OrganizationInfoState.Accepted)
            {
                consultantOffice.RejectDescription = null;
            }

            await _organizationService.UpdateOrganization(consultantOffice);

            #endregion

            #region Edit Consultant Info 

            #region Edit Properties

            info.Education = model.Education;
            info.NationalCode = model.NationalCode;

            #endregion

            #region Update Method

            await _consultantRepository.UpdateConsultantInfo(info);

            #endregion

            #endregion

            return EditConsultantInfoResult.success;
        }

        //Filter Consultant Requests Admin Side 
        public async Task<FilterConsultantAdminSideViewModel> FilterConsultantAdminSideViewModel(FilterConsultantAdminSideViewModel filter)
        {
            return await _consultantRepository.FilterConsultantAdminSideViewModel(filter);
        }

        #endregion

        #region User Panel Side 

        //Get User Selected Consultant 
        public async Task<UserSelectedConsultant?> GetUserSelectedConsultantByUserId(ulong userId)
        {
            return await _consultantRepository.GetUserSelectedConsultantByUserId(userId);
        }

        //Get List Of Consultant
        public async Task<List<Consultant>?> FilterConsultantUserPanelSide(FilterConsultantUserPanelSideViewModel filter)
        {
            return await _consultantRepository.FilterConsultantUserPanelSide(filter);
        }

        //Fill Consultant Information Detail View Model
        public async Task<ShowConsultantInformationDetailViewModel?> FillShowConsultantInformationDetailViewModel(ulong consultantId)
        {
            #region Get Consultant By Consultant Id

            var consultant = await GetConsultantById(consultantId);
            if (consultant == null) return null;

            #endregion

            #region Check Consultant Validation 

            #region Organization Validation 

            var organization = await _organizationService.GetConsultantOrganizationByUserId(consultant.UserId);
            if (organization == null) return null;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return null;

            #endregion

            #endregion

            #region Get Consultant Work Address 

            var workAddress = await _workAddressService.GetLastWorkAddressByUserId(consultant.UserId);

            #endregion

            #region Get Consultant Personal Information 

            var consultantInfo = await _consultantRepository.GetConsultantInfoByConsultantId(consultantId);
            if (consultantInfo == null) return null;

            #endregion

            #region Fill View Model 

            ShowConsultantInformationDetailViewModel model = new ShowConsultantInformationDetailViewModel()
            {
                ConsultantInfo = consultantInfo,
                User = consultant.User,
                WorkAddress = workAddress,
                WorkLocation = consultant.User.WorkAddress
            };

            #endregion

            return model;
        }

        //Choosing A Consultant
        public async Task<bool> ChoosingConsultantFromUser(ulong consultantUserId, ulong patientId)
        {
            #region Get Consultant By Consultant Id

            var consultant = await _consultantRepository.GetConsultantByUserId(consultantUserId);
            if (consultant == null) return false;

            #endregion

            #region Get Users

            var consultantUser = await _userService.GetUserById(consultant.UserId);
            if (consultantUser == null) return false;

            var patient = await _userService.GetUserById(patientId);
            if (patient == null) return false;

            #endregion

            #region Check Validation 

            #region Organization Validation 

            var organization = await _organizationService.GetConsultantOrganizationByUserId(consultant.UserId);
            if (organization == null) return false;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return false;

            #endregion

            #region Get User Selected Consultant By User Id

            var userSelectedConsultant = await GetUserSelectedConsultantByUserId(patientId);
            if (userSelectedConsultant != null
                                && (userSelectedConsultant.ConsultantRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.WaitingForConfirm
                                                    || userSelectedConsultant.ConsultantRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Accepted))
            {
                return false;
            }

            if (userSelectedConsultant != null && userSelectedConsultant.ConsultantRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Decline)
            {
                await _consultantRepository.RemoveConsultantForThisPatient(userSelectedConsultant);
            }

            #endregion

            #endregion

            #region Add Consultant For Patient Method 

            UserSelectedConsultant model = new UserSelectedConsultant()
            {
                CreateDate = DateTime.Now,
                ConsultantId = consultant.UserId,
                PatientId = patientId,
                ConsultantRequestState = Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.WaitingForConfirm,
                IsDelete = false,
                RejectDescription = null
            };

            await _consultantRepository.AddConsultantForThisPatient(model);

            #endregion

            return true;
        }

        //Show User Consultant Info In User Panel
        public async Task<ShowUserConsultantInfo?> FillShowUserConsultantInfo(ulong userId)
        {
            #region Get User Seleted Consultant 

            var request = await GetUserSelectedConsultantByUserId(userId);
            if (request == null) return null;

            #endregion

            #region Get Consultant By Id 

            var consultant = await _userService.GetUserById(request.ConsultantId);
            if (consultant == null) return null;

            var mainConsultant = await _consultantRepository.GetConsultantByUserId(consultant.Id);
            if (mainConsultant == null) return null;

            #endregion

            #region Get Consultant Personal Information 

            var consultantInfo = await _consultantRepository.GetConsultantInfoByConsultantId(mainConsultant.Id);
            if (consultantInfo == null) return null;

            #endregion

            #region Fill Model

            ShowUserConsultantInfo model = new ShowUserConsultantInfo()
            {
                ConsultantInfo = consultantInfo,
                User = consultant
            };

            #endregion

            return model;
        }

        //Cancel User Selected Consultant From User Panel 
        public async Task<bool> CancelUserSelectedConsultantFromUserPanel(ulong patientId)
        {
            #region Get User Selected Consultant By patientId

            var userSelectedConsultant = await _consultantRepository.GetUserSelectedConsultantByUserId(patientId);
            if (userSelectedConsultant == null) return false;

            #endregion

            #region Delete Recorde

            userSelectedConsultant.IsDelete = true;

            await _consultantRepository.UpdateUserSelectedConsultant(userSelectedConsultant);

            #endregion

            return true;
        }

        #endregion
    }
}
