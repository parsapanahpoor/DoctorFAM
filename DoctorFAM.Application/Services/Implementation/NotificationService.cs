using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Notification;
using DoctorFAM.Domain.Enums.Notification;
using DoctorFAM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class NotificationService : INotificationService
    {
        #region Ctor

        private readonly INotificationRepository _notificationService;

        private readonly IUserService _userService;

        private readonly IRequestService _requestService;

        public NotificationService(INotificationRepository notificationService, IUserService userService, IRequestService requestService)
        {
            _notificationService = notificationService;
            _userService = userService;
            _requestService = requestService;
        }

        #endregion

        #region Supporter And Admin Method 

        //Create Notification For Admin And Supporters
        public async Task<bool> CreateSupporterNotification(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification , ulong senderId)
        {
            #region Get Admins And Supporters 

            List<User> user = new List<User>();

            //Get Admins
            var admins = await _userService.GetListOfAdmins();
            user.AddRange(admins);

            //Get Supporters
            var supporters = await _userService.GetListOfSupporters();
            user.AddRange(supporters);

            #endregion

            #region Check target 

            //If Target is Request
            if (notification == NotificationTarget.request)
            {
                var request = await _requestService.GetRequestById(targetId);
                if (request == null) return false;
            }

            #endregion

            #region Fill Notification Entity

            List<SupporterNotification> model = new List<SupporterNotification>();

            foreach (var item in user)
            {
                SupporterNotification notif = new SupporterNotification()
                {
                    CreateDate = DateTime.Now,
                    IsDelete = false,
                    IsSeen = false,
                    SupporterNotificationText = SupporterNotificationText,
                    TargetId = targetId,
                    UserId = senderId,
                    ReciverId = item.Id,
                };

                model.Add(notif);
            };

            await _notificationService.CreateRangeSupporter(model);

            #endregion

            return true;
        }

        //Get User Notifications By User Id
        public async Task<List<SupporterNotification>?> GetListOfSupporterNotificationByUserId(ulong userId)
        {
            return await _notificationService.GetListOfSupporterNotificationByUserId(userId);
        }

        //Get SupporterNotification By Id
        public async Task<SupporterNotification?> GetSupporterNotificationById(ulong notificationId)
        {
            return await _notificationService.GetSupporterNotificationById(notificationId);
        }

        //Seen All Of Un Seen Notification For Current Notifications
        public async Task<bool> SeenAllOfUnSeenCurrentUserNotification(ulong userId)
        {
            #region Get All Of Un Seen Notification By Reciver Id

            var notification = await _notificationService.GetAllOfUnSeenNoficationByReciverId(userId);
            if (notification == null) return false;

            #endregion

            foreach (var item in notification)
            {
                item.IsSeen = true;
                item.IsDelete = true;

                await _notificationService.UpdateSupporterNotifications(item);
            }

            return true;
        }

        //Get All Of Un Seen Reciver Notification By ReciverId Id
        public async Task<List<SupporterNotification>?> GetAllOfUnSeenNoficationByReciverId(ulong reciverId)
        {
            return await _notificationService.GetAllOfUnSeenNoficationByReciverId(reciverId);
        }

        #endregion
    }
}
