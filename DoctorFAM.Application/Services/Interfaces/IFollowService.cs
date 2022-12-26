using DoctorFAM.Domain.ViewModels.Site.Doctor.Follow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IFollowService
    {
        #region Site Side 

        //Model Of View Component That Show Doctor Badge Detail For Followers Detail 
        Task<FollowCountViewComponentViewModel?> ModelOfViewComponentThatShowDoctorBadgeDetailForFollowersDetail(ulong targetUserId);

        //Check That Current User Followed Target User 
        Task<bool> CheckThatCurrentUserFollowedTargetUser(ulong currentUserId, ulong targetUserId);

        #endregion
    }
}
