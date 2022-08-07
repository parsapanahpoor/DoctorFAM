using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.DoctorReservation
{
    public class ReservationDateCancelation : BaseEntity
    {
        #region properties

        public ulong DoctorReservationDateId { get; set; }

        #endregion

        #region relation 

        public DoctorReservationDate DoctorReservationDate { get; set; }

        public ICollection<ReservationDateTimeCancelation> ReservationDateTimeCancelation { get; set; }

        #endregion
    }
}
