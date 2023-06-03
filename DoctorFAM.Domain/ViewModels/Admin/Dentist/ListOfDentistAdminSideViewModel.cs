#region Usings

using DoctorFAM.Domain.Entities.Doctors;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DoctorFAM.Domain.ViewModels.Admin.Dentist;

public class ListOfDentistAdminSideViewModel
{
	#region properties

	public DentistUsersAdminSideViewModel? User { get; set; }

	public OrganizationInfoState organizationmState { get; set; }

    #endregion
}

public class DentistUsersAdminSideViewModel
{
	public ulong  UserId { get; set; }

	public string Username { get; set; }

	public string Mobile { get; set; }

	public string Email{ get; set; }

	public bool MobileState { get; set; }

	public bool EmailState { get; set; }

	public DateTime RegisterDate { get; set; }

	public bool ActiveSatte { get; set; }

	public string? UserAvatar { get; set; }

}
