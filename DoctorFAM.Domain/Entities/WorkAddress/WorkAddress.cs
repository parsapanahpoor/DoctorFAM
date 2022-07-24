using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.WorkAddress
{
    public class WorkAddress : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public string Address { get; set; }

        #endregion

        #region relation

        public User User { get; set; }

        public ICollection<DoctorReservation.DoctorReservationDateTime> DoctorReservationDateTimes { get; set; }

        #endregion
    }
}
