using System.ComponentModel.DataAnnotations;

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

        public string? UserRequetsDescription { get; set; }

        public ulong WorkAddressId { get; set; }

        #endregion
    }
}
