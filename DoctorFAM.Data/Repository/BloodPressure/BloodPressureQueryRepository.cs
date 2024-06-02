using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore.BloodPressure;
using DoctorFAM.Domain.ViewModels.Admin.BloodPressure;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Data.Repository.BloodPressure;

public class BloodPressureQueryRepository : QueryGenericRepository<Domain.Entities.BloodPressure.BloodPressurePopulation>, IBloodPressureQueryRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public BloodPressureQueryRepository(DoctorFAMDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    public async Task<bool> IsExist_AnyUser_InBloodPressurePopulation_ByUserId(ulong userId)
    {
        return await _context.BloodPressurePopulation
                             .AsNoTracking()
                             .AnyAsync(p=> !p.IsDelete && 
                                       p.UserId == userId);
    }

    public async Task<List<ListOfBloodPressurePopulationDTO>> ListOfBloodPressurePopulation(CancellationToken cancellationToken)
    {
        return await _context.BloodPressurePopulation
                             .AsNoTracking()
                             .Where(p => !p.IsDelete)
                             .Select(p => new ListOfBloodPressurePopulationDTO()
                             {
                                 Age = p.Age,
                                 Gender = p.Gender,
                                 Person = _context.Users
                                                        .AsNoTracking()
                                                        .Where(u => !u.IsDelete &&
                                                               u.Id == p.UserId)
                                                        .Select(u => new BloodPressureianPersonDTO()
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