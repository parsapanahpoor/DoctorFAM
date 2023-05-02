using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.OnlineVisit
{
    public class OnlineVisitWorkShiftDetail : BaseEntity
    {
        #region properties

        public ulong OnlineVisitWorkShiftId { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public int BusinessKey { get; set; }

        #endregion

        #region relation

        #endregion
    }
}
