#region Usings

using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Enums.DoctorTitleName;
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

	public DoctorSpecialistUserInfoViewModel? DoctorUserInfo { get; set; }

	#endregion
}

public class DoctorSpecialistUserInfoViewModel
{
	#region properties

	public ulong UserId { get; set; }

	public string Username { get; set; }

	public string UserAvatar { get; set; }

    public DoctorTilteName DoctorTilteName { get; set; }

    public DoctorsInfo doctorsInfo { get; set; }

    #endregion
}

public class ListOfDoctorIdAndDoctorUserId
{
    public ulong DoctorUserId{ get; set; }
    public ulong DoctorId { get; set; }
}
