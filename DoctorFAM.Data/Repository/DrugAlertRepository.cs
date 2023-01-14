using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.DurgAlert;
using DoctorFAM.Domain.Interfaces.EFCore;
using Microsoft.EntityFrameworkCore;
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

        //Get Drug Alert Detail By ID
        public async Task<DrugAlert?> GetDrugAlertById(ulong drugAlertId)
        {
            return await _context.DrugAlerts.FirstOrDefaultAsync(p=> !p.IsDelete && p.Id == drugAlertId);
        }

        //create Drug Alert Detail 
        public async Task CreateDrugAlertDetail(DrugAlertDetail alert)
        {
            await _context.DrugAlertDetails.AddAsync(alert);
        }

        //Save Changes
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
