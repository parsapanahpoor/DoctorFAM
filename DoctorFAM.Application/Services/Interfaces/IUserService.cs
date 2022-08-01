using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.Account;
using DoctorFAM.Domain.ViewModels.Admin;
using DoctorFAM.Domain.ViewModels.Admin.Account;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Employees;
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

        Task RegisterDoctors(string mobile);

        Task RegisterPharmacy(string mobile);

        Task RegisterSeller(string mobile);

        Task<ActiveMobileByActivationCodeResult> ActiveUserMobile(ActiveMobileByActivationCodeViewModel activeMobileByActivationCodeViewModel);

        Task<ForgotPasswordResult> RecoverUserPassword(ForgetPasswordViewModel forgot);

        #endregion

        #region Admin
        Task<FilterUserViewModel> FilterUsers(FilterUserViewModel filter);

        Task<bool> ChangePasswordInAdmin(ChangePasswordInAdminViewModel passwordViewModel);

        Task<AdminEditUserInfoViewModel> FillAdminEditUserInfoViewModel(ulong userId);

        Task<bool> IsValidMobileForUserEditByAdmin(string mobile, ulong userId);

        Task<bool> IsValidEmailForUserEditByAdmin(string email, ulong userId);

        Task<AdminEditUserInfoResult> EditUserInfo(AdminEditUserInfoViewModel edit, IFormFile? UserAvatar);

        #endregion

        #region User Panel

        Task<AddNewUserResult> CreateUserFromDoctorPanel(AddEmployeeViewModel user, IFormFile? avatar, ulong MasterId);

        Task<UserPanelEditUserInfoViewModel> FillUserPanelEditUserInfoViewModel(ulong userId);

        Task<UserPanelEditUserInfoResult> EditUserInfoInUserPanel(UserPanelEditUserInfoViewModel edit, IFormFile? UserAvatar);

        Task<ChangeUserPasswordResponse> ChangeUserPasswordAsync(ulong userId, ChangeUserPasswordViewModel model);

        #endregion
    }
}
