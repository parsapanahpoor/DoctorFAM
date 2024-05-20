namespace DoctorFAM.Domain.ViewModels.Site.Rating;

public record ShowRatingFormForPatientDTO
{
    #region proeprties

    public ShowRatingFormForPatientDTO_DoctorProfile DoctorInfo { get; set; }

    public ShowRatingFormForPatientDTO_ReservationInfo ReservationInfo { get; set; }

    public string PatientMobile { get; set; }

    #endregion
}

public record ShowRatingFormForPatientDTO_DoctorProfile
{
    #region properties

    public ulong DoctorUserId { get; set; }

    public string DoctorUsername { get; set; }

    public string DoctorAvatar { get; set; }

    #endregion
}

public record ShowRatingFormForPatientDTO_ReservationInfo
{
    #region properties

    public ulong ReservationId { get; set; }

    public ulong ReservationDateTimeId { get; set; }

    public DateTime ReservationDate { get; set; }

    public string ReservationDateStartTime { get; set; }

    #endregion
}
