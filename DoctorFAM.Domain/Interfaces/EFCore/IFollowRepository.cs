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

        #endregion
    }
}
