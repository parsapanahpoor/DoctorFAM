using DoctorFAM.Domain.Enums.DoctorReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Reservation
{
    public class ChooseTypeOfReservationViewModel
    {
        #region properties

        public ulong ReservationDateTimeId { get; set; }

        public ulong DoctorId { get; set; }

        public DoctorReservationType? DoctorReservationType { get; set; }

        public string? ReservationRequestDescription { get; set; }

        #endregion
    }
}
