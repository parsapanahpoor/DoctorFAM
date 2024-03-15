using DoctorFAM.Domain.ViewModels.Common;

namespace DoctorFAM.Domain.ViewModels.Site.HealthCenters;

public class FilterHealthCentersSiteSideDTO : BasePaging<HealthCentersInfoDTO>
{
    #region properties

    

    #endregion
}

public class HealthCentersInfoDTO
{
    public ulong HealthCenterId { get; set; }

    public string HealthCenterTitle { get; set; }

    public string HealthCenterCoverImage { get; set; }
}
