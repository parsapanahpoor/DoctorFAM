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

        //Add Insulin Usage To The Data Base
        Task AddInsulinUsageToTheDataBase(LogForUsageInsulin model);

        //Get Logs Of User A1C By User Id
        Task<List<LogForUsersA1C>> GetLogsOfUserA1CByUserId(ulong userId);

        //Get User Insulin Usage Logs
        List<DateTime>? GetUserInsulineUsagesCreateDates(ulong userId);

        //Get List Of User Insulin Usage By Create Date 
        Task<List<LogForFillUsageInsulinSiteSideViewModel>> GetListOfUserInsulinUsageByCreateDate(DateTime date, ulong userId);

        #endregion
    }
}
