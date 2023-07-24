using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class WorkAddressRepository : IWorkAddressRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public WorkAddressRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region User Panel Side 

        public async Task<List<WorkAddress>?> GetUserWorkAddressesByUserId(ulong userId)
        {
            return await _context.WorkAddresses.Include(p=> p.State).Where(p => !p.IsDelete && p.UserId == userId).ToListAsync();
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
            return await  _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userid);
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
            return await _context.WorkAddresses.Include(p=> p.State).Include(p=> p.Country).Include(p=> p.City)
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
}
