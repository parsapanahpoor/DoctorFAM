using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorFAM.Domain.Entities.RatingAgg;

public class OrganizationStarPoint :BaseEntity
{
    #region properties

    public ulong OperatorUserId { get; set; }

    public int PointValue { get; set; }

    #endregion

    [ForeignKey("OperatorUserId")]
    public User User { get; set; }
}
