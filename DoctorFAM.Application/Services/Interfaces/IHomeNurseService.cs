using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeNurse;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public  interface IHomeNurseService
    {
        #region Site Side

        #endregion

        #region Admin Side

        Task<FilterHomeNurseViewModel> FilterHomeNurse(FilterHomeNurseViewModel filter);

        Task<HomeNurseRequestDetailViewModel> ShowHomeNurseDetail(ulong requestId);

        #endregion

        Task<ulong?> CreateHomeNurseRequest(ulong userId);

        Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model);

        Task<ulong> CreatePatientDetail(PatientViewModel patient);
    }
}
