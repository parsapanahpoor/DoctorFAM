using DoctorFAM.Domain.ViewModels.Site.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IOnlineVisitService
    {
        #region Site Side 

        //Create Online Visit Request
        Task<ulong?> CreateOnlineVisitRequest(ulong userId);

        //Validation For Create Patient 
        Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model);

        Task<ulong> CreatePatientDetail(PatientViewModel patient);

        #endregion
    }
}
