
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Common;
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

        public RequestServicecs(IPatientService patientService, IRequestRepository request, ILocationService locationService)
        {
            _patientService = patientService;
            _request = request;
            _locationService = locationService;
        }

        #endregion

        #region Site Side

        #region Request 

        //Validator For Request While Compelete Steps By Id 
        public async Task<bool> RequestValidatorWhileCompeleteSteps(ulong requestId, ulong userId, ulong? patientId, RequestType requestType)
        {
            #region Get Request By Id 

            var request = await GetRequestById(requestId);

            #endregion

            //Request Is Not Exist
            if (request == null) return false;

            //If Request Is Not For This User
            if(request.UserId != userId) return false;

            //If Request Type Is Not Valid
            if (request.RequestType != requestType) return false;

            //If Request State Is Not Valid
            if (request.RequestState != RequestState.WaitingForCompleteInformationFromUser) return false;

            //If Request Patient Is Not Valid 
            if(patientId.HasValue && request.PatientId != patientId.Value) return false;

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

        public async Task AddPatientIdToRequest(ulong requestId , ulong patientId)
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

        #endregion

        #region Patient Request Detail

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

            requestState.RequestState = Domain.Enums.Request.RequestState.TramsferringToTheBankingPortal;

            await _request.UpdateRequest(requestState);

            #endregion

            #endregion

            return CreatePatientAddressResult.Success;
        }

        //Get Request Detail By Request Id
        public async Task<PaitientRequestDetail?> GetPatientRequestDetailByRequestId(ulong requestId)
        {
            return await _request.GetPatientRequestDetailByRequestId(requestId);
        }

        #endregion

        #endregion

        #region Admin

        #endregion
    }
}
