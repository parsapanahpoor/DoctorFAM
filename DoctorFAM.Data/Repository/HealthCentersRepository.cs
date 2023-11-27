using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Dentist;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.HealthCenters;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Dentist.SideBar;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DosctorSideBarInfo;
using DoctorFAM.Domain.ViewModels.HealthCenters.SideBar;
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

    //Is Exist Any Health Center By User Id
    public async Task<bool> IsExistAnyHealthCenterByUserId(ulong userId)
    {
        return await _context.HealthCenters
                             .AsNoTracking()
                             .AnyAsync(p => p.UserId == userId && !p.IsDelete);
    }

    //Add Health Center Without Save Changes
    public async Task AddHealthCenterWithoutSaveChanges(HealthCenter healthCenter)
    {
        await _context.HealthCenters.AddAsync(healthCenter);
    }

    //Save Changes
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    //Fill Health Center Side Bar Panel 
    public async Task<HealthCenterSideBarViewModel> GetHealthCenterSideBarInfo(ulong userId)
    {
        HealthCenterSideBarViewModel model = new HealthCenterSideBarViewModel();

        #region Get Health Center Office

        var organizationIds = await _context.OrganizationMembers
                                           .AsNoTracking()
                                           .Where(p => !p.IsDelete && p.UserId == userId)
                                           .Select(p => p.OrganizationId)
                                           .ToListAsync();

        if (organizationIds is not null && organizationIds.Any())
        {
            foreach (var organizationId in organizationIds)
            {
                if (await _context.Organizations.AsNoTracking().AnyAsync(p => !p.IsDelete && p.Id == organizationId && p.OrganizationType == Domain.Enums.Organization.OrganizationType.HealthCenter))
                {
                    OrganizationInfoState state = await _context.Organizations
                                                                .AsNoTracking()
                                                                .Where(p => !p.IsDelete && p.Id == organizationId && p.OrganizationType == Domain.Enums.Organization.OrganizationType.HealthCenter)
                                                                .Select(p => p.OrganizationInfoState)
                                                                .FirstOrDefaultAsync();

                    #region Health Center State 

                    //If Health Center Registers Now
                    if (state == OrganizationInfoState.JustRegister) model.HealthCenterInfoState = "NewUser";

                    //If Health Center State Is WatingForConfirm
                    if (state == OrganizationInfoState.WatingForConfirm) model.HealthCenterInfoState = "WatingForConfirm";

                    //If Health Center State Is Rejected
                    if (state == OrganizationInfoState.Rejected) model.HealthCenterInfoState = "Rejected";

                    //If Health Center State Is Accepted
                    if (state == OrganizationInfoState.Accepted) model.HealthCenterInfoState = "Accepted";

                    #endregion

                    return model;
                }
            }
        }

        #endregion

        return model;
    }

    #endregion
}
