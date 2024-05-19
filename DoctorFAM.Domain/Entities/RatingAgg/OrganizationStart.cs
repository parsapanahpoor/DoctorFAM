using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.Rating;

namespace DoctorFAM.Domain.Entities.RatingAgg;

public sealed class OrganizationStart : BaseEntity
{
    #region properties

    public ulong OperatorUserId { get; set; }

    public ulong PatientUserId { get; set; }

    public OrganizationStartEnum OrganizationStartEnum { get; set; }

    public int Star { get; set; }

    #endregion
}
