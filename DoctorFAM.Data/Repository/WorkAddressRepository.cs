#region Usings

using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DoctorFAM.Data.Repository;

#endregion

public class WorkAddressRepository : IWorkAddressRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public WorkAddressRepository(DoctorFAMDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Doctor Panel 

    //Get List Of Doctor Addresses By Doctor User Id
    public async Task<List<ListOfDoctorsLocationDTO>?> GetListOfDoctorAddressesByDoctorUserId(ulong doctorUserId)
    {
        return await _context.WorkAddresses
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.UserId == doctorUserId)
                             .Select(p => new ListOfDoctorsLocationDTO()
                             {
                                 WorkAddress = p.Address,
                                 Id = p.Id,
                                 CityName = _context.LocationInfoes
                                                    .AsNoTracking()
                                                    .Where(s=> !s.IsDelete && s.Id == p.CityId)
                                                    .Select(s=> s.Title)
                                                    .FirstOrDefault(),
                                 CountryName = _context.LocationInfoes
                                                    .AsNoTracking()
                                                    .Where(s => !s.IsDelete && s.Id == p.CountryId)
                                                    .Select(s => s.Title)
                                                    .FirstOrDefault(),
                                 StateName = _context.LocationInfoes
                                                    .AsNoTracking()
                                                    .Where(s => !s.IsDelete && s.Id == p.StateId)
                                                    .Select(s => s.Title)
                                                    .FirstOrDefault(),

                             })
                             .ToListAsync();
    }

    #endregion

    #region User Panel Side 

    //Get Work Address By Id
    public async Task<WorkAddress?> GetWorkAddressById(ulong workAddressId)
    {
        return await _context.WorkAddresses
                             .Where(p => !p.IsDelete && p.Id == workAddressId)
                             .FirstOrDefaultAsync();
    }

    //Update Work Address
    public void Update(WorkAddress workAddress)
    {
        _context.WorkAddresses.Update(workAddress);
    }

    //Save Changees
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    //Get Count Of User Work Addresses
    public async Task<int> GetCountOfUserWorkAddresses(ulong userId)
    {
        return await _context.WorkAddresses
                             .CountAsync(p=> !p.IsDelete && p.UserId == userId);
    }

    //Get User Work Address By Work Address Id
    public async Task<WorkAddress?> GetUserWorkAddressByWorkAddressIdAsyNoTracking(ulong addressId)
    {
        return await _context.WorkAddresses
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => !p.IsDelete && p.Id == addressId);
    }

    //Get User Work Address By Work Address Id
    public async Task<WorkAddress?> GetUserWorkAddressByWorkAddressId(ulong addressId)
    {
        return await _context.WorkAddresses
                             .FirstOrDefaultAsync(p => !p.IsDelete && p.Id == addressId);
    }

    public async Task<List<WorkAddress>?> GetUserWorkAddressesByUserId(ulong userId)
    {
        return await _context.WorkAddresses
                             .Include(p => p.State)
                             .Where(p => !p.IsDelete && p.UserId == userId).ToListAsync();
    }

    public async Task AddWorkAddress(WorkAddress workAddress)
    {
        await _context.WorkAddresses.AddAsync(workAddress);
        await _context.SaveChangesAsync();
    }

    //Add Work Address Without Save Changes
    public async Task AddWorkAddressWithoutSaveChanges(WorkAddress workAddress)
    {
        await _context.WorkAddresses.AddAsync(workAddress);
    }

    public async Task<WorkAddress?> GetUserWorkAddressById(ulong userid)
    {
        return await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userid);
    }

    public async Task<WorkAddress?> GetUserWorkAddressByIdWithAsNoTracking(ulong userid)
    {
        return await _context.WorkAddresses
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userid);
    }

    public async Task UpdateUserWorkAddress(WorkAddress workAddress)
    {
        _context.WorkAddresses.Update(workAddress);
        await _context.SaveChangesAsync();
    }

    //Update User Work Address Without Save Changes
    public async Task UpdateUserWorkAddressWithoutSaveChanges(WorkAddress workAddress)
    {
        _context.WorkAddresses.Update(workAddress);
    }

    public async Task<WorkAddress?> GetLastWorkAddressByUserId(ulong userId)
    {
        return await _context.WorkAddresses.Include(p => p.State).Include(p => p.Country).Include(p => p.City)
                            .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId);
    }

    public async Task<WorkAddress?> GetLastWorkAddressByUserIdWithAsNoTracking(ulong userId)
    {
        return await _context.WorkAddresses
                             .AsNoTracking()
                             .Include(p => p.State)
                             .Include(p => p.Country)
                             .Include(p => p.City)
                             .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId);
    }

    #endregion
}
