using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class PatientRepository : IPatientRepository
    {
        #region Ctor

        public DoctorFAMDbContext _context;

        public PatientRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side

        public async Task<bool> IsExistPatientById(ulong patientId)
        {
            return await _context.Patients.AnyAsync(p => p.Id == patientId && !p.IsDelete);
        }

        public async Task<Patient?> GetPatientById(ulong patientId)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.Id == patientId && !p.IsDelete);
        }

        public async Task AddPatient(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
