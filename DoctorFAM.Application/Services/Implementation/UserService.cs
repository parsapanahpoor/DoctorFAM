using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Application.Utils;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Account;
using DoctorFAM.Domain.ViewModels.Admin;
using DoctorFAM.Domain.ViewModels.Admin.Account;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.UserPanel.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        #region Ctor

        public DoctorFAMDbContext _context { get; set; }
        public ISiteSettingService _siteSettingService { get; set; }

        private IViewRenderService _viewRenderService;

        private IEmailSender _emailSender;

        public IUserRepository _userRepository;

        public UserService(DoctorFAMDbContext context, ISiteSettingService siteSettingService, IViewRenderService viewRenderService, IEmailSender emailSender, IUserRepository userRepository)
        {
            _context = context;
            _siteSettingService = siteSettingService;
            _viewRenderService = viewRenderService;
            _emailSender = emailSender;
            _userRepository = userRepository;
        }

        #endregion

        #region Authorize

        public async Task<bool> IsExistUserById(ulong userId)
        {
            return await _userRepository.IsExistUserById(userId);
        }

        public async Task<User?> GetUserByMobile(string mobile)
        {
            return await _context.Users.FirstOrDefaultAsync(s =>
                s.Mobile == mobile.Trim().ToLower() && !s.IsDelete);
        }

        public async Task<LoginResult> CheckUserForLogin(LoginUserViewModel login)
        {
            // get email and password
            var password = PasswordHasher.EncodePasswordMd5(login.Password.SanitizeText());
            var mobile = login.Mobile.Trim().ToLower().SanitizeText();

            // get user by email
            var user = await GetUserByMobile(mobile);

            // check user exists
            if (user == null) return LoginResult.UserNotFound;

            // check user password
            if (!user.Password.Equals(password)) return LoginResult.UserNotFound;

            // check user ban status
            if (user.IsBan) return LoginResult.UserIsBan;

            // check user activation
            if (!user.IsMobileConfirm) return LoginResult.MobileNotActivated;

            return LoginResult.Success;
        }

        public async Task<bool> IsExistsUserByEmail(string email)
        {
            return await _context.Users.AnyAsync(s => s.Email == email.Trim().ToLower() && !s.IsDelete);
        }

        public async Task<bool> IsExistUserByMobile(string mobile)
        {
            return await _context.Users.AnyAsync(p => p.Mobile == mobile && !p.IsDelete);
        }

        public async Task<User?> GetUserById(ulong userId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(s => s.Id == userId && !s.IsDelete);
        }

        public async Task<RegisterUserResult> RegisterUser(RegisterUserViewModel register)
        {
            //Fix Email Format
            var mobile = register.Mobile.Trim().ToLower().SanitizeText();

            //Check Email Address
            if (await IsExistsUserByEmail(register.Mobile))
            {
                return RegisterUserResult.MobileExist;
            }

            //Check Mobile Number
            if (await IsExistUserByMobile(register.Mobile))
            {
                return RegisterUserResult.MobileExist;
            }

            //Field about Accept Site Roles
            if (register.SiteRoles == false)
            {
                return RegisterUserResult.SiteRoleNotAccept; 
            }

            //Hash Password
            var password = PasswordHasher.EncodePasswordMd5(register.Password.SanitizeText());

            //Create User
            var User = new DoctorFAM.Domain.Entities.Account.User()
            {
                //Email = email,
                Password = password,
                Username = mobile,
                Mobile = register.Mobile.SanitizeText(),
                EmailActivationCode = CodeGenerator.GenerateUniqCode(),
                MobileActivationCode = CodeGenerator.GenerateUniqCode(),
            };

            await _context.Users.AddAsync(User);
            await _context.SaveChangesAsync();

            #region Send Email


            var emailViewModel = new EmailViewModel
            {
                EmailActivationCode = User.EmailActivationCode,
                ButtonName = "فعالسازی حساب کاربری",
                FullName = User.Username,
                Description = $"{User.Username} عزیز لطفا جهت فعالسازی حساب کاربری خود روی لینک زیر کلیک کنید .",
                ButtonLink = $"{PathTools.SiteAddress}/Activate-Account/{User.EmailActivationCode}",
                EmailBanner = string.Empty,
            };

            // string body = _viewRenderService.RenderToStringAsync("_Email", emailViewModel);

            //  await _emailSender.SendEmail(email, "فعالسازی حساب کاربری", body);

            //var result = SendEmail.Send(User.Email, "فعالسازی حساب کاربری", body);


            #endregion


            return RegisterUserResult.Success;

        }

        public async Task<bool> AccountActivation(string emailActivationCode)
        {
            // get user by email activation code
            var user = await GetUserByEmailActivationCode(emailActivationCode);

            // check user exists
            if (user == null) return false;

            // update user
            user.IsEmailConfirm = true;
            user.EmailActivationCode = CodeGenerator.GenerateUniqCode();

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<User?> GetUserByEmailActivationCode(string emailActivationCode)
        {
            return await _context.Users.FirstOrDefaultAsync(s =>
                s.EmailActivationCode == emailActivationCode.SanitizeText());
        }

        public async Task<bool> ForgotPasswordUser(ForgotPasswordViewModel forgotPassword)
        {
            // get user by email
            var user = await GetUserByMobile(forgotPassword.Mobile.SanitizeText());

            // check user exists
            if (user == null) return false;

            #region Send Email

            var emailViewModel = new EmailViewModel
            {
                EmailActivationCode = user.EmailActivationCode,
                ButtonName = "فعالسازی حساب کاربری",
                FullName = user.Username,
                Description = $"{user.Username} عزیز لطفا جهت بازیابی کلمه عبور روی لینک زیر کلیک کنید .",
                ButtonLink = $"{PathTools.SiteAddress}/ResetPassword/{user.EmailActivationCode}",
                EmailBanner = string.Empty,
            };

            // string body = _viewRenderService.RenderToStringAsync("_Email", emailViewModel);

            // await _emailSender.SendEmail(forgotPassword.Email.SanitizeText(), "بازیابی کلمه عبور", body);

            #endregion

            return true;
        }

        public async Task<ResetPasswordViewModel> GetResetPasswordViewModel(string emailActivationCode)
        {
            // get user by activation code
            var user = await GetUserByEmailActivationCode(emailActivationCode.SanitizeText());

            // check user exists
            if (user == null) return null;

            return new ResetPasswordViewModel()
            {
                MobileActivationCode = user.MobileActivationCode
            };
        }

        public async Task<bool> ResetPassword(ResetPasswordViewModel resetPassword)
        {
            // get user by activation code
            var user = await GetUserByEmailActivationCode(resetPassword.MobileActivationCode);

            // check user exists
            if (user == null) return false;

            // hash password
            var password = PasswordHasher.EncodePasswordMd5(resetPassword.Password.SanitizeText());

            // update user
            user.Password = password;
            user.IsEmailConfirm = true;
            user.EmailActivationCode = CodeGenerator.GenerateUniqCode();

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }

        #endregion

        #region Site Side

        public async Task RegisterDoctors(string mobile)
        {
            #region Get User By Mobile

            var user = await GetUserByMobile(mobile);

            #endregion

            #region Add Doctor Role To User

            var userRole = new UserRole()
            {
                RoleId = 2,
                UserId = user.Id
            };

            await _context.UserRoles.AddAsync(userRole);

            await _context.SaveChangesAsync();

            #endregion
        }

        public async Task RegisterSeller(string mobile)
        {
            #region Get User By Mobile

            var user = await GetUserByMobile(mobile);

            #endregion

            #region Add Seller Role To User

            var userRole = new UserRole()
            {
                RoleId = 4,
                UserId = user.Id
            };

            await _context.UserRoles.AddAsync(userRole);

            await _context.SaveChangesAsync();

            #endregion
        }

        #endregion

        #region Admin

        public async Task<FilterUserViewModel> FilterUsers(FilterUserViewModel filter)
        {
            var query = _context.Users
                .Where(s => !s.IsDelete)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region Status

            switch (filter.Status)
            {
                case UserStatus.All:
                    break;
                case UserStatus.EmailConfirmed:
                    query = query.Where(s => s.IsEmailConfirm);
                    break;
                case UserStatus.EmailNotConfirmed:
                    query = query.Where(s => !s.IsEmailConfirm);
                    break;
                case UserStatus.MobileConfirmed:
                    query = query.Where(s => s.IsMobileConfirm);
                    break;
                case UserStatus.MobileNotConfirmed:
                    query = query.Where(s => !s.IsMobileConfirm);
                    break;
                case UserStatus.BanForComment:
                    query = query.Where(s => s.BanForComment);
                    break;
                case UserStatus.IsBan:
                    query = query.Where(s => s.IsBan);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.Email))
            {
                query = query.Where(s => EF.Functions.Like(s.Email, $"%{filter.Email}%"));
            }

            if (!string.IsNullOrEmpty(filter.Mobile))
            {
                query = query.Where(s => s.Mobile != null && EF.Functions.Like(s.Mobile, $"%{filter.Mobile}%"));
            }

            if (filter.RoleId != 0)
            {
                query = query.Include(s => s.UserRoles).Where(s => s.UserRoles.Select(s => s.RoleId).Contains(filter.RoleId));
            }

            //if (!string.IsNullOrEmpty(filter.FromDate))
            //{
            //    var fromDate = filter.FromDate.ToMiladiDateTime();
            //    query = query.Where(s => s.CreateDate >= fromDate);
            //}

            if (!string.IsNullOrEmpty(filter.FullName))
            {
                query = query.Where(s => s.Username.Contains(filter.FullName));
            }

            //if (!string.IsNullOrEmpty(filter.ToDate))
            //{
            //    var toDate = filter.ToDate.ToMiladiDateTime();
            //    query = query.Where(s => s.CreateDate <= toDate);
            //}

            if (filter.TodayRegister == true)
            {
                query = query.Where(p => !p.IsDelete && p.CreateDate.Year == DateTime.Now.Year && p.CreateDate.DayOfYear == DateTime.Now.DayOfYear);
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        public async Task<bool> ChangePasswordInAdmin(ChangePasswordInAdminViewModel passwordViewModel)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a => a.Id == passwordViewModel.UserId);

            if (user == null)
            {
                return false;
            }

            user.Password = PasswordHasher.EncodePasswordMd5(passwordViewModel.Password);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<AdminEditUserInfoViewModel> FillAdminEditUserInfoViewModel(ulong userId)
        {
            #region Get User By Id

            var user = await GetUserById(userId);

            if (user == null) return null;

            #endregion

            #region Get User Role

            var userRoleIds = await _context.UserRoles
               .Where(s => !s.IsDelete && s.UserId == userId)
               .Select(s => s.RoleId)
               .ToListAsync();

            #endregion

            #region Fill View Model

            AdminEditUserInfoViewModel model = new AdminEditUserInfoViewModel()
            {
                Mobile = user.Mobile,
                Email = user.Email,
                BanForComment = user.BanForComment,
                BanForTicket = user.BanForTicket,
                IsAdmin = user.IsAdmin,
                IsBan = user.IsBan,
                IsEmailConfirm = user.IsEmailConfirm,
                IsMobileConfirm = user.IsMobileConfirm,
                username = user.Username,
                UserRoles = userRoleIds,
                UserId = user.Id,
                AvatarName = user.Avatar,
                ExtraPhoneNumber = user.ExtraPhoneNumber,
                FatherName = user.FatherName,
                FirstName = user.FirstName,
                HomePhoneNumber = user.HomePhoneNumber,
                LastName = user.LastName,
                NationalId = user.NationalId,
                WorkAddress = user.WorkAddress
            };

            if (user.BithDay != null && user.BithDay.HasValue)
            {
                model.BithDay = user.BithDay.Value.ToShamsi();
            }

            if (!string.IsNullOrEmpty(user.NationalId))
            {
                model.NationalId = user.NationalId;
            }

            #endregion

            return model;
        }

        public async Task<AdminEditUserInfoResult> EditUserInfo(AdminEditUserInfoViewModel edit, IFormFile? UserAvatar)
        {
            #region Data Valdiation

            var user = await GetUserById(edit.UserId);

            if (user == null)
            {
                return AdminEditUserInfoResult.UserNotFound;
            }

            if (UserAvatar != null && !UserAvatar.IsImage())
            {
                return AdminEditUserInfoResult.NotValidImage;
            }

            if (UserAvatar != null)
            {
                if (!string.IsNullOrEmpty(user.Avatar))
                {
                    user.Avatar.DeleteImage(PathTools.UserAvatarPathServer, PathTools.UserAvatarPathThumbServer);
                }

                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(UserAvatar.FileName);
                UserAvatar.AddImageToServer(imageName, PathTools.UserAvatarPathServer, 270, 270, PathTools.UserAvatarPathThumbServer);
                user.Avatar = imageName;
            }

            if (!string.IsNullOrEmpty(edit.Email))
            {
                if (!await IsValidEmailForUserEditByAdmin(edit.Email, user.Id))
                {
                    return AdminEditUserInfoResult.NotValidEmail;
                }
            }

            if (!string.IsNullOrEmpty(edit.Mobile) && !await IsValidMobileForUserEditByAdmin(edit.Mobile, user.Id))
            {
                return AdminEditUserInfoResult.NotValidMobile;
            }

            #endregion

            #region Update User Field

            user.Username = edit.username.SanitizeText();
            user.Email = edit.Email;
            user.Mobile = edit.Mobile;
            user.IsMobileConfirm = edit.IsMobileConfirm;
            user.IsEmailConfirm = edit.IsEmailConfirm;
            user.IsAdmin = edit.IsAdmin;
            user.IsBan = edit.IsBan;
            user.BanForComment = edit.BanForComment;
            user.BanForTicket = edit.BanForTicket;
            user.NationalId = edit.NationalId;
            user.FirstName = edit.FirstName;
            user.LastName = edit.LastName;
            user.ExtraPhoneNumber = edit.ExtraPhoneNumber;
            user.FatherName = edit.FatherName;
            user.HomePhoneNumber = edit.HomePhoneNumber;
            user.WorkAddress = edit.WorkAddress;

            if (!string.IsNullOrEmpty(edit.BithDay))
            {
                user.BithDay = edit.BithDay.ToMiladiDateTime();
            }

            _context.Update(user);
            await _context.SaveChangesAsync();

            #endregion

            #region Delete User Rols

            var roles = await _context.UserRoles.Where(s => !s.IsDelete && s.UserId == user.Id).ToListAsync();

            _context.RemoveRange(roles);

            #endregion

            #region Add User Roles

            if (edit.UserRoles != null && edit.UserRoles.Any())
            {
                foreach (var roleId in edit.UserRoles)
                {
                    var userRole = new UserRole()
                    {
                        RoleId = roleId,
                        UserId = user.Id
                    };
                    await _context.AddAsync(userRole);
                }

                await _context.SaveChangesAsync();
            }

            #endregion

            return AdminEditUserInfoResult.Success;
        }

        public async Task<bool> IsValidMobileForUserEditByAdmin(string mobile, ulong userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(s => !s.IsDelete && s.Mobile == mobile.Trim());

            if (user == null) return true;
            if (user.Id == userId) return true;

            return false;
        }

        public async Task<bool> IsValidEmailForUserEditByAdmin(string email, ulong userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(s => !s.IsDelete && s.Email == email.Trim().ToLower());

            if (user == null) return true;

            if (user.Id == userId) return true;

            return false;
        }

        #endregion

        #region User Panel

        public async Task<UserPanelEditUserInfoViewModel> FillUserPanelEditUserInfoViewModel(ulong userId)
        {
            #region Get User By Id

            var user = await GetUserById(userId);

            if (user == null) return null;

            #endregion

            #region Fill View Model

            UserPanelEditUserInfoViewModel model =  new UserPanelEditUserInfoViewModel()
            {
                Mobile = user.Mobile,
                Email = user.Email,
                UserId = user.Id,
                AvatarName = user.Avatar,
                username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ExtraPhoneNumber = user.ExtraPhoneNumber,  
                FatherName = user.FatherName,
                HomePhoneNumber = user.HomePhoneNumber,
                WorkAddress = user.WorkAddress,
            };

            if (user.BithDay != null && user.BithDay.HasValue)
            {
                model.BithDay = user.BithDay.Value.ToShamsi();
            }

            if (!string.IsNullOrEmpty(user.NationalId))
            {
                model.NationalId = user.NationalId;
            }

            #endregion

            return model;
        }

        public async Task<UserPanelEditUserInfoResult> EditUserInfoInUserPanel(UserPanelEditUserInfoViewModel edit, IFormFile? UserAvatar)
        {
            #region Data Valdiation

            var user = await GetUserById(edit.UserId);

            if (user == null)
            {
                return UserPanelEditUserInfoResult.UserNotFound;
            }

            if (UserAvatar != null && !UserAvatar.IsImage())
            {
                return UserPanelEditUserInfoResult.NotValidImage;
            }

            if (UserAvatar != null)
            {
                if (!string.IsNullOrEmpty(user.Avatar))
                {
                    user.Avatar.DeleteImage(PathTools.UserAvatarPathServer, PathTools.UserAvatarPathThumbServer);
                }

                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(UserAvatar.FileName);
                UserAvatar.AddImageToServer(imageName, PathTools.UserAvatarPathServer, 270, 270, PathTools.UserAvatarPathThumbServer);
                user.Avatar = imageName;
            }

            if (!string.IsNullOrEmpty(edit.Email))
            {
                if (!await IsValidEmailForUserEditByAdmin(edit.Email, user.Id))
                {
                    return UserPanelEditUserInfoResult.NotValidEmail;
                }
            }

            if (string.IsNullOrEmpty(edit.NationalId))
            {
                return UserPanelEditUserInfoResult.NationalId;
            }
          
            #endregion

            #region Update User Field

            user.Username = edit.username.SanitizeText();
            user.Email = edit.Email.SanitizeText();
            user.FirstName = edit.FirstName.SanitizeText();
            user.LastName = edit.LastName.SanitizeText();
            user.BithDay = edit.BithDay.ToMiladiDateTime();
            user.FatherName = edit.FatherName.SanitizeText();
            user.NationalId = edit.NationalId;
            user.ExtraPhoneNumber = edit.ExtraPhoneNumber.SanitizeText();
            user.HomePhoneNumber = edit.HomePhoneNumber.SanitizeText();
            user.WorkAddress = edit.WorkAddress.SanitizeText();

            _context.Update(user);
            await _context.SaveChangesAsync();

            #endregion

            return UserPanelEditUserInfoResult.Success;
        }

        public async Task<ChangeUserPasswordResponse> ChangeUserPasswordAsync(ulong userId, ChangeUserPasswordViewModel model)
        {
            #region Get User By Id

            var user = await GetUserById(userId);

            if (user == null) return ChangeUserPasswordResponse.UserNotFound;

            #endregion

            #region Change Password

            if (user.Password != PasswordHasher.EncodePasswordMd5(model.CurrentPassword))
            {
                return ChangeUserPasswordResponse.WrongPassword;
            }

            user.Password = PasswordHasher.EncodePasswordMd5(model.NewPassword);
            await _userRepository.EditUser(user);

            #endregion

            return ChangeUserPasswordResponse.Success;
        }

        #endregion
    }
}
