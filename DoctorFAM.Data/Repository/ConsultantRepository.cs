using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class ConsultantRepository :IConsultantRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public ConsultantRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Consultant Panel Side 
        

       
        #endregion
    }
}
