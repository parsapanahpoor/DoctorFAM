#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.OnlineVisit;

#endregion

public class ListOfOnlineVisitRequestsAdminSideViewModel
{
	#region proeprties

	public ListUsersInOnlineVisitRequestAdminSideViewModel User { get; set; }

	public DateTime DateTime { get; set; }

	public DateTime CreateDate { get; set; }

	public string WorkShiftTime { get; set; }

    public bool IsFinaly { get; set; }

    public bool IsTakenFromDoctor { get; set; }

    #endregion
}

public class ListUsersInOnlineVisitRequestAdminSideViewModel
{
	public ulong UserId { get; set; }

	public string Username { get; set; }

	public string Mobile { get; set; }

	public string UserAvatar { get; set; }
}
