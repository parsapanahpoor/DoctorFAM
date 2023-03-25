using DoctorFAM.Domain.Entities.A1C;
using DoctorFAM.Domain.Entities.A1C_SMBG_NoteBook_;
using DoctorFAM.Domain.ViewModels.Site.Diabet.SMBG_NoteBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces.EFCore
{
    public interface ISMBGNoteBookRepository
    {
        #region Site Side

        //Create Log For Users A1C
        Task CreateLogForUsersA1C(LogForUsersA1C model);

        //Add Log For Long Effect Insulin Usage To The Data Base
        Task AddLogForLongEffectInsulinUsageToTheDataBase(LogForLongEffectInsulinUsage model);

        //Check That Exist Any Long Effect Insulin Usage Of Today Date Time
        Task<bool> CheckThatExistAnyLongEffectInsulinUsageOfTodayDateTime(ulong userId, DateTime today);

        //Fill List Of User A1C Site Side View Model 
        Task<List<ListOfUserA1CSiteSideViewModel>?> FillListOfUserA1CSiteSideViewModel(ulong userId);

        //Add Insulin Usage To The Data Base
        Task AddInsulinUsageToTheDataBase(LogForUsageInsulin model);

        //Get Logs Of User A1C By User Id
        Task<List<LogForUsersA1C>> GetLogsOfUserA1CByUserId(ulong userId);

        //Get Lastest User A1C By User Id
        Task<LogForUsersA1C?> GetLastestUserA1CByUserId(ulong userId);

        //Get User Long Effect Insulin Usage Today
        Task<LogForLongEffectInsulinUsageSiteSideViewModel?> GetUserLongEffectInsulinUsageToday(ulong userId);

        //Get User Insulin Usage Logs
        List<DateTime>? GetUserInsulineUsagesCreateDates(ulong userId);

        //Get List Of User Insulin Usage By Create Date 
        Task<List<LogForFillUsageInsulinSiteSideViewModel>> GetListOfUserInsulinUsageByCreateDate(DateTime date, ulong userId);

        #endregion
    }
}
