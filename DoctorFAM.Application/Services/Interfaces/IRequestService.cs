using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.ViewModels.Site.Common;
using DoctorFAM.Domain.ViewModels.Site.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IRequestService
    {
        #region Site Side

        #region Request 

        //Invoice Finalization And See Invoice Detail
        Task<int> FinalizationHomePharmacyInvoiceFromPharmacy(ulong requestId, ulong userId);

        //Is Operator Is Current User 
        Task<bool> IsOperatorIsCurrentUser(ulong userId, ulong requestId);

        //Validator For Request While Compelete Steps By Id 
        Task<bool> RequestValidatorWhileCompeleteSteps(ulong requestId, ulong userId, ulong? patientId, RequestType requestType);

        Task<bool> IsExistRequestByRequestId(ulong requestId);

        Task<Request?> GetRequestById(ulong requestId);

        Task AddRequest(Request request);

        Task AddPatientIdToRequest(ulong requestId, ulong patientId);

        Task UpdateRequest(Request request);

        Task UpdateRequestStateForTramsferringToTheBankingPortal(Request request);

        Task UpdateRequestStateForPayed(Request request);

        Task UpdateRequestStateForNotPayed(Request request);

        //Get Request Transfering Price From Operator 
        Task<RequestTransferingPriceFromOperator?> GetRequestTransferingPriceFromOperator(ulong sellerId, ulong requestId);

        //Add Request Transfering Price From Operator 
        Task<bool> AddRequestTransferingPriceFromOperator(RequestTransferingPriceFromOperator requestTransfering, ulong operatorId);

        //Get List Of Requests That Pass History Until 2days And With Waiting For Complete Information From Patient
        Task<List<Request>?> GetListOfRequestsThatPassHistoryUntil2daysAndWithWaitingForCompleteInformationFromPatient();

        //Soft Delete Range Of Requests
        Task SoftDeleteRangeOfRequests(List<Request> requests);

        #endregion

        #region Patient Request Detail

        //Create Patient Request Detail Home Visit 
        Task<CreatePatientAddressResult> CreatePatientRequestDetailHomeVisit(PatienAddressForHomeVistiViewModel model);

        Task<CreatePatientAddressResult> CreatePatientRequestDetail(PatienAddressViewModel model);

        Task AddPatientRequestDetail(PaitientRequestDetail patient);

        //Get Request Detail By Request Id
        Task<PaitientRequestDetail?> GetPatientRequestDetailByRequestId(ulong requestId);

        #endregion

        #region Request Time Detail

        //Get Request DateTime Detail By Request Detai lId 
        Task<PatientRequestDateTimeDetail?> GetRequestDateTimeDetailByRequestDetailId(ulong requestId);

        #endregion

        #endregion

        #region Admin

        #endregion
    }
}
