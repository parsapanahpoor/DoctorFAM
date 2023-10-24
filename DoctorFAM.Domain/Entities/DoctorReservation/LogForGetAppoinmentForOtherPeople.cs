#region Usings

using DoctorFAM.Domain.Entities.Common;
namespace DoctorFAM.Domain.Entities.DoctorReservation;

#endregion

public sealed class LogForGetAppoinmentForOtherPeople : BaseEntity
{
    #region properties

    public ulong ReservationDateTimeId { get; set; }

    public ulong UserId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    #endregion
}
