using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Data.Repository;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.PopulationCovered;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.DeathCertificate;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DeathCertificate;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse.DeathCertificate;
using DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse.HomeNurse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class DeathCertificateService : IDeathCertificateService
    {
        #region Ctor

        private readonly IDeathCertificateRepository _deathCertificate;
        private readonly IRequestService _requestService;
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;
        private readonly ILocationService _locationService;
        private readonly IWalletRepository _walletRepository;
        private readonly IPopulationCoveredRepository _populationCovered;
        private readonly IHomePharmacyRepository _homePharmacyRepository;
        private readonly IOrganizationService _organizationService;
        private readonly IDoctorsService _doctorsService;
        private readonly IWorkAddressService _workAddressService;
        private readonly IHomeVisitService _homeVisitService;

        public DeathCertificateService(IDeathCertificateRepository deathCertificate, IRequestService requestService,
                                IUserService userService, IPatientService patientService, ILocationService locationservice, IWalletRepository walletRepository
                                    , IPopulationCoveredRepository populationCovered, IHomePharmacyRepository homePharmacyRepository, IOrganizationService organizationService, IDoctorsService doctorsService, IWorkAddressService workAddressService
                                        , IHomeVisitService homeVisitService)
        {
            _deathCertificate = deathCertificate;
            _requestService = requestService;
            _userService = userService;
            _patientService = patientService;
            _locationService = locationservice;
            _walletRepository = walletRepository;
            _populationCovered = populationCovered;
            _homePharmacyRepository = homePharmacyRepository;
            _organizationService = organizationService;
            _doctorsService = doctorsService;
            _workAddressService = workAddressService;
            _homeVisitService = homeVisitService;
        }

        #endregion

        #region Home Visit Methods 

        public async Task<ulong?> CreateDeathCertificateRequest(ulong userId)
        {
            #region User Validation

            if (await _userService.GetUserById(userId) == null)
            {
                return null;
            }

            #endregion

            #region Fill Entitie

            Random key = new Random();

            Request request = new Request()
            {
                RequestType = Domain.Enums.RequestType.RequestType.DeathCertificate,
                RequestState = Domain.Enums.Request.RequestState.WaitingForCompleteInformationFromUser,
                CreateDate = DateTime.Now,
                IsDelete = false,
                UserId = userId,
                BusinessKey = (ulong)key.Next(0, 1000000000)
            };

            #endregion

            #region Add Request Method

            await _requestService.AddRequest(request);

            #endregion

            return request.Id;
        }

        public async Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model)
        {
            var result = await _requestService.IsExistRequestByRequestId(model.RequestId);

            if (result == false) return CreatePatientResult.RequestIdNotFound;

            return CreatePatientResult.Success;
        }

        public async Task<ulong> CreatePatientDetail(PatientViewModel patient)
        {
            #region Fill Entity

            Patient model = new Patient
            {
                RequestId = patient.RequestId,
                Age = patient.Age,
                Gender = patient.Gender,
                InsuranceType = patient.InsuranceType,
                NationalId = patient.NationalId,
                PatientName = patient.PatientName.SanitizeText(),
                PatientLastName = patient.PatientLastName.SanitizeText(),
                RequestDescription = patient.RequestDescription.SanitizeText(),
                UserId = patient.UserId
            };

            #endregion

            #region MyRegion

            await _patientService.AddPatient(model);

            #endregion

            return model.Id;
        }

        //Fill Patient View Model From Selected Population Covered Data
        public async Task<PatientViewModel> FillPatientViewModelFromSelectedPopulationCoveredData(ulong populationId, ulong requestId, ulong userId)
        {
            #region Get User

            var user = await _userService.GetUserById(userId);
            if (user == null) return null;

            #endregion

            #region Get Request 

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return null;
            if (request.RequestType != RequestType.HomeNurse) return null;

            #endregion

            #region Get Population Coverd

            var population = await _populationCovered.GetPopulationCoveredById(populationId);

            if (population == null) return null;

            //When popluation Covered Is not For Current User 
            if (population.UserId != userId) return null;

            #endregion

            #region Fill Entity

            PatientViewModel model = new PatientViewModel
            {
                RequestId = requestId,
                Age = population.Age,
                Gender = population.Gender,
                InsuranceType = population.InsuranceType,
                NationalId = population.NationalId,
                PatientName = population.PatientName.SanitizeText(),
                PatientLastName = population.PatientLastName.SanitizeText(),
                UserId = userId
            };

            #endregion

            return model;
        }

        #endregion

        #region Site Side

        public async Task<bool> ChargeUserWallet(ulong userId, int price , ulong requestId)
        {
            if (!await _userService.IsExistUserById(userId))
            {
                return false;
            }

            var wallet = new Wallet
            {
                UserId = userId,
                TransactionType = TransactionType.Deposit,
                GatewayType = GatewayType.Zarinpal,
                PaymentType = PaymentType.ChargeWallet,
                Price = price,
                Description = "شارژ حساب کاربری برای پرداخت هزینه ی صدور گواهی فوت",
                IsFinally = true,
                RequestId = requestId
            };

            await _walletRepository.CreateWalletAsync(wallet);
            return true;
        }

        public async Task<bool> PayDeathCertificateTariff(ulong userId, int price , ulong requestId)
        {
            if (!await _userService.IsExistUserById(userId))
            {
                return false;
            }

            var wallet = new Wallet
            {
                UserId = userId,
                TransactionType = TransactionType.Withdraw,
                GatewayType = GatewayType.Zarinpal,
                PaymentType = PaymentType.DeathCertificate,
                Price = price,
                Description = "پرداخت مبلغ صدور گواهی فوت",
                IsFinally = true,
                RequestId = requestId
            };

            await _walletRepository.CreateWalletAsync(wallet);
            return true;
        }

        //Get Activated And Death Certificate Interests Death Certificate For Send Correct Notification For Arrival Death Certificate Request 
        public async Task<List<string?>> GetActivatedAndDoctorsInterestDeathCertificate(ulong requestId)
        {
            #region Get Request By Id 

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return null;

            #endregion

            #region Get Request Detail 

            var requetsDetail = await _requestService.GetPatientRequestDetailByRequestId(requestId);
            if (requetsDetail == null) return null;

            #endregion

            #region Get Activated Doctors By Death Certificate Interests 

            var returnValue = await _deathCertificate.GetActivatedAndDoctorsInterestDeathCertificate(requetsDetail.CountryId, requetsDetail.StateId, requetsDetail.CityId);

            #endregion

            return returnValue;
        }

        #endregion

        #region Admin Side

        public async Task<FilterDeathCertificateViewModel> FilterDeathCertificate(FilterDeathCertificateViewModel filter)
        {
            return await _deathCertificate.FilterDeathCertificate(filter);
        }

        public async Task<Request?> GetRquestForDeathCertificateById(ulong requestId)
        {
            return await _deathCertificate.GetRquestForDeathCertificateById(requestId);
        }

        public async Task<Patient?> GetPatientByRequestId(ulong requestId)
        {
            return await _deathCertificate.GetPatientByRequestId(requestId);
        }

        public async Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId)
        {
            return await _deathCertificate.GetRequestPatientDetailByRequestId(requestId);
        }

        public async Task<Domain.ViewModels.Admin.HealthHouse.DeathCertificate.DeathCertificateRequestDetailViewModel> ShowDeathCertificateDetail(ulong requestId)
        {
            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return null;
            if (request.RequestType != Domain.Enums.RequestType.RequestType.DeathCertificate) return null;
            if (!request.PatientId.HasValue) return null;

            #endregion

            #region Fill Model 

            Domain.ViewModels.Admin.HealthHouse.DeathCertificate.DeathCertificateRequestDetailViewModel model = new Domain.ViewModels.Admin.HealthHouse.DeathCertificate.DeathCertificateRequestDetailViewModel()
            {
                Patient = await _patientService.GetPatientById(request.PatientId.Value),
                User = await _userService.GetUserById(request.UserId),
                PatientRequestDetail = await _homeVisitService.GetRequestPatientDetailByRequestId(request.Id),
                Request = request,
            };

            if (request.OperationId.HasValue)
            {
                model.Doctor = await _userService.GetUserById(request.OperationId.Value);
            }

            #endregion

            return model;
        }

        //List Of Your Death Certificate Request 
        public async Task<ListOfPayedDeathCertificateRequestDoctorSideViewModel> ListOfYourDeathCertificateRequestsDoctorPanelSide(ListOfPayedDeathCertificateRequestDoctorSideViewModel filter, ulong userId)
        {
            return await _deathCertificate.ListOfYourDeathCertificateRequestsDoctorPanelSide(filter , userId);
        }

        //Show Death Certificate Request Detail Doctor Panel Side View Model 
        public async Task<DoctorFAM.Domain.ViewModels.DoctorPanel.DeathCertificate.DeathCertificateRequestDetailViewModel?> FillDeathCertificateRequestDetailDoctorPanelViewModel(ulong requestId, ulong userId)
        {
            #region Get Doctor Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return null;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return null;

            #endregion

            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return null;
            if (request.RequestType != RequestType.DeathCertificate) return null;
            if (!request.PatientId.HasValue) return null;
            if (request.RequestState == RequestState.Finalized)
            {
                if(request.OperationId.Value != organization.OwnerId) return null;
            }
            else
            {
                if (request.OperationId.HasValue) return null;
                if (request.RequestState != RequestState.Paid) return null;
            }

            #endregion

            #region Fill Model 

            DoctorFAM.Domain.ViewModels.DoctorPanel.DeathCertificate.DeathCertificateRequestDetailViewModel model = new DoctorFAM.Domain.ViewModels.DoctorPanel.DeathCertificate.DeathCertificateRequestDetailViewModel()
            {
                Patient = await _patientService.GetPatientById(request.PatientId.Value),
                User = await _userService.GetUserById(request.UserId),
                PatientRequestDetail = await _homePharmacyRepository.GetRequestPatientDetailByRequestId(request.Id),
                Request = request,
            };

            #endregion

            return model;
        }

        //Confirm Death Certificate Request From Doctor 
        public async Task<bool> ConfirmDeathCertificateRequestFromDoctor(ulong requestId, ulong userId)
        {
            #region Get Doctor Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return false;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return false;

            #endregion

            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return false;
            if (request.RequestType != RequestType.DeathCertificate) return false;
            if (!request.PatientId.HasValue) return false;
            if (request.OperationId.HasValue) return false;
            if (request.RequestState != RequestState.Paid) return false;

            #endregion

            #region Get Request By Doctor 

            request.OperationId = organization.OwnerId;
            request.RequestState = RequestState.Finalized;

            await _requestService.UpdateRequest(request);

            #endregion

            return true;
        }

        #endregion

        #region User Panel Side 

        //Filter User Death Certificate Requests
        public async Task<Domain.ViewModels.UserPanel.HealthHouse.DeathCertificate.FilterUserDeathCertificateRequestViewModel> FilterUserDeathCertificateRequestViewModel(Domain.ViewModels.UserPanel.HealthHouse.DeathCertificate.FilterUserDeathCertificateRequestViewModel filter)
        {
            return await _deathCertificate.FilterUserDeathCertificateRequestViewModel(filter);
        }

        //Fill Doctor Information Detail View Model
        public async Task<ShowDeathCertificateDetaiFromUserPanellViewModel?> FillShowDeathCertificateDetaiFromUserPanellViewModel(ulong requestId, ulong userId)
        {
            #region Get Request By Id 

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return null;
            if (request.UserId != userId) return null;
            if (request.OperationId.HasValue == false) return null;
            if (request.RequestState != Domain.Enums.Request.RequestState.Finalized) return null;

            #endregion

            #region Get Doctor By User Id

            var doctor = await _doctorsService.GetDoctorByUserId(request.OperationId.Value);
            if (doctor == null) return null;

            #endregion

            #region Get Doctor Work Address 

            var workAddress = await _workAddressService.GetLastWorkAddressByUserId(doctor.UserId);

            #endregion

            #region Get Doctor Personal Information 

            var doctorInfo = await _doctorsService.GetDoctorsInformationByUserId(doctor.UserId);
            if (doctorInfo == null) return null;

            #endregion

            #region Fill View Model 

            ShowDeathCertificateDetaiFromUserPanellViewModel model = new ShowDeathCertificateDetaiFromUserPanellViewModel()
            {
                DoctorsInfo = doctorInfo,
                User = doctor.User,
                WorkAddress = workAddress,
                WorkLocation = doctor.User.WorkAddress
            };

            #endregion

            return model;
        }

        #endregion
    }
}
