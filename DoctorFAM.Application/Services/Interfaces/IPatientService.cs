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

        Task<bool> IsExistPatientById(ulong patientId);

        Task<Patient?> GetPatientById(ulong patientId);

        Task AddPatient(Patient patient);

        #endregion
    }
}
