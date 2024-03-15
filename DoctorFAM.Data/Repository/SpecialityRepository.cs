#region Usings

using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Product;
using DoctorFAM.Domain.Entities.Speciality;
using DoctorFAM.Domain.Enums.Gender;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Speciality;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.Site.Specialists;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

    #region General 

    public async Task<List<ulong>> GetListOfSpecialitiesChildrenIds_BySpecialityParentId(ulong specialityParentId , 
                                                                                   CancellationToken cancellation)
    {
        return await _context.Specialities
                             .AsNoTracking()
                             .Where(p => !p.IsDelete &&
                                    p.ParentId == specialityParentId)
                             .Select(p => p.Id)
                             .ToListAsync();
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

    //تخصص ها 
    public async Task<List<Speciality>> GetChildJustSpecialityByParentId(ulong parentId)
    {
        return await _context.Specialities
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.ParentId == parentId && p.IsSpecialty)
                             .ToListAsync();
    }

    //فوق تخصص ها
    public async Task<List<Speciality>> GetChildJustSuperSpecialityByParentId(ulong parentId)
    {
        return await _context.Specialities
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.ParentId == parentId && p.IsSuperSpecialty)
                             .ToListAsync();
    }

    //فوق تخصص ها
    public async Task<List<SelectListViewModel>> GetChildJustSuperSpecialityByParentIdSelectListViewModel(ulong parentId)
    {
        return await _context.Specialities
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.ParentId == parentId && p.IsSuperSpecialty)
                            .Select(s => new SelectListViewModel
                            {
                                Id = s.Id,
                                Title = s.UniqueName
                            })
                            .ToListAsync();
    }

    //تخصص ها 
    public async Task<List<SelectListViewModel>> GetChildJustSpecialityByParentIdSelectListViewModel(ulong parentId)
    {
        return await _context.Specialities
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.ParentId == parentId && p.IsSpecialty)
                            .Select(s => new SelectListViewModel
                            {
                                Id = s.Id,
                                Title = s.UniqueName
                            })
                            .ToListAsync();
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

    public async Task<FilterSpecialistDoctorsSiteSideViewModel> FilterSpecialistDoctorsSiteSide(FilterSpecialistDoctorsSiteSideViewModel model, CancellationToken token)
    {
        #region Joins

        var user = _context.Users
                     .AsNoTracking()
                     .Where(s => !s.IsDelete &&
                            s.IsMobileConfirm)
                     .OrderByDescending(s => s.CreateDate)
                     .AsQueryable();

        var acceptedDoctor = _context.Organizations
                                           .AsNoTracking()
                                           .Where(p => !p.IsDelete &&
                                                  p.OrganizationInfoState == OrganizationInfoState.Accepted &&
                                                  p.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice)
                                           .AsQueryable();

        var doctorsInfos = _context.Doctors
                                  .AsNoTracking()
                                  .Include(p => p.DoctorsInfos)
                                  .Include(p => p.DoctorSelectedSpecialities)
                                  .Where(p => !p.IsDelete &&
                                         p.DoctorSelectedSpecialities.Any(s => s.DoctorId == p.Id))
                                  .Join(acceptedDoctor, d => d.UserId, o => o.OwnerId, (doctor, organization) =>
                                    new
                                    {
                                        doctorId = doctor.Id,
                                        userId = doctor.UserId,
                                        SpecialityName = doctor.DoctorsInfos.Specialty,
                                        PartyToTheContractWithTheFamilyDoctor = doctor.DoctorsInfos.ContractWithFamilyDoctors,
                                        Gender = doctor.DoctorsInfos.Gender,
                                        Education = doctor.DoctorsInfos.Education,
                                        Speciality = doctor.DoctorsInfos.Specialty,
                                        TitleName = doctor.DoctorsInfos.DoctorTilteName
                                    })
                                  .AsQueryable();



        #endregion

        #region Gender

        if (model.Gender.HasValue)
        {
            if (model.Gender.Value == 0) doctorsInfos = doctorsInfos.Where(p => p.Gender == Gender.Male);

            if (model.Gender.Value == 1) doctorsInfos = doctorsInfos.Where(p => p.Gender == Gender.Female);
        }

        #endregion

        #region Contract With Family Doctors

        if (model.IsContactPartyWithFamilyDoctors.HasValue)
        {
            if (model.IsContactPartyWithFamilyDoctors.Value == false) doctorsInfos = doctorsInfos.Where(p => !p.PartyToTheContractWithTheFamilyDoctor);

            if (model.IsContactPartyWithFamilyDoctors.Value == true) doctorsInfos = doctorsInfos.Where(p => p.PartyToTheContractWithTheFamilyDoctor);
        }

        #endregion

        #region Username 

        if (!string.IsNullOrEmpty(model.Username))
        {
            user = user.Where(s => s.Username.Contains(model.Username));
        }

        #endregion

        #region Country

        if (model.CountryId.HasValue)
        {
            user = _context.WorkAddresses
                           .AsNoTracking()
                           .Where(p => !p.IsDelete &&
                                  p.CountryId == model.CountryId.Value)
                            .Join(user, w => w.UserId, u => u.Id, (country, user) => user)
                            .Distinct();
        }

        #endregion

        #region State

        if (model.StateId.HasValue)
        {
            user = _context.WorkAddresses
                           .AsNoTracking()
                           .Where(p => !p.IsDelete &&
                                  p.StateId == model.StateId.Value)
                            .Join(user, w => w.UserId, u => u.Id, (state, user) => user)
                            .Distinct();
        }

        #endregion

        #region City

        if (model.CityId.HasValue)
        {
            user = _context.WorkAddresses
                           .AsNoTracking()
                           .Where(p => !p.IsDelete &&
                                  p.CityId == model.CityId.Value)
                            .Join(user, w => w.UserId, u => u.Id, (city, user) => user)
                            .Distinct();
        }

        #endregion

        var returnModel = user.Join(doctorsInfos, u => u.Id, d => d.userId, (user, doctor) =>
                             new Specialist
                             {
                                 DoctorId = doctor.doctorId,
                                 PartyToTheContractWithTheFamilyDoctor = doctor.PartyToTheContractWithTheFamilyDoctor,
                                 SpecialityName = doctor.SpecialityName,
                                 UserAvatar = user.Avatar,
                                 UserId = user.Id,
                                 Username = user.Username,
                                 Gender = doctor.Gender,
                                 Specialty = doctor.Speciality,
                                 Education = doctor.Education,
                                 DoctorTitleName = doctor.TitleName
                             });


        await model.Paging(returnModel);

        return model;
    }

    //List Of Specialists Site Side 
    public async Task<List<ListOfSpecialistsSiteSideViewModel>> ListOfSpecialistsSiteSide(FilterFamilyDoctorUserPanelSideViewModel filter)
    {
        #region Get Super Specialists Records 

        List<ulong> superSpecialistsRecords = new();

        if (filter.specificId.HasValue)
        {
            superSpecialistsRecords = await _context.Specialities
                                                                      .AsNoTracking()
                                                                      .Where(p => !p.IsDelete && p.Id == filter.specificId.Value)
                                                                      .Select(p => p.Id)
                                                                      .ToListAsync();
        }
        else
        {
            superSpecialistsRecords = await _context.Specialities
                                                                      .AsNoTracking()
                                                                      .Where(p => !p.IsDelete && p.IsSpecialty)
                                                                      .Select(p => p.Id)
                                                                      .ToListAsync();
        }

        #endregion

        #region Fill Model

        List<ListOfSpecialistsSiteSideViewModel> model = new List<ListOfSpecialistsSiteSideViewModel>();

        List<ulong> specialists = new List<ulong>();

        if (superSpecialistsRecords != null && superSpecialistsRecords.Any())
        {
            foreach (var superSpecialityId in superSpecialistsRecords)
            {
                List<ListOfDoctorIdAndDoctorUserId> doctorIds = await _context.DoctorSelectedSpeciality
                                               .AsNoTracking()
                                               .Where(p => !p.IsDelete && p.SpecialityId == superSpecialityId)
                                               .Select(p => new ListOfDoctorIdAndDoctorUserId()
                                               {
                                                   DoctorUserId = _context.Doctors
                                                                    .AsNoTracking()
                                                                    .Where(s => !s.IsDelete && s.Id == p.DoctorId)
                                                                    .Select(s => s.UserId)
                                                                    .FirstOrDefault(),
                                                   DoctorId = p.DoctorId
                                               })
                                               .ToListAsync();


                if (doctorIds != null && doctorIds.Any())
                {
                    foreach (var doctorId in doctorIds)
                    {
                        if (model != null && model.Any())
                        {
                            if (!model.Any(p => p.DoctorUserInfo.UserId == doctorId.DoctorUserId))
                            {
                                ListOfSpecialistsSiteSideViewModel modelChild = new ListOfSpecialistsSiteSideViewModel()
                                {
                                    DoctorUserInfo = await _context.Users.Include(p => p.Doctors).ThenInclude(p => p.DoctorsInfos)
                                                                                                                     .AsNoTracking()
                                                                                                                     .Where(p => !p.IsDelete && p.Id == doctorId.DoctorUserId)
                                                                                                                     .Select(p => new DoctorSpecialistUserInfoViewModel()
                                                                                                                     {
                                                                                                                         UserAvatar = p.Avatar,
                                                                                                                         UserId = p.Id,
                                                                                                                         Username = p.Username,
                                                                                                                         DoctorTilteName = _context.DoctorsInfos
                                                                                                                                                   .AsNoTracking()
                                                                                                                                                   .Where(p => !p.IsDelete && p.DoctorId == doctorId.DoctorId)
                                                                                                                                                   .Select(p => p.DoctorTilteName)
                                                                                                                                                   .FirstOrDefault(),
                                                                                                                         doctorsInfo = p.Doctors.DoctorsInfos
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
                                DoctorUserInfo = await _context.Users.Include(p => p.Doctors).ThenInclude(p => p.DoctorsInfos)
                                                                                      .AsNoTracking()
                                                                                      .Where(p => !p.IsDelete && p.Id == doctorId.DoctorUserId)
                                                                                      .Select(p => new DoctorSpecialistUserInfoViewModel()
                                                                                      {
                                                                                          UserAvatar = p.Avatar,
                                                                                          UserId = p.Id,
                                                                                          Username = p.Username,
                                                                                          DoctorTilteName = _context.DoctorsInfos
                                                                                                                                                   .AsNoTracking()
                                                                                                                                                   .Where(p => !p.IsDelete && p.DoctorId == doctorId.DoctorId)
                                                                                                                                                   .Select(p => p.DoctorTilteName)
                                                                                                                                                   .FirstOrDefault(),
                                                                                          doctorsInfo = p.Doctors.DoctorsInfos
                                                                                      })
                                                                                      .FirstOrDefaultAsync()
                            };

                            model.Add(modelChild);
                        }

                    }
                }

            }
        }

        if (filter.Gender.HasValue)
        {
            if (filter.Gender.Value == 0)
            {
                model = model.Where(p => p.DoctorUserInfo.doctorsInfo.Gender == Domain.Enums.Gender.Gender.Male).ToList();
            }
            if (filter.Gender.Value == 1)
            {
                model = model.Where(p => p.DoctorUserInfo.doctorsInfo.Gender == Domain.Enums.Gender.Gender.Female).ToList();
            }
        }

        if (filter.IsContactPartyWithFamilyDoctors.HasValue)
        {
            if (filter.IsContactPartyWithFamilyDoctors.Value == false)
            {
                model = model.Where(p => !p.DoctorUserInfo.doctorsInfo.ContractWithFamilyDoctors).ToList();
            }
            else
            {
                model = model.Where(p => p.DoctorUserInfo.doctorsInfo.ContractWithFamilyDoctors).ToList();
            }
        }

        if (!string.IsNullOrEmpty(filter.Username))
        {
            model = model.Where(s => s.DoctorUserInfo.Username.Contains(filter.Username)).ToList();
        }

        if (filter.CountryId.HasValue)
        {
            List<ListOfSpecialistsSiteSideViewModel?> CountryModel = new List<ListOfSpecialistsSiteSideViewModel?>();

            foreach (var item in model.Select(p => p.DoctorUserInfo.UserId))
            {
                var address = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == item && p.CountryId == filter.CountryId.Value);

                if (address != null)
                {
                    ListOfSpecialistsSiteSideViewModel modelChild = new ListOfSpecialistsSiteSideViewModel()
                    {
                        DoctorUserInfo = await _context.Users.Include(p => p.Doctors).ThenInclude(p => p.DoctorsInfos)
                                                                                                                      .AsNoTracking()
                                                                                                                      .Where(p => !p.IsDelete && p.Id == address.UserId)
                                                                                                                      .Select(p => new DoctorSpecialistUserInfoViewModel()
                                                                                                                      {
                                                                                                                          UserAvatar = p.Avatar,
                                                                                                                          UserId = p.Id,
                                                                                                                          Username = p.Username,
                                                                                                                          DoctorTilteName = p.Doctors.DoctorsInfos.DoctorTilteName,
                                                                                                                          doctorsInfo = p.Doctors.DoctorsInfos
                                                                                                                      })
                                                                                                                      .FirstOrDefaultAsync()
                    };

                    CountryModel.Add(modelChild);
                }
            }

            model = CountryModel;
        }

        if (filter.StateId.HasValue)
        {
            List<ListOfSpecialistsSiteSideViewModel?> StateModel = new List<ListOfSpecialistsSiteSideViewModel?>();

            foreach (var item in model.Select(p => p.DoctorUserInfo.UserId))
            {
                var address = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == item && p.StateId == filter.StateId.Value);

                if (address != null)
                {
                    ListOfSpecialistsSiteSideViewModel modelChild = new ListOfSpecialistsSiteSideViewModel()
                    {
                        DoctorUserInfo = await _context.Users.Include(p => p.Doctors).ThenInclude(p => p.DoctorsInfos)
                                                                                                                     .AsNoTracking()
                                                                                                                     .Where(p => !p.IsDelete && p.Id == address.UserId)
                                                                                                                     .Select(p => new DoctorSpecialistUserInfoViewModel()
                                                                                                                     {
                                                                                                                         UserAvatar = p.Avatar,
                                                                                                                         UserId = p.Id,
                                                                                                                         Username = p.Username,
                                                                                                                         DoctorTilteName = p.Doctors.DoctorsInfos.DoctorTilteName,
                                                                                                                         doctorsInfo = p.Doctors.DoctorsInfos
                                                                                                                     })
                                                                                                                     .FirstOrDefaultAsync()
                    };

                    StateModel.Add(modelChild);
                }
            }

            model = StateModel;
        }

        if (filter.CityId.HasValue)
        {
            List<ListOfSpecialistsSiteSideViewModel?> CityModel = new List<ListOfSpecialistsSiteSideViewModel?>();

            foreach (var item in model.Select(p => p.DoctorUserInfo.UserId))
            {
                var address = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == item && p.CityId == filter.CityId.Value);

                if (address != null)
                {
                    ListOfSpecialistsSiteSideViewModel modelChild = new ListOfSpecialistsSiteSideViewModel()
                    {
                        DoctorUserInfo = await _context.Users.Include(p => p.Doctors).ThenInclude(p => p.DoctorsInfos)
                                                                                                                    .AsNoTracking()
                                                                                                                    .Where(p => !p.IsDelete && p.Id == address.UserId)
                                                                                                                    .Select(p => new DoctorSpecialistUserInfoViewModel()
                                                                                                                    {
                                                                                                                        UserAvatar = p.Avatar,
                                                                                                                        UserId = p.Id,
                                                                                                                        Username = p.Username,
                                                                                                                        DoctorTilteName = p.Doctors.DoctorsInfos.DoctorTilteName,
                                                                                                                        doctorsInfo = p.Doctors.DoctorsInfos
                                                                                                                    })
                                                                                                                    .FirstOrDefaultAsync()
                    };

                    CityModel.Add(modelChild);
                }
            }

            model = CityModel;
        }

        return model;

        #endregion
    }



    //List Of Super Specialists 
    public async Task<List<ListOfSpecialistsSiteSideViewModel>> ListOfSuperSpecialists(FilterFamilyDoctorUserPanelSideViewModel filter)
    {
        #region Get Super Specialists Records 

        List<ulong> superSpecialistsRecords = new();

        if (filter.specificId.HasValue)
        {
            superSpecialistsRecords = await _context.Specialities
                                                                      .AsNoTracking()
                                                                      .Where(p => !p.IsDelete && p.Id == filter.specificId.Value)
                                                                      .Select(p => p.Id)
                                                                      .ToListAsync();
        }
        else
        {
            superSpecialistsRecords = await _context.Specialities
                                                                      .AsNoTracking()
                                                                      .Where(p => !p.IsDelete && p.IsSuperSpecialty)
                                                                      .Select(p => p.Id)
                                                                      .ToListAsync();
        }

        #endregion

        #region Fill Model

        List<ListOfSpecialistsSiteSideViewModel> model = new List<ListOfSpecialistsSiteSideViewModel>();

        List<ulong> specialists = new List<ulong>();

        if (superSpecialistsRecords != null && superSpecialistsRecords.Any())
        {
            foreach (var superSpecialityId in superSpecialistsRecords)
            {
                List<ListOfDoctorIdAndDoctorUserId> doctorIds = await _context.DoctorSelectedSpeciality
                                               .AsNoTracking()
                                               .Where(p => !p.IsDelete && p.SpecialityId == superSpecialityId)
                                               .Select(p => new ListOfDoctorIdAndDoctorUserId()
                                               {
                                                   DoctorUserId = _context.Doctors
                                                                    .AsNoTracking()
                                                                    .Where(s => !s.IsDelete && s.Id == p.DoctorId)
                                                                    .Select(s => s.UserId)
                                                                    .FirstOrDefault(),
                                                   DoctorId = p.DoctorId
                                               })
                                               .ToListAsync();


                if (doctorIds != null && doctorIds.Any())
                {
                    foreach (var doctorId in doctorIds)
                    {
                        if (model != null && model.Any())
                        {
                            if (!model.Any(p => p.DoctorUserInfo.UserId == doctorId.DoctorUserId))
                            {
                                ListOfSpecialistsSiteSideViewModel modelChild = new ListOfSpecialistsSiteSideViewModel()
                                {
                                    DoctorUserInfo = await _context.Users.Include(p => p.Doctors).ThenInclude(p => p.DoctorsInfos)
                                                                                                                     .AsNoTracking()
                                                                                                                     .Where(p => !p.IsDelete && p.Id == doctorId.DoctorUserId)
                                                                                                                     .Select(p => new DoctorSpecialistUserInfoViewModel()
                                                                                                                     {
                                                                                                                         UserAvatar = p.Avatar,
                                                                                                                         UserId = p.Id,
                                                                                                                         Username = p.Username,
                                                                                                                         DoctorTilteName = _context.DoctorsInfos
                                                                                                                                                   .AsNoTracking()
                                                                                                                                                   .Where(p => !p.IsDelete && p.DoctorId == doctorId.DoctorId)
                                                                                                                                                   .Select(p => p.DoctorTilteName)
                                                                                                                                                   .FirstOrDefault(),
                                                                                                                         doctorsInfo = p.Doctors.DoctorsInfos
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
                                DoctorUserInfo = await _context.Users.Include(p => p.Doctors).ThenInclude(p => p.DoctorsInfos)
                                                                                      .AsNoTracking()
                                                                                      .Where(p => !p.IsDelete && p.Id == doctorId.DoctorUserId)
                                                                                      .Select(p => new DoctorSpecialistUserInfoViewModel()
                                                                                      {
                                                                                          UserAvatar = p.Avatar,
                                                                                          UserId = p.Id,
                                                                                          Username = p.Username,
                                                                                          DoctorTilteName = _context.DoctorsInfos
                                                                                                                                                   .AsNoTracking()
                                                                                                                                                   .Where(p => !p.IsDelete && p.DoctorId == doctorId.DoctorId)
                                                                                                                                                   .Select(p => p.DoctorTilteName)
                                                                                                                                                   .FirstOrDefault(),
                                                                                          doctorsInfo = p.Doctors.DoctorsInfos
                                                                                      })
                                                                                      .FirstOrDefaultAsync()
                            };

                            model.Add(modelChild);
                        }

                    }
                }

            }
        }

        if (filter.Gender.HasValue)
        {
            if (filter.Gender.Value == 0)
            {
                model = model.Where(p => p.DoctorUserInfo.doctorsInfo.Gender == Domain.Enums.Gender.Gender.Male).ToList();
            }
            if (filter.Gender.Value == 1)
            {
                model = model.Where(p => p.DoctorUserInfo.doctorsInfo.Gender == Domain.Enums.Gender.Gender.Female).ToList();
            }
        }

        if (filter.IsContactPartyWithFamilyDoctors.HasValue)
        {
            if (filter.IsContactPartyWithFamilyDoctors.Value == false)
            {
                model = model.Where(p => !p.DoctorUserInfo.doctorsInfo.ContractWithFamilyDoctors).ToList();
            }
            else
            {
                model = model.Where(p => p.DoctorUserInfo.doctorsInfo.ContractWithFamilyDoctors).ToList();
            }
        }

        if (!string.IsNullOrEmpty(filter.Username))
        {
            model = model.Where(s => s.DoctorUserInfo.Username.Contains(filter.Username)).ToList();
        }

        if (filter.CountryId.HasValue)
        {
            List<ListOfSpecialistsSiteSideViewModel?> CountryModel = new List<ListOfSpecialistsSiteSideViewModel?>();

            foreach (var item in model.Select(p => p.DoctorUserInfo.UserId))
            {
                var address = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == item && p.CountryId == filter.CountryId.Value);

                if (address != null)
                {
                    ListOfSpecialistsSiteSideViewModel modelChild = new ListOfSpecialistsSiteSideViewModel()
                    {
                        DoctorUserInfo = await _context.Users.Include(p => p.Doctors).ThenInclude(p => p.DoctorsInfos)
                                                                                                                      .AsNoTracking()
                                                                                                                      .Where(p => !p.IsDelete && p.Id == address.UserId)
                                                                                                                      .Select(p => new DoctorSpecialistUserInfoViewModel()
                                                                                                                      {
                                                                                                                          UserAvatar = p.Avatar,
                                                                                                                          UserId = p.Id,
                                                                                                                          Username = p.Username,
                                                                                                                          DoctorTilteName = p.Doctors.DoctorsInfos.DoctorTilteName,
                                                                                                                          doctorsInfo = p.Doctors.DoctorsInfos
                                                                                                                      })
                                                                                                                      .FirstOrDefaultAsync()
                    };

                    CountryModel.Add(modelChild);
                }
            }

            model = CountryModel;
        }

        if (filter.StateId.HasValue)
        {
            List<ListOfSpecialistsSiteSideViewModel?> StateModel = new List<ListOfSpecialistsSiteSideViewModel?>();

            foreach (var item in model.Select(p => p.DoctorUserInfo.UserId))
            {
                var address = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == item && p.StateId == filter.StateId.Value);

                if (address != null)
                {
                    ListOfSpecialistsSiteSideViewModel modelChild = new ListOfSpecialistsSiteSideViewModel()
                    {
                        DoctorUserInfo = await _context.Users.Include(p => p.Doctors).ThenInclude(p => p.DoctorsInfos)
                                                                                                                     .AsNoTracking()
                                                                                                                     .Where(p => !p.IsDelete && p.Id == address.UserId)
                                                                                                                     .Select(p => new DoctorSpecialistUserInfoViewModel()
                                                                                                                     {
                                                                                                                         UserAvatar = p.Avatar,
                                                                                                                         UserId = p.Id,
                                                                                                                         Username = p.Username,
                                                                                                                         DoctorTilteName = p.Doctors.DoctorsInfos.DoctorTilteName,
                                                                                                                         doctorsInfo = p.Doctors.DoctorsInfos
                                                                                                                     })
                                                                                                                     .FirstOrDefaultAsync()
                    };

                    StateModel.Add(modelChild);
                }
            }

            model = StateModel;
        }

        if (filter.CityId.HasValue)
        {
            List<ListOfSpecialistsSiteSideViewModel?> CityModel = new List<ListOfSpecialistsSiteSideViewModel?>();

            foreach (var item in model.Select(p => p.DoctorUserInfo.UserId))
            {
                var address = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == item && p.CityId == filter.CityId.Value);

                if (address != null)
                {
                    ListOfSpecialistsSiteSideViewModel modelChild = new ListOfSpecialistsSiteSideViewModel()
                    {
                        DoctorUserInfo = await _context.Users.Include(p => p.Doctors).ThenInclude(p => p.DoctorsInfos)
                                                                                                                    .AsNoTracking()
                                                                                                                    .Where(p => !p.IsDelete && p.Id == address.UserId)
                                                                                                                    .Select(p => new DoctorSpecialistUserInfoViewModel()
                                                                                                                    {
                                                                                                                        UserAvatar = p.Avatar,
                                                                                                                        UserId = p.Id,
                                                                                                                        Username = p.Username,
                                                                                                                        DoctorTilteName = p.Doctors.DoctorsInfos.DoctorTilteName,
                                                                                                                        doctorsInfo = p.Doctors.DoctorsInfos
                                                                                                                    })
                                                                                                                    .FirstOrDefaultAsync()
                    };

                    CityModel.Add(modelChild);
                }
            }

            model = CityModel;
        }

        return model;

        #endregion
    }

    //Get List Of General Title Specialities
    public async Task<List<Speciality>> GetListOfGeneralTitleSpecialities()
    {
        return await _context.Specialities
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.IsTitle && !p.IsSpecialty && !p.IsSuperSpecialty)
                             .ToListAsync();
    }

    #endregion
}
