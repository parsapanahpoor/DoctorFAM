using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.DoctorReservation;
namespace DoctorFAM.Domain.ViewModels.Supporter.Reservation;

public record ListOfCommentsForWaitingForPaymentReservationRequestSupporterSideDTO
{
    #region properties

    public LogForDoctorReservationDateTimeWaitingForPaymentComment? LogInformation { get; set; }

    public User? UserInfo { get; set; }

    #endregion
}
