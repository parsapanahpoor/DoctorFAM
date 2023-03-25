using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.A1C_SMBG_NoteBook_
{
    public class LogForLongEffectInsulinUsage : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public ulong InsulinId { get; set; }

        public int CountOfUsage { get; set; }

        #endregion

        #region relations



        #endregion
    }
}
