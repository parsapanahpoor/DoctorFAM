using DoctorFAM.Domain.Entities.Notification;
using DoctorFAM.Domain.Enums.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface INotificationService
    {
        #region Site Side 

        //Create Notification For Pharmacy From Home Pharmacy Request 
        Task CreateNotificationForPharmacyFromHomePharmacyRequest(ulong requestId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

        //Create Notification For User Patiet 
        Task CreateNotificationForUserPatient(ulong requestId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

        //Create Notification For Operator 
        Task CreateNotificationForOperator(ulong requestId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

        #endregion

        #region Supporter And Admin 

        //Create Notification For Admin And Supporters
        Task<bool> CreateSupporterNotification(ulong targetId, SupporterNotificationText SupporterNotificationText, NotificationTarget notification, ulong senderId);

        //Get User Notifications By User Id
        Task<List<SupporterNotification>?> GetListOfSupporterNotificationByUserId(ulong userId);

        //Get SupporterNotification By Id
        Task<SupporterNotification?> GetSupporterNotificationById(ulong notificationId);

        //Get All Of Un Seen Reciver Notification By ReciverId Id
        Task<List<SupporterNotification>?> GetAllOfUnSeenNoficationByReciverId(ulong reciverId);

        //Seen All Of Un Seen Notification For Current Notifications
        Task<bool> SeenAllOfUnSeenCurrentUserNotification(ulong userId);

        #endregion
    }
}
