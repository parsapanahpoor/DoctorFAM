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
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.UserPanel.Reservation
{
    public class FilterFamilyDoctorReservationDateTimeUserPanelViewModel : BasePaging<DoctorReservationDateTime>
    {
        #region properties

        public ulong PatientId { get; set; }

        public ulong UserId { get; set; }

        public ulong ReservationDateId { get; set; }

        [Display(Name = "Start Time")]
        public string? StartTime { get; set; }

        [Display(Name = "End Time")]
        public string? EndTime { get; set; }

        public FilterRequestOrder? FilterRequestOrder { get; set; }

        public FilterFamilyDoctorReservationInUserPanelState? FilterFamilyDoctorReservationInUserPanelState { get; set; }

        public FilterDoctorReservationType? FilterDoctorReservationType { get; set; }

        #endregion
    }

}
