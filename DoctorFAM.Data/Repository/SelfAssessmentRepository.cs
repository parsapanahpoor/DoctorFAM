using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class SelfAssessmentRepository : ISelfAssessmentRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public SelfAssessmentRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Diabet Self Assessment 

        #region Site Side 



        #endregion

        #region User Panel 



        #endregion

        #endregion
    }
}
