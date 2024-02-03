using DoctorFAM.Domain.Entities.Common;
namespace DoctorFAM.Domain.Entities.Story;

public sealed class Story : BaseEntity
{
    #region properties

    public ulong UserId { get; set; }

    public string File { get; set; }

    public string Description { get; set; }

    #endregion
}
