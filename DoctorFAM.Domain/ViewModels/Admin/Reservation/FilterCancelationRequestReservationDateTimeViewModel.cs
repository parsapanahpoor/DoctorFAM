using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Reservation
{
    public class FilterCancelationRequestReservationDateTimeViewModel : BasePaging<Domain.Entities.DoctorReservation.ReservationDateTimeCancelation>
    {
        #region properties

        public ulong ReservationDateId { get; set; }

        #endregion
    }
}
