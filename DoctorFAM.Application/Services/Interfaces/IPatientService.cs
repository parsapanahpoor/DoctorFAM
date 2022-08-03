using DoctorFAM.Domain.Entities.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IPatientService
    {
        #region Site Side

        //Patient Validator While Compelete Data From User In Services Steps 
        Task<bool> PatientValidatorWhileCompeleteDataFromUser(ulong patientId, ulong userId, ulong requestId);

        Task<bool> IsExistPatientById(ulong patientId);

        Task<Patient?> GetPatientById(ulong patientId);

        Task AddPatient(Patient patient);

        #endregion
    }
}
