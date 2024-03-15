using DoctorFAM.Domain.ViewModels.Site.HealthCenters;

namespace DoctorFAM.Application.CQRS.SiteSide.HealthCenters.Query.FilterHealthCenters;

public class FilterHealthCentersQuery : IRequest<FilterHealthCentersSiteSideDTO>
{
    public FilterHealthCentersSiteSideDTO Filter { get; set; }
}
