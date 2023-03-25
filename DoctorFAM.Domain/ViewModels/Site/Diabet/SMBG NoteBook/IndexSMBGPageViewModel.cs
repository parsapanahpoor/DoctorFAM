using DoctorFAM.Domain.Entities.A1C;
using DoctorFAM.Domain.Entities.A1C_SMBG_NoteBook_;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Drugs;
using DoctorFAM.Domain.Enums.SMBG;
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

        public LogForUsersA1C?  logForUsersA1c{ get; set; }

        public LogForLongEffectInsulinUsageSiteSideViewModel?  LogForLongEffectInsulinUsage{ get; set; }

        public List<ShowUserInsulinUsageHistory> ShowUserInsulinUsageHistory { get; set; }

        #endregion
    }

    public class ShowUserInsulinUsageHistory
    {
        public DateTime CreateDate { get; set; }

        public List<LogForFillUsageInsulinSiteSideViewModel> LogForUsageInsulin { get; set; }
    }

    public class LogForFillUsageInsulinSiteSideViewModel 
    {
        #region properties

        public ulong UserId { get; set; }

        public Insulin? Insulin { get; set; }

        public int CountOfInsulinUsage { get; set; }

        public int BloodSugar { get; set; }

        public TimeOfUsageInsulinState TimeOfUsageInsulinState { get; set; }

        public TimeOfUsageInsulinType? TimeOfUsageInsulinType { get; set; }

        public DateTime CreateDate { get; set; }

        #endregion
    }

    public class LogForLongEffectInsulinUsageSiteSideViewModel
    {
        #region properties

        public string InsulinName{ get; set; }

        public DateTime CreateDateTime { get; set; }

        public int CountOfUsage { get; set; }

        #endregion
    }
}
