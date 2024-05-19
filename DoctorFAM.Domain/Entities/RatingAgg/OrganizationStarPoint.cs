using DoctorFAM.Domain.Entities.Common;

namespace DoctorFAM.Domain.Entities.RatingAgg;

public class OrganizationStarPoint :BaseEntity
{
    #region properties

    public ulong OperatorUserId { get; set; }

    public ulong PointValue { get; set; }

    #endregion
}
