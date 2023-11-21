using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Enums.DoctorReservation;

namespace DoctorFAM.Domain.ViewModels.Supporter.Reservation;

public record ListOfCommentsForWaitingForPaymentReservationRequestSupporterSideDTO
{
    #region properties

    public LogForDoctorReservationDateTimeWaitingForPaymentComment? LogInformation { get; set; }

    public User? UserInfo { get; set; }

    #endregion
}

public record ReservationLogForWaitingPaymentAdmindSideDTO
{
    public ulong ReservationDateTimeId { get; set; }

    public DoctorReservationState DoctorReservationState { get; set; }

    public ulong? PatientId { get; set; }
}
