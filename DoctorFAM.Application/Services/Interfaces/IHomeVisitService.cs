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

        Task<ulong?> CreateHomeVisitRequest(ulong userId);
        Task<bool> IsExistHomeVisitRequestById(ulong requestId);
        Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model);
        Task<ulong> CreatePatientDetail(PatientViewModel patient);        
    }
}
