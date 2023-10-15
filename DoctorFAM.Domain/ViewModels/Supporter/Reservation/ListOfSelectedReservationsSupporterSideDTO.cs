namespace DoctorFAM.Domain.ViewModels.Supporter.Reservation;

public record ListOfSelectedReservationsSupporterSideDTO
{
    #region properties

    public PatientInfoListOfSelectedReservationsSupporterSideDTO? PatientInfo { get; set; }

    public DoctorInfoListOfSelectedReservationsSupporterSideDTO? DoctorInfo { get; set; }

    public Domain.Entities.DoctorReservation.DoctorReservationDateTime? ReservationDateTime { get; set; }

    public Domain.Entities.DoctorReservation.DoctorReservationDate? ReservationDate { get; set; }

    #endregion
}

public record PatientInfoListOfSelectedReservationsSupporterSideDTO
{
    #region properties

    public string? Username { get; set; }

    public string? Mobile { get; set; }

    #endregion
}

public record DoctorInfoListOfSelectedReservationsSupporterSideDTO
{
    #region properties

    public string? Username { get; set; }

    public string? Mobile { get; set; }

    #endregion
}
