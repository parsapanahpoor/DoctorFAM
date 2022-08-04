using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.DoctorReservation
{
    public class DoctorReservationDate : BaseEntity
    {
        #region properties

        public ulong  UserId { get; set; }

        public DateTime ReservationDate { get; set; }

        #endregion

        #region relations

        public User User { get; set; }

        public ICollection<DoctorReservationDateTime> DoctorReservationDateTimes { get; set; }

        public ICollection<CancelReservationRequest> CancelReservationRequests { get; set; }

        #endregion
    }
}
