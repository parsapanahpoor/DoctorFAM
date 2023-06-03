#region Usings

using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Dentist;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Dentist.NavBar;
using DoctorFAM.Domain.ViewModels.Dentist.SideBar;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DosctorSideBarInfo;
using Microsoft.EntityFrameworkCore;


#endregion

namespace DoctorFAM.Data.Repository;

public class DentistRepoistory : IDentistRepoistory
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public DentistRepoistory(DoctorFAMDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Dentist Panel 

    //Is Exist Any Dentist By User Id
    public async Task<bool> IsExistAnyDentistByUserId(ulong userId)
    {
        return await _context.Dentist.AsNoTracking()
                                .AnyAsync(p => p.UserId == userId && !p.IsDelete);
    }

    //Add Dentist Without Save Changes
    public async Task AddDentistWithoutSaveChanges(Dentist dentist)
    {
        await _context.Dentist.AddAsync(dentist);
    }

    //Fill Dentist NavBar Info 
    public async Task<DentistPanelNavNarViewModel?> FillDentistPanelNavNarViewModel(ulong userId)
    {
        return await _context.Users
                              .AsNoTracking()
                              .Where(p => !p.IsDelete && p.Id == userId)
                              .Select(p => new DentistPanelNavNarViewModel()
                              {
                                  UserId = userId,
                                  UserAvatar = p.Avatar,
                                  UserBalance = p.WalletBalance,
                                  Username = p.Username
                              })
                              .FirstOrDefaultAsync();
    }

    //Fill Dentist Side Bar Panel 
    public async Task<DentistSideBarViewModel> GetDentistSideBarInfo(ulong userId)
    {
        DentistSideBarViewModel model = new DentistSideBarViewModel();

        #region Get Doctor Office

        var organizationIds = await _context.OrganizationMembers
                                           .AsNoTracking()
                                           .Where(p => !p.IsDelete && p.UserId == userId)
                                           .Select(p => p.OrganizationId)
                                           .ToListAsync();

        if (organizationIds is not null && organizationIds.Any())
        {
            foreach (var organizationId in organizationIds)
            {
                if (await _context.Organizations.AsNoTracking().AnyAsync(p => !p.IsDelete && p.Id == organizationId && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DentistOffice))
                {
                    OrganizationInfoState state = await _context.Organizations
                                                                .AsNoTracking()
                                                                .Where(p => !p.IsDelete && p.Id == organizationId && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DentistOffice)
                                                                .Select(p => p.OrganizationInfoState)
                                                                .FirstOrDefaultAsync();

                    #region Dentist State 

                    //If Dentist Registers Now
                    if (state == OrganizationInfoState.JustRegister) model.DentistInfoState = "NewUser";

                    //If Dentist State Is WatingForConfirm
                    if (state == OrganizationInfoState.WatingForConfirm) model.DentistInfoState = "WatingForConfirm";

                    //If Dentist State Is Rejected
                    if (state == OrganizationInfoState.Rejected) model.DentistInfoState = "Rejected";

                    //If Dentist State Is Accepted
                    if (state == OrganizationInfoState.Accepted) model.DentistInfoState = "Accepted";

                    #endregion

                    return model;
                }
            }
        }

        #endregion

        return model;
    }

    //Is Exist Any Dentist Info By UserId
    public async Task<bool> IsExistAnyDentistInfoByUserId(ulong userId)
    {
        return await _context.DentistInfo
                             .AsNoTracking()
                             .AnyAsync(p => !p.IsDelete && p.UserId == userId);
    }

    //Get Doctors Information By UserId
    public async Task<DentistsInfo?> GetDentistsInformationByUserId(ulong userId)
    {
        return await _context.DentistInfo
                             .AsNoTracking() 
                             .FirstOrDefaultAsync(p => p.UserId == userId && !p.IsDelete);
    }

    #endregion
}
