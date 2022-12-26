using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class FollowRepository : IFollowRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public FollowRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion
    }
}
