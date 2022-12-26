using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
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
            return await _context.Follow.CountAsync(p=> !p.IsDelete && p.TargetUserId == userId);
        }

        //Check That Current User Followed Target User 
        public async Task<bool> CheckThatCurrentUserFollowedTargetUser(ulong currentUserId , ulong targetUserId)
        {
            return _context.Follow.Any(p => !p.IsDelete && p.UserId == currentUserId && p.TargetUserId == targetUserId);
        }

        #endregion
    }
}
