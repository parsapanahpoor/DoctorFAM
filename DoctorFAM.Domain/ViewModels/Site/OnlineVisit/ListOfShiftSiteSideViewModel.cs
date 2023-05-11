using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.OnlineVisit
{
    public class ListOfShiftSiteSideViewModel
    {
        #region properties

        public int businessKey { get; set; }

        public string? ShiftTime { get; set; }

        public ulong WorkShiftDateTimeId { get; set; }

        public ulong WorkShiftDateId { get; set; }

        #endregion
    }
}
