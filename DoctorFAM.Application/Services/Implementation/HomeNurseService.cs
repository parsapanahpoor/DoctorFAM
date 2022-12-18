using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeNurse;
using DoctorFAM.Domain.ViewModels.Site.HomeNurseRequest;
using DoctorFAM.Domain.ViewModels.Site.HomeVisitRequest;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class HomeNurseService : IHomeNurseService
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;
        private readonly IHomeNurseRepository _homeNurse;
        private readonly IRequestService _requestService;
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;
        private readonly ILocationService _locationService;
        private readonly IWalletRepository _walletRepository;
        private readonly IPopulationCoveredRepository _populationCovered;
        private readonly ISiteSettingService _siteSetting;

        public HomeNurseService(DoctorFAMDbContext context, IHomeNurseRepository homeNurse, IRequestService requestService,
                                IUserService userService, IPatientService patientService , ILocationService locationService,
                                IWalletRepository walletRepository, IPopulationCoveredRepository populationCovered, ISiteSettingService siteSetting)
        {
            _context = context;
            _homeNurse = homeNurse;
            _requestService = requestService;
            _userService = userService;
            _patientService = patientService;
            _locationService = locationService;
            _walletRepository = walletRepository;
            _populationCovered = populationCovered;
            _siteSetting = siteSetting;
        }

        #endregion

        #region Home Nurse Methods 

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
                Description = "شارژ حساب کاربری برای پرداخت هزینه ی پرستار در منزل ",
                IsFinally = true,
                RequestId = requestId
            };

            await _walletRepository.CreateWalletAsync(wallet);
            return true;
        }

        public async Task<bool> PayHomeNurseTariff(ulong userId, int price , ulong requestId)
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
                PaymentType = PaymentType.HomeNurse,
                Price = price,
                Description = "پرداخت مبلغ پرستار در منزل ",
                IsFinally = true,
                RequestId = requestId
            };

            await _walletRepository.CreateWalletAsync(wallet);
            return true;
        }

        public async Task<ulong?> CreateHomeNurseRequest(ulong userId)
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
                RequestType = Domain.Enums.RequestType.RequestType.HomeNurse,
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


        #endregion

        #region Site Side

        //Proccess Home Nurse Request Cost 
        public async Task<int> ProccessHomeNurseRequestCost(Request request)
        {
            #region Get Requets Patient Address Detail

            var requestPatietnAddressDetail = await GetRequestPatientDetailByRequestId(request.Id);
            if (requestPatietnAddressDetail == null) return 0;

            #endregion

            #region Get Requets Patient Date Time 

            var dateTimeDetail = await _requestService.GetRequestDateTimeDetailByRequestDetailId(request.Id);
            if (dateTimeDetail == null) return 0;

            #endregion

            #region Get Home Nurse Tariff From Site Setting 

            double homeNurseTariff = await _siteSetting.GetHomeNurseTariff();
            if (homeNurseTariff == null || homeNurseTariff == 0) return 0;

            #endregion

            #region Proccess Cost

            double cost = homeNurseTariff;

            if (requestPatietnAddressDetail.Distance != null && requestPatietnAddressDetail.Distance != 0)
            {
                var DistanceFromCityTarriff = await _siteSetting.GetDistanceFromCityTarriffCost();

                var distancePerTenKilometer = DistanceFromCityTarriff / 10;

                cost = cost + (DistanceFromCityTarriff * distancePerTenKilometer);
            }

            if (dateTimeDetail.StartTime >= 22)
            {
                cost = cost + ((homeNurseTariff * 20) / 100);
            }

            #endregion

            #region Get Request Selected Tariffs 

            var selectedTariffs = await _siteSetting.GetRequestSelectedTariffsByRequestId(request.Id);

            if (selectedTariffs != null && selectedTariffs.Any())
            {
                foreach (var tariff in selectedTariffs)
                {
                    cost = cost + Int64.Parse(tariff.TariffForHealthHouseService.Price);
                }
            }

            #endregion

            return (int)cost;
        }

        //Fill Home Nurse Request Invoice View Model
        public async Task<HomeNurseRequestInvoiceViewModel?> FillHomeNurseRequestInvoiceViewModel(Request request)
        {
            //Make Instance From Return Model 
            HomeNurseRequestInvoiceViewModel model = new HomeNurseRequestInvoiceViewModel();
            model.RequestId = request.Id;

            #region Get Requets Patient Address Detail

            var requestPatietnAddressDetail = await GetRequestPatientDetailByRequestId(request.Id);
            if (requestPatietnAddressDetail == null) return null;

            model.PaitientRequestDetail = requestPatietnAddressDetail;

            #endregion

            #region Get Requets Patient Date Time 

            var dateTimeDetail = await _requestService.GetRequestDateTimeDetailByRequestDetailId(request.Id);
            if (dateTimeDetail == null) return null;

            model.PatientRequestDateTimeDetail = dateTimeDetail;

            #endregion

            #region Get Home Nurse Tariff From Site Setting 

            double homeNurseTariff = await _siteSetting.GetHomeNurseTariff();
            if (homeNurseTariff == null || homeNurseTariff == 0) return null;

            model.HomeVisitTariff = (int)homeNurseTariff;

            #endregion

            #region Proccess Cost

            double cost = homeNurseTariff;

            if (requestPatietnAddressDetail.Distance != null && requestPatietnAddressDetail.Distance != 0)
            {
                var DistanceFromCityTarriff = await _siteSetting.GetDistanceFromCityTarriffCost();

                var distancePerTenKilometer = DistanceFromCityTarriff / 10;

                cost = cost + (DistanceFromCityTarriff * distancePerTenKilometer);

                DistanceFromCityTarriff = (DistanceFromCityTarriff * distancePerTenKilometer);
            }

            if (dateTimeDetail.StartTime >= 22 )
            {
                cost = cost + ((homeNurseTariff * 20) / 100);

                model.OverTiming = ((int)((homeNurseTariff * 20) / 100));
            }

            #endregion

            #region Get Request Selected Tariffs 

            List<HomeNurseInvoiceTariff> returnTariff = new List<HomeNurseInvoiceTariff>();

            var selectedTariffs = await _siteSetting.GetTariffBySelectedTariffs(request.Id);

            if (selectedTariffs != null && selectedTariffs.Any())
            {
                foreach (var tariff in selectedTariffs)
                {
                    cost = cost + Int64.Parse(tariff.Price);

                    returnTariff.Add(new HomeNurseInvoiceTariff()
                    {
                        Price = tariff.Price,
                        Title = tariff.Title
                    });
                }
            }

            model.TariffForHealthHouseServices = returnTariff;

            #endregion

            #region Invoic Sum 

            model.InvoiceSum = (int)cost;

            #endregion

            return model;
        }

        #endregion

        #region Admin Side

        public async Task<FilterHomeNurseViewModel> FilterHomeNurse(FilterHomeNurseViewModel filter)
        {
            return await _homeNurse.FilterHomeNurse(filter);
        }

        public async Task<Request?> GetRquestForHomeNurseById(ulong requestId)
        {
            return await _homeNurse.GetRquestForHomeNurseById(requestId);
        }

        public async Task<Patient?> GetPatientByRequestId(ulong requestId)
        {
            return await _homeNurse.GetPatientByRequestId(requestId);
        }

        public async Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId)
        {
            return await _homeNurse.GetRequestPatientDetailByRequestId(requestId);
        }

        public async Task<HomeNurseRequestDetailViewModel> ShowHomeNurseDetail(ulong requestId)
        {
            #region Get request By Id

            var request = await GetRquestForHomeNurseById(requestId);

            if (request == null) return null;

            #endregion

            #region Get Patient By Id 

            var patient = await GetPatientByRequestId(requestId);

            #endregion

            #region Get Patient Request Detail 

            var requestDetail = await GetRequestPatientDetailByRequestId(requestId);

            #endregion

            #region Fill View Model

            HomeNurseRequestDetailViewModel model = new HomeNurseRequestDetailViewModel()
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
                var country = await _locationService.GetLocationById(requestDetail.CountryId);

                var state = await _locationService.GetLocationById(requestDetail.StateId);

                var city = await _locationService.GetLocationById(requestDetail.CityId);

                model.Country = country.UniqueName;

                model.State = state.UniqueName;

                model.City = city.UniqueName;
            }

            #endregion

            return model;
        }

        #endregion
    }
}
