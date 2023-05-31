#region Usings



#endregion

namespace DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse.HomeLaboratory;

public class ShowHomeLaboratoryRequestResultLaboratorySideViewModel
{
	#region properties

	public ulong RequestId { get; set; }

	public string? ResultImage { get; set; }

	public bool ResultInDoctorFAMPanel { get; set; }

	public bool ResultInSocialMedia { get; set; }

	public bool ResultInVisitInPerson { get; set; }

	#endregion
}
