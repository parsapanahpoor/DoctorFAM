using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Common;
using DoctorFAM.Domain.ViewModels.Site.HomeLaboratory;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeLabratory;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse.HomeLaboratory;

namespace DoctorFAM.Application.Services.Implementation
{
    public class HomeLaboratoryService : IHomeLaboratoryServices
    {
        #region Ctor

        private readonly IHomeLaboratoryRepository _homeLaboratory;
        private readonly IUserService _userService;
        private readonly IRequestService _requestService;
        private readonly IPatientService _patientService;
        private readonly ILocationService _locationService;
        private readonly IWalletRepository _walletRepository;
        private readonly IPopulationCoveredRepository _populationCovered;
        private readonly ISiteSettingService _siteSettingService;

        public HomeLaboratoryService(IHomeLaboratoryRepository homeLaboratory, IUserService userService, IRequestService requestService, IPatientService patientService, ILocationService locationService
                                        ,IWalletRepository walletRepository, IPopulationCoveredRepository populationCovered, ISiteSettingService siteSettingService)
        {
            _homeLaboratory = homeLaboratory;
            _userService = userService;
            _requestService = requestService;
            _patientService = patientService;
            _locationService = locationService;
            _walletRepository = walletRepository;
            _populationCovered = populationCovered;
            _siteSettingService = siteSettingService;
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
                Description = "شارژ حساب کاربری برای پرداخت هزینه ی آزمایشگاه در منزل",
                IsFinally = true
            };

            await _walletRepository.CreateWalletAsync(wallet);
            return true;
        }

        public async Task<bool> PayHomeLAboratoryTariff(ulong userId, int price, ulong? requestId)
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
                PaymentType = PaymentType.HomeLaboratory,
                Price = price,
                Description = "پرداخت مبلغ آزمایشگاه در منزل",
                IsFinally = true,
                RequestId = requestId
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

        public async Task<ulong?> CreateHomeLaboratoryRequest(ulong userId)
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
                RequestType = Domain.Enums.RequestType.RequestType.HomeLab,
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

        public async Task<ulong> CreatePatientDetail(PatientViewModel patient)
        {
            #region Get Insurance By Id

            var insurance = await _siteSettingService.GetInsuranceById(patient.InsuranceId);
            if (insurance is null) return 0;

            #endregion

            #region Fill Entity

            Patient model = new Patient
            {
                RequestId = patient.RequestId,
                Age = patient.Age,
                Gender = patient.Gender,
                InsuranceId = insurance.Id,
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
            if (request.RequestType != RequestType.HomeLab) return null;

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
                InsuranceId = population.InsuranceId,
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
                InsuranceId = population.InsuranceId,
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


        public async Task<RequestedLaboratoryViewModel?> FillRequestedLaboratoryViewModel(ulong requestId)
        {
            #region Data VAlidation

            if (!await _requestService.IsExistRequestByRequestId(requestId)) return null;

            #endregion

            #region Get Request

            var request = await _requestService.GetRequestById(requestId);

            if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeLab) return null;

            #endregion

            #region Get List Of Laboratory

            var laboratory = await _homeLaboratory.GetHomeLaboratoryRequestDetailByRequestId(requestId);

            #endregion

            #region Fill View Model

            RequestedLaboratoryViewModel requestLaboratory = new RequestedLaboratoryViewModel()
            {
                RequestId = requestId,
                ListOfRequestedLaboratory = laboratory,
            };

            #endregion

            return requestLaboratory;
        }

        public async Task<CreateLaboratoryRequestSiteSideResult> CreateLaboratoryRequestSiteSide(RequestedLaboratoryViewModel model, IFormFile? ExperimentPrescriptionImage, IFormFile? ExperimentImage)
        {
            #region Model Validation

            //if laboratoryTrackingCode has value and thier other properties have value too
            if (!string.IsNullOrEmpty(model.ExperimentTrakingCode) && (!string.IsNullOrEmpty(model.ExperimentName) || ExperimentImage != null  || ExperimentPrescriptionImage != null))
            {
                return CreateLaboratoryRequestSiteSideResult.MoreThanOneChoice;
            }

            //if LaboratoryPrescriptionImage has value and thier other properties have value too
            if (ExperimentPrescriptionImage != null && (!string.IsNullOrEmpty(model.ExperimentName)  || ExperimentImage != null || !string.IsNullOrEmpty(model.ExperimentTrakingCode)))
            {
                return CreateLaboratoryRequestSiteSideResult.MoreThanOneChoice;
            }

            //if LaboratoryName and Laboratory Count has value and thier other properties have value too
            if (!string.IsNullOrEmpty(model.ExperimentName) && (!string.IsNullOrEmpty(model.ExperimentTrakingCode) || ExperimentPrescriptionImage != null))
            {
                return CreateLaboratoryRequestSiteSideResult.MoreThanOneChoice;
            }

            //if LaboratoryImage and Laboratory Count has value and thier other properties have value too
            if (ExperimentImage != null && (!string.IsNullOrEmpty(model.ExperimentTrakingCode) || ExperimentPrescriptionImage != null))
            {
                return CreateLaboratoryRequestSiteSideResult.MoreThanOneChoice;
            }

            //if all of the properties dont fill
            if (string.IsNullOrEmpty(model.ExperimentTrakingCode) && string.IsNullOrEmpty(model.ExperimentName)  && ExperimentPrescriptionImage == null && ExperimentImage == null)
            {
                return CreateLaboratoryRequestSiteSideResult.AllOfPropertiesAreNull;
            }

            //if image is not image
            if (ExperimentPrescriptionImage != null && !ExperimentPrescriptionImage.IsImage())
            {
                return CreateLaboratoryRequestSiteSideResult.DetailNotValid;
            }

            //if image is not image
            if (ExperimentImage != null && !ExperimentImage.IsImage())
            {
                return CreateLaboratoryRequestSiteSideResult.DetailNotValid;
            }

            #endregion

            #region Get Request

            var request = await _requestService.GetRequestById(model.RequestId);

            if (request == null) return CreateLaboratoryRequestSiteSideResult.DetailNotValid;

            if (request.RequestType != Domain.Enums.RequestType.RequestType.HomeLab) return CreateLaboratoryRequestSiteSideResult.DetailNotValid;

            #endregion

            #region Fill Data And Add Home Laboratory Request Detail

            #region Fill peroperties

            HomeLaboratoryRequestDetail laboratoryRequest = new HomeLaboratoryRequestDetail()
            {
                RequestId = model.RequestId,
                CreateDate = DateTime.Now,
                Description = model.Description.SanitizeText(),

                ExperimentName = model.ExperimentName.SanitizeText(),
                ExperimentTrakingCode = model.ExperimentTrakingCode.SanitizeText(),
                IsDelete = false,
            };


            #endregion

            #region Image

            if (ExperimentPrescriptionImage != null)
            {
                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(ExperimentPrescriptionImage.FileName);
                ExperimentPrescriptionImage.AddImageToServer(imageName, PathTools.LabPrescriptionPathServer, 270, 270, PathTools.LabPrescriptionPathThumbServer);
                laboratoryRequest.ExperimentPrescription = imageName;
            }

            if (ExperimentImage != null)
            {
                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(ExperimentImage.FileName);
                ExperimentImage.AddImageToServer(imageName, PathTools.LabPrescriptionPathServer, 270, 270, PathTools.LabPrescriptionPathThumbServer);
                laboratoryRequest.ExperimentImage = imageName;
            }

            #endregion

            await _homeLaboratory.AddLaboratoryRequest(laboratoryRequest);

            #endregion

            return CreateLaboratoryRequestSiteSideResult.Success;
        }

        public async Task<bool> DeleteRequestedLaboratory(ulong requestedLaboratoryId)
        {
            #region Get Requested Laboratory 

            var laboratory = await _homeLaboratory.GetRequestedLaboratoryById(requestedLaboratoryId);

            if (laboratory == null) return false;

            #endregion

            #region Delete Image

            if (laboratory.ExperimentPrescription != null)
            {
                laboratory.ExperimentPrescription.DeleteImage(PathTools.LabPrescriptionPathServer, PathTools.LabPrescriptionPathThumbServer);
            }

            if (laboratory.ExperimentImage != null)
            {
                laboratory.ExperimentImage.DeleteImage(PathTools.LabPrescriptionPathServer, PathTools.LabPrescriptionPathThumbServer);
            }

            #endregion

            #region Remove Laboratory

            laboratory.IsDelete = true;

            await _homeLaboratory.DeleteRequestedLaboratory(laboratory);

            #endregion

            return true;
        }

        public async Task<CreatePatientAddressResult> CreatePatientRequestDetail(PatientRequestedLaboratoryAddressViewModel model)
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
                RequestId = model.RequestId,
                CreateDate = DateTime.Now,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
            };

            await _homeLaboratory.AddPatientRequestDateTimeDetail(datetimeRequest);

            #endregion

            return CreatePatientAddressResult.Success;
        }

        #endregion

        #region Admin Side

        public async Task<FilterHomeLabratoryViewModel> FilterHomeLabratory(FilterHomeLabratoryViewModel filter)
        {
            return await _homeLaboratory.FilterHomeLabratory(filter);
        }

        public async Task<HomeLabratoryRequestDetailViewModel> ShowHomeLabratoryDetail(ulong requestId)
        {
            #region Get request By Id

            var request = await GetRquestForHomeLabratoryById(requestId);

            if (request == null) return null;

            #endregion

            #region Get Patient By Id 

            var patient = await GetPatientByRequestId(requestId);

            #endregion

            #region Get Patient Request Detail 

            var requestDetail = await GetRequestPatientDetailByRequestId(requestId);

            #endregion

            #region Fill View Model

            HomeLabratoryRequestDetailViewModel model = new HomeLabratoryRequestDetailViewModel()
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
                Insurance = patient?.Insurance.Title,
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

            model.RequestedLabratory = await GetRequestLabratoryByRequestId(request.Id);

            #endregion

            return model;
        }

        public async Task<Patient?> GetPatientByRequestId(ulong requestId)
        {
            return await _homeLaboratory.GetPatientByRequestId(requestId);
        }

        public async Task<Request?> GetRquestForHomeLabratoryById(ulong requestId)
        {
            return await _homeLaboratory.GetRquestForHomeLabratoryById(requestId);
        }

        public async Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId)
        {
            return await _homeLaboratory.GetRequestPatientDetailByRequestId(requestId);
        }

        public async Task<PatientRequestDateTimeDetail?> GetRequestDateTimeDetailByRequestDetailId(ulong requestDetailId)
        {
            return await _homeLaboratory.GetRequestDateTimeDetailByRequestDetailId(requestDetailId);
        }

        public async Task<List<RequestedLabratoryAdminSideViewModel>?> GetRequestLabratoryByRequestId(ulong requestId)
        {
            return await _homeLaboratory.GetRequestLabratoryByRequestId(requestId);
        }

        #endregion

        #region User Panel

        public async Task<ListOfHomeLaboratoryUserPanelSideViewModel> ListOfUserHomeLaboratoryRequest(ListOfHomeLaboratoryUserPanelSideViewModel filter)
        {
            return await _homeLaboratory.ListOfUserHomeLaboratoryRequest(filter);
        }

        #endregion
    }
}
