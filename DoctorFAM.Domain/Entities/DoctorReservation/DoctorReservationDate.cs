#region Usings

using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;

namespace DoctorFAM.Domain.Entities.DoctorReservation;

#endregion

public sealed class DoctorReservationDate : BaseEntity
{
    #region properties

    public ulong  UserId { get; set; }

    public DateTime ReservationDate { get; set; }

    #endregion

    #region relations

    public User User { get; set; }

    public ICollection<DoctorReservationDateTime> DoctorReservationDateTimes { get; set; }

    public ICollection<ReservationDateCancelation> ReservationDateCancelation { get; set; }

    #endregion
}
