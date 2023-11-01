using DoctorFAM.Domain.Entities.Common;

namespace DoctorFAM.Domain.Entities.DoctorReservation;

public sealed class LogForDoctorReservationDateTimeWaitingForPaymentComment : BaseEntity
{
    #region properties

    public ulong UserId { get; set; }

    public ulong LogForDoctorReservationDateTimeWaitingForPaymentId { get; set; }

    public string Comment { get; set; }

    #endregion
}
