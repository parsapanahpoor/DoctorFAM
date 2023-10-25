#region Usings

using DoctorFAM.Domain.Entities.Common;
namespace DoctorFAM.Domain.Entities.DoctorReservation;

#endregion

public sealed class LogForDoctorReservationDateTimeWaitingForPayment : BaseEntity
{
	#region properties

	public ulong DoctorReservationDateTimeId { get; set; }

    public ulong PatientUserId { get; set; }

    public ulong? SupporterUserId { get; set; }

    public bool IsSeenBySupporters { get; set; }

    #endregion

    #region Navigation Properties

    public DoctorReservationDateTime DoctorReservationDateTime { get; set; }

    #endregion
}
