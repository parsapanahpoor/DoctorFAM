using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;

namespace DoctorFAM.Domain.Entities.HealthCenters;

public sealed class HealthCenter : BaseEntity
{
    #region properties

    public ulong UserId { get; set; }

    #endregion

    #region Relations

    public User User { get; set; }

    public HealthCentersInfo HealthCentersInfo { get; set; }

    #endregion
}
