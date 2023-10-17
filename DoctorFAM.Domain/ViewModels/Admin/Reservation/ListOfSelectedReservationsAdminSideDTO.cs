namespace DoctorFAM.Domain.ViewModels.Admin.Reservation;

public record ListOfSelectedReservationsAdminSideDTO
{
    #region properties

    public PatientInfoListOfSelectedReservationsAdminSideDTO? PatientInfo { get; set; }

    public DoctorInfoListOfSelectedReservationsAdminSideDTO? DoctorInfo { get; set; }

    public Domain.Entities.DoctorReservation.DoctorReservationDateTime? ReservationDateTime { get; set; }

    public Domain.Entities.DoctorReservation.DoctorReservationDate? ReservationDate { get; set; }

    #endregion
}

public record PatientInfoListOfSelectedReservationsAdminSideDTO
{
    #region properties

    public string? Username { get; set; }

    public string? Mobile { get; set; }

    #endregion
}

public record DoctorInfoListOfSelectedReservationsAdminSideDTO
{
    #region properties

    public string? Username { get; set; }

    public string? Mobile { get; set; }

    #endregion
}
