using DoctorFAM.Domain.Entities.FollowAndUnFollow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces.EFCore
{
    public interface IFollowRepository
    {
        #region Site Side 

        //Get Count Of User Followrs By User Id 
        Task<int> GetCounOfUserFollowrsByUserId(ulong userId);

        //Check That Current User Followed Target User 
        Task<bool> CheckThatCurrentUserFollowedTargetUser(ulong currentUserId, ulong targetUserId);

        //Follow Method 
        Task FollowMethod(Follow follow);

        //Get Follow Record With Current User Id And Target User Id 
        Task<Follow?> GetFollowRecordWithCurrentUserIdAndTargetUserId(ulong currentUserId, ulong targetUserId);

        //Update Follow Record
        Task UpdateFollowRecord(Follow follow);

        //Get List Of User Followers
        Task<List<Follow>?> GetListOfUserFollowers(ulong userId);

        #endregion
    }
}
