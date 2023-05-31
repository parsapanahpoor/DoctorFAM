#region Usings

using DoctorFAM.Domain.Entities.Common;

#endregion

namespace DoctorFAM.Domain.Entities.Laboratory;

public sealed class HomeLaboratoruRequestResult : BaseEntity
{
	#region prorperties

	public ulong RequestId { get; set; }

    public string ResultPicture { get; set; }

    #endregion
}
