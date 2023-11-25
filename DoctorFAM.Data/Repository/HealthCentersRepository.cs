using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore;

namespace DoctorFAM.Data.Repository;

public class HealthCentersRepository : IHealthCentersRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public HealthCentersRepository(DoctorFAMDbContext context)
    {
        _context = context;
    }

    #endregion
}
