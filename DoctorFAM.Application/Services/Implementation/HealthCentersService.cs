using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;

namespace DoctorFAM.Application.Services.Implementation;

public class HealthCentersService : IHealthCentersService
{
    #region Ctor

    private readonly IHealthCentersRepository _healthCentersRepository;

    public HealthCentersService(IHealthCentersRepository healthCentersRepository)
    {
        _healthCentersRepository = healthCentersRepository;
    }

    #endregion
}
