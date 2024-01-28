using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Requests;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IRequestRepository
    {
        #region Site Side

        #region Request 

        Task<bool> IsExistRequestByRequestId(ulong requestId);

        Task<Request?> GetRequestById(ulong requestId);

        Task AddRequest(Request request);

        Task UpdateRequest(Request request);

        //Get List Of Requests That Pass History Until 2days And With Waiting For Complete Information From Patient
        Task<List<Request>?> GetListOfRequestsThatPassHistoryUntil2daysAndWithWaitingForCompleteInformationFromPatient();

        //Soft Delete Range Of Requests
        Task SoftDeleteRangeOfRequests(List<Request> requests);

        #endregion

        #region Patient Request Detail

        //Add Patient Request Date Time Detail 
        Task AddPatientRequestDateTimeDetail(PatientRequestDateTimeDetail request);

        Task AddPatientRequestDetail(PaitientRequestDetail request);

        //Get Request Detail By Request Id
        Task<PaitientRequestDetail?> GetPatientRequestDetailByRequestId(ulong requestId);

        //Get Request Transfering Price From Operator 
        Task<RequestTransferingPriceFromOperator?> GetRequestTransferingPriceFromOperator(ulong sellerId, ulong requestId);

        //Add Request Transfering Price From Operator 
        Task AddRequestTransferingPriceFromOperator(RequestTransferingPriceFromOperator request);

        #endregion

        #region Request Time Detail

        //Get Request DateTime Detail By Request Detai lId 
        Task<PatientRequestDateTimeDetail?> GetRequestDateTimeDetailByRequestDetailId(ulong requestId);

        //Add Home Visit Request Detail
        Task AddHomeVisitRequestDetail(HomeVisitRequestDetail homeVisit);

        #endregion

        #endregion

        #region Admin

        #endregion
    }
}
