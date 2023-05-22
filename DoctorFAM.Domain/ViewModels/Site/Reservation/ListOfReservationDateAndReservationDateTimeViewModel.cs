using DoctorFAM.Domain.Entities.DoctorReservation;

namespace DoctorFAM.Domain.ViewModels.Site.Reservation;

public class ListOfReservationDateAndReservationDateTimeViewModel
{
	#region properties

	public DoctorReservationDate DoctorReservationDate { get; set; }

	public List<DoctorReservationDateTime> DoctorReservationDateTimes { get; set; }

	#endregion
}
