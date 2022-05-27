using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeLabratory;
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

        #region Admin Side

        Task<FilterHomeLabratoryViewModel> FilterHomeLabratory(FilterHomeLabratoryViewModel filter);

        Task<Request?> GetRquestForHomeLabratoryById(ulong requestId);

        Task<Patient?> GetPatientByRequestId(ulong requestId);

        Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

        Task<PatientRequestDateTimeDetail?> GetRequestDateTimeDetailByRequestDetailId(ulong requestDetailId);

        Task<List<RequestedLabratoryAdminSideViewModel>?> GetRequestLabratoryByRequestId(ulong requestId);

        #endregion

    }
}
