using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DosctorSideBarInfo;
using Microsoft.EntityFrameworkCore;

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

    #region Health Center Side

    //Get Member Of Health Center With User Id 
    public async Task<OrganizationMember?> GetMemberOfHealthCenterWithUserId(ulong userId)
    {
        return await _context.OrganizationMembers
                                     .Include(p => p.Organization)
                                     .FirstOrDefaultAsync(p => !p.IsDelete &&
                                                          p.UserId == userId &&
                                                          p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.HealthCenter);
    }

    #endregion
}
