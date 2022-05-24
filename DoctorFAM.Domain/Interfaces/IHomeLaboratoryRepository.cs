using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IHomeLaboratoryRepository
    {
        #region Site Side

        Task<List<HomeLaboratoryRequestDetail>> GetHomeLaboratoryRequestDetailByRequestId(ulong requestId);

        Task AddLaboratoryRequest(HomeLaboratoryRequestDetail laboratory);

        Task DeleteRequestedLaboratory(HomeLaboratoryRequestDetail laboratory);

        Task<HomeLaboratoryRequestDetail> GetRequestedLaboratoryById(ulong requesedLaboratoryId);

        Task AddPatientRequestDateTimeDetail(PatientRequestDateTimeDetail request);

        #endregion
    }
}
