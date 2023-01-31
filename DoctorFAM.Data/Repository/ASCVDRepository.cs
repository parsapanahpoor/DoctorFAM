using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.ASCVD;
using DoctorFAM.Domain.Interfaces.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class ASCVDRepository : IASCVDRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public ASCVDRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side 

        //Add Ascvd To The Data Base 
        public async Task AddAscvdToTheDataBase(ASCVD ascvd)
        {
            await _context.ASCVD.AddAsync(ascvd);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
