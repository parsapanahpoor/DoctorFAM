using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Enums.HealthCenter;
using DoctorFAM.Domain.ViewModels.Common;

namespace DoctorFAM.Domain.ViewModels.HealthCenters.HealthCenterMembers;

public class FilterHealthcenterMembersDTO : BasePaging<ListOFHealthMembersDTO>
{
    public string Username { get; set; }

    public string Mobile { get; set; }
}

public class ListOFHealthMembersDTO 
{
    #region properties

    public string Username { get; set; }

    public string? UserAvatar { get; set; }

    public string Mobile { get; set; }

    public DateTime StartDate { get; set; }

    public DoctorSelectedHealthCenterState DoctorSelectedHealthCenterState { get; set; }

    public ulong Id { get; set; }

    #endregion
}
