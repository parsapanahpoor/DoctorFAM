#region Usings

using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Specialists;

#endregion

public class ListOfSpecialistsSiteSideViewModel
{
	#region properties

	public DoctorSpecialistUserInfoViewModel DoctorUserInfo { get; set; }

	#endregion
}

public class DoctorSpecialistUserInfoViewModel
{
	#region properties

	public ulong UserId { get; set; }

	public string Username { get; set; }

	public string UserAvatar { get; set; }

	#endregion
}
