using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class PeriodicSelftEvaluationRepository : IPeriodicSelftEvaluationRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public PeriodicSelftEvaluationRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Admin Side 

        #endregion
    }
}
