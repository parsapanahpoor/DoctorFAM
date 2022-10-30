using DoctorFAM.Domain.Entities.Account;
using Microsoft.EntityFrameworkCore;
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

        //Get User Roles 
        Task<List<string>?> GetUserRoles(ulong userId);

        //Add Cooperation Request
        Task AddCooperationRequest(DoctorFAM.Domain.Entities.CooperationRequest.CooperationRequest request);

        Task<bool> IsExistUserById(ulong userId);

        Task<User?> GetUserByMobile(string Mobile);

        Task SaveChangesAsync();

        //Get User Roles By User Id 
        Task<List<ulong>?> GetUserRolesByUserId(ulong userId);

        #endregion

        #region User Panel

        Task EditUser(User user);

        //Get List Of Admins and Supporters 
        Task<List<string>?> GetAllAdminsAndSupportersNotification();

        #endregion

        #region Admin Side 

        //Get List Of Admins and Supporters User Id For Send Notification For Death Certificate
        Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInDeathCertificate();

        //Get Home Visit Supporters
        Task<List<User>?> GetHomeVisitSupporters();

        //Get Death Certificate Supporters
        Task<List<User>?> GetDeathCertificateSupporters();

        //Get List Of Admins and Supporters User Id For Send Notification For Home Visit
        Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInHomeVisit();

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

        //Get List Of Admins About Send Notification For Arrival New Consultant Inormations
        Task<List<string>?> GetListOfAdminsAboutSendNotificationForArrivalNewConsultantInormations();

        //Add User Role 
        Task AddUserRole(UserRole userRole);

        #endregion
    }
}
