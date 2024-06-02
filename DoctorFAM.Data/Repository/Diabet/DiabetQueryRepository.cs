using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore.Diabet;
using DoctorFAM.Domain.Interfaces.EFCore.OrganizationRating;
using DoctorFAM.Domain.ViewModels.Admin.Diabet;
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

    public async Task<List<ListOfDiabetPopulationDTO>> ListOfDiabetPopulation(CancellationToken cancellationToken)
    {
        return await _context.DiabetPopulation
                             .AsNoTracking()
                             .Where(p => !p.IsDelete)
                             .Select( p => new ListOfDiabetPopulationDTO() 
                             {
                                 Age = p.Age,
                                 Gender = p.Gender,
                                 Person =  _context.Users
                                                        .AsNoTracking()
                                                        .Where(u => !u.IsDelete &&
                                                               u.Id == p.UserId)
                                                        .Select(u => new DiabetianPersonDTO()
                                                        {
                                                            Mobile = u.Mobile,
                                                            NationalId = u.NationalId,
                                                            UserId = p.UserId,
                                                            Username = u.Username
                                                        })
                                                        .FirstOrDefault()
                             })
                             .ToListAsync();
    }
}