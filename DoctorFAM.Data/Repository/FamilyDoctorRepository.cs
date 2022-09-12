using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.FamilyDoctor;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class FamilyDoctorRepository : IFamilyDoctorRepository
    {
        #region Ctor 

        private readonly DoctorFAMDbContext _context;

        public FamilyDoctorRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region User Panel

        //Is Exist Any Family Doctor For Patient
        public async Task<bool> IsExistAnyFamilyDoctorForPatient(ulong userId)
        {
            return await _context.UserSelectedFamilyDoctor.AnyAsync(p => !p.IsDelete && p.PatientId == userId && p.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Accepted);
        }

        //Get User Selected Family Doctor 
        public async Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByUserId(ulong userId)
        {
            return await _context.UserSelectedFamilyDoctor.FirstOrDefaultAsync(p => !p.IsDelete && p.PatientId == userId);
        }

        //Add Family Doctor For This Patient 
        public async Task AddFamilyDoctorForThisPatient(UserSelectedFamilyDoctor familyDoctor)
        {
            await _context.UserSelectedFamilyDoctor.AddAsync(familyDoctor);
            await _context.SaveChangesAsync();
        }

        //Remove Family Doctor For This Patient 
        public async Task RemoveFamilyDoctorForThisPatient(UserSelectedFamilyDoctor familyDoctor)
        {
            familyDoctor.IsDelete = true;

            _context.UserSelectedFamilyDoctor.Update(familyDoctor);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
