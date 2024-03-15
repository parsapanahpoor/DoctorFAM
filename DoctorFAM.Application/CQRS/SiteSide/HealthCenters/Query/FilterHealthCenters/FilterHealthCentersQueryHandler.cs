using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Site.HealthCenters;
namespace DoctorFAM.Application.CQRS.SiteSide.HealthCenters.Query.FilterHealthCenters;

public class FilterHealthCentersQueryHandler : IRequestHandler<FilterHealthCentersQuery, FilterHealthCentersSiteSideDTO>
{
    #region Ctor

    private readonly IHealthCentersRepository _healthCentersRepository;

    public FilterHealthCentersQueryHandler(IHealthCentersRepository healthCentersRepository)
    {
            _healthCentersRepository = healthCentersRepository;
    }

    #endregion

    public async Task<FilterHealthCentersSiteSideDTO> Handle(FilterHealthCentersQuery request, CancellationToken cancellationToken)
    {
        return await _healthCentersRepository.FilterHealthCentersSiteSide(request.Filter, cancellationToken) ;
    }
}
