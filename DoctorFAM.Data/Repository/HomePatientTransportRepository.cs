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
    public class HomePatientTransportRepository : IHomePatientTransportRepository
    {
        #region Ctor

        public DoctorFAMDbContext _context;

        public HomePatientTransportRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side

        #endregion
    }
}
