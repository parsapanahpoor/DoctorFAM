using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment
{
    public class DoctorPersonalBookingViewModel 
    {
        #region properties

        public ulong DoctorReservationDateTimeId { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        public string Mobile { get; set; }

        public string? NationalId { get; set; }

        #endregion
    }
}
