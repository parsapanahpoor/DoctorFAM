using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit
{
    public class WorkShiftDateDetailDoctorPanelViewModel
    {
        #region properties

        public ulong OnlineVisitDoctorsReservationDateId { get; set; }

        public DateTime SelectedDate { get; set; }

        public int  StartTime { get; set; }

        public int EndTime{ get; set; }

        public int CountOfFreeTime { get; set; }

        public ulong WorkShiftId { get; set; }

        #endregion
    }
}
