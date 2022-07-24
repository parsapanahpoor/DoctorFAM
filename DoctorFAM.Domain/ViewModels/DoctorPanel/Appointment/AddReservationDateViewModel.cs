using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment
{
    public class AddReservationDateViewModel
    {
        [Display(Name = "Reservation Date")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "The information entered is not valid.")]
        public string ReservationDate { get; set; }
    }
}
