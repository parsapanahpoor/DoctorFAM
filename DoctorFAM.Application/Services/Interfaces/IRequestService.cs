using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.ViewModels.Site.Common;
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

        #endregion

        #region Patient Request Detail

        Task<CreatePatientAddressResult> CreatePatientRequestDetail(PatienAddressViewModel model);

        Task AddPatientRequestDetail(PaitientRequestDetail patient);

        //Get Request Detail By Request Id
        Task<PaitientRequestDetail?> GetPatientRequestDetailByRequestId(ulong requestId);

        #endregion

        #endregion

        #region Admin

        #endregion
    }
}
