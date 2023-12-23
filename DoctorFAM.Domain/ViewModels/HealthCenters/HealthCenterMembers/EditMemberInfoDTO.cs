using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.HealthCenters;
using DoctorFAM.Domain.Enums.HealthCenter;

namespace DoctorFAM.Domain.ViewModels.HealthCenters.HealthCenterMembers;

public record EditMemberInfoDTO 
{
    #region properties

    public User? User { get; set; }

    public DoctorSelectedHealthCenterState DoctorSelectedHealthCenterState { get; set; }

    public ulong Id { get; set; }

    #endregion
}
