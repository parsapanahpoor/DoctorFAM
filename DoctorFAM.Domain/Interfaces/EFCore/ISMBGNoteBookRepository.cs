using DoctorFAM.Domain.Entities.A1C;
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

        //Get Logs Of User A1C By User Id
        Task<List<LogForUsersA1C>> GetLogsOfUserA1CByUserId(ulong userId);

        #endregion
    }
}
