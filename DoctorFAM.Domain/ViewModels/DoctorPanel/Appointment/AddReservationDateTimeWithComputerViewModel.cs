using DoctorFAM.Domain.Enums.DoctorReservation;
using System.ComponentModel.DataAnnotations;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment;

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

    public ulong LocationId { get; set; }

    #endregion
}
