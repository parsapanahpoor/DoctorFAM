#region Usings

using DoctorFAM.Domain.Entities.Common;
namespace DoctorFAM.Domain.Entities.DoctorReservation;

#endregion

public sealed class ReservationDateTimeCancelation : BaseEntity
{
    #region properties

    public ulong ReservationDateCancelationId { get; set; }

    public ulong  DoctorReservationDateTimeId{ get; set; }

    #endregion

    #region relations 

    public ReservationDateCancelation ReservationDateCancelation { get; set; }

    public DoctorReservationDateTime DoctorReservationDateTime { get; set; }

    #endregion
}
