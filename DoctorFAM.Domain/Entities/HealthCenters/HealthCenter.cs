using DoctorFAM.Domain.Entities.Common;

namespace DoctorFAM.Domain.Entities.HealthCenters;

public sealed class HealthCenter : BaseEntity
{
    #region properties

    public ulong UserId { get; set; }

    #endregion
}
