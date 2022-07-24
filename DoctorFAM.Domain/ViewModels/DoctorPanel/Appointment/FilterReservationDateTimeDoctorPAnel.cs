using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Enums.DoctorReservation;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment
{
    public class FilterReservationDateTimeDoctorPAnel : BasePaging<DoctorReservationDateTime>
    {
        #region properties

        public ulong UserId { get; set; }

        public ulong ReservationDateId { get; set; }

        [Display(Name = "Start Time")]
        public string? StartTime { get; set; }

        [Display(Name = "End Time")]
        public string? EndTime { get; set; }

        public FilterRequestOrder FilterRequestOrder { get; set; }

        public FilterDoctorReservationState FilterDoctorReservationState { get; set; }

        public FilterDoctorReservationType FilterDoctorReservationType { get; set; }

        #endregion
    }
}
