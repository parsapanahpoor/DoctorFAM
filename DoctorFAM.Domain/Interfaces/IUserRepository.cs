using DoctorFAM.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IUserRepository 
    {
        #region Site Side

        Task<bool> IsExistUserById(ulong userId);

        Task<User?> GetUserByMobile(string Mobile);

        Task SaveChangesAsync();

        #endregion

        #region User Panel

        Task EditUser(User user);

        //Get List Of Admins and Supporters 
        Task<List<string>?> GetAllAdminsAndSupportersNotification();

        #endregion

        #region Admin Side 

        //Get Home Nurse Supporters
        Task<List<User>?> GetHomeNurseSupporters();

        //Get Online Visit Supporters
        Task<List<User>?> GetOnlineVisitSupporters();

        //Get List Of Admins and Supporters User Id For Send Notification For Home Pharmacy
        Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInHomePharmacy();

        //Get List Of Admins and Supporters User Id For Send Notification For Online Request
        Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInOnlineVisit();

        //Get List Of Admins 
        Task<List<User>?> GetListOfAdmins();

        //Get List Of Supporters
        Task<List<User>?> GetListOfSupporters();

        //Get Home Pharmacy Supporters
        Task<List<User>?> GetHomePharmacySupporters();

        //Get List Of Admins About Send Notification For Arrival New Nurses Inormations
        Task<List<string>?> GetListOfAdminsAboutSendNotificationForArrivalNewNursesInormations();

        #endregion
    }
}
