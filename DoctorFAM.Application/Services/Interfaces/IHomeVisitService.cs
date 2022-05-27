using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeVisit;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IHomeVisitService
    {
        #region Site Side

        #endregion

        #region Admin Side

        Task<FilterHomeVisistViewModel> FilterHomeVisit(FilterHomeVisistViewModel filter);

        Task<HomeVisitRequestDetailViewModel> ShowHomeVisitDetail(ulong requestId);

        Task<Patient?> GetPatientByRequestId(ulong requestId);

        Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

        #endregion

        Task<ulong?> CreateHomeVisitRequest(ulong userId);

        Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model);

        Task<ulong> CreatePatientDetail(PatientViewModel patient);        
    }
}
