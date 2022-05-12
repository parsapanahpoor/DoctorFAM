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
    public class DeathCertificateRepository : IDeathCertificateRepository
    {
        #region Ctor

        public DoctorFAMDbContext _context;

        public DeathCertificateRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side

        #endregion
    }
}
