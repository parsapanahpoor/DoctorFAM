using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore.Diabet;
using DoctorFAM.Domain.Interfaces.EFCore.OrganizationRating;
using Microsoft.EntityFrameworkCore;

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

    public async Task<bool> IsExist_AnyUser_InDiabetPopulation_ByUserId(ulong userId)
    {
        return await _context.DiabetPopulation
                             .AsNoTracking()
                             .AnyAsync(p=> !p.IsDelete && 
                                       p.UserId == userId);
    }
}