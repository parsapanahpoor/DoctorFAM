using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.A1C;
using DoctorFAM.Domain.Entities.A1C_SMBG_NoteBook_;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Site.Diabet.SMBG_NoteBook;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class SMBGNoteBookRepository : ISMBGNoteBookRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public SMBGNoteBookRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side

        //Get Logs Of User A1C By User Id
        public async Task<List<LogForUsersA1C>> GetLogsOfUserA1CByUserId(ulong userId)
        {
            return await _context.logForUsersA1Cs.Where(p => !p.IsDelete && p.UserId == userId)
                                    .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        //Get Lastest User A1C By User Id
        public async Task<LogForUsersA1C?> GetLastestUserA1CByUserId(ulong userId)
        {
            return await _context.logForUsersA1Cs.Where(p => !p.IsDelete && p.UserId == userId)
                                    .OrderByDescending(p => p.CreateDate).Take(1).FirstOrDefaultAsync();
        }

        //Get User Long Effect Insulin Usage Today
        public async Task<LogForLongEffectInsulinUsageSiteSideViewModel?> GetUserLongEffectInsulinUsageToday(ulong userId)
        {
            return await _context.LogForLongEffectInsulinUsages.Where(p => !p.IsDelete && p.UserId == userId && p.CreateDate.Year == DateTime.Now.Year
                                                                      && p.CreateDate.Month == DateTime.Now.Month
                                                                      && p.CreateDate.Day == DateTime.Now.Day)
                                                                                .Select(p => new LogForLongEffectInsulinUsageSiteSideViewModel()
                                                                                {
                                                                                    CountOfUsage = p.CountOfUsage,
                                                                                    CreateDateTime = p.CreateDate,
                                                                                    InsulinName = _context.Insulins.Where(s => !s.IsDelete && s.Id == p.InsulinId).Select(s => s.InsulinName).FirstOrDefault(),
                                                                                }).FirstOrDefaultAsync();
        }

        //Create Log For Users A1C
        public async Task CreateLogForUsersA1C(LogForUsersA1C model)
        {
            await _context.logForUsersA1Cs.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        //Add Log For Long Effect Insulin Usage To The Data Base
        public async Task AddLogForLongEffectInsulinUsageToTheDataBase(LogForLongEffectInsulinUsage model)
        {
            await _context.LogForLongEffectInsulinUsages.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        //Check That Exist Any Long Effect Insulin Usage Of Today Date Time
        public async Task<bool> CheckThatExistAnyLongEffectInsulinUsageOfTodayDateTime(ulong userId, DateTime today)
        {
            return await _context.LogForLongEffectInsulinUsages.AnyAsync(p => !p.IsDelete && p.UserId == userId
                                                                            && p.CreateDate.Year == today.Year
                                                                            && p.CreateDate.Month == today.Month
                                                                            && p.CreateDate.Day == today.Day);
        }

        //Fill List Of User A1C Site Side View Model 
        public async Task<List<ListOfUserA1CSiteSideViewModel>?> FillListOfUserA1CSiteSideViewModel(ulong userId)
        {
            return await _context.logForUsersA1Cs.Where(p => !p.IsDelete && p.UserId == userId).OrderByDescending(p => p.CreateDate)
                                                    .Select(p => new ListOfUserA1CSiteSideViewModel()
                                                    {
                                                        DateTime = p.CreateDate,
                                                        Result = p.A1C
                                                    }).ToListAsync();
        }

        //Add Insulin Usage To The Data Base
        public async Task AddInsulinUsageToTheDataBase(LogForUsageInsulin model)
        {
            await _context.LogForUsageInsulin.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        //Get User Insuline Usages Create Dates
        public List<DateTime>? GetUserInsulineUsagesCreateDates(ulong userId)
        {
            return _context.LogForUsageInsulin.Where(p => !p.IsDelete && p.UserId == userId)
                         .DistinctBy(p => p.CreateDate)
                         .Select(p => p.CreateDate)
                         .ToList();
        }

        //Get List Of User Insulin Usage By Create Date 
        public async Task<List<LogForFillUsageInsulinSiteSideViewModel>> GetListOfUserInsulinUsageByCreateDate(DateTime date, ulong userId)
        {
            return await _context.LogForUsageInsulin.Where(p => !p.IsDelete && p.UserId == userId
                                                           && p.CreateDate.Year == date.Year
                                                           && p.CreateDate.Month == date.Month
                                                           && p.CreateDate.Day == date.Day)
                                                           .OrderByDescending(p => p.CreateDate)
                                                           .Select(p => new LogForFillUsageInsulinSiteSideViewModel()
                                                           {
                                                               Insulin = _context.Insulins.FirstOrDefault(i => !i.IsDelete && i.Id == p.InsulinId),
                                                               BloodSugar = p.BloodSugar,
                                                               CountOfInsulinUsage = p.CountOfInsulinUsage,
                                                               TimeOfUsageInsulinState = p.TimeOfUsageInsulinState,
                                                               TimeOfUsageInsulinType = p.TimeOfUsageInsulinType,
                                                               UserId = p.UserId,
                                                               CreateDate = p.CreateDate,
                                                           })
                                                           .ToListAsync();
        }

        #endregion
    }
}
