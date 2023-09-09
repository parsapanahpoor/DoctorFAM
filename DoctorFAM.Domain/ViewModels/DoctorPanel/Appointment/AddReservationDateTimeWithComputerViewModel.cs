using DoctorFAM.Domain.Enums.DoctorReservation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment
{
    public class AddReservationDateTimeWithComputerViewModel
    {
        #region properties

        public ulong ReservationDateId { get; set; }

        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public int StartTime { get; set; }

        [Display(Name = "End Time")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public int EndTime { get; set; }

        public DoctorReservationType DoctorReservationType { get; set; }

        public int PeriodNumber { get; set; }

        #endregion
    }
}
