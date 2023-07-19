#region Usings

using Microsoft.AspNetCore.Http;


#endregion

namespace DoctorFAM.Domain.ViewModels.Laboratory.HomeLaboratory;

public class HomeLaboratoryRequestResultLaboratorySideViewModel
{
	#region properties

	public ulong RequestId { get; set; }

    public string? AttachmentFileName { get; set; }

    public bool Finalize { get; set; }

	public bool ResultInSocialMedia { get; set; }

	public bool ResultInDoctorFAMPanel { get; set; }

	public bool ResultInVisitInPerson { get; set; }

	#endregion
}
