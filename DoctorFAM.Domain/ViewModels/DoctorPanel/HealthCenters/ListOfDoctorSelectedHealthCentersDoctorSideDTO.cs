using DoctorFAM.Domain.Enums.HealthCenter;
using DoctorFAM.Domain.ViewModels.Common;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.HealthCenters;

public class ListOfDoctorSelectedHealthCentersDoctorSideDTO
{
    #region properties

    public string HealthCenterImage { get; set; }

    public DoctorSelectedHealthCenterState DoctorSelectedHealthCenterState { get; set; }

    public string HealthCenterName { get; set; }

    #endregion
}

public class FilterOfDoctorSelectedHealthCentersDoctorSide : BasePaging<ListOfDoctorSelectedHealthCentersDoctorSideDTO>
{
    public ulong UserId { get; set; }
}
