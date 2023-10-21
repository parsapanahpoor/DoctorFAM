#region Usings

using DoctorFAM.Domain.Entities.Common;

namespace DoctorFAM.Domain.Entities.DoctorReservation;

#endregion

public sealed class ReservationDateCancelation : BaseEntity
{
    #region properties

    public ulong DoctorReservationDateId { get; set; }

    #endregion

    #region relation 

    public DoctorReservationDate DoctorReservationDate { get; set; }

    public ICollection<ReservationDateTimeCancelation> ReservationDateTimeCancelation { get; set; }

    #endregion
}
