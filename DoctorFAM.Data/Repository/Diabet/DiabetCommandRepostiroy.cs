using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore.Diabet;
namespace DoctorFAM.Data.Repository.Diabet;

public class DiabetCommandRepository : CommandGenericRepository<DoctorFAM.Domain.Entities.Diabet.DiabetPopulation>, IDiabetCommandRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public DiabetCommandRepository(DoctorFAMDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

}