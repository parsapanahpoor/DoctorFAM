#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site;

#endregion

public class ListOfDentistShowSiteSideViewModel
{
	#region properties

	public DentistUserInfoForShowInListOFDentsits DentistUserInfos { get; set; }

	#endregion
}

public class DentistUserInfoForShowInListOFDentsits
{
	#region properties

	public string DoctorUsername { get; set; }

	public ulong UserId { get; set; }

	public string UserAvatar { get; set; }

	#endregion
}
