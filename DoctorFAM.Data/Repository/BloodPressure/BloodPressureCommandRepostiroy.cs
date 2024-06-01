using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore.BloodPressure;
namespace DoctorFAM.Data.Repository.BloodPressure;

public class BloodPressureCommandRepository : CommandGenericRepository<DoctorFAM.Domain.Entities.BloodPressure.BloodPressurePopulation>, IBloodPressureCommandRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public BloodPressureCommandRepository(DoctorFAMDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion
}