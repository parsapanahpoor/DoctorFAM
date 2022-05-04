using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class PatientService : IPatientService
    {
        #region Ctor

        public IPatientRepository _patient;

        public PatientService(IPatientRepository patient)
        {
            _patient = patient;
        }

        #endregion

        #region Site Side

        public async Task<bool> IsExistPatientById(ulong patientId)
        {
            return await _patient.IsExistPatientById(patientId);
        }

        public async Task<Patient?> GetPatientById(ulong patientId)
        {
            return await _patient.GetPatientById(patientId);
        }

        #endregion
    }
}
