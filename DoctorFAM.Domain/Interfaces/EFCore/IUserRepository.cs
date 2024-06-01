using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.DoctorReservation;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IUserRepository 
    {
        #region General 

        Task<User?> GetUserById(ulong userId,CancellationToken token);

        #endregion

        #region Site Side

        //Add User
        Task AddUser(User user);

        //Add LogForGetAppoinmentForOtherPeople To The Data Base Without Save Changes
        Task AddLogForGetAppoinmentForOtherPeopleToTheDataBaseWithoutSaveChanges(LogForGetAppoinmentForOtherPeople otherPerson);

        //Update User Without SaveChanges
        void UpdateUserWithoutSaveChange(User user);

        //Get Username By User ID
        Task<string?> GetUsernameByUserID(ulong userId);

        //Get User By Username
        Task<User?> GetUserByUsername(string userName);

        //Get User Roles 
        Task<List<string>?> GetUserRoles(ulong userId);

        //Add Cooperation Request
        Task AddCooperationRequest(DoctorFAM.Domain.Entities.CooperationRequest.CooperationRequest request);

        Task<bool> IsExistUserById(ulong userId);

        Task<bool> IsExist_User_ByMobile(string mobile);

        Task<User?> GetUserByMobile(string Mobile);

        Task SaveChangesAsync();

        //Get User Roles By User Id 
        Task<List<ulong>?> GetUserRolesByUserId(ulong userId);

        #endregion

        #region User Panel

        Task EditUser(User user);

        //Get List Of Admins and Supporters 
        Task<List<string>?> GetAllAdminsAndSupportersNotification();

        //Is Exist Any User By National Id 
        Task<bool> IsExistAnyUserByNationalId(string nationalId);

        #endregion

        #region Admin Side 

        //Get List Of Admins and Supporters User Id For Send Notification For Home Laboratory
        Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInHomeLaboratory();

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

        //Get List Of Admins and Supporters User Id For Send Notification For Online Visit
        Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInOnlineVisit();

        //Get List Of Admins 
        Task<List<User>?> GetListOfAdmins();

        //Get List Of Supporters
        Task<List<User>?> GetListOfSupporters();

        //Get Home Pharmacy Supporters
        Task<List<User>?> GetHomePharmacySupporters();

        //Get List Of Admins About Send Notification For Arrival New Nurses Inormations
        Task<List<string>?> GetListOfAdminsAboutSendNotificationForArrivalNewNursesInormations();

        //Count Of Users 
        Task<int> CountOfUsers();

        //Get List Of Admins About Send Notification For Arrival New Consultant Inormations
        Task<List<string>?> GetListOfAdminsAboutSendNotificationForArrivalNewConsultantInormations();

        //Add User Role 
        Task AddUserRole(UserRole userRole);

        #endregion

        #region Cooperation Request 

        //Get Cooperation Request By Id
        Task<DoctorFAM.Domain.Entities.CooperationRequest.CooperationRequest?> GetCooperationRequestById(ulong requestCooperationId);

        //Update Cooperation Request To Fowloaded Up 
        Task UpdateCooperationRequestToFowloadedUp(DoctorFAM.Domain.Entities.CooperationRequest.CooperationRequest cooperationRequest);

        //List Of Cooperation Requests
        Task<List<DoctorFAM.Domain.Entities.CooperationRequest.CooperationRequest>> ListOfCooperationRequests();

        #endregion
    }
}
