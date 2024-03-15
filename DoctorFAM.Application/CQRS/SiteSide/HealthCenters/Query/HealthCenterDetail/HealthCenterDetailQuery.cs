using DoctorFAM.Domain.ViewModels.Site.HealthCenters;

namespace DoctorFAM.Application.CQRS.SiteSide.HealthCenters.Query.HealthCenterDetail;

public class HealthCenterDetailQuery : IRequest<HealthCenterDetailSiteSideDTO>
{
    #region properties

    public ulong HealthCenterId { get; set; }

    #endregion
}
