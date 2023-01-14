using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.DurgAlert;
using DoctorFAM.Domain.Interfaces.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class DrugAlertRepository : IDrugAlertRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public DrugAlertRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side 

        //Create Drug Aler
        public async Task CreateDrugAler(DrugAlert alert)
        {
            await _context.DrugAlerts.AddAsync(alert);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
