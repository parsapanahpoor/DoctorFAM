namespace DoctorFAM.Domain.ViewModels.BackgroundTasks.Reservation;

public record SendSMSForReminderToReservationDTO
{
    #region properties

    public string DoctorUsername { get; set; }

    public ulong DoctorReservationDateTimeId { get; set; }

    public string UserMobile { get; set; }

    #endregion
}
