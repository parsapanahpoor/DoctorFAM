using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.OnlineVisit
{
    public sealed class  OnlineVisitUserRequestDetail : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public int DayDatebusinessKey { get; set; }

        public ulong WorkShiftDateTimeId { get; set; }

        public ulong WorkShiftDateId { get; set; }

        public bool IsFinaly { get; set; }

        public bool IsTakenFromDoctor { get; set; }

        #endregion
    }
}
