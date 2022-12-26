using DoctorFAM.Data.DbContext;
using DoctorFAM.Data.Migrations;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.FollowAndUnFollow;
using DoctorFAM.Domain.Interfaces.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class FollowRepository : IFollowRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public FollowRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side 

        //Get Count Of User Followrs By User Id 
        public async Task<int> GetCounOfUserFollowrsByUserId(ulong userId)
        {
            return await _context.Follow.CountAsync(p => !p.IsDelete && p.TargetUserId == userId);
        }

        //Check That Current User Followed Target User 
        public async Task<bool> CheckThatCurrentUserFollowedTargetUser(ulong currentUserId, ulong targetUserId)
        {
            return _context.Follow.Any(p => !p.IsDelete && p.UserId == currentUserId && p.TargetUserId == targetUserId);
        }

        //Follow Method 
        public async Task FollowMethod(Follow follow)
        {
            await _context.Follow.AddAsync(follow);
            await _context.SaveChangesAsync();
        }

        //Get Follow Record With Current User Id And Target User Id 
        public async Task<Follow?> GetFollowRecordWithCurrentUserIdAndTargetUserId(ulong currentUserId, ulong targetUserId)
        {
            return await _context.Follow.FirstOrDefaultAsync(p => !p.IsDelete && p.TargetUserId == targetUserId && p.UserId == currentUserId);
        }

        //Update Follow Record
        public async Task UpdateFollowRecord(Follow follow)
        {
            _context.Follow.Update(follow);
            await _context.SaveChangesAsync();
        }

        //Get List Of User Followers
        public async Task<List<Follow>?> GetListOfUserFollowers(ulong userId)
        {
            return await _context.Follow.Where(p=> !p.IsDelete && p.TargetUserId == userId).ToListAsync();
        }

        #endregion
    }
}
