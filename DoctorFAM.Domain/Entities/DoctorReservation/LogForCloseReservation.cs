#region Usings

using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
namespace DoctorFAM.Domain.Entities.DoctorReservation;

#endregion

public sealed class LogForCloseReservation : BaseEntity
{
    #region properties

    public ulong UserId { get; set; }

    public ulong DoctorReservationDateTimeId { get; set; }

    #endregion

    #region relation

    public User User { get; set; }

    public DoctorReservationDateTime DoctorReservationDateTime { get; set; }

    #endregion
}
