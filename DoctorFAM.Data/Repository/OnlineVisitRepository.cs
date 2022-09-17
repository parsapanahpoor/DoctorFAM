using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class OnlineVisitRepository : IOnlineVisitRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public OnlineVisitRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side

        #endregion
    }
}
