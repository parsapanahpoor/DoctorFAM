using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
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

        Task<bool> IsExistRequestByRequestId(ulong requestId);

        Task<Request?> GetRequestById(ulong requestId);

        Task AddRequest(Request request);

        Task AddPatientIdToRequest(ulong requestId, ulong patientId);

        #endregion

        #region Patient Request Detail

        Task<CreatePatientAddressResult> CreatePatientRequestDetail(PatienAddressViewModel model);

        #endregion

        #endregion

        #region Admin

        #endregion
    }
}
