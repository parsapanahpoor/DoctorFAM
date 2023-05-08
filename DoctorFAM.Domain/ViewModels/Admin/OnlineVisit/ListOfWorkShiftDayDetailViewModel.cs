using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.OnlineVisit
{
    public class ListOfWorkShiftDayDetailViewModel
    {
        #region properties

        public ulong WorkShiftId { get; set; }

        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public int DateBusinessKey { get; set; }

        #endregion
    }
}
