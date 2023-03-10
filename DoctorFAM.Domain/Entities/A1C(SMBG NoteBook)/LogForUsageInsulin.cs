using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.SMBG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.A1C_SMBG_NoteBook_
{
    public class LogForUsageInsulin : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public ulong InsulinId { get; set; }

        public int CountOfInsulinUsage { get; set; }

        public int BloodSugar { get; set; }

        public TimeOfUsageInsulinState TimeOfUsageInsulinState { get; set; }

        public TimeOfUsageInsulinType? TimeOfUsageInsulinType { get; set; }

        #endregion
    }
}
