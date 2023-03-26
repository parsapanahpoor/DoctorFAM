using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.DurgAlert;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.BackgroundTasks.DrugAlert;
using Microsoft.EntityFrameworkCore;

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
            return await _context.DrugAlerts.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == drugAlertId);
        }

        //create Drug Alert Detail 
        public async Task CreateDrugAlertDetail(DrugAlertDetail alert)
        {
            await _context.DrugAlertDetails.AddAsync(alert);
        }

        //Update Drug Alert Whitout Save changes 
        public void UpdateDrugAlertWhitoutSavechanges(DrugAlert drug)
        {
            _context.DrugAlerts.Update(drug);
        }

        //Save Changes
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        //Get List Of User Drug Alerts 
        public async Task<List<DrugAlert>?> GetListOfUserDrugAlerts(ulong userId)
        {
            return await _context.DrugAlerts.Where(p => !p.IsDelete && p.UserId == userId)
                                                .OrderByDescending(p => p.CreateDate).ToListAsync();
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

        #endregion\

        #region Back Ground Task

        //Get List Of Weekly Usage Drugs
        public async Task<List<ListOfWeeklyDrugAlertViewModel>> FillListOfWeeklyDrugAlertViewModel()
        {
            return await _context.DrugAlertDetails.Include(p => p.DrugAlert).Where(p => !p.IsDelete && p.DrugAlert.DrugAlertDurationType == Domain.Enums.DrugAlert.DrugAlertDurationType.Weekly
                                                   && p.DateTime.HasValue && p.DateTime.Value.Year == DateTime.Now.Year&& p.DateTime.Value.DayOfYear == DateTime.Now.DayOfYear)
                                                   .Select(p => new ListOfWeeklyDrugAlertViewModel()
                                                   {
                                                       DrugAlertDetail = p,
                                                       DrugAlert = p.DrugAlert,
                                                       Mobile = _context.Users.Where(s => !s.IsDelete && s.Id == p.DrugAlert.UserId).Select(p=> p.Mobile).FirstOrDefault(),
                                                   }).ToListAsync();
                                                  

        }

        //Get List Of Monthly Usage Drugs
        public async Task<List<ListOfMonthlyDrugAlertViewModel>> FillListOfMonthlyDrugAlertViewModel()
        {
            return await _context.DrugAlertDetails.Include(p => p.DrugAlert).Where(p => !p.IsDelete && p.DrugAlert.DrugAlertDurationType == Domain.Enums.DrugAlert.DrugAlertDurationType.Monthly
                                                   && p.DateTime.HasValue && p.DateTime.Value.Year == DateTime.Now.Year && p.DateTime.Value.DayOfYear == DateTime.Now.DayOfYear)
                                                   .Select(p => new ListOfMonthlyDrugAlertViewModel()
                                                   {
                                                       DrugAlertDetail = p,
                                                       DrugAlert = p.DrugAlert,
                                                       Mobile = _context.Users.Where(s => !s.IsDelete && s.Id == p.DrugAlert.UserId).Select(p => p.Mobile).FirstOrDefault(),
                                                   }).ToListAsync();


        }

        //Get List Of Yearly Usage Drugs
        public async Task<List<ListOfYearlyDrugAlertViewModel>> FillListOfYearlyDrugAlertViewModel()
        {
            return await _context.DrugAlertDetails.Include(p => p.DrugAlert).Where(p => !p.IsDelete && p.DrugAlert.DrugAlertDurationType == Domain.Enums.DrugAlert.DrugAlertDurationType.Yearly
                                                   && p.DateTime.HasValue && p.DateTime.Value.Year == DateTime.Now.Year && p.DateTime.Value.DayOfYear == DateTime.Now.DayOfYear)
                                                   .Select(p => new ListOfYearlyDrugAlertViewModel()
                                                   {
                                                       DrugAlertDetail = p,
                                                       DrugAlert = p.DrugAlert,
                                                       Mobile = _context.Users.Where(s => !s.IsDelete && s.Id == p.DrugAlert.UserId).Select(p => p.Mobile).FirstOrDefault(),
                                                   }).ToListAsync();


        }

        //Get List Of Daily Usage Drugs
        public async Task<List<ListOfDailyDrugAlertViewModel>> FillListOfDailyDrugAlertViewModel()
        {
            return await _context.DrugAlerts.Where(p => !p.IsDelete && p.DrugAlertDurationType == Domain.Enums.DrugAlert.DrugAlertDurationType.Daily)
                                                   .Select(p => new ListOfDailyDrugAlertViewModel()
                                                   {
                                                       DrugAlert = p,
                                                       Mobile = _context.Users.Where(s => !s.IsDelete && s.Id == p.UserId).Select(p => p.Mobile).FirstOrDefault(),
                                                   }).ToListAsync();


        }

        //Update Drug Alert Detail Whitout Save Changes
        public void UpdateDrugAlertDetailWhitoutSaveChanges(DrugAlertDetail drugAlert)
        {
            _context.DrugAlertDetails.Update(drugAlert);
        }

        //Save Changes 
        public async Task Savechanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
