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

        //Get List Of User Drug Alerts 
        public async Task<List<DrugAlert>?> GetListOfUserDrugAlerts(ulong userId)
        {
            return await _context.DrugAlerts.Where(p=> !p.IsDelete && p.UserId == userId)
                                                .OrderByDescending(p=> p.CreateDate).ToListAsync();
        }

        //Get Drug Alerts Detail By Drug Alert Id 
        public async Task<List<DrugAlertDetail>?> GetDrugAlertsDetailByDrugAlertId(ulong drugAlertId)
        {
            return await _context.DrugAlertDetails.Where(p => !p.IsDelete && p.DrugAlertId == drugAlertId)
                                                                                                    .ToListAsync();
        }

        //Update Drug Alert Without SaveChanges
        public void UpdateDrugAlertWithoutSaveChanges(DrugAlert alert)
        {
            _context.DrugAlerts.Update(alert);
        }

        //Update Drug Alert Detail Without Savechanges
        public void UpdateDrugAlertDetailWithoutSavechanges(DrugAlertDetail alertDetail)
        {
            _context.DrugAlertDetails.Update(alertDetail);
        }

        #endregion
    }
}
