using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment
{
    public class CancelReservationRequestViewModel
    {
        #region properties

        public ulong ReservationDateId { get; set; }

        public List<ulong> ReservationDateTimeId { get; set; }

        #endregion
    }
}
