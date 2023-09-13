#region Usings

using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Entities.Tourism;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Laboratory;
using DoctorFAM.Domain.ViewModels.Admin.Tourist;
using DoctorFAM.Domain.ViewModels.Tourism.SiteSideBar;
using Microsoft.EntityFrameworkCore;
using System.Linq;

#endregion

namespace DoctorFAM.Data.Repository;

public class TourismRepository : ITourismRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public TourismRepository(DoctorFAMDbContext context)
    {
            _context = context;
    }

    #endregion

    #region Tourism Panel 

    //Is Exist Any Tourism By This User Id 
    public async Task<bool> IsExistAnyTourismByUserId(ulong userId)
    {
        return await _context.Tourisms
                             .AnyAsync(p => p.UserId == userId && !p.IsDelete);
    }

    //Add Tourisms To Data Base
    public async Task<ulong> AddTourisms(Tourism tourisms)
    {
        await _context.Tourisms.AddAsync(tourisms);
        await _context.SaveChangesAsync();

        return tourisms.Id;
    }

    //Fill Tourism Side Bar Panel
    public async Task<TourismSideBarViewModel> GetTourismSideBarInfo(ulong userId)
    {
        #region Get Tourism Office

        var OrganitionMember = await _context.OrganizationMembers
                                             .Include(p => p.Organization)
                                             .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Tourism);

        #endregion

        TourismSideBarViewModel model = new TourismSideBarViewModel();

        #region Tourism State 

        //If Tourism Registers Now
        if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.JustRegister) model.TourismInfoState = "NewUser";

        //If Tourism State Is WatingForConfirm
        if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.WatingForConfirm) model.TourismInfoState = "WatingForConfirm";

        //If Tourism State Is Rejected
        if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Rejected) model.TourismInfoState = "Rejected";

        //If Tourism State Is Accepted
        if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Accepted) model.TourismInfoState = "Accepted";

        #endregion

        return model;
    }

    //Is Exist Any Tourist By This User Id 
    public async Task<bool> IsExistAnyTouristByUserId(ulong userId)
    {
        return await _context.Tourisms.AnyAsync(p => p.UserId == userId && !p.IsDelete);
    }

    //Get Tourist Information By User Id
    public async Task<TourismInfo?> GetTouristInformationByUserId(ulong userId)
    {
        var tourism = await GetTouristByUserId(userId);
        if(tourism == null) return null;

        return await _context.TourismInfos
                             .FirstOrDefaultAsync(p => p.TourismId == tourism.Id && !p.IsDelete);
    }

    //Is Exist Any Tourist Info ByUser Id
    public async Task<bool> IsExistAnyTouristInfoByUserId(ulong userId)
    {
        var tourism = await GetTouristByUserId(userId);
        if (tourism == null) return false;

        return await _context.TourismInfos
                             .AnyAsync(p => p.TourismId == tourism.Id && !p.IsDelete);
    }

    //Add Tourist Info To The Data Base
    public async Task AddTouristInfo(TourismInfo tourism)
    {
        await _context.TourismInfos.AddAsync(tourism);
        await _context.SaveChangesAsync();
    }

    #endregion

    #region Admin Side

    //Get Tourist By User Id
    public async Task<Tourism?> GetTouristByUserId(ulong userId)
    {
        return await _context.Tourisms
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId);
    }

    //Filter Tourist Info Admin Side
    public async Task<ListOfTouristInfoViewModel> FilterListOfTouristInfoViewModel(ListOfTouristInfoViewModel filter)
    {
        var query = _context.Organizations
            .Where(s => !s.IsDelete && s.OrganizationType == Domain.Enums.Organization.OrganizationType.Tourism)
            .Include(p => p.User)
            .OrderByDescending(s => s.CreateDate)
            .AsQueryable();

        #region State

        switch (filter.TouristState)
        {
            case TouristState.All:
                break;
            case TouristState.Accepted:
                query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.Accepted);
                break;
            case TouristState.WaitingForConfirm:
                query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.WatingForConfirm);
                break;
            case TouristState.Rejected:
                query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.Rejected);
                break;
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.Email))
        {
            query = query.Where(s => EF.Functions.Like(s.User.Email, $"%{filter.Email}%"));
        }

        if (!string.IsNullOrEmpty(filter.Mobile))
        {
            query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.Mobile}%"));
        }

        if (!string.IsNullOrEmpty(filter.FullName))
        {
            query = query.Where(s => s.User.Username.Contains(filter.FullName));
        }

        if (!string.IsNullOrEmpty(filter.NationalCode))
        {
            query = query.Where(s => s.User.NationalId.Contains(filter.NationalCode));
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    //Get TouristInfo Info By Tourist Id
    public async Task<TourismInfo?> GetTouristInfoByTouristId(ulong TouristId)
    {
        return await _context.TourismInfos
                             .FirstOrDefaultAsync(p => !p.IsDelete && p.TourismId == TouristId);
    }

    //Get Tourist By Tourist Id
    public async Task<Tourism?> GetTouristById(ulong TouristId)
    {
        return await _context.Tourisms
                             .FirstOrDefaultAsync(p => !p.IsDelete && p.Id == TouristId);
    }

    //Update Tourist Info 
    public async Task UpdateTouristInfo(TourismInfo tourismInfo)
    {
        _context.TourismInfos.Update(tourismInfo);
        await _context.SaveChangesAsync();
    }

    #endregion
}
