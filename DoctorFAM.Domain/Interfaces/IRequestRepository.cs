using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
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

        #endregion

        #region Patient Request Detail

        Task AddPatientRequestDetail(PaitientRequestDetail request);

        #endregion

        #endregion

        #region Admin

        #endregion
    }
}
