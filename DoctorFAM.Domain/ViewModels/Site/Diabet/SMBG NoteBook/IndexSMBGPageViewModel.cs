using DoctorFAM.Domain.Entities.A1C;
using DoctorFAM.Domain.Entities.A1C_SMBG_NoteBook_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Diabet.SMBG_NoteBook
{
    public class IndexSMBGPageViewModel 
    {
        #region properties

        public List<LogForUsersA1C>  logForUsersA1c{ get; set; }

        public List<ShowUserInsulinUsageHistory> ShowUserInsulinUsageHistory { get; set; }

        #endregion
    }

    public class ShowUserInsulinUsageHistory
    {
        public DateTime CreateDate { get; set; }

        public List<LogForUsageInsulin> LogForUsageInsulin { get; set; }
    }
}
