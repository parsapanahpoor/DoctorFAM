
using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.Migrations;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Common;
using DoctorFAM.Domain.ViewModels.Site.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class RequestServicecs : IRequestService
    {
        #region Ctor

        public IRequestRepository _request;

        public IPatientService _patientService;

        public ILocationService _locationService;

        private readonly IOrganizationService _organizationService;

        private readonly ISiteSettingService _siteSettingService;

        public RequestServicecs(IPatientService patientService, IRequestRepository request, ILocationService locationService, IOrganizationService organizationService
                                        , ISiteSettingService siteSettingService)
        {
            _patientService = patientService;
            _request = request;
            _locationService = locationService;
            _organizationService = organizationService;
            _siteSettingService = siteSettingService;
        }

        #endregion

        #region Site Side

        #region Request 

        //Invoice Finalization And See Invoice Detail
        public async Task<int> FinalizationHomePharmacyInvoiceFromPharmacy(ulong requestId, ulong userId)
        {
            //return 0 : NotFound
            //return 1 : Success
            //return 2 : Dont Update 

            #region Get Organization By User Id

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return 0;

            #endregion

            #region Get Request

            var request = await GetRequestById(requestId);
            if (request == null) return 0;
            if (!request.OperationId.HasValue || request.OperationId.Value != organization.OwnerId) return 0;
            if (request.RequestType != RequestType.HomeDrog) return 0;

            #endregion

            #region Update Request State

            if (request.RequestState == RequestState.ConfirmFromDestinationAndWaitingForIssuanceOfDraftInvoice)
            {
                request.RequestState = RequestState.WaitingForAcceptFromCustomer;

                await UpdateRequest(request);
                return 1;
            }

            #endregion

            //Dont Update State
            return 2;
        }

        //Is Operator Is Current User 
        public async Task<bool> IsOperatorIsCurrentUser(ulong userId, ulong requestId)
        {
            #region Get Organization By User Id

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Request 

            var request = await GetRequestById(requestId);
            if (request == null) return false;

            #endregion

            #region Validation Method 

            if (!request.OperationId.HasValue) return false;

            if (request.OperationId.Value == organization.OwnerId)
            {
                return true;
            }

            #endregion

            return false;
        }

        //Validator For Request While Compelete Steps By Id 
        public async Task<bool> RequestValidatorWhileCompeleteSteps(ulong requestId, ulong userId, ulong? patientId, RequestType requestType)
        {
            #region Get Request By Id 

            var request = await GetRequestById(requestId);

            #endregion

            //Request Is Not Exist
            if (request == null) return false;

            //If Request Is Not For This User
            if (request.UserId != userId) return false;

            //If Request Type Is Not Valid
            if (request.RequestType != requestType) return false;

            //If Request State Is Not Valid
            if (request.RequestState != RequestState.WaitingForCompleteInformationFromUser) return false;

            //If Request Patient Is Not Valid 
            if (patientId.HasValue && request.PatientId != patientId.Value) return false;

            return true;
        }

        public async Task UpdateRequest(Request request)
        {
            await _request.UpdateRequest(request);
        }

        public async Task AddPatientRequestDetail(PaitientRequestDetail patient)
        {
            await _request.AddPatientRequestDetail(patient);
        }

        public async Task<bool> IsExistRequestByRequestId(ulong requestId)
        {
            return await _request.IsExistRequestByRequestId(requestId);
        }

        public async Task<Request?> GetRequestById(ulong requestId)
        {
            return await _request.GetRequestById(requestId);
        }

        public async Task AddRequest(Request request)
        {
            await _request.AddRequest(request);
        }

        public async Task AddPatientIdToRequest(ulong requestId, ulong patientId)
        {
            #region Get Request 

            var request = await _request.GetRequestById(requestId);

            #endregion

            #region Update request

            request.PatientId = patientId;

            await _request.UpdateRequest(request);

            #endregion
        }

        public async Task UpdateRequestStateForTramsferringToTheBankingPortal(Request request)
        {
            request.RequestState = Domain.Enums.Request.RequestState.TramsferringToTheBankingPortal;

            await _request.UpdateRequest(request);
        }

        public async Task UpdateRequestStateForPayed(Request request)
        {
            request.RequestState = Domain.Enums.Request.RequestState.Paid;

            await _request.UpdateRequest(request);
        }

        public async Task UpdateRequestStateForNotPayed(Request request)
        {
            request.RequestState = Domain.Enums.Request.RequestState.unpaid;

            await _request.UpdateRequest(request);
        }

        //Get Request Transfering Price From Operator 
        public async Task<RequestTransferingPriceFromOperator?> GetRequestTransferingPriceFromOperator(ulong sellerId, ulong requestId)
        {
            #region Get Organization By User Id

            var organization = await _organizationService.GetOrganizationByUserId(sellerId);
            if (organization == null) return null;

            #endregion

            return await _request.GetRequestTransferingPriceFromOperator(organization.OwnerId, requestId);
        }

        //Add Request Transfering Price From Operator 
        public async Task<bool> AddRequestTransferingPriceFromOperator(RequestTransferingPriceFromOperator requestTransfering, ulong operatorId)
        {
            #region Get Organization By User Id

            var organization = await _organizationService.GetOrganizationByUserId(operatorId);
            if (organization == null) return false;

            #endregion

            #region Get Request 

            var request = await GetRequestById(requestTransfering.RequestId);
            if (request == null) return false;
            if (request.OperationId != organization.OwnerId) return false;

            #endregion

            #region Add Method 

            await _request.AddRequestTransferingPriceFromOperator(requestTransfering);

            #endregion

            return true;
        }

        //Get List Of Requests That Pass History Until 2days And With Waiting For Complete Information From Patient
        public async Task<List<Request>?> GetListOfRequestsThatPassHistoryUntil2daysAndWithWaitingForCompleteInformationFromPatient()
        {
            return await _request.GetListOfRequestsThatPassHistoryUntil2daysAndWithWaitingForCompleteInformationFromPatient();
        }

        //Soft Delete Range Of Requests
        public async Task SoftDeleteRangeOfRequests(List<Request> requests)
        {
            await _request.SoftDeleteRangeOfRequests(requests);
        }

        #endregion

        #region Patient Request Detail

        //Create Patient Request Detail Home Visit 
        public async Task<CreatePatientAddressResult> CreatePatientRequestDetailHomeVisit(PatienAddressForHomeVistiViewModel model)
        {
            #region Data Validation

            //If Patient Not Found
            if (!await _patientService.IsExistPatientById(model.PatientId)) return CreatePatientAddressResult.PatientNotFound;

            //If Request Not Found
            if (!await IsExistRequestByRequestId(model.RequestId)) return CreatePatientAddressResult.RquestNotFound;

            //If Country Not Found
            if (!await _locationService.IsExistAnyLocationByLocationid(model.CountryId)) return CreatePatientAddressResult.LocationNotFound;

            //If State Not Found
            if (!await _locationService.IsExistAnyLocationByLocationid(model.StateId)) return CreatePatientAddressResult.LocationNotFound;

            //If City Not Found
            if (!await _locationService.IsExistAnyLocationByLocationid(model.CountryId)) return CreatePatientAddressResult.LocationNotFound;

            #endregion

            #region Patient Request Address Detail 

            #region Fill Entity For Patient Request Detail

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

            await _request.AddPatientRequestDetail(request);

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

            await _request.AddPatientRequestDateTimeDetail(datetimeRequest);

            #endregion

            #region Update Reuqest State

            #region Get Request 

            var requestState = await _request.GetRequestById(model.RequestId);

            #endregion

            #region Update request

            requestState.RequestState = Domain.Enums.Request.RequestState.WaitingForCompleteInformationFromUser;

            await _request.UpdateRequest(requestState);

            #endregion

            #endregion

            return CreatePatientAddressResult.Success;
        }

        public async Task<CreatePatientAddressResult> CreatePatientRequestDetail(PatienAddressViewModel model)
        {
            #region Data Validation

            //If Patient Not Found
            if (!await _patientService.IsExistPatientById(model.PatientId)) return CreatePatientAddressResult.PatientNotFound;

            //If Request Not Found
            if (!await IsExistRequestByRequestId(model.RequestId)) return CreatePatientAddressResult.RquestNotFound;

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

            await _request.AddPatientRequestDetail(request);

            #endregion

            #region Update Reuqest State

            #region Get Request 

            var requestState = await _request.GetRequestById(model.RequestId);

            #endregion

            #region Update request

            requestState.RequestState = Domain.Enums.Request.RequestState.WaitingForCompleteInformationFromUser;

            await _request.UpdateRequest(requestState);

            #endregion

            #endregion

            #region Patient Request DateTime Detail


            if (model.SendDate != null)
            {

                var time = model.SendDate.ToMiladiDateTime();

                PatientRequestDateTimeDetail datetimeRequest = new PatientRequestDateTimeDetail()
                {
                    SendDate = time,
                    RequestId = model.RequestId,
                    CreateDate = DateTime.Now,
                    StartTime = model.StartTime,
                    EndTime = 0,
                };

                await _request.AddPatientRequestDateTimeDetail(datetimeRequest);

            }

            #endregion

            return CreatePatientAddressResult.Success;
        }

        //Get Request Detail By Request Id
        public async Task<PaitientRequestDetail?> GetPatientRequestDetailByRequestId(ulong requestId)
        {
            return await _request.GetPatientRequestDetailByRequestId(requestId);
        }

        #endregion

        #region Request Time Detail

        //Get Request DateTime Detail By Request Detai lId 
        public async Task<PatientRequestDateTimeDetail?> GetRequestDateTimeDetailByRequestDetailId(ulong requestId)
        {
            return await _request.GetRequestDateTimeDetailByRequestDetailId(requestId);
        }

        #endregion

        #endregion

        #region Admin

        #endregion
    }
}
