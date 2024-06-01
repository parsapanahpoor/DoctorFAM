using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore.Diabet;
using DoctorFAM.Domain.Interfaces.EFCore.OrganizationRating;

namespace DoctorFAM.Data.Repository.Diabet;

public class DiabetQueryRepository : QueryGenericRepository<Domain.Entities.Diabet.DiabetPopulation>, IDiabetQueryRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public DiabetQueryRepository(DoctorFAMDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion
}