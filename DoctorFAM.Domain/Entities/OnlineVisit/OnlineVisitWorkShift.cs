using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.OnlineVisit
{
    public sealed class OnlineVisitWorkShift : BaseEntity
    {
        #region propertiers

        public int StartShiftTime { get; set; }

        public int EndShiftTime { get; set;}

        public int PeriodOfShiftTime { get; set; }

        #endregion

        #region relations

        #endregion
    }
}
