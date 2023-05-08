using DoctorFAM.Domain.Entities.Notification;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Notification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface INotificationRepository
    {
        #region Supporter And Admin Method 

        //Create Notification For Admin And Supporters
        Task CreateSupporter(SupporterNotification notification);

        //Create Range Notification For Admin And Supporters
        Task CreateRangeSupporter(List<SupporterNotification> notification);

        //Get User Notifications By User ID
        Task<List<SupporterNotification>?> GetListOfSupporterNotificationByUserId(ulong userId);

        //Get SupporterNotification By Id
        Task<SupporterNotification?> GetSupporterNotificationById(ulong notificationId);

        //Update Range OF Notifications 
        Task UpdateSupporterNotifications(List<SupporterNotification> notifications);

        //Get All Of Un Seen Reciver Notification By User Id
        Task<List<SupporterNotification>?> GetAllOfUnSeenNoficationByReciverId(ulong reciverId);

        //Update Supporter Notifications 
        Task UpdateSupporterNotifications(SupporterNotification notifications);

        //Create Notification For Admin And Supporters
        Task CreateRangeSupporter(SupporterNotification notification);

        #endregion

        #region Doctor Panel 

        //Get Doctor Notification By Doctor User Id
        Task<List<ListOFDoctorNotificationForShowInDoctorPanelViewModel>?> GetDoctorNotificationByDoctorUserId(ulong doctorUserId);

        #endregion
    }
}
