using DoctorFAM.Domain.Entities.Common;

namespace DoctorFAM.Domain.Entities.RatingAgg;

public class OrganizationStarPoint :BaseEntity
{
    #region properties

    public ulong OperatorUserId { get; set; }

    public int PointValue { get; set; }

    #endregion
}
