#region Usings

using DoctorFAM.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

#endregion

namespace DoctorFAM.Domain.Entities.OnlineVisit;

public sealed class  OnlineVisitUserRequestDetail : BaseEntity
{
    #region properties

    public ulong UserId { get; set; }

    public int DayDatebusinessKey { get; set; }

    public ulong WorkShiftDateTimeId { get; set; }

    public ulong WorkShiftDateId { get; set; }

    public bool IsFinaly { get; set; }

    public bool IsTakenFromDoctor { get; set; }

    [Timestamp]
    public byte[] Timestamp { get; set; }

    #endregion
}
