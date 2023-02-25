using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.Enums.Gender;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DeathCertificate;
using DoctorFAM.Domain.ViewModels.DoctorPanel.HomeVisit;
using DoctorFAM.Domain.ViewModels.Site.HomeVisitRequest;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;

namespace DoctorFAM.Application.Services.Implementation
{
    public class HomeVisitService : IHomeVisitService
    {
        #region Ctor

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
        private readonly IDoctorsService _doctorsService;
        private readonly IDoctorsRepository _doctorsRepository;
        private readonly IWorkAddressService _workAddressService;

        public HomeVisitService(IHomeVisitRepository homeVisit, IRequestService requestService,
                                IUserService userService, IPatientService patientService, ILocationService locationServoce
                                , IWalletRepository walletRepository, IPopulationCoveredRepository populationCovered, ISiteSettingService siteSettingService,
                                    IOrganizationService organizationService, IHomePharmacyRepository pharmacyService, IDoctorsService doctorsService, IDoctorsRepository doctorsRepository
                                        , IWorkAddressService workAddressService)
        {
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
            _doctorsService = doctorsService;
            _doctorsRepository = doctorsRepository;
            _workAddressService = workAddressService;
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
            #region Get Insurance

            var insurance = await _siteSettingService.GetInsuranceById(patient.InsuranceId);
            if (insurance == null) return 0;

            #endregion

            #region Fill Entity

            Patient model = new Patient
            {
                RequestId = patient.RequestId,
                Age = patient.Age,
                Gender = patient.Gender,
                InsuranceId = patient.InsuranceId,
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
                InsuranceId = (ulong)population.InsuranceId,
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
                InsuranceId = (ulong)population.InsuranceId,
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

            #region Get Home Visit Request Detail By Request Id

            var detail = await _homeVisit.GetHomeVisitRequestDetailByRequestId(requestId);
            if (detail == null) return null;

            #endregion

            #region Get Activated Doctors By Home Visit Interests 

            var gender = new Gender();

            if (detail.FemalePhysician == true)
            {
                gender = Gender.Female;
            }
            else
            {
                gender = Gender.Male;
            }

            var returnValue = await _homeVisit.GetActivatedAndDoctorsInterestHomeVisit(requetsDetail.CountryId, requetsDetail.StateId, requetsDetail.CityId, gender);

            #endregion

            return returnValue;
        }

        #endregion

        #region Site Side

        public async Task<bool> ChargeUserWallet(ulong userId, int price, ulong? requestId)
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
                IsFinally = true,
                RequestId = requestId.Value
            };

            await _walletRepository.CreateWalletAsync(wallet);
            return true;
        }

        public async Task<bool> PayHomeVisitTariff(ulong userId, int price, ulong? requestId)
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
                IsFinally = true,
                RequestId = requestId.Value
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

            //if (homeVisitRequestDetail.IntramuscularInjection == true)
            //{
            //    var IntramuscularInjection = await _siteSettingService.GetIntramuscularInjectionCost();

            //    cost = cost + IntramuscularInjection;
            //}

            #endregion

            #region Get Request Selected Tariffs 

            var selectedTariffs = await _siteSettingService.GetRequestSelectedTariffsByRequestId(request.Id);

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

        //Fill Home Visit Request Invoice View Model
        public async Task<HomeVisitRequestInvoiceViewModel?> FillHomeVisitRequestInvoiceViewModel(Request request)
        {
            //Make Instance From Return Model 
            HomeVisitRequestInvoiceViewModel model = new HomeVisitRequestInvoiceViewModel();
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

            #region Get Home Visit Request Detail 

            var homeVisitRequestDetail = await GetHomeVisitRequestDetailByRequestId(request.Id);
            if (homeVisitRequestDetail != null)
            {
                model.HomeVisitRequestDetail = homeVisitRequestDetail;
            }

            #endregion

            #region Get Home Visit Tariff From Site Setting 

            double homeVisitTariff = await _siteSettingService.GetHomeVisitTariff();
            if (homeVisitTariff == null || homeVisitTariff == 0) return null;

            model.HomeVisitTariff = (int)homeVisitTariff;

            #endregion

            #region Proccess Cost

            double cost = homeVisitTariff;

            if (requestPatietnAddressDetail.Distance != null && requestPatietnAddressDetail.Distance != 0)
            {
                var DistanceFromCityTarriff = await _siteSettingService.GetDistanceFromCityTarriffCost();

                var distancePerTenKilometer = DistanceFromCityTarriff / 10;

                cost = cost + (DistanceFromCityTarriff * distancePerTenKilometer);

                DistanceFromCityTarriff = (DistanceFromCityTarriff * distancePerTenKilometer);
            }

            if (homeVisitRequestDetail != null)
            {
                if (homeVisitRequestDetail.EmergencyVisit == true)
                {
                    cost = cost + ((homeVisitTariff * 20) / 100);

                    model.EmergencyVisit = ((int)((homeVisitTariff * 20) / 100));
                }

                if (homeVisitRequestDetail.FemalePhysician == true)
                {
                    cost = cost + ((homeVisitTariff * 20) / 100);

                    model.FemalePhysician = ((int)((homeVisitTariff * 20) / 100));
                }
            }

            if (dateTimeDetail.StartTime >= 22 || dateTimeDetail.EndTime <= 8)
            {
                cost = cost + ((homeVisitTariff * 20) / 100);

                model.OverTiming = ((int)((homeVisitTariff * 20) / 100));
            }

            #endregion

            #region Get Request Selected Tariffs 

            List<HomeVisitInvoiceTariff> returnTariff = new List<HomeVisitInvoiceTariff>();

            var selectedTariffs = await _siteSettingService.GetTariffBySelectedTariffs(request.Id);

            if (selectedTariffs != null && selectedTariffs.Any())
            {
                foreach (var tariff in selectedTariffs)
                {
                    cost = cost + Int64.Parse(tariff.Price);

                    returnTariff.Add(new HomeVisitInvoiceTariff()
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

        //Fill Request Seleted Features View Model 
        public async Task<HomeVisitRequestFeatureViewModel> FillRequestSeletedFeaturesViewModel(ulong requestId)
        {
            //Initial Instance For Model
            HomeVisitRequestFeatureViewModel model = new HomeVisitRequestFeatureViewModel()
            {
                EmergencyVisit = false,
                RequestId = requestId,
                ListOfTariffs = await _siteSettingService.GetListOfTariffForHomeVisitHealthHouseServices(),
                FemalePhysician = false,
            };

            #region Get Request Selected Tariffs 

            var selectedTariffs = await _siteSettingService.GetTariffBySelectedTariffs(requestId);
            if (selectedTariffs != null && selectedTariffs.Any())
            {
                model.ListOfUserSelectedTAriff = selectedTariffs;
            }

            #endregion

            #region Get Home Visit Request Detail 

            var homeVisitRequestDetail = await GetHomeVisitRequestDetailByRequestId(requestId);
            if (homeVisitRequestDetail != null)
            {
                model.EmergencyVisit = homeVisitRequestDetail.EmergencyVisit;
                model.FemalePhysician = homeVisitRequestDetail.FemalePhysician;
            }

            #endregion

            return model;
        }

        //Add Feature For Request Selected Features
        public async Task<bool> AddFeatureForRequestSelectedFeatures(ulong requestId, ulong tarrifId)
        {
            #region Get Tarrif By Id 

            var tariff = await _siteSettingService.GetHealthHouseTariffServiceById(tarrifId);
            if (tariff == null || !tariff.HomeVisit) return false;

            #endregion

            #region Add Request selected Tariff Request 

            RequestSelectedHealthHouseTariff selectedtariff = new RequestSelectedHealthHouseTariff()
            {
                CreateDate = DateTime.Now,
                RequestId = requestId,
                TariffForHealthHouseServiceId = tarrifId
            };

            //Add Request Selected Tariff To Data Base 
            await _siteSettingService.AddRequestSelectedHealtHouseTariffWithoutSavechanges(selectedtariff);
            await _homeVisit.Savechanges();

            #endregion

            return true;
        }

        //Minus Feature For Request Selectde Features
        public async Task<bool> MinusFeatureForRequestSelectdeFeatures(ulong requestId, ulong tarrifId)
        {
            #region Get Tarrif By Id 

            var tariff = await _siteSettingService.GetHealthHouseTariffServiceById(tarrifId);
            if (tariff == null || !tariff.HomeVisit) return false;

            #endregion

            #region Check Validation  

            var selectedFeature = await _homeVisit.GetrequestSelectedTariffByRequestIdAndTarrifId(requestId, tarrifId);
            if (selectedFeature == null) return false;

            //Delete Selected Feature
            selectedFeature.IsDelete = true;

            //Update Method 
            await _homeVisit.UpdaterequestSelectedFeatureState(selectedFeature);

            #endregion

            return true;
        }

        //Add Or Edit Home Visit Request Detail State  
        public async Task<bool> AddOrEditHomeVisitRequestDetailState(Request request, bool femalDoctor, bool emergancy)
        {
            #region Get Home Visit Request Detail 

            var homeVisitRequestDetail = await GetHomeVisitRequestDetailByRequestId(request.Id);

            #endregion

            #region Add 

            if (homeVisitRequestDetail == null)
            {
                HomeVisitRequestDetail visitRequestDetail = new HomeVisitRequestDetail()
                {
                    EmergencyVisit = emergancy,
                    FemalePhysician = femalDoctor,
                    RequestId = request.Id,
                };

                await _homeVisit.AddHomeVisitRequestDetailvisitRequestDetail(visitRequestDetail);

                return true;
            }

            #endregion

            #region Edit

            if (homeVisitRequestDetail != null)
            {
                homeVisitRequestDetail.FemalePhysician = femalDoctor;
                homeVisitRequestDetail.EmergencyVisit = emergancy;

                //Update Home Visit Requst Detail
                await _homeVisit.UpdateHomeVisitRequstDetail(homeVisitRequestDetail);

                return true;
            }

            #endregion

            return false;
        }

        #endregion

        #region Doctor Panel Side

        //Check Log For Decline Home Visit Request 
        public async Task<List<LogForDeclineHomeVisitRequestFromUser>?> CheckLogForDeclineHomeVisitRequest(ulong userId)
        {
            return await _homeVisit.CheckLogForDeclineHomeVisitRequest(userId);
        }

        //Fill Home Visit Request Detail View Model
        public async Task<Domain.ViewModels.DoctorPanel.HomeVisit.HomeVisitRequestDetailViewModel?> FillHomeVisitRequestDetailViewModel(ulong requestId, ulong userId)
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
            if (request.OperationId.HasValue)
            {
                if (request.OperationId.Value != organization.OwnerId)
                {
                    return null;
                }
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
                PatientRequestDateTimeDetail = await _requestService.GetRequestDateTimeDetailByRequestDetailId(requestId),
                TariffsSelected = await _siteSettingService.GetRequestSelectedTariffsByRequestId(requestId),
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

        //Confirm Home Visit Request From Doctor 
        public async Task<bool> ConfirmHomeVisitRequestFromDoctor(ulong requestId, ulong userId)
        {
            #region Get Doctor Organization

            var organization = await _organziationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return false;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return false;

            #endregion

            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return false;
            if (request.RequestType != RequestType.HomeVisit) return false;
            if (!request.PatientId.HasValue) return false;
            if (request.OperationId.HasValue) return false;
            if (request.RequestState != RequestState.Paid) return false;

            #endregion

            #region Get Request By Doctor 

            request.OperationId = organization.OwnerId;
            request.RequestState = RequestState.SelectedFromDoctor;

            await _requestService.UpdateRequest(request);

            #endregion

            return true;
        }

        #endregion

        #region Admin Side

        public async Task<FilterHomeVisistViewModel> FilterHomeVisit(FilterHomeVisistViewModel filter)
        {
            return await _homeVisit.FilterHomeVisit(filter);
        }

        public async Task<Domain.ViewModels.Admin.HealthHouse.HomeVisit.HomeVisitRequestDetailViewModel> ShowHomeVisitDetail(ulong requestId)
        {
            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return null;
            if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeVisit) return null;
            if (!request.PatientId.HasValue) return null;

            #endregion

            #region Fill Model 

            Domain.ViewModels.Admin.HealthHouse.HomeVisit.HomeVisitRequestDetailViewModel model = new Domain.ViewModels.Admin.HealthHouse.HomeVisit.HomeVisitRequestDetailViewModel()
            {
                Patient = await _patientService.GetPatientById(request.PatientId.Value),
                User = await _userService.GetUserById(request.UserId),
                PatientRequestDetail = await _homeVisit.GetRequestPatientDetailByRequestId(request.Id),
                PatientRequestDateTimeDetail = await _requestService.GetRequestDateTimeDetailByRequestDetailId(request.Id),
                Request = request,
                HomeVisitRequestDetail = await GetHomeVisitRequestDetailByRequestId(request.Id),
                TariffSelected = await _siteSettingService.GetRequestSelectedTariffsByRequestId(request.Id),
            };

            if (request.OperationId.HasValue)
            {
                model.Doctor = await _userService.GetUserById(request.OperationId.Value);
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

        #region User Panel

        //Filter User Home Visit Requests
        public async Task<Domain.ViewModels.UserPanel.HealthHouse.HomeVisit.FilterHomeVisitViewModel> FilterListOfUserHomeVisitRequest(Domain.ViewModels.UserPanel.HealthHouse.HomeVisit.FilterHomeVisitViewModel filter)
        {
            return await _homeVisit.FilterListOfUserHomeVisitRequest(filter);
        }

        //Fill Doctor Information Detail View Model
        public async Task<ShowDoctorInformationDetailViewModel?> FillShowDoctorInformationDetailViewModel(ulong doctorId)
        {
            #region Get Doctor By Doctor Id

            var doctor = await _doctorsService.GetDoctorByUserId(doctorId);
            if (doctor == null) return null;

            #endregion

            #region Get Doctor Work Address 

            var workAddress = await _workAddressService.GetLastWorkAddressByUserId(doctor.UserId);

            #endregion

            #region Get Doctor Personal Information 

            var doctorInfo = await _doctorsRepository.GetDoctorsInfoByDoctorId(doctor.Id);
            if (doctorInfo == null) return null;

            #endregion

            #region Fill View Model 

            ShowDoctorInformationDetailViewModel model = new ShowDoctorInformationDetailViewModel()
            {
                DoctorsInfo = doctorInfo,
                User = doctor.User,
                WorkAddress = workAddress,
                WorkLocation = doctor.User.WorkAddress
            };

            #endregion

            return model;
        }

        //Accept Doctor Request From Home Visit Request
        public async Task<bool> AcceptDoctorRequestFromHomeVisitRequest(Request request)
        {
            #region Update Request State

            request.RequestState = RequestState.Finalized;

            await _requestService.UpdateRequest(request);

            #endregion

            return true;
        }

        //Decline Doctor Request From Home Visit Request
        public async Task<bool> DeclinetDoctorRequestFromHomeVisitRequest(Request request)
        {
            #region Log For Decline Home Visit Request

            LogForDeclineHomeVisitRequestFromUser model = new LogForDeclineHomeVisitRequestFromUser()
            {
                CreateDate = DateTime.Now,
                DoctorId = request.OperationId.Value,
                RequestId = request.Id
            };

            await _homeVisit.AddLogForDeclineHomeVisitRequest(model);

            #endregion

            #region Update Request State

            request.RequestState = RequestState.Paid;
            request.OperationId = null;

            await _requestService.UpdateRequest(request);

            #endregion

            return true;
        }

        //Remove Home Visit Request From User
        public async Task<bool> RemoveHomeVisitRequestFromUser(Request request, ulong userId)
        {
            #region Get Request Date Time Detail 

            var dateTimeDetail = await _pharmacyService.GetRequestDateTimeDetailByRequestDetailId(request.Id);
            if (dateTimeDetail == null) return false;
            if ((dateTimeDetail.SendDate.Year == DateTime.Now.Year && DateTime.Now.DayOfYear > dateTimeDetail.SendDate.DayOfYear)
                || dateTimeDetail.SendDate.Year < DateTime.Now.Year) return false;
            if (dateTimeDetail.SendDate == DateTime.Now && dateTimeDetail.SendDate.Hour <= DateTime.Now.Hour)
            {
                return false;
            }

            #endregion

            #region Update Request

            request.RequestState = RequestState.Canceled;

            await _requestService.UpdateRequest(request);

            #endregion

            #region Add Transaction For Cancelation

            #region Get Last Transaction For This Request 

            var tranaction = await _walletRepository.GetHomeVisitTransactionForCancelationHomeVisitRequest(request.Id);
            if (tranaction == null) return false;

            #endregion

            #region Pay Cancelation Price For User 

            if (dateTimeDetail.SendDate == DateTime.Now)
            {
                var wallet = new Wallet
                {
                    UserId = userId,
                    TransactionType = TransactionType.Deposit,
                    GatewayType = GatewayType.Zarinpal,
                    PaymentType = PaymentType.HomeVisit,
                    Price = (int)(((double)tranaction.Price * (double)30) / (double)100),
                    Description = "عودت وجه برای لغو ویزیت در منزل",
                    IsFinally = true,
                    RequestId = request.Id
                };

                await _walletRepository.CreateWalletAsync(wallet);
            }
            else
            {
                var wallet = new Wallet
                {
                    UserId = userId,
                    TransactionType = TransactionType.Deposit,
                    GatewayType = GatewayType.Zarinpal,
                    PaymentType = PaymentType.HomeVisit,
                    Price = (int)(((double)tranaction.Price * (double)70) / (double)100),
                    Description = "عودت وجه برای لغو ویزیت در منزل",
                    IsFinally = true,
                    RequestId = request.Id
                };

                await _walletRepository.CreateWalletAsync(wallet);
            }

            #endregion

            #endregion

            return true;
        }

        #endregion
    }
}
