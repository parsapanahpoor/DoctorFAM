using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.HealthCenter;

namespace DoctorFAM.Domain.Entities.HealthCenters;

public sealed class DoctorSelectedHealthCenter : BaseEntity
{
    #region properties

    public ulong ApplicantUserId { get; set; }

    public ulong HealthCenterId { get; set; }

    public DoctorSelectedHealthCenterState DoctorSelectedHealthCenterState { get; set; }

    #endregion
}
