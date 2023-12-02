using DoctorFAM.Domain.Entities.HealthCenters;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.ViewModels.Common;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.HealthCenters;

public class FilterHealthCentersInDoctorPanelDTO : BasePaging<HealthCenter>
{
    public ulong? CountryId { get; set; }

    public ulong? StateId { get; set; }

    public ulong? CityId { get; set; }

    public string? HealthCenterName { get; set; }
}
