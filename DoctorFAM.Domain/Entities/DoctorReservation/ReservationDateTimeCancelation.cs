using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.DoctorReservation
{
    public class ReservationDateTimeCancelation : BaseEntity
    {
        #region properties

        public ulong DoctorReservationDateId { get; set; }

        public ulong  DoctorReservationDateTimeId{ get; set; }

        #endregion

        #region relations 

        public ReservationDateCancelation ReservationDateCancelation { get; set; }

        public DoctorReservationDateTime DoctorReservationDateTime { get; set; }

        #endregion
    }
}
