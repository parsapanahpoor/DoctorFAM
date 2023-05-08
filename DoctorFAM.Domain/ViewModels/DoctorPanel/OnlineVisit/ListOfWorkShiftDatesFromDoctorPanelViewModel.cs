using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit
{
    public class ListOfWorkShiftDatesFromDoctorPanelViewModel
    {
        #region properties

        public ulong OnlineVisitDoctorsReservationDateId { get; set; }

        public DateTime OnlineVisitShiftDate { get; set; }

        public int BusinessKey { get; set; }

        public int CountOfWorkShifts { get; set; }

        public int CountOfAllShiftTime { get; set; }

        #endregion
    }
}
