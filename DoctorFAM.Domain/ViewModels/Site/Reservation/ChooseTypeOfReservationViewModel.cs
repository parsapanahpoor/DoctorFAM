using DoctorFAM.Domain.Enums.DoctorReservation;

namespace DoctorFAM.Domain.ViewModels.Site.Reservation;

public record ChooseTypeOfReservationViewModel
{
    #region properties

    public ulong ReservationDateTimeId { get; set; }

    public ulong DoctorId { get; set; }

    public DoctorReservationType? DoctorReservationType { get; set; }

    public DoctorReservationType? DoctorSelectedReservationType { get; set; }

    public string? ReservationRequestDescription { get; set; }

    public UserInfoForGetReservation? UserInfoForGetReservation { get; set; }

    #endregion
}

public record UserInfoForGetReservation
{
    #region properties

    public int GetReservationForHimSelf { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? NationalCode { get; set; }

    public string? OthersFirstName { get; set; }

    public string? OthersLastName { get; set; }

    #endregion
}

public enum UserInfoForGetReservationResult
{
    FirstName,
    LastName,
    NationalCode,
    UserNotfound,
    NationalCodeIsExist
}