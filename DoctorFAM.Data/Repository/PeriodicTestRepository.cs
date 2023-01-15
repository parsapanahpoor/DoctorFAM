using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Interfaces.EFCore;
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



        #endregion
    }
}
