using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Entities.WorkAddress;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment;

public class ShowPatientDetailViewModel
{
    #region properties

    public User User { get; set; }

    public DoctorReservationDate DoctorReservationDate { get; set; }

    public DoctorReservationDateTime DoctorReservationDateTime { get; set; }

    public bool DoctorBooking { get; set; }

    public string? UserRequestDescription { get; set; }

    public WorkAddress? WorkAddress { get; set; }

    #endregion
}
