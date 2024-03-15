using DoctorFAM.Domain.ViewModels.Site.HealthCenters;

namespace DoctorFAM.Application.CQRS.SiteSide.HealthCenters.Query.HealthCenterDoctorsPage;

public class HealthCenterDoctorsPageQuery : IRequest<HealthCenterDoctorsPageSiteSideDTO>
{
    #region properties

    public ulong HealthCenterId { get; set; }

    public string SpecialityTitle { get; set; }

    public ulong SpecialityId { get; set; }

    #endregion
}
