﻿using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore.BloodPressure;
using DoctorFAM.Domain.Interfaces.EFCore.OrganizationRating;
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
}