#region Usings

using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Speciality;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Speciality;
using DoctorFAM.Domain.ViewModels.Site.Specialists;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Data.Repository;

#endregion

public class SpecialityRepository : ISpecialityRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public SpecialityRepository(DoctorFAMDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Admin Side

    //Is Exist Speciality By Speciality Id
    public async Task<bool> IsExistSpecialityBySpecialityId(ulong speciality)
    {
        return await _context.Specialities.AnyAsync(p => p.Id == speciality && !p.IsDelete);
    }

    //Check That Is Exist Any Speciality With This Unique Name 
    public async Task<bool> CheckThatExistAnySpecialityWithThisUniqueName(string uniqueName)
    {
        return await _context.Specialities.AnyAsync(p => p.UniqueName == uniqueName && !p.IsDelete);
    }

    //Check That Is Exist Any Speciality With This Unique Id 
    public async Task<bool> CheckThatExistAnySpecialityWithThisUniqueId(ulong uniqueId)
    {
        return await _context.Specialities.AnyAsync(p => p.UniqueId == uniqueId && !p.IsDelete);
    }

    //Get Speciality By Id 
    public async Task<Speciality?> GetSpecialityById(ulong specialityId)
    {
        return await _context.Specialities.Include(p => p.SpecialtiyInfo)
                    .FirstOrDefaultAsync(s => !s.IsDelete && s.Id == specialityId);
    }

    //List Of Specilaity Admin Side 
    public async Task<FilterSpecialityViewModel> ListOfSpecilaityAdminSide(FilterSpecialityViewModel filter)
    {
        var query = _context.SpecialtiyInfos
            .Include(a => a.Speciality)
            .ThenInclude(p => p.Parent)
            .OrderByDescending(s => s.CreateDate)
            .AsQueryable();

        #region Filter

        if (!string.IsNullOrEmpty(filter.UniqueName))
        {
            query = query.Where(s => EF.Functions.Like(s.Speciality.UniqueName, $"%{filter.UniqueName}%"));
        }

        if (!string.IsNullOrEmpty(filter.Title))
        {
            query = query.Where(s => EF.Functions.Like(s.Title, $"%{filter.Title}%"));
        }

        if (filter.ParentId != null)
        {
            query = query.Where(a => a.Speciality.ParentId == filter.ParentId);
            filter.ParentSpeciality = await _context.Specialities.FirstOrDefaultAsync(a => a.Id == filter.ParentId);
        }
        else
        {
            query = query.Where(a => a.Speciality.ParentId == null);
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    //Add Speciality To The Data Base 
    public async Task<ulong> AddSpecialityToTheDataBase(Speciality speciality)
    {
        #region Add speciality

        await _context.Specialities.AddAsync(speciality);
        await _context.SaveChangesAsync();

        #endregion

        return speciality.Id;
    }

    //Add Speciality Info To The Data Base
    public async Task AddSpecialityInfoToTheDataBase(List<SpecialtiyInfo> SpecialtiyInfo)
    {
        await _context.SpecialtiyInfos.AddRangeAsync(SpecialtiyInfo);
        await _context.SaveChangesAsync();
    }

    //Fill Edit Speciality View Model 
    public async Task<EditSpecialityViewModel?> FillEditSpecialityViewModel(ulong specialityId)
    {
        return await _context.Specialities
                        .Include(p => p.SpecialtiyInfo)
                        .Where(p => p.Id == specialityId && !p.IsDelete).Select(p => new EditSpecialityViewModel()
                        {
                            Id = p.Id,
                            UniqueName = p.UniqueName,
                            UniqueId = p.UniqueId,
                            ParentId = p.ParentId,
                            IsTitle = p.IsTitle,
                            IsSuperSpeciality = p.IsSuperSpecialty,
                            IsSpeciality = p.IsSpecialty,
                            CurrentInfos = p.SpecialtiyInfo.AsQueryable().IgnoreQueryFilters().ToList()
                        }).FirstOrDefaultAsync();
    }

    //Update Spaciality Admin Side 
    public void UpdateSpacialityAdminSide(Speciality speciality)
    {
        _context.Specialities.Update(speciality);
    }

    //Update Speciality Info Admin Side 
    public void UpdateSpecialityInfo(SpecialtiyInfo specialtiyInfo)
    {
        _context.SpecialtiyInfos.Update(specialtiyInfo);
    }

    //Save Changes
    public async Task Savechanges()
    {
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSpecialityInfo(ulong specialityId)
    {
        var specialityInfo = await _context.SpecialtiyInfos.Where(p => p.SpecialityId == specialityId).IgnoreQueryFilters().ToListAsync();

        if (specialityInfo != null && specialityInfo.Any())
        {
            foreach (var item in specialityInfo)
            {
                _context.SpecialtiyInfos.Remove(item);
            }
        }
    }

    public async Task<List<Speciality>> GetChildSpecialityByParentId(ulong parentId)
    {
        return await _context.Specialities.Where(p => !p.IsDelete && p.ParentId == parentId).ToListAsync();
    }

    public async Task DeleteSpeciality(Speciality speciality)
    {

        //Delete First PartOf speciality
        speciality.IsDelete = true;
        _context.Specialities.Update(speciality);

        //Delete First PartOf specialityInfo
        await DeleteSpecialityInfo(speciality.Id);

        //Get Seconde PartOf speciality
        var secondePartOfChild = await GetChildSpecialityByParentId(speciality.Id);

        if (secondePartOfChild != null && secondePartOfChild.Any())
        {
            foreach (var item in secondePartOfChild)
            {
                //Delete Seconde PartOf speciality
                item.IsDelete = true;
                _context.Specialities.Update(item);

                //Delete Seconde PartOf specialityInfo
                await DeleteSpecialityInfo(item.Id);

                //Get third PartOf speciality
                var thirdPartOfChild = await GetChildSpecialityByParentId(item.Id);

                //Delete third PartOf specialityInfo
                if (thirdPartOfChild != null && thirdPartOfChild.Any())
                {
                    foreach (var item2 in thirdPartOfChild)
                    {
                        //Delete third PartOf speciality
                        item2.IsDelete = true;
                        _context.Specialities.Update(item2);

                        //Delete third PartOf specialityInfo
                        await DeleteSpecialityInfo(item2.Id);
                    }
                }

            }
        }

        await _context.SaveChangesAsync();

    }

    //Get List Of Specialities 
    public async Task<List<SpecialtiyInfo>> GetListOfSpecialities()
    {
        return await _context.SpecialtiyInfos.Include(p => p.Speciality)
                                .Where(p => !p.IsDelete).ToListAsync();
    }

    #endregion

    #region Doctor Panel 

    //Get List Of Doctor's Specialities
    public async Task<List<ulong>?> GetListOfDoctorSpecialities(ulong userId)
    {
        return await _context.DoctorSelectedSpeciality.Where(p => !p.IsDelete && p.DoctorId == userId)
                                                                     .Select(p => p.SpecialityId).ToListAsync();
    }

    //Remove List Of User Seleted Specialities
    public async Task RemoveListOfUserSeletedSpecialities(List<DoctorSelectedSpeciality> doctorSelecteds)
    {
        _context.DoctorSelectedSpeciality.RemoveRange(doctorSelecteds);
        await _context.SaveChangesAsync();
    }

    //Get Docto Selected Specialities By User Id
    public async Task<List<DoctorSelectedSpeciality>?> GetDoctoSelectedSpecialitiesByUserId(ulong userid)
    {
        return await _context.DoctorSelectedSpeciality.Where(p => !p.IsDelete && p.DoctorId == userid).ToListAsync();
    }

    //Add Doctor Selected Speciality
    public async Task AddDoctorSelectedSpeciality(DoctorSelectedSpeciality speciality)
    {
        await _context.DoctorSelectedSpeciality.AddAsync(speciality);
    }

    #endregion

    #region Site Side 

    //List Of Specialists Site Side 
    public async Task<List<ListOfSpecialistsSiteSideViewModel>> ListOfSpecialistsSiteSide()
    {
        #region Get Super Specialists Records 

        List<ulong> superSpecialistsRecords = await _context.Specialities
                                                            .AsNoTracking()
                                                            .Where(p => !p.IsDelete && p.IsSpecialty)
                                                            .Select(p => p.Id)
                                                            .ToListAsync();

        #endregion

        #region Fill Model

        List<ListOfSpecialistsSiteSideViewModel> model = new List<ListOfSpecialistsSiteSideViewModel>();

        List<ulong> specialists = new List<ulong>();

        if (superSpecialistsRecords != null && superSpecialistsRecords.Any())
        {
            foreach (var superSpecialityId in superSpecialistsRecords)
            {
                List<ulong> doctorUsersIds = await _context.DoctorSelectedSpeciality
                                               .AsNoTracking()
                                               .Where(p => !p.IsDelete && p.SpecialityId == superSpecialityId)
                                               .Select(p => _context.Doctors
                                                                    .AsNoTracking()
                                                                    .Where(s => !s.IsDelete && s.Id == p.DoctorId)
                                                                    .Select(s => s.UserId)
                                                                    .FirstOrDefault())
                                               .ToListAsync();


                if (doctorUsersIds != null && doctorUsersIds.Any())
                {
                    foreach (var doctorUserId in doctorUsersIds)
                    {
                        if (model != null && model.Any())
                        {
                            if (!model.Any(p => p.DoctorUserInfo.UserId == doctorUserId))
                            {
                                ListOfSpecialistsSiteSideViewModel modelChild = new ListOfSpecialistsSiteSideViewModel()
                                {
                                    DoctorUserInfo = await _context.Users
                                                                                                                     .AsNoTracking()
                                                                                                                     .Where(p => !p.IsDelete && p.Id == doctorUserId)
                                                                                                                     .Select(p => new DoctorSpecialistUserInfoViewModel()
                                                                                                                     {
                                                                                                                         UserAvatar = p.Avatar,
                                                                                                                         UserId = p.Id,
                                                                                                                         Username = p.Username
                                                                                                                     })
                                                                                                                     .FirstOrDefaultAsync()
                                };

                                model.Add(modelChild);
                            }
                        }
                        else
                        {
                            ListOfSpecialistsSiteSideViewModel modelChild = new ListOfSpecialistsSiteSideViewModel()
                            {
                                DoctorUserInfo = await _context.Users
                                                                                      .AsNoTracking()
                                                                                      .Where(p => !p.IsDelete && p.Id == doctorUserId)
                                                                                      .Select(p => new DoctorSpecialistUserInfoViewModel()
                                                                                      {
                                                                                          UserAvatar = p.Avatar,
                                                                                          UserId = p.Id,
                                                                                          Username = p.Username
                                                                                      })
                                                                                      .FirstOrDefaultAsync()
                            };

                            model.Add(modelChild);
                        }

                    }
                }

            }
        }

        return model;

        #endregion

        return null;
    }

    //List Of Super Specialists 
    public async Task<List<ListOfSpecialistsSiteSideViewModel>> ListOfSuperSpecialists()
    {
        #region Get Super Specialists Records 

        List<ulong> superSpecialistsRecords = await _context.Specialities
                                                            .AsNoTracking()
                                                            .Where(p => !p.IsDelete && p.IsSuperSpecialty)
                                                            .Select(p => p.Id)
                                                            .ToListAsync();

        #endregion

        #region Fill Model

        List<ListOfSpecialistsSiteSideViewModel> model = new List<ListOfSpecialistsSiteSideViewModel>();

        List<ulong> specialists = new List<ulong>();

        if (superSpecialistsRecords != null && superSpecialistsRecords.Any())
        {
            foreach (var superSpecialityId in superSpecialistsRecords)
            {
                List<ulong> doctorUsersIds = await _context.DoctorSelectedSpeciality
                                               .AsNoTracking()
                                               .Where(p => !p.IsDelete && p.SpecialityId == superSpecialityId)
                                               .Select(p => _context.Doctors
                                                                    .AsNoTracking()
                                                                    .Where(s => !s.IsDelete && s.Id == p.DoctorId)
                                                                    .Select(s => s.UserId)
                                                                    .FirstOrDefault())
                                               .ToListAsync();


                if (doctorUsersIds != null && doctorUsersIds.Any())
                {
                    foreach (var doctorUserId in doctorUsersIds)
                    {
                        if (model != null && model.Any())
                        {
                            if (!model.Any(p => p.DoctorUserInfo.UserId == doctorUserId))
                            {
                                ListOfSpecialistsSiteSideViewModel modelChild = new ListOfSpecialistsSiteSideViewModel()
                                {
                                    DoctorUserInfo = await _context.Users
                                                                                                                     .AsNoTracking()
                                                                                                                     .Where(p => !p.IsDelete && p.Id == doctorUserId)
                                                                                                                     .Select(p => new DoctorSpecialistUserInfoViewModel()
                                                                                                                     {
                                                                                                                         UserAvatar = p.Avatar,
                                                                                                                         UserId = p.Id,
                                                                                                                         Username = p.Username
                                                                                                                     })
                                                                                                                     .FirstOrDefaultAsync()
                                };

                                model.Add(modelChild);
                            }
                        }
                        else
                        {
                            ListOfSpecialistsSiteSideViewModel modelChild = new ListOfSpecialistsSiteSideViewModel()
                            {
                                DoctorUserInfo = await _context.Users
                                                                                      .AsNoTracking()
                                                                                      .Where(p => !p.IsDelete && p.Id == doctorUserId)
                                                                                      .Select(p => new DoctorSpecialistUserInfoViewModel()
                                                                                      {
                                                                                          UserAvatar = p.Avatar,
                                                                                          UserId = p.Id,
                                                                                          Username = p.Username
                                                                                      })
                                                                                      .FirstOrDefaultAsync()
                            };

                            model.Add(modelChild);
                        }

                    }
                }

            }
        }

        return model;

        #endregion

        return null;
    }

    #endregion
}
