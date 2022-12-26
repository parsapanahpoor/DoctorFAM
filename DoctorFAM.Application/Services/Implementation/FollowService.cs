using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Follow;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion
    }
}
