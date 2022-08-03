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

        //Patient Validator While Compelete Data From User In Services Steps 
        public async Task<bool> PatientValidatorWhileCompeleteDataFromUser(ulong patientId , ulong userId , ulong requestId)
        {
            #region Get Patient By Patient Id 

            var patient = await _patient.GetPatientById(patientId);

            #endregion

            //If Patient Is Not Exist 
            if (patient == null) return false;

            //If Patient User Id Is Not Valid
            if(patient.UserId != userId) return false;

            //If patient Request Is Not Valid 
            if(patient.RequestId != requestId) return false;

            return true;
        }

        public async Task AddPatient(Patient patient)
        {
            await _patient.AddPatient(patient);
        }

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
