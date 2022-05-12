using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class HomeNurseRepository : IHomeNurseRepository
    {
        #region Ctor

        public DoctorFAMDbContext _context;

        public HomeNurseRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side

        #endregion
    }
}
