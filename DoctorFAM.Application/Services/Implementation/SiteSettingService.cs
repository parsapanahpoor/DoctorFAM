using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class SiteSettingService : ISiteSettingService
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public SiteSettingService(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

    }
}
