using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.DoctorReservation
{
    public class CancelReservationRequest : BaseEntity
    {
        #region properties

        public ulong DoctorReservationDateId { get; set; }

        public ulong DoctorReservationDateTimeId { get; set; }

        public ulong UserId { get; set; }

        #endregion

        #region relations

        public DoctorReservationDate DoctorReservationDate { get; set; }

        public DoctorReservationDateTime DoctorReservationDateTime { get; set; }

        public User User { get; set; }

        #endregion
    }
}
