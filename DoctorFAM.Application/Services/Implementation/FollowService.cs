using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FollowAndUnFollow;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Follow;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Follow;

namespace DoctorFAM.Application.Services.Implementation
{
    public class FollowService : IFollowService
    {
        #region Ctor 

        private readonly IFollowRepository _followRepository;
        private readonly IOrganizationService _organizationService;
        private readonly IUserService _userService;

        public FollowService(IFollowRepository followRepository, IOrganizationService organizationService , IUserService userService)
        {
            _followRepository = followRepository;
            _organizationService = organizationService;
            _userService = userService; 
        }

        #endregion

        #region Site Side 

        //Model Of View Component That Show Doctor Badge Detail For Followers Detail 
        public async Task<FollowCountViewComponentViewModel?> ModelOfViewComponentThatShowDoctorBadgeDetailForFollowersDetail(ulong targetUserId)
        {
            #region Get User Target

            var targetUser = await _userService.GetUserById(targetUserId);
            if (targetUser == null) return null;

            #endregion

            #region Fill Model

            FollowCountViewComponentViewModel model = new FollowCountViewComponentViewModel();

            //Count Of Target User Followers
            model.FollowersCount = await _followRepository.GetCounOfUserFollowrsByUserId(targetUserId);

            #endregion

            return model;
        }

        //Check That Current User Followed Target User 
        public async Task<bool> CheckThatCurrentUserFollowedTargetUser(ulong currentUserId, ulong targetUserId)
        {
            return await  _followRepository.CheckThatCurrentUserFollowedTargetUser(currentUserId , targetUserId);
        }

        //Follow Users
        public async Task<bool> FollowUsers(ulong currentUserId , ulong targetUserId)
        {
            #region Get User Target

            var targetUser = await _userService.GetUserById(targetUserId);
            if (targetUser == null) return false;

            #endregion

            #region Get Current User

            var currentUser = await _userService.GetUserById(currentUserId);
            if (currentUser == null) return false;

            #endregion

            #region Check That User Followed Target User Before 

            if (await _followRepository.CheckThatCurrentUserFollowedTargetUser(currentUserId, targetUserId))
            {
                return false;
            }

            #endregion

            #region Fill Model 

            Follow follow = new Follow()
            {
                TargetUserId = targetUserId,
                UserId = currentUserId
            };

            #endregion

            #region Follow Method 

            await _followRepository.FollowMethod(follow);

            #endregion

            return true;
        }

        //Un Follow 
        public async Task<bool> UnFollow(ulong currentUserId , ulong targetUserId)
        {
            #region Get User Target

            var targetUser = await _userService.GetUserById(targetUserId);
            if (targetUser == null) return false;

            #endregion

            #region Get Current User

            var currentUser = await _userService.GetUserById(currentUserId);
            if (currentUser == null) return false;

            #endregion

            #region Get Follow Recorde

            var follow = await _followRepository.GetFollowRecordWithCurrentUserIdAndTargetUserId(currentUserId , targetUserId);
            if (follow == null) return false;

            #endregion

            #region Update Follow Record

            follow.IsDelete = true;

            await _followRepository.UpdateFollowRecord(follow);

            #endregion

            return true;
        }

        //List Of User Followers That Has Role 
        public async Task<List<ListOfFollowersViewModel>?> ListOfUserFollowersThatHasRole(ulong currentUserId)
        {
            #region Get Organization 

            var organization = await _organizationService.GetOrganizationByUserId(currentUserId);
            if (organization == null) return null;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return null;

            #endregion

            #region Get User Followrs

            var followers = await _followRepository.GetListOfUserFollowers(organization.OwnerId);
            if (followers == null) return null;

            #endregion

            #region Fill return Model 

            List<ListOfFollowersViewModel> model = new List<ListOfFollowersViewModel>();

            foreach (var Follower in followers)
            {
                model.Add(new ListOfFollowersViewModel() { 
                    CreateDate = Follower.CreateDate,
                    User = await _userService.GetUserById(Follower.UserId),
                });
            }

            #endregion

            return model;
        }

        #endregion
    }
}
