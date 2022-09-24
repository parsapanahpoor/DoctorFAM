using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion

        #region Admin

        #endregion
    }
}
