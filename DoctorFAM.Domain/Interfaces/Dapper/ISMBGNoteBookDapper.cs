using DoctorFAM.Domain.Entities.A1C_SMBG_NoteBook_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces.Dapper
{
    public interface ISMBGNoteBookDapper
    {
        #region Site Side 

        //Get User Insuline Usages Create Dates
        Task<List<DateTime>?> GetUserInsulineUsagesCreateDates(ulong userId);

        #endregion
    }
}
