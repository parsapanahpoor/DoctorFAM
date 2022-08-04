using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomePharmacy;
using DoctorFAM.Domain.ViewModels.Site.Common;
using DoctorFAM.Domain.ViewModels.Site.HomePharmacy;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class HomePharmacyService : IHomePharmacyServicec
    {
        #region Ctor

        private readonly IHomePharmacyRepository _homePharmacy;

        private readonly IUserService _userService;

        private readonly IRequestService _requestService;

        private readonly IPatientService _patientService;

        private readonly ILocationService _locationService;

        private readonly IWalletRepository _walletRepository;

        private readonly IPopulationCoveredRepository _populationCovered;

        public HomePharmacyService(IHomePharmacyRepository homePharmacy, IUserService userService,
                                    IRequestService requestService, IPatientService patientService
                                    , ILocationService locationService , IWalletRepository walletRepository , IPopulationCoveredRepository populationCovered)
        {
            _homePharmacy = homePharmacy;
            _userService = userService;
            _requestService = requestService;
            _patientService = patientService;
            _locationService = locationService;
            _walletRepository = walletRepository; 
            _populationCovered = populationCovered;
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

        public async Task<bool> PayHomePharmacyTariff(ulong userId, int price)
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
                PaymentType = PaymentType.HomePharmacy,
                Price = price,
                Description = "پرداخت مبلغ آزمایشگاه در منزل",
                IsFinally = true
            };

            await _walletRepository.CreateWalletAsync(wallet);
            return true;
        }


        public async Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model)
        {
            var result = await _requestService.IsExistRequestByRequestId(model.RequestId);

            if (result == false) return CreatePatientResult.RequestIdNotFound;

            return CreatePatientResult.Success;
        }

        public async Task<ulong?> CreateHomePharmacyRequest(ulong userId)
        {
            #region User Validation

            if (await _userService.GetUserById(userId) == null)
            {
                return null;
            }

            #endregion

            #region Fill Entitie

            Request request = new Request()
            {
                RequestType = Domain.Enums.RequestType.RequestType.HomeDrog,
                RequestState = Domain.Enums.Request.RequestState.WaitingForCompleteInformationFromUser,
                CreateDate = DateTime.Now,
                IsDelete = false,
                UserId = userId
            };

            #endregion

            #region Add Request Method

            await _requestService.AddRequest(request);

            #endregion

            return request.Id;
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

        public async Task<RequestedDrugsViewModel?> FillRequestedDrugsViewModel(ulong requestId)
        {
            #region Data VAlidation

            if (!await _requestService.IsExistRequestByRequestId(requestId)) return null;

            #endregion

            #region Get Request

            var request = await _requestService.GetRequestById(requestId);

            if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeDrog) return null;

            #endregion

            #region Get List Of Drugs

            var drugs = await _homePharmacy.GetHomePharmacyRequestDetailByRequestId(requestId);

            #endregion

            #region Fill View Model

            RequestedDrugsViewModel requestDrugs = new RequestedDrugsViewModel()
            {
                RequestId = requestId,
                ListOfRequestedDrugs = drugs,
            };

            #endregion

            return requestDrugs;
        }

        public async Task<CreateDrugRequestSiteSideResult> CreateDrugRequestSiteSide(RequestedDrugsViewModel model, IFormFile? DrugPrescriptionImage, IFormFile? DrugImage)
        {
            #region Model Validation

            //if drugTrackingCode has value and thier other properties have value too
            if (!string.IsNullOrEmpty(model.DrugTrakingCode) && (!string.IsNullOrEmpty(model.DrugName) || DrugImage != null || !string.IsNullOrEmpty(model.DrugCount) || DrugPrescriptionImage != null))
            {
                return CreateDrugRequestSiteSideResult.MoreThanOneChoice;
            }

            //if DrugPrescriptionImage has value and thier other properties have value too
            if (DrugPrescriptionImage != null && (!string.IsNullOrEmpty(model.DrugName) || !string.IsNullOrEmpty(model.DrugCount) || DrugImage != null || !string.IsNullOrEmpty(model.DrugTrakingCode)))
            {
                return CreateDrugRequestSiteSideResult.MoreThanOneChoice;
            }

            //if drugName and Drug Count has value and thier other properties have value too
            if (!string.IsNullOrEmpty(model.DrugName) && (!string.IsNullOrEmpty(model.DrugTrakingCode) || DrugPrescriptionImage != null))
            {
                return CreateDrugRequestSiteSideResult.MoreThanOneChoice;
            }

            //if drugImage and Drug Count has value and thier other properties have value too
            if (DrugImage != null && (!string.IsNullOrEmpty(model.DrugTrakingCode) || DrugPrescriptionImage != null))
            {
                return CreateDrugRequestSiteSideResult.MoreThanOneChoice;
            }

            //if user fill drugName but doesnt Fill drug Count
            if (!string.IsNullOrEmpty(model.DrugName) && string.IsNullOrEmpty(model.DrugCount))
            {
                return CreateDrugRequestSiteSideResult.DrugCountIsNull;
            }

            //if user fill drugImage but doesnt Fill drug Count
            if (DrugImage != null && string.IsNullOrEmpty(model.DrugCount))
            {
                return CreateDrugRequestSiteSideResult.DrugCountIsNull;
            }

            //if user fill drugCount but doesnt fill drugName and drugImage
            if (string.IsNullOrEmpty(model.DrugName) && DrugImage == null && !string.IsNullOrEmpty(model.DrugCount))
            {
                return CreateDrugRequestSiteSideResult.DrugNameAndImageIsNull;
            }

            //if all of the properties dont fill
            if (string.IsNullOrEmpty(model.DrugTrakingCode) && string.IsNullOrEmpty(model.DrugName) && string.IsNullOrEmpty(model.DrugCount) && DrugPrescriptionImage == null)
            {
                return CreateDrugRequestSiteSideResult.AllOfPropertiesAreNull;
            }

            //if image is not image
            if (DrugPrescriptionImage != null && !DrugPrescriptionImage.IsImage())
            {
                return CreateDrugRequestSiteSideResult.DetailNotValid;
            }

            //if image is not image
            if (DrugImage != null && !DrugImage.IsImage())
            {
                return CreateDrugRequestSiteSideResult.DetailNotValid;
            }

            #endregion

            #region Get Request

            var request = await _requestService.GetRequestById(model.RequestId);

            if (request == null) return CreateDrugRequestSiteSideResult.DetailNotValid;

            if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeDrog) return CreateDrugRequestSiteSideResult.DetailNotValid;

            #endregion

            #region Fill Data And Add Home Druge Request Detail

            #region Fill peroperties

            HomePharmacyRequestDetail drugRequest = new HomePharmacyRequestDetail()
            {
                RequestId = model.RequestId,
                CreateDate = DateTime.Now,
                Description = model.Description.SanitizeText(),
                DrugCount = model.DrugCount.SanitizeText(),
                DrugName = model.DrugName.SanitizeText(),
                DrugTrakingCode = model.DrugTrakingCode.SanitizeText(),
                IsDelete = false,
            };


            #endregion

            #region Image

            if (DrugPrescriptionImage != null)
            {
                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(DrugPrescriptionImage.FileName);
                DrugPrescriptionImage.AddImageToServer(imageName, PathTools.DrugPrescriptionPathServer, 270, 270, PathTools.DrugPrescriptionPathThumbServer);
                drugRequest.DrugPrescription = imageName;
            }

            if (DrugImage != null)
            {
                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(DrugImage.FileName);
                DrugImage.AddImageToServer(imageName, PathTools.DrugPrescriptionPathServer, 270, 270, PathTools.DrugPrescriptionPathThumbServer);
                drugRequest.DrugImage = imageName;
            }

            #endregion

            await _homePharmacy.AddDrugRequest(drugRequest);

            #endregion

            return CreateDrugRequestSiteSideResult.Success;
        }

        public async Task<bool> DeleteRequestedDrug(ulong requestedDrugId)
        {
            #region Get Requested Drug 

            var drug = await _homePharmacy.GetRequestedDrugById(requestedDrugId);

            if (drug == null) return false;

            #endregion

            #region Delete Image

            if (drug.DrugPrescription != null)
            {
                drug.DrugPrescription.DeleteImage(PathTools.DrugPrescriptionPathServer, PathTools.DrugPrescriptionPathThumbServer);
            }

            if (drug.DrugImage != null)
            {
                drug.DrugImage.DeleteImage(PathTools.DrugPrescriptionPathServer, PathTools.DrugPrescriptionPathThumbServer);
            }

            #endregion

            #region Remove Drug

            drug.IsDelete = true;

            await _homePharmacy.DeleteRequestedDrug(drug);

            #endregion

            return true;
        }

        public async Task<CreatePatientAddressResult> CreatePatientRequestDetail(PatientRequestedDrugAddressViewModel model)
        {
            #region Data Validation

            //If Patient Not Found
            if (!await _patientService.IsExistPatientById(model.PatientId)) return CreatePatientAddressResult.PatientNotFound;

            //If Request Not Found
            if (!await _requestService.IsExistRequestByRequestId(model.RequestId)) return CreatePatientAddressResult.RquestNotFound;

            //If Country Not Found
            if (!await _locationService.IsExistAnyLocationByLocationid(model.CountryId)) return CreatePatientAddressResult.LocationNotFound;

            //If State Not Found
            if (!await _locationService.IsExistAnyLocationByLocationid(model.StateId)) return CreatePatientAddressResult.LocationNotFound;

            //If City Not Found
            if (!await _locationService.IsExistAnyLocationByLocationid(model.CountryId)) return CreatePatientAddressResult.LocationNotFound;

            #endregion

            #region Fill Entity

            PaitientRequestDetail request = new PaitientRequestDetail()
            {
                RequestId = model.RequestId,
                PatientId = model.PatientId,
                CountryId = model.CountryId,
                StateId = model.StateId,
                CityId = model.CityId,
                Mobile = model.Mobile,
                Vilage = model.Vilage,
                Distance = model.Distance,
                Phone = model.Phone,
                CreateDate = DateTime.Now,
                FullAddress = model.FullAddress,
            };

            #endregion

            #region Add Method

            await _requestService.AddPatientRequestDetail(request);

            #endregion

            #region Update Reuqest State

            #region Get Request 

            var requestState = await _requestService.GetRequestById(model.RequestId);

            #endregion

            #region Update request

            requestState.RequestState = Domain.Enums.Request.RequestState.TramsferringToTheBankingPortal;

            await _requestService.UpdateRequest(requestState);

            #endregion

            #endregion

            #region Patient Request DateTime Detail

            var time = model.SendDate.ToMiladiDateTime();

            PatientRequestDateTimeDetail datetimeRequest = new PatientRequestDateTimeDetail()
            {
                SendDate = time,
                RequestId = request.Id,
                CreateDate = DateTime.Now,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
            };

            await _homePharmacy.AddPatientRequestDateTimeDetail(datetimeRequest);

            #endregion

            return CreatePatientAddressResult.Success;
        }

        //Fill Patient ViewModel From Selected Population Covered Data
        public async Task<PatientViewModel> FillPatientViewModelFromSelectedPopulationCoveredData(ulong populationId, ulong requestId, ulong userId)
        {
            #region Get User

            var user = await _userService.GetUserById(userId);
            if (user == null) return null;

            #endregion

            #region Get Request 

            var request = await _requestService.GetRequestById(requestId);
            if (request == null) return null;
            if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeDrog) return null;

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

        #region Admin Side

        public async Task<FilterHomePharmacyViewModel> FilterHomePharmacy(FilterHomePharmacyViewModel filter)
        {
            return await _homePharmacy.FilterHomePharmacy(filter);
        }

        public async Task<HomePharmacyRequestDetailViewModel> ShowHomePharmacyDetail(ulong requestId)
        {
            #region Get request By Id

            var request = await GetRquestForHomePharmacyById(requestId);

            if (request == null) return null;

            #endregion

            #region Get Patient By Id 

            var patient = await GetPatientByRequestId(requestId);

            #endregion

            #region Get Patient Request Detail 

            var requestDetail = await GetRequestPatientDetailByRequestId(requestId);

            #endregion

            #region Fill View Model

            HomePharmacyRequestDetailViewModel model = new HomePharmacyRequestDetailViewModel()
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

            #region Get Request Detail Date Time 

            if (requestDetail != null)
            {
                var dateTime = await GetRequestDateTimeDetailByRequestDetailId(requestDetail.Id);

                if (dateTime != null)
                {
                    model.SendDate = dateTime.SendDate;
                    model.StartTime = dateTime.StartTime;
                    model.EndTime = dateTime.EndTime;
                }
            }

            #endregion

            #region Get Request Drugs 

            model.RequestedDrugs = await GetRequestDrugsByRequestId(request.Id);

            #endregion

            return model;
        }

        public async Task<Patient?> GetPatientByRequestId(ulong requestId)
        {
            return await _homePharmacy.GetPatientByRequestId(requestId);
        }

        public async Task<Request?> GetRquestForHomePharmacyById(ulong requestId)
        {
            return await _homePharmacy.GetRquestForHomePharmacyById(requestId);
        }

        public async Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId)
        {
            return await _homePharmacy.GetRequestPatientDetailByRequestId(requestId);
        }

        public async Task<PatientRequestDateTimeDetail?> GetRequestDateTimeDetailByRequestDetailId(ulong requestId)
        {
            return await _homePharmacy.GetRequestDateTimeDetailByRequestDetailId(requestId);
        }

        public async Task<List<RequestedDrugsAdminSideViewModel>?> GetRequestDrugsByRequestId(ulong requestId)
        {
            return await _homePharmacy.GetRequestDrugsByRequestId(requestId);
        }

        //Get List Of Home Pharmacy Request Detail By Request Id 
        public async Task<List<HomePharmacyRequestDetail>> GetHomePharmacyRequestDetailByRequestId(ulong requestId)
        {
            return await _homePharmacy.GetHomePharmacyRequestDetailByRequestId(requestId);
        }

        #endregion
    }
}
