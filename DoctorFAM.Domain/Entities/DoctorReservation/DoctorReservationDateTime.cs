using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.DoctorReservation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.DoctorReservation
{
    public class DoctorReservationDateTime : BaseEntity
    {
        #region properties

        public ulong DoctorReservationDateId { get; set; }

        public ulong? PatientId { get; set; }

        public DoctorReservationState DoctorReservationState { get; set; }

        public ulong? WorkAddressId { get; set; }

        public DoctorReservationType? DoctorReservationType { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        #endregion

        #region relations

        [ForeignKey("PatientId")]
        public User User { get; set; }

        public DoctorReservationDate DoctorReservationDate { get; set; }

        public WorkAddress.WorkAddress WorkAddress { get; set; }

        public ICollection<LogForCloseReservation> LogForCloseReservations { get; set; }

        public ReservationDateTimeCancelation ReservationDateTimeCancelation { get; set; }

        #endregion
    }
}
