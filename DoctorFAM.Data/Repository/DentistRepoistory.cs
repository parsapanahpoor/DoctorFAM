#region Usings

using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Dentist;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Dentist;
using DoctorFAM.Domain.ViewModels.Dentist.NavBar;
using DoctorFAM.Domain.ViewModels.Dentist.SideBar;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DosctorSideBarInfo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.NetworkInformation;


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

    //Save Changes
    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

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

    //Add Dentist
    public async Task<ulong> AddDentist(Dentist dentist)
    {
        await _context.Dentist.AddAsync(dentist);
        await _context.SaveChangesAsync();

        return dentist.Id;
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

    //Get List Of Dentist Skills By Dentist Id
    public async Task<List<DentistsSkills>> GetListOfDentistSkillsByDentistUserId(ulong dentistUserId)
    {
        return await _context.DentistsSkills
                             .AsNoTracking() 
                             .Where(p => p.UserId == dentistUserId && !p.IsDelete)
                             .ToListAsync();
    }

    //Get Dentist Id By User Id
    public async Task<ulong> GetDentistIdByUserId(ulong userId)
    {
        return await _context.Dentist
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.UserId == userId)
                             .Select(p => p.Id)
                             .FirstOrDefaultAsync();
    }

    //Remove Dentist Skills Without Save Changes 
    public void RemoveDentistSkillsWithoutSaveChanges(List<DentistsSkills> skills)
    {
        _context.DentistsSkills.RemoveRange(skills);
    }

    //Add Dentist Skills Without Save Changes 
    public async Task AddDentistSkillsWithoutSaveChanges(DentistsSkills skills)
    {
        await _context.DentistsSkills.AddRangeAsync(skills);
    }

    //Update Dentist Infos Without Save Changes 
    public void UpdateDentistInfosWithoutSaveChanges(DentistsInfo info)
    {
        _context.DentistInfo.Update(info);
    }

    //Get Dentist's Free SMS Count
    public async Task<int> GetDentistsFreeSMSCount()
    {
        return await _context.SiteSettings
                             .AsNoTracking()
                             .Where(p => !p.IsDelete)
                             .Select(p => p.CountOFFreeSMSForDoctors)
                             .FirstOrDefaultAsync();
    }

    //Add Dentist Info Without Save Changes
    public async Task AddDentistInfoWithoutSaveChanges(DentistsInfo info)
    {
        await _context.DentistInfo.AddAsync(info);
    }


    #endregion

    #region Admin Side 

    //Get List Of Dentist For Show Admin Panel 
    public async Task<List<ListOfDentistAdminSideViewModel>?> GetListOfDentistForShowAdminPanel()
    {
        return await _context.Organizations
                             .AsNoTracking()
                             .Where(p=> !p.IsDelete && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DentistOffice)
                             .OrderByDescending(p=> p.CreateDate)
                             .Select(p=> new ListOfDentistAdminSideViewModel()
                             {
                                 organizationmState = p.OrganizationInfoState,
                                 User = _context.Users
                                                .AsNoTracking()
                                                .Where(s=> !s.IsDelete && s.Id == p.OwnerId)
                                                .Select(s=> new DentistUsersAdminSideViewModel()
                                                {
                                                    ActiveSatte = s.IsMobileConfirm,
                                                    Email = s.Email,
                                                    EmailState = s.IsEmailConfirm,
                                                    Mobile = s.Mobile,
                                                    MobileState = s.IsMobileConfirm,
                                                    RegisterDate = s.CreateDate,
                                                    UserId = s.Id,
                                                    Username = s.Username,
                                                    UserAvatar = s.Avatar
                                                })
                                                .FirstOrDefault()
                             })
                             .ToListAsync();
    }

    #endregion
}
