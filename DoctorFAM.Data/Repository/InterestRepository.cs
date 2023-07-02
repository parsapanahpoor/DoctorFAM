#region Using

using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.Entities.States;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Interest;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace DoctorFAM.Data.Repository;

#endregion

public class InterestRepository : IInterestRepository
{
	#region Ctor

	private readonly DoctorFAMDbContext _context;

    public InterestRepository(DoctorFAMDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Admin Side

    public async Task<FilterInterestAdminSideViewModel> FilterInterest(FilterInterestAdminSideViewModel filter)
    {
        var query = _context.InterestInfos
            .Include(a => a.Interest)
            .OrderByDescending(s => s.CreateDate)
            .AsQueryable();

        #region State

        switch (filter.InterestStatus)
        {
            case InterestStatus.All:
                break;
            case InterestStatus.NotDeleted:
                query = query.Where(a => !a.Interest.IsDelete);
                break;
            case InterestStatus.Deleted:
                query = query.Where(a => a.Interest.IsDelete);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.Title))
        {
            query = query.Where(s => EF.Functions.Like(s.Title, $"%{filter.Title}%"));
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    //Add Interest To The Data Base 
    public async Task<ulong> AddInterestToTheDataBase(DoctorsInterest interest)
    {
        await _context.Interests.AddAsync(interest);
        await _context.SaveChangesAsync();

        return interest.Id;
    }

    //Add Interest Info
    public async Task AddInterestInfo(List<DoctorsInterestInfo> interestInfo)
    {
        await _context.InterestInfos.AddRangeAsync(interestInfo);
        await _context.SaveChangesAsync();
    }

    public async Task<EditInterestViewModel?> FillEditInterestViewModel(ulong interestId)
    {
        return await _context.Interests
                        .Include(p => p.InterestInfo)
                        .Where(p => p.Id == interestId && !p.IsDelete).Select(p => new EditInterestViewModel()
                        {
                            Id = p.Id,
                            CurrentInfos = p.InterestInfo.AsQueryable().IgnoreQueryFilters().ToList()
                        }).FirstOrDefaultAsync();
    }

    public async Task<DoctorsInterest?> GetInterestById(ulong interestId)
    {
        return await _context.Interests
                             .Include(p => p.InterestInfo)
                             .FirstOrDefaultAsync(s => !s.IsDelete && s.Id == interestId);
    }

    public  void UpdateInterestInfoWithoutSaveChanges(DoctorsInterestInfo interestInfo)
    {
        _context.InterestInfos.Update(interestInfo);
    }

    //Save Changes
    public async Task SaveChanges()
    {
       await _context.SaveChangesAsync();
    }

    public async Task DeleteInterestInfo(ulong interestId)
    {
        var interestInfo = await _context.InterestInfos.Where(p => p.InterestId == interestId).IgnoreQueryFilters().ToListAsync();

        if (interestInfo != null && interestInfo.Any())
        {
            foreach (var item in interestInfo)
            {
                _context.InterestInfos.Remove(item);
            }
        }
    }

    public async Task DeleteInterest(DoctorsInterest interest)
    {
        //Delete First PartOf Interests
        interest.IsDelete = true;
        _context.Interests.Update(interest);

        //Delete First PartOf InteresrInfo
        await DeleteInterestInfo(interest.Id);

        await _context.SaveChangesAsync();
    }

    //Update Interest Without Save changes
    public void UpdateInterestWithoutSavechanges(DoctorsInterest interest)
    {
        _context.Interests.Update(interest);
    }

    #endregion
}
