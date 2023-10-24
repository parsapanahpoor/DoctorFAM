#region Usings

using DoctorFAM.Domain.Entities.Common;
namespace DoctorFAM.Domain.Entities.DoctorReservation;

#endregion

public sealed class DoctorPersonalBooking : BaseEntity
{
    #region properties

    public ulong DoctorReservationDateTimeId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Mobile { get; set; }

    public string? NationalId { get; set; }

    #endregion

    #region relations 

    public DoctorReservationDateTime DoctorReservationDateTime { get; set; }

    #endregion
}
