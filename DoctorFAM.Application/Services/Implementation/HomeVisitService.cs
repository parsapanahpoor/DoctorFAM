﻿using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Data.Repository;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeVisit;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DeathCertificate;
using DoctorFAM.Domain.ViewModels.DoctorPanel.HomeVisit;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class HomeVisitService : IHomeVisitService
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;
        private readonly IHomeVisitRepository _homeVisit;
        private readonly IRequestService _requestService;
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;
        private readonly ILocationService _locationServoce;
        private readonly IWalletRepository _walletRepository;
        private readonly IPopulationCoveredRepository _populationCovered;
        private readonly ISiteSettingService _siteSettingService;
        private readonly IOrganizationService _organziationService;
        private readonly IHomePharmacyRepository _pharmacyService;

        public HomeVisitService(DoctorFAMDbContext context, IHomeVisitRepository homeVisit, IRequestService requestService,
                                IUserService userService, IPatientService patientService, ILocationService locationServoce
                                , IWalletRepository walletRepository, IPopulationCoveredRepository populationCovered, ISiteSettingService siteSettingService ,
                                    IOrganizationService organizationService, IHomePharmacyRepository pharmacyService)
        {
            _context = context;
            _homeVisit = homeVisit;
            _requestService = requestService;
            _userService = userService;
            _patientService = patientService;
            _locationServoce = locationServoce;
            _walletRepository = walletRepository;
            _populationCovered = populationCovered;
            _siteSettingService = siteSettingService;
            _organziationService = organizationService;
            _pharmacyService = pharmacyService;
        }

        #endregion

        #region Home Visit Methods 

        public async Task<ulong?> CreateHomeVisitRequest(ulong userId)
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
                RequestType = Domain.Enums.RequestType.RequestType.HomeVisit,
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

            #region Add Patient

            await _patientService.AddPatient(model);

            #endregion

            return model.Id;
        }

        public async Task<PatientViewModel> FillPatientViewModelFromSelectedPopulationCoveredData(ulong populationId, ulong requestId, ulong userId)
        {
            #region Get User

            var user = await _userService.GetUserById(userId);
            if (user == null) return null;

            #endregion

            #region Get Request 

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return null;
            if (request.RequestType != RequestType.HomeVisit) return null;

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

        public async Task<ulong> CreatePatientDetailByPopulationCovered(ulong populationId, ulong requestId, ulong userId)
        {
            #region Get User

            var user = await _userService.GetUserById(userId);
            if (user == null) return 0;

            #endregion

            #region Get Request 

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return 0;

            #endregion

            #region Get Population Coverd

            var population = await _populationCovered.GetPopulationCoveredById(populationId);

            if (population == null) return 0;

            //When popluation Covered Is not For Current User 
            if (population.UserId != userId) return 0;

            #endregion

            #region Fill Entity

            Patient model = new Patient
            {
                RequestId = requestId,
                Age = population.Age,
                Gender = population.Gender,
                InsuranceType = population.InsuranceType,
                NationalId = population.NationalId,
                PatientName = population.PatientName.SanitizeText(),
                PatientLastName = population.PatientLastName.SanitizeText(),
                RequestDescription = "Population Covered",
                UserId = userId
            };

            #endregion

            #region Add Patient

            await _patientService.AddPatient(model);

            #endregion

            return model.Id;
        }

        //Get Home Visit Request Detail By Request Id
        public async Task<HomeVisitRequestDetail?> GetHomeVisitRequestDetailByRequestId(ulong requestId)
        {
            return await _homeVisit.GetHomeVisitRequestDetailByRequestId(requestId);
        }

        //Get Activated And Home Visit Interests Home Visit For Send Correct Notification For Arrival Home Visit Request 
        public async Task<List<string?>> GetActivatedAndDoctorsInterestHomeVisit(ulong requestId)
        {
            #region Get Request By Id 

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return null;

            #endregion

            #region Get Request Detail 

            var requetsDetail = await _requestService.GetPatientRequestDetailByRequestId(requestId);
            if (requetsDetail == null) return null;

            #endregion

            #region Get Activated Doctors By Home Visit Interests 

            var returnValue = await _homeVisit.GetActivatedAndDoctorsInterestHomeVisit(requetsDetail.CountryId, requetsDetail.StateId, requetsDetail.CityId);

            #endregion

            return returnValue;
        }

        #endregion

        #region Site Side

        public async Task<bool> ChargeUserWallet(ulong userId, int price)
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
                Description = "شارژ حساب کاربری برای پرداخت هزینه ی ویزیت در منزل",
                IsFinally = true
            };

            await _walletRepository.CreateWalletAsync(wallet);
            return true;
        }

        public async Task<bool> PayHomeVisitTariff(ulong userId, int price)
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
                PaymentType = PaymentType.HomeVisit,
                Price = price,
                Description = "پرداخت مبلغ ویزیت در منزل",
                IsFinally = true
            };

            await _walletRepository.CreateWalletAsync(wallet);
            return true;
        }

        //Proccess Home Visit Request Cost 
        public async Task<int> ProccessHomeVisitRequestCost(Request request)
        {
            #region Get Requets Patient Address Detail

            var requestPatietnAddressDetail = await GetRequestPatientDetailByRequestId(request.Id);
            if (requestPatietnAddressDetail == null) return 0;

            #endregion

            #region Get Requets Patient Date Time 

            var dateTimeDetail = await _requestService.GetRequestDateTimeDetailByRequestDetailId(request.Id);
            if (dateTimeDetail == null) return 0;

            #endregion

            #region Get Home Visit Request Detail 

            var homeVisitRequestDetail = await GetHomeVisitRequestDetailByRequestId(request.Id);
            if (homeVisitRequestDetail == null) return 0;

            #endregion

            #region Get Home Visit Tariff From Site Setting 

            double homeVisitTariff = await _siteSettingService.GetHomeVisitTariff();
            if (homeVisitTariff == null || homeVisitTariff == 0) return 0;

            #endregion

            #region Proccess Cost

            double cost = homeVisitTariff;

            if (requestPatietnAddressDetail.Distance != null && requestPatietnAddressDetail.Distance != 0)
            {
                var DistanceFromCityTarriff = await _siteSettingService.GetDistanceFromCityTarriffCost();

                var distancePerTenKilometer = DistanceFromCityTarriff / 10;

                cost = cost + (DistanceFromCityTarriff * distancePerTenKilometer);
            }

            if (homeVisitRequestDetail.EmergencyVisit == true)
            {
                cost = cost + ((homeVisitTariff * 20) / 100);
            }

            if (homeVisitRequestDetail.FemalePhysician == true)
            {
                cost = cost + ((homeVisitTariff * 20) / 100);
            }

            if (dateTimeDetail.StartTime >= 22 || dateTimeDetail.EndTime <= 8)
            {
                cost = cost + ((homeVisitTariff * 20) / 100);
            }

            if (homeVisitRequestDetail.IntramuscularInjection == true)
            {
                var IntramuscularInjection = await _siteSettingService.GetIntramuscularInjectionCost();

                cost = cost + IntramuscularInjection;
            }

            if (homeVisitRequestDetail.DermalOrSubcutaneousInjection == true)
            {
                var DermalOrSubcutaneousInjection = await _siteSettingService.GetDermalOrSubcutaneousInjectionCost();

                cost = cost + DermalOrSubcutaneousInjection;
            }

            if (homeVisitRequestDetail.ReedyInjection == true)
            {
                var ReedyInjection = await _siteSettingService.GetReedyInjectionCost();

                cost = cost + ReedyInjection;
            }

            if (homeVisitRequestDetail.SerumTherapy == true)
            {
                var SerumTherapy = await _siteSettingService.GetSerumTherapyCost();

                cost = cost + SerumTherapy;
            }

            if (homeVisitRequestDetail.BloodPressureMeasurement == true)
            {
                var BloodPressureMeasurement = await _siteSettingService.GetBloodPressureMeasurementCost();

                cost = cost + BloodPressureMeasurement;
            }

            if (homeVisitRequestDetail.Glucometry == true)
            {
                var Glucometry = await _siteSettingService.GetGlucometrytCost();

                cost = cost + Glucometry;
            }

            if (homeVisitRequestDetail.PulseOximetry == true)
            {
                var PulseOximetry = await _siteSettingService.GetPulseOximetryCost();

                cost = cost + PulseOximetry;
            }

            if (homeVisitRequestDetail.SmallDressing == true)
            {
                var SmallDressing = await _siteSettingService.GetSmallDressingCost();

                cost = cost + SmallDressing;
            }

            if (homeVisitRequestDetail.GreatDressing == true)
            {
                var GreatDressing = await _siteSettingService.GetGreatDressingCost();

                cost = cost + GreatDressing;
            }

            if (homeVisitRequestDetail.GastricIntubation == true)
            {
                var GastricIntubation = await _siteSettingService.GetGastricIntubationCost();

                cost = cost + GastricIntubation;
            }

            if (homeVisitRequestDetail.UrinaryBladder == true)
            {
                var UrinaryBladder = await _siteSettingService.GetUrinaryBladderCost();

                cost = cost + UrinaryBladder;
            }

            if (homeVisitRequestDetail.OxygenTherapy == true)
            {
                var OxygenTherapy = await _siteSettingService.GetOxygenTherapyCost();

                cost = cost + OxygenTherapy;
            }

            if (homeVisitRequestDetail.ECG == true)
            {
                var ECG = await _siteSettingService.GetECGCost();

                cost = cost + ECG;
            }

            #endregion

            return (int)cost;
        }

        #endregion

        #region Doctor Panel Side

        //Fill Home Visit Request Detail View Model
        public async Task<Domain.ViewModels.DoctorPanel.HomeVisit.HomeVisitRequestDetailViewModel?> FillHomeVisitRequestDetailViewModel(ulong requestId , ulong userId)
        {
            #region Get Organization

            var organization = await _organziationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return null;
            if (request.RequestType != RequestType.HomeVisit) return null;
            if (!request.PatientId.HasValue) return null;
            if (request.OperationId.HasValue && request.OperationId.Value != organization.OwnerId)
            {
                return null;
            }
            else
            {
                if (request.RequestState != RequestState.Paid) return null;
            }

            #endregion

            #region Fill Model 

            Domain.ViewModels.DoctorPanel.HomeVisit.HomeVisitRequestDetailViewModel model = new Domain.ViewModels.DoctorPanel.HomeVisit.HomeVisitRequestDetailViewModel()
            {
                Patient = await _patientService.GetPatientById(request.PatientId.Value),
                User = await _userService.GetUserById(request.UserId),
                PatientRequestDetail = await _pharmacyService.GetRequestPatientDetailByRequestId(request.Id),
                Request = request,
                HomeVisitRequestDetail = await _homeVisit.GetHomeVisitRequestDetailByRequestId(requestId),
                PatientRequestDateTimeDetail = await _requestService.GetRequestDateTimeDetailByRequestDetailId(requestId)
            };

            #endregion

            return model;
        }

        public async Task<ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel> ListOfPayedHomeVisitsRequestsDoctorPanelSide(ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel filter)
        {
            return await _homeVisit.ListOfPayedHomeVisitsRequestsDoctorPanelSide(filter);
        }

        //List Of Your Home Visits Requests Doctor Panel Side
        public async Task<ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel> ListOfYourHomeVisitsRequestsDoctorPanelSide(ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel filter)
        {
            return await _homeVisit.ListOfYourHomeVisitsRequestsDoctorPanelSide(filter);
        }

        public async Task<ListOfPayedDeathCertificateRequestDoctorSideViewModel> ListOfPayedDeathCertificateRequestsDoctorPanelSide(ListOfPayedDeathCertificateRequestDoctorSideViewModel filter)
        {
            return await _homeVisit.ListOfPayedDeathCertificateRequestsDoctorPanelSide(filter);
        }

        #endregion

        #region Admin Side

        public async Task<FilterHomeVisistViewModel> FilterHomeVisit(FilterHomeVisistViewModel filter)
        {
            return await _homeVisit.FilterHomeVisit(filter);
        }

        public async Task<Domain.ViewModels.Admin.HealthHouse.HomeVisit.HomeVisitRequestDetailViewModel> ShowHomeVisitDetail(ulong requestId)
        {
            #region Get request By Id

            var request = await GetRquestForHomeVisitById(requestId);

            if (request == null) return null;

            #endregion

            #region Get Patient By Id 

            var patient = await GetPatientByRequestId(requestId);

            #endregion

            #region Get Patient Request Detail 

            var requestDetail = await GetRequestPatientDetailByRequestId(requestId);

            #endregion

            #region Fill View Model

            Domain.ViewModels.Admin.HealthHouse.HomeVisit.HomeVisitRequestDetailViewModel model = new Domain.ViewModels.Admin.HealthHouse.HomeVisit.HomeVisitRequestDetailViewModel()
            {
                Email = request.User.Email,
                Username = request.User.Username,
                Mobile = request.User.Mobile,
                RequestState = request.RequestState,
                PatientName = patient?.PatientName,
                PatientLastName = patient?.PatientLastName,
                NationalId = patient?.NationalId,
                Gender = patient?.Gender,
                Age = patient?.Age,
                InsuranceType = patient?.InsuranceType,
                RequestDescription = patient?.RequestDescription,
                Vilage = requestDetail?.Vilage,
                FullAddress = requestDetail?.FullAddress,
                Phone = requestDetail?.Phone,
                RequestDetailMobile = requestDetail?.Mobile,
                Distance = requestDetail?.Distance
            };

            #endregion

            #region Get Location

            if (requestDetail != null)
            {
                var country = await _locationServoce.GetLocationById(requestDetail.CountryId);

                var state = await _locationServoce.GetLocationById(requestDetail.StateId);

                var city = await _locationServoce.GetLocationById(requestDetail.CityId);

                model.Country = country.UniqueName;

                model.State = state.UniqueName;

                model.City = city.UniqueName;
            }

            #endregion

            return model;
        }

        public async Task<Patient?> GetPatientByRequestId(ulong requestId)
        {
            return await _homeVisit.GetPatientByRequestId(requestId);
        }

        public async Task<Request?> GetRquestForHomeVisitById(ulong requestId)
        {
            return await _homeVisit.GetRquestForHomeVisitById(requestId);
        }

        public async Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId)
        {
            return await _homeVisit.GetRequestPatientDetailByRequestId(requestId);
        }

        #endregion
    }
}
