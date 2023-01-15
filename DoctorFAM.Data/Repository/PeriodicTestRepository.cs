using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.PeriodicTest;
using DoctorFAM.Domain.Interfaces.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class PeriodicTestRepository : IPeriodicTestRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public PeriodicTestRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side 

        //Create Periodic Test Admin Side
        public async Task CreatePeriodicTestAdminSide(PeriodicTest test)
        {
            await _context.PeriodicTests.AddAsync(test);
            await _context.SaveChangesAsync();
        }

        //Get Periodic Test By Id 
        public async Task<PeriodicTest?> GetPeriodicTestById(ulong id)
        {
            return await _context.PeriodicTests.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == id);
        }

        //Update Periodic Test Admin Side 
        public async Task UpdatePeriodicTestAdminSide(PeriodicTest test)
        {
            _context.PeriodicTests.Update(test);
            await _context.SaveChangesAsync();
        }

        //Get List Of Periodic Test 
        public async Task<List<PeriodicTest>?> GetListOfPeriodicTest()
        {
            return await _context.PeriodicTests.Where(p => !p.IsDelete).ToListAsync();
        }

        #endregion
    }
}
