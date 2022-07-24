using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment
{
    public class AddReservationDateTimeViewModel
    {
        #region properties

        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string StartTime { get; set; }

        [Display(Name = "End Time")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string EndTime { get; set; }

        public ulong ReservationDateId { get; set; }

        #endregion
    }
}
