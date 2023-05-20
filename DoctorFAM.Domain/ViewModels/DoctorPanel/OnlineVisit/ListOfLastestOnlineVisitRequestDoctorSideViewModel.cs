namespace DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;

public class ListOfLastestOnlineVisitRequestDoctorSideViewModel
{
	#region properties

	public OnlineVisitRequestUser? User { get; set; }

	public string? WorkShiftTime{ get; set; }

	public DateTime WorkShiftDate { get; set; }

	public DateTime RequestCreateDate { get; set; }

	public ulong UserRequestId { get; set; }

	public string? WorkShift { get; set; }

	#endregion
}

public class OnlineVisitRequestUser
{
	public ulong UserId { get; set; }

	public string Username { get; set; }

	public string? UserAvatar { get; set; }

	public string Mobile { get; set; }
}
