#region Usings

using DoctorFAM.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

#endregion

namespace DoctorFAM.Domain.Entities.Dentist;

public sealed class DentistsSkills : BaseEntity
{
	#region properties

	public ulong UserId { get; set; }

    [MaxLength(400)]
    public string DentistSkill { get; set; }

	#endregion
}
