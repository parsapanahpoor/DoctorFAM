using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.Account;
using DoctorFAM.Domain.ViewModels.Admin;
using DoctorFAM.Domain.ViewModels.Admin.Account;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Employees;
using DoctorFAM.Domain.ViewModels.Laboratory.Employee;
using DoctorFAM.Domain.ViewModels.Site.Account;
using DoctorFAM.Domain.ViewModels.UserPanel.Account;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IUserService
    {
        #region Authorize

        //Register Nurse
        Task RegisterNurse(string mobile);

        //Filter User In Modal
        Task<Domain.ViewModels.UserPanel.FilterUserViewModel> FilterUsersInModal(Domain.ViewModels.UserPanel.FilterUserViewModel filter);

        Task ResendActivationCodeSMS(string Mobile);

        Task<bool> IsExistUserById(ulong userId);

        Task<User?> GetUserById(ulong userId);

        Task<RegisterUserResult> RegisterUser(RegisterUserViewModel register);

        Task<bool> IsExistsUserByEmail(string email);

        Task<bool> IsExistUserByMobile(string mobile);

        Task<LoginResult> CheckUserForLogin(LoginUserViewModel login);

        Task<User?> GetUserByMobile(string mobile);

        Task<bool> AccountActivation(string emailActivationCode);

        Task<User> GetUserByEmailActivationCode(string emailActivationCode);

        Task<ResetPasswordResult> ResetUserPassword(ResetPasswordViewModel pass, string mobile);

        #endregion

        #region Site Side

        //Register Labratory
        Task LabratoryConsultant(string mobile);

        Task RegisterDoctors(string mobile);

        Task RegisterPharmacy(string mobile);

        Task RegisterSeller(string mobile);

        Task<ActiveMobileByActivationCodeResult> ActiveUserMobile(ActiveMobileByActivationCodeViewModel activeMobileByActivationCodeViewModel);

        Task<ForgotPasswordResult> RecoverUserPassword(ForgetPasswordViewModel forgot);

        #endregion

        #region Admin

        //Get List Of Admins and Supporters User Id For Send Notification For Death Certificate
        Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInDeathCertificate();

        //Get Death Certificate Supporters
        Task<List<User>?> GetDeathCertificateSupporters();

        //Get Home Visit Supporters
        Task<List<User>?> GetHomeVisitSupporters();

        //Get List Of Admins About Send Notification For Arrival New Nurses Inormations
        Task<List<string>?> GetListOfAdminsAboutSendNotificationForArrivalNewNursesInormations();

        //Get Online Visit Supporters
        Task<List<User>?> GetOnlineVisitSupporters();

        //Get Home Nurse Supporters
        Task<List<User>?> GetHomeNurseSupporters();

        //Get List Of Admins and Supporters User Id For Send Notification For Online Request
        Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInOnlineVisit();

        //Get List Of Admins and Supporters User Id For Send Notification For Home Visit
        Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInHomeVisit();

        //Get List Of Admins and Supporters User Id For Send Notification For Home Pharmacy
        Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInHomePharmacy();

        //Get List Of Admins 
        Task<List<User>?> GetListOfAdmins();

        //Get List Of Supporters
        Task<List<User>?> GetListOfSupporters();

        //Get Home Pharmacy Supporters
        Task<List<User>?> GetHomePharmacySupporters();

        //Update User 
        Task UpdateUser(User user);

        Task<FilterUserViewModel> FilterUsers(FilterUserViewModel filter);

        Task<bool> ChangePasswordInAdmin(ChangePasswordInAdminViewModel passwordViewModel);

        Task<AdminEditUserInfoViewModel> FillAdminEditUserInfoViewModel(ulong userId);

        Task<bool> IsValidMobileForUserEditByAdmin(string mobile, ulong userId);

        Task<bool> IsValidEmailForUserEditByAdmin(string email, ulong userId);

        Task<AdminEditUserInfoResult> EditUserInfo(AdminEditUserInfoViewModel edit, IFormFile? UserAvatar);

        //Register Consultant
        Task RegisterConsultant(string mobile);

        //Get List Of Admins About Send Notification For Arrival New Consultant Inormations
        Task<List<string>?> GetListOfAdminsAboutSendNotificationForArrivalNewConsultantInormations();

        //Create User From Laboratory Panel
        Task<AddNewUserResult> CreateUserFromLaboratoryPanel(AddLaboratoryEmployeeViewModel user, IFormFile? avatar, ulong MasterId);

        #endregion

        #region User Panel

        Task<AddNewUserResult> CreateUserFromDoctorPanel(AddEmployeeViewModel user, IFormFile? avatar, ulong MasterId);

        Task<UserPanelEditUserInfoViewModel> FillUserPanelEditUserInfoViewModel(ulong userId);

        Task<UserPanelEditUserInfoResult> EditUserInfoInUserPanel(UserPanelEditUserInfoViewModel edit, IFormFile? UserAvatar);

        Task<ChangeUserPasswordResponse> ChangeUserPasswordAsync(ulong userId, ChangeUserPasswordViewModel model);

        //Get List Of Admins and Supporters 
        Task<List<string>?> GetAllAdminsAndSupportersNotification();

        #endregion
    }
}
