using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.DoctorReservation
{
    public class LogForCloseReservation : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public ulong DoctorReservationDateTimeId { get; set; }

        #endregion

        #region relation

        public User User { get; set; }

        public DoctorReservationDateTime DoctorReservationDateTime { get; set; }

        #endregion
    }
}
