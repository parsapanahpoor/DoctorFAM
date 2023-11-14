namespace DoctorFAM.Domain.ViewModels.Admin.Reservation;

public record ListOfSelectedReservationsAdminSideDTO
{
    #region properties

    public PatientInfoListOfSelectedReservationsAdminSideDTO? PatientInfo { get; set; }

    public DoctorInfoListOfSelectedReservationsAdminSideDTO? DoctorInfo { get; set; }

    public Entities.DoctorReservation.DoctorReservationDateTime? ReservationDateTime { get; set; }

    public Entities.DoctorReservation.DoctorReservationDate? ReservationDate { get; set; }

    public LogForGetAppoinmentForOtherPeoplesAdminSide? LogForGetAppoinmentForOtherPeoples { get; set; }

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

public record LogForGetAppoinmentForOtherPeoplesAdminSide
{
    #region properties

    public string? FirstName { get; set;}

    public string? LastName { get; set; }

    #endregion
}

