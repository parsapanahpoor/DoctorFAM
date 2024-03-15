using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.HealthCenters;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.DoctorPanel.HealthCenters;
using DoctorFAM.Domain.ViewModels.HealthCenters.HealthCenterMembers;
using DoctorFAM.Domain.ViewModels.HealthCenters.SideBar;
using DoctorFAM.Domain.ViewModels.Site.HealthCenters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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

    #region General

    public async Task<bool> IsHealthCenter_AcceptedAndExist(ulong healthCenterId , 
                                                            CancellationToken cancellationToken)
    {
        //Get Health Center OwnerId 
        var ownerId = await _context.HealthCenters
                                    .AsNoTracking()
                                    .Where(p => !p.IsDelete && 
                                           p.Id == healthCenterId)
                                    .Select(p=> p.UserId)
                                    .FirstOrDefaultAsync();

        if (ownerId == null || ownerId == 0) return false;

        return await _context.Organizations
                             .AsNoTracking()
                             .AnyAsync(p=> !p.IsDelete && 
                                       p.OwnerId == ownerId && 
                                       p.OrganizationInfoState == OrganizationInfoState.Accepted &&
                                       p.OrganizationType == Domain.Enums.Organization.OrganizationType.HealthCenter);
    }

    public async Task<ulong> GetHealthCenterOwnerUserIdByHealthCenterId(ulong healthCenterId)
    {
        return await _context.HealthCenters
                             .AsNoTracking()
                             .Where(p => !p.IsDelete &&
                                    p.Id == healthCenterId)
                             .Select(p => p.UserId)
                             .FirstOrDefaultAsync();
    }

    public async Task<string?> GetHealthCenterNameByHealthCenterId(ulong healthCenterId)
    {
        return await _context.HealthCentersInfos
                             .AsNoTracking()
                             .Where(p => !p.IsDelete &&
                                    p.HealthCenterId == healthCenterId)
                             .Select(p => p.HealthCenterName)
                             .FirstOrDefaultAsync();
    }

    public async Task<bool> IsExistAnyDoctorSelectedHealthCenterRecordByDoctorUserIdAndHealthCenterId(ulong healthCenterId, ulong doctorUserId)
    {
        return await _context.DoctorSelectedHealthCenters
                             .AsNoTracking()
                             .AnyAsync(p => !p.IsDelete &&
                                       p.HealthCenterId == healthCenterId &&
                                       p.ApplicantUserId == doctorUserId &&
                                       p.DoctorSelectedHealthCenterState != Domain.Enums.HealthCenter.DoctorSelectedHealthCenterState.Decline);
    }

    public async Task<bool> IsExistAnyHealthCenterById(ulong id)
    {
        return await _context.HealthCenters
                             .AsNoTracking()
                             .AnyAsync(p => !p.IsDelete &&
                                       p.Id == id);
    }

    public async Task AddDoctorSelectedHealthCenter(DoctorSelectedHealthCenter doctorSelectedHealth)
    {
        await _context.DoctorSelectedHealthCenters.AddAsync(doctorSelectedHealth);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
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

    //Get QueryAble OF Health Centers
    public IQueryable<Organization> GetQueryAbleOFHealthCenters()
    {
        return _context.Organizations
                        .Where(s => !s.IsDelete &&
                               s.OrganizationType == Domain.Enums.Organization.OrganizationType.HealthCenter)
                        .Include(p => p.User)
                        .OrderByDescending(s => s.CreateDate)
                        .AsQueryable();
    }

    //Get Health Center By User Id
    public IQueryable<HealthCenter> GetHealthCenterByUserIdAsQueryAble(ulong userId)
    {
        return _context.HealthCenters
                       .Where(p => !p.IsDelete && p.UserId == userId)
                       .AsQueryable();
    }

    //Get Health Center Info By Health Center Id
    public IQueryable<HealthCentersInfo>? GetHealthCenterInfoByHealthCenterIdAsQueryAble(ulong HealthCenterId)
    {
        return _context.HealthCentersInfos
                .Where(p => !p.IsDelete && p.HealthCenterId == HealthCenterId)
                             .AsQueryable();
    }

    //Get Health Center By Health Center Id 
    public IQueryable<HealthCenter> GetHealthCenterByHealthCenterId(ulong healthCenterId)
    {
        return _context.HealthCenters
                       .AsNoTracking()
                       .Where(p => !p.IsDelete & p.Id == healthCenterId)
                       .AsQueryable();
    }

    //Get Health Center By Health Center Id
    public IQueryable<HealthCenter?> GetHealthCenterById(ulong id)
    {
        return _context.HealthCenters
                        .Where(p => !p.IsDelete && p.Id == id)
                        .AsQueryable();
    }

    //Get Health Center By Health Center Id
    public async Task<HealthCenter?> GetHealthCenterByIdAsync(ulong id)
    {
        return await _context.HealthCenters
                        .Where(p => !p.IsDelete && p.Id == id)
                        .FirstOrDefaultAsync();
    }


    //Get Health Center By Health Center User Id
    public Task<HealthCenter?> GetHealthCenterByUserId(ulong userId)
    {
        return _context.HealthCenters
                       .Where(p => !p.IsDelete && p.UserId == userId)
                       .FirstOrDefaultAsync();
    }

    //Update Method 
    public void UpdateHealthCenterInfo(HealthCentersInfo model)
    {
        _context.HealthCentersInfos.Update(model);
    }

    //Update Method 
    public async Task AddHealthCenterInfo(HealthCentersInfo model)
    {
        await _context.HealthCentersInfos.AddAsync(model);
    }

    //Is Exist Any Health Center Info By UserId
    public IQueryable<HealthCentersInfo> IsExistAnyHealthCenterInfoByUserId(ulong userId)
    {
        return _context.HealthCentersInfos
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.UserId == userId)
                             .AsQueryable();
    }

    //Get Health Centers Information By UserId
    public IQueryable<HealthCentersInfo?> GetHealthCentersInformationByUserId(ulong userId)
    {
        return _context.HealthCentersInfos
                             .AsNoTracking()
                             .Where(p => p.UserId == userId && !p.IsDelete)
                             .AsQueryable();
    }

    //Add Health Center With Returning Id 
    public async Task<ulong> AddHealthCenterWithReturningId(HealthCenter healthCenter)
    {
        await _context.HealthCenters.AddAsync(healthCenter);
        await SaveChangesAsync();

        return healthCenter.Id;
    }

    public async Task<FilterHealthcenterMembersDTO> FilterHealthcenterMembers(FilterHealthcenterMembersDTO model, ulong healthCenterId, CancellationToken cancellationToken)
    {
        var query = _context.DoctorSelectedHealthCenters
                      .AsNoTracking()
                      .Where(p => !p.IsDelete &&
                             p.HealthCenterId == healthCenterId &&
                             p.DoctorSelectedHealthCenterState != Domain.Enums.HealthCenter.DoctorSelectedHealthCenterState.Decline)
                      .OrderByDescending(p => p.CreateDate)
                      .AsQueryable();

        var users = _context.Users
                                  .AsNoTracking()
                                  .Where(p => !p.IsDelete)
                                  .AsQueryable();

        var returnModel = from q in query
                          join u in users
                          on q.ApplicantUserId equals u.Id
                          select new ListOFHealthMembersDTO
                          {
                              DoctorSelectedHealthCenterState = q.DoctorSelectedHealthCenterState,
                              Mobile = u.Mobile,
                              StartDate = q.CreateDate,
                              UserAvatar = u.Avatar,
                              Username = u.Username,
                              Id = q.Id
                          };

        await model.Paging(returnModel);
        return model;
    }

    public async Task<EditMemberInfoDTO?> FillEditMemberInfoDTO(ulong id , CancellationToken cancellation)
    {
        return await _context.DoctorSelectedHealthCenters
                             .AsNoTracking()
                             .Where(p => !p.IsDelete &&
                                    p.Id == id)
                             .Select(p => new EditMemberInfoDTO()
                             {
                                 DoctorSelectedHealthCenterState = p.DoctorSelectedHealthCenterState,
                                 User = _context.Users
                                                .AsNoTracking()
                                                .Where(s=> !s.IsDelete &&  s.Id == p.ApplicantUserId)
                                                .FirstOrDefault(),
                                 Id = p.Id
                             })
                             .FirstOrDefaultAsync();
    }

    public async Task<DoctorSelectedHealthCenter?> GetDoctorSelectedHealthCenterById(ulong id , CancellationToken cancellationToken)
    {
        return await _context.DoctorSelectedHealthCenters
                             .Where(p => !p.IsDelete && 
                                    p.Id == id)
                             .FirstOrDefaultAsync();
    }

    public void UpdateDoctorSelectedHealthCenterRequest(DoctorSelectedHealthCenter model)
    {
        _context.DoctorSelectedHealthCenters.Update(model);
    }

    #endregion

    #region Doctor Panel 

    public async Task<List<ulong>> GetListOfHealthCentersIdFromDoctorSelectedHealthCentersByDoctorUserId(ulong doctorUserId)
    {
        return await _context.DoctorSelectedHealthCenters
                             .AsNoTracking()
                             .Where(p => !p.IsDelete &&
                                    p.ApplicantUserId == doctorUserId)
                             .Select(p => p.HealthCenterId)
                             .ToListAsync();
    }

    public async Task<FilterOfDoctorSelectedHealthCentersDoctorSide> FilterOfDoctorSelectedHealthCentersDoctorSide(FilterOfDoctorSelectedHealthCentersDoctorSide filter)
    {
        var query = _context.HealthCenters
                                    .AsNoTracking()
                                    .Include(p => p.HealthCentersInfo)
                                    .Where(p => !p.IsDelete)
                                    .OrderByDescending(p => p.CreateDate)
                                    .AsQueryable();

        var userIds = _context.DoctorSelectedHealthCenters
                              .AsNoTracking()
                              .Where(p => !p.IsDelete && p.ApplicantUserId == filter.UserId)
                              .AsQueryable();

        var model = from q in query
                    join u in userIds
                    on q.Id equals u.HealthCenterId
                    select new ListOfDoctorSelectedHealthCentersDoctorSideDTO
                    {
                        DoctorSelectedHealthCenterState = u.DoctorSelectedHealthCenterState,
                        HealthCenterImage = q.HealthCentersInfo.HealthCenterImage,
                        HealthCenterName = q.HealthCentersInfo.HealthCenterName
                    };

        await filter.Paging(model);

        return filter;
    }

    public async Task<FilterHealthCentersInDoctorPanelDTO> ListOfHealthCenters(FilterHealthCentersInDoctorPanelDTO model)
    {
        var query = _context.HealthCenters
                            .AsNoTracking()
                            .Include(p => p.HealthCentersInfo)
                            .Include(p => p.User)
                            .Where(p => !p.IsDelete)
                            .OrderByDescending(p => p.CreateDate)
                            .AsQueryable();

        //Health Center Name
        if (!string.IsNullOrEmpty(model.HealthCenterName))
        {
            query = query.Where(p => p.HealthCentersInfo.HealthCenterName.Contains(model.HealthCenterName));
        }

        #region Country

        if (model.CountryId.HasValue)
        {
            var userIds = _context.WorkAddresses
                                  .AsNoTracking()
                                  .Where(p => !p.IsDelete && p.CountryId == model.CountryId)
                                  .Select(p => p.UserId)
                                  .Distinct()
                                  .AsQueryable();

            query = from q in query
                    join u in userIds
                    on q.UserId equals u
                    select new HealthCenter
                    {
                        HealthCentersInfo = q.HealthCentersInfo,
                        Id = q.Id,
                        CreateDate = q.CreateDate,
                        IsDelete = q.IsDelete,
                        User = q.User,
                        UserId = q.UserId
                    };

        }

        #endregion

        #region State

        if (model.StateId.HasValue)
        {
            var userIds = _context.WorkAddresses
                                  .AsNoTracking()
                                  .Where(p => !p.IsDelete && p.StateId == model.StateId)
                                  .Select(p => p.UserId)
                                  .Distinct()
                                  .AsQueryable();

            query = from q in query
                    join u in userIds
                    on q.UserId equals u
                    select new HealthCenter
                    {
                        HealthCentersInfo = q.HealthCentersInfo,
                        Id = q.Id,
                        CreateDate = q.CreateDate,
                        IsDelete = q.IsDelete,
                        User = q.User,
                        UserId = q.UserId
                    };

        }

        #endregion

        #region CityId

        if (model.CityId.HasValue)
        {
            var userIds = _context.WorkAddresses
                                  .AsNoTracking()
                                  .Where(p => !p.IsDelete && p.CityId == model.CityId)
                                  .Select(p => p.UserId)
                                  .Distinct()
                                  .AsQueryable();

            query = from q in query
                    join u in userIds
                    on q.UserId equals u
                    select new HealthCenter
                    {
                        HealthCentersInfo = q.HealthCentersInfo,
                        Id = q.Id,
                        CreateDate = q.CreateDate,
                        IsDelete = q.IsDelete,
                        User = q.User,
                        UserId = q.UserId
                    };

        }

        #endregion

        await model.Paging(query);

        return model;
    }

    #endregion

    #region Site Side 

    public async Task<FilterHealthCentersSiteSideDTO> FilterHealthCentersSiteSide(FilterHealthCentersSiteSideDTO model,
                                                                                  CancellationToken cancellationToken)
    {
        var organizations = _context.Organizations
                                    .AsNoTracking()
                                    .Where(p => !p.IsDelete &&
                                           p.OrganizationType == Domain.Enums.Organization.OrganizationType.HealthCenter &&
                                           p.OrganizationInfoState == OrganizationInfoState.Accepted)
                                    .OrderByDescending(p => p.CreateDate)
                                    .AsQueryable();


        var healthCentersInfo = _context.HealthCentersInfos
                                  .AsNoTracking()
                                  .Where(p => !p.IsDelete)
                                  .AsQueryable();

        var returnModel = from o in organizations
                          join h in healthCentersInfo
                          on o.OwnerId equals h.UserId
                          select new HealthCentersInfoDTO
                          {
                             HealthCenterTitle = h.HealthCenterName,
                             HealthCenterCoverImage = h.HealthCenterImage,
                             HealthCenterId = h.HealthCenterId
                          };

        await model.Paging(returnModel);
        return model;
    }

    public async Task<HealthCenterDetailSiteSideDTO?> Fill_HealthCenterDetailSiteSideDTO_ByHealthCenterId(ulong healthCenterId,
                                                                                                          CancellationToken cancellation)
    {
        return await _context.HealthCentersInfos
                             .AsNoTracking()
                             .Where(p=> !p.IsDelete && 
                                    p.HealthCenterId == healthCenterId)
                             .Select(p=> new HealthCenterDetailSiteSideDTO()
                             {
                                 HealthCenterInformation = new HealthCenterInformationSiteSideDTO()
                                 {
                                     HealthCenterId = p.HealthCenterId,
                                     GeneralPhone = p.GeneralPhone,
                                     HealthCenterImage = p.HealthCenterImage,
                                     HealthCenterName = p.HealthCenterName,
                                     WorkAddress = _context.WorkAddresses
                                                           .AsNoTracking()
                                                           .Where(l=> l.UserId == p.UserId)
                                                           .FirstOrDefault()
                                 },
                                 DoctorsInfo = null,
                                 Specialities = null,
                             })
                             .FirstOrDefaultAsync();
    }

    public async Task<List<ulong>> GetList_OfHealthCenterAcceptedDoctorsUserId_ByHealthCenterInformations(ulong healthCenterId,
                                                                                                          CancellationToken cancellation)
    {
        return await _context.DoctorSelectedHealthCenters
                             .AsNoTracking()
                             .Where(p=> !p.IsDelete && 
                                    p.HealthCenterId == healthCenterId &&
                                    p.DoctorSelectedHealthCenterState == Domain.Enums.HealthCenter.DoctorSelectedHealthCenterState.Accept)
                             .OrderByDescending(p=> p.CreateDate)
                             .Select(p=> p.ApplicantUserId)
                             .ToListAsync();
    }

    public async Task<List<ulong>> GetList_OfHealthCenterAcceptedDoctorsId_ByHealthCenterInformations(ulong healthCenterId,
                                                                                                      CancellationToken cancellation)
    {
        return await _context.DoctorSelectedHealthCenters
                             .AsNoTracking()
                             .Where(p => !p.IsDelete &&
                                    p.HealthCenterId == healthCenterId &&
                                    p.DoctorSelectedHealthCenterState == Domain.Enums.HealthCenter.DoctorSelectedHealthCenterState.Accept)
                             .OrderByDescending(p => p.CreateDate)
                             .Select(p => _context.Doctors.AsNoTracking().Where(d=> !d.IsDelete && 
                                                                                d.UserId== p.ApplicantUserId)
                                                                          .Select(p=> p.Id)
                                                                          .FirstOrDefault())
                             .ToListAsync();
    }

    public async Task<DoctorsMiniInfoDTO?> FillDoctorsMiniInfoDTO_ByHealthCenterDoctorsUserIds(ulong healthCenterId , 
                                                                                              CancellationToken cancellationToken)
    {
        return await _context.Users
                             .AsNoTracking()
                             .Include(p => p.Doctors)
                             .Where(p => !p.IsDelete &&
                                    p.Id == healthCenterId)
                             .Select(p => new DoctorsMiniInfoDTO()
                             {
                                 DoctorUserAvatar = p.Avatar,
                                 DoctorUserId = p.Id,
                                 DoctorUsername = p.Username,
                                 SpecialitiesIds = _context.DoctorSelectedSpeciality
                                                           .AsNoTracking()
                                                           .Where(s=> !s.IsDelete && 
                                                                  s.DoctorId == p.Doctors.Id)
                                                           .Select(s=> s.SpecialityId)
                                                           .ToList()
                             })
                             .FirstOrDefaultAsync();
    }

    public async Task<SpecialitiesInfo?> Fill_SpecialitiesInfo_BySpecialityId(ulong specialityId , 
                                                                              CancellationToken cancellation)
    {
        return await _context.Specialities
                             .AsNoTracking()
                             .Where(p => p.IsDelete &&
                                    p.Id == specialityId)
                             .Select(p => new SpecialitiesInfo()
                             {
                                 SpecialityId = p.Id , 
                                 SpecialityName = p.UniqueName
                             })
                             .FirstOrDefaultAsync();
    }

    public async Task<bool> HasDoctor_SelectedCurrentSpeciality_ByDoctorIdAndSpecialityId(ulong doctorId , 
                                                                                              ulong specialityId ,
                                                                                              CancellationToken cancellation)
    {
        return await _context.DoctorSelectedSpeciality
                             .AsNoTracking()
                             .AnyAsync(p => p.DoctorId == doctorId &&
                                      !p.IsDelete &&
                                       p.SpecialityId == specialityId);
    }

    public async Task<HealthCenterDoctorDetailSiteSideDTO?> FillHealthCenterDoctorDetailSiteSideDTO_ByDoctorId(ulong doctorId , 
                                                                                                               CancellationToken cancellation)
    {
        return await _context.Doctors
                             .AsNoTracking()
                             .Where(p => !p.IsDelete &&
                                    p.Id == doctorId)
                             .Select(p => new HealthCenterDoctorDetailSiteSideDTO()
                             {
                                 DoctorInfo = _context.DoctorsInfos
                                                      .AsNoTracking()
                                                      .Where(d => !d.IsDelete &&
                                                             d.DoctorId == doctorId)
                                                      .Select(d => new HealthCenterDoctorInfoDetailSiteSideDTO()
                                                      {
                                                          ContractWithFamilyDoctor = d.ContractWithFamilyDoctors,
                                                          DoctorSpecialityName = d.Specialty,
                                                          DoctorTilteName = d.DoctorTilteName,
                                                          Education = d.Education,
                                                          Gender = d.Gender,
                                                          DoctorId = p.Id
                                                      })
                                                      .FirstOrDefault(),

                                 DoctorUserInfo = _context.Users
                                                          .Where(d => !d.IsDelete &&
                                                                 d.Id == p.UserId)
                                                          .Select(d => new HealthCenterDoctorUserDetailSiteSideDTO()
                                                          {
                                                              DoctorUserAvatar = d.Avatar,
                                                              DoctorUserId = d.Id,
                                                              DoctorUsername = d.Username
                                                          })
                                                          .FirstOrDefault()
                             })
                             .FirstOrDefaultAsync();
    }

    #endregion
}
