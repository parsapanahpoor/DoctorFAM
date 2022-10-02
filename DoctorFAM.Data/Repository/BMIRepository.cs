using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.BMI;
using DoctorFAM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class BMIRepository : IBMIRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public BMIRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side 

        //Add BMI To Data Base 
        public async Task CreateBMI(BMI bmi)
        {
            await _context.BMI.AddAsync(bmi);
            await _context.SaveChangesAsync();
        }

        //Add GFR To Data Base 
        public async Task CreateGFR(GFR gfr)
        {
            await _context.GFR.AddAsync(gfr);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region User Panel 

        //Get List Of User BMI History
        public async Task<List<BMI>?> GetUserBMIHistory(ulong userId)
        {
            return await _context.BMI.Where(p => !p.IsDelete && p.UserId == userId)
                        .OrderByDescending(p=> p.CreateDate).ToListAsync(); 
        }

        //Get List Of User GFR History
        public async Task<List<GFR>?> GetUserGFRHistory(ulong userId)
        {
            return await _context.GFR.Where(p => !p.IsDelete && p.UserId == userId)
                        .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        #endregion
    }
}
