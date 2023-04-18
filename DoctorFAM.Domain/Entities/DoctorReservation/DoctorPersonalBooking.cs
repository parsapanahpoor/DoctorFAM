using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.DoctorReservation
{
    public class DoctorPersonalBooking : BaseEntity
    {
        #region properties

        public ulong DoctorReservationDateTimeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Mobile { get; set; }

        public string? NationalId { get; set; }

        #endregion

        #region relations 

        public DoctorReservationDateTime DoctorReservationDateTime { get; set; }

        #endregion
    }
}
