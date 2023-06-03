#region usings

using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.CooperationRequest;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Account;
using DoctorFAM.Domain.ViewModels.Admin;
using DoctorFAM.Domain.ViewModels.Admin.Account;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Employees;
using DoctorFAM.Domain.ViewModels.Laboratory.Employee;
using DoctorFAM.Domain.ViewModels.Site.Account;
using DoctorFAM.Domain.ViewModels.UserPanel.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static DoctorFAM.Domain.ViewModels.UserPanel.FilterUserViewModel;

#endregion

namespace DoctorFAM.Application.Services.Implementation;

public class UserService : IUserService
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;
    private readonly ISiteSettingService _siteSettingService;
    private readonly IViewRenderService _viewRenderService;
    private readonly IEmailSender _emailSender;
    private readonly IUserRepository _userRepository;
    private readonly IOrganizationService _organizationService;
    private readonly ISMSService _smsservice;
    private static readonly HttpClient client = new HttpClient();
    private readonly IDoctorsRepository _doctorService;
    private readonly IPopulationCoveredRepository _populationCoveredService;

    public UserService(DoctorFAMDbContext context, ISiteSettingService siteSettingService, IViewRenderService viewRenderService,
                            IEmailSender emailSender, IUserRepository userRepository, IOrganizationService organizationService, ISMSService smsservice
                                , IDoctorsRepository doctorService, IPopulationCoveredRepository populationCoveredService)
    {
        _context = context;
        _siteSettingService = siteSettingService;
        _viewRenderService = viewRenderService;
        _emailSender = emailSender;
        _userRepository = userRepository;
        _organizationService = organizationService;
        _smsservice = smsservice;
        _doctorService = doctorService;
        _populationCoveredService = populationCoveredService;
    }

    #endregion

    #region Authorize

    //Get User Mobile With As No Tracking
    public async Task<string?> GetUserMobileByUserIdWithAsNoTracking(ulong userId)
    {
        return await _context.Users.AsNoTracking().Where(p => !p.IsDelete && p.Id == userId)
                                    .Select(p => p.Mobile).FirstOrDefaultAsync();
    }

    //Get User Roles 
    public async Task<List<string>?> GetUserRoles(ulong userId)
    {
        return await _userRepository.GetUserRoles(userId);
    }

    //Check That Has User Fill Personal Information 
    public async Task<bool> CheckThatHasUserFillPersonalInformation(ulong userId)
    {
        #region Get User By User Id

        var user = await GetUserById(userId);
        if (user == null) return false;

        #endregion

        #region Check User Info

        if (string.IsNullOrEmpty(user.NationalId)
            || string.IsNullOrEmpty(user.Mobile)
            || string.IsNullOrEmpty(user.FirstName)
            || string.IsNullOrEmpty(user.LastName)
            || string.IsNullOrEmpty(user.Username))
        {
            return false;
        }

        #endregion

        return true;
    }

    //Add User Role 
    public async Task AddUserRole(UserRole userRole)
    {
        await _userRepository.AddUserRole(userRole);
    }

    public async Task ResendActivationCodeSMS(string Mobile)
    {
        var user = await _userRepository.GetUserByMobile(Mobile);
        user.MobileActivationCode = new Random().Next(10000, 999999).ToString();
        user.ExpireMobileSMSDateTime = DateTime.Now;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        #region Send Verification Code SMS

        var result = $"https://api.kavenegar.com/v1/564672526D58694D3477685571796F7372574F576C476B6366785462356D3164683370395A2B61356D6E383D/verify/lookup.json?receptor={user.Mobile}&token={user.MobileActivationCode}&template=Register";
        var results = client.GetStringAsync(result);

        //var message = Messages.SendActivationRegisterSms(user.MobileActivationCode);

        //await _smsservice.SendSimpleSMS(user.Mobile, message);

        #endregion

    }

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

    //Get User By Id With As No Tracking
    public async Task<User?> GetUserByIdWithAsNoTracking(ulong userId)
    {
        return await _context.Users
                             .AsNoTracking()
                             .FirstOrDefaultAsync(s => s.Id == userId && !s.IsDelete);
    }

    //Get User Avatar Name By User Id
    public async Task<string?> GetUserImageNameByUserId(ulong userId)
    {
        #region Get User By Id 

        var user = await GetUserById(userId);
        if (user is null) return null;

        #endregion

        return user.Avatar;
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
            MobileActivationCode = new Random().Next(10000, 999999).ToString(),
            ExpireMobileSMSDateTime = DateTime.Now
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

        #endregion

        #region Send Verification Code SMS

        var result = $"https://api.kavenegar.com/v1/564672526D58694D3477685571796F7372574F576C476B6366785462356D3164683370395A2B61356D6E383D/verify/lookup.json?receptor={User.Mobile}&token={User.MobileActivationCode}&template=Register";
        var results = client.GetStringAsync(result);

        //var message = Messages.SendActivationRegisterSms(User.MobileActivationCode);

        //await _smsservice.SendSimpleSMS(User.Mobile, message);

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

    public async Task<ResetPasswordResult> ResetUserPassword(ResetPasswordViewModel pass, string mobile)
    {
        #region Get User By Mobile

        var user = await GetUserByMobile(mobile);
        if (user == null) return ResetPasswordResult.NotFound;

        if (user.MobileActivationCode != pass.ActiveCode) return ResetPasswordResult.WrongActiveCode;

        #endregion

        #region Update User Info

        user.Password = PasswordHasher.EncodePasswordMd5(pass.Password.SanitizeText());
        user.IsMobileConfirm = true;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        #endregion

        return ResetPasswordResult.Success;
    }

    //Add Cooperation Request
    public async Task AddCooperationRequest(string mobile, string RoleTitle, string UserName)
    {
        #region Send Cooperation Requestt 

        CooperationRequest cooperation = new CooperationRequest()
        {
            FollowedUp = false,
            Mobile = mobile.SanitizeText(),
            RoleTitle = RoleTitle.SanitizeText(),
            UserName = UserName.SanitizeText(),
        };

        await _userRepository.AddCooperationRequest(cooperation);

        #endregion
    }

    //Send Cooperation Request For Exist User
    public async Task<bool> SendCooperationRequestForExistUser(User user, string roleName)
    {
        #region Get User Roles

        var userRoles = await _userRepository.GetUserRolesByUserId(user.Id);

        //Check That User Has This Role Or Not 
        if (userRoles != null)
        {
            //If User Select Doctor Role While User Has Doctor Role
            if (roleName == "doctor" && userRoles.Contains(2)) return false;
            if (roleName == "doctor" && userRoles.Contains(5)) return false;

            //If User Select Seller Role While User Has Seller Role
            if (roleName == "seller" && userRoles.Contains(4)) return false;

            //If User Select Consultant Role While User Has Consultant Role
            if (roleName == "Consultant" && userRoles.Contains(15)) return false;

            //If User Select Nurse Role While User Has Nurse Role
            if (roleName == "Nurse" && userRoles.Contains(14)) return false;

            //If User Select Labratory Role While User Has Labratory Role
            if (roleName == "Labratory" && userRoles.Contains(16)) return false;
            if (roleName == "Labratory" && userRoles.Contains(17)) return false;
            if (roleName == "Labratory" && userRoles.Contains(18)) return false;

            //If User Select pharmacy Role While User Has pharmacy Role
            if (roleName == "pharmacy" && userRoles.Contains(6)) return false;

            //If User Select Dentist Role While User Has Dentist Role
            if (roleName == "Dentist" && userRoles.Contains(19)) return false;
        }

        #endregion

        #region Add Role To The User

        //Add Doctor Role To The User
        if (roleName == "doctor")
        {
            var userRole = new UserRole()
            {
                RoleId = 2,
                UserId = user.Id
            };

            await _userRepository.AddUserRole(userRole);
        }

        //Add seller Role To The User
        if (roleName == "seller")
        {
            var userRole = new UserRole()
            {
                RoleId = 4,
                UserId = user.Id
            };

            await _userRepository.AddUserRole(userRole);
        }

        //Add Consultant Role To The User
        if (roleName == "Consultant")
        {
            var userRole = new UserRole()
            {
                RoleId = 15,
                UserId = user.Id
            };

            await _userRepository.AddUserRole(userRole);
        }

        //Add Nurse Role To The User
        if (roleName == "Nurse")
        {
            var userRole = new UserRole()
            {
                RoleId = 14,
                UserId = user.Id
            };

            await _userRepository.AddUserRole(userRole);
        }

        //Add Labratory Role To The User
        if (roleName == "Labratory")
        {
            var userRole = new UserRole()
            {
                RoleId = 16,
                UserId = user.Id
            };

            await _userRepository.AddUserRole(userRole);
        }

        //Add pharmacy Role To The User
        if (roleName == "pharmacy")
        {
            var userRole = new UserRole()
            {
                RoleId = 6,
                UserId = user.Id
            };

            await _userRepository.AddUserRole(userRole);
        }

        //Add Dentist Role To The User
        if (roleName == "Dentist")
        {
            var userRole = new UserRole()
            {
                RoleId = 19,
                UserId = user.Id
            };

            await _userRepository.AddUserRole(userRole);
        }

        #endregion

        return true;
    }

    #endregion

    #region Cooperation Request 

    //Get Cooperation Request By Id
    public async Task<DoctorFAM.Domain.Entities.CooperationRequest.CooperationRequest?> GetCooperationRequestById(ulong requestCooperationId)
    {
        return await _userRepository.GetCooperationRequestById(requestCooperationId);
    }

    //Seen Cooperation Requests
    public async Task<bool> SeenCooperationRequests(ulong cooperationRequestId)
    {
        #region Get Request Cooperation Request

        var request = await GetCooperationRequestById(cooperationRequestId);
        if (request == null || request.FollowedUp)
        {
            return false;
        }

        #endregion

        #region Update Request Cooperation State 

        request.FollowedUp = true;

        //Update Method 
        await _userRepository.UpdateCooperationRequestToFowloadedUp(request);

        #endregion

        return true;
    }

    //Delete Cooperation Requests
    public async Task<bool> DeleteCooperationRequests(ulong cooperationRequestId)
    {
        #region Get Request Cooperation Request

        var request = await GetCooperationRequestById(cooperationRequestId);
        if (request == null)
        {
            return false;
        }

        #endregion

        #region Update Request Cooperation State 

        request.IsDelete = true;

        //Update Method 
        await _userRepository.UpdateCooperationRequestToFowloadedUp(request);

        #endregion

        return true;
    }

    //List Of Cooperation Requests
    public async Task<List<DoctorFAM.Domain.Entities.CooperationRequest.CooperationRequest>> ListOfCooperationRequests()
    {
        return await _userRepository.ListOfCooperationRequests();
    }

    #endregion

    #region Site Side

    //Get Username By User ID
    public async Task<string?> GetUsernameByUserID(ulong userId)
    {
        return await _userRepository.GetUsernameByUserID(userId);
    }

    //Is Exist Any Organization With Waiting State From Current User
    public async Task<bool> IsExistAnyCooperationRequestWithWaitingStateFromCurrentUser(ulong userId)
    {
        #region Get Organization by UserId

        var organization = await _organizationService.IsExistAnyWaitingOrganizationWithThisCurrentUser(userId);

        if (organization == true) return true;

        #endregion

        return false;
    }

    //Get User By Username
    public async Task<User?> GetUserByUsername(string userName)
    {
        return await _userRepository.GetUserByUsername(userName);
    }

    public async Task<ForgotPasswordResult> RecoverUserPassword(ForgetPasswordViewModel forgot)
    {
        #region Get User By Mobile

        var user = await GetUserByMobile(forgot.Mobile);
        if (user == null) return ForgotPasswordResult.NotFound;

        if (user != null && user.IsBan)
        {
            return ForgotPasswordResult.UserIsBlocked;
        }

        #endregion

        #region Update User Info

        user.MobileActivationCode = new Random().Next(10000, 999999).ToString();
        user.ExpireMobileSMSDateTime = DateTime.Now;

        _context.Users.Update(user);

        await _context.SaveChangesAsync();

        #endregion

        #region Send Verification Code SMS

        var result = $"https://api.kavenegar.com/v1/564672526D58694D3477685571796F7372574F576C476B6366785462356D3164683370395A2B61356D6E383D/verify/lookup.json?receptor={user.Mobile}&token={user.MobileActivationCode}&template=Register";
        var results = client.GetStringAsync(result);

        #endregion

        return ForgotPasswordResult.Success;
    }

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

    //Register Nurse
    public async Task RegisterNurse(string mobile)
    {
        #region Get User By Mobile

        var user = await GetUserByMobile(mobile);

        #endregion

        #region Add Nurse Role To User

        var userRole = new UserRole()
        {
            RoleId = 14,
            UserId = user.Id
        };

        await _context.UserRoles.AddAsync(userRole);

        await _context.SaveChangesAsync();

        #endregion
    }

    //Get List Of Admins About Send Notification For Arrival New Consultant Inormations
    public async Task<List<string>?> GetListOfAdminsAboutSendNotificationForArrivalNewConsultantInormations()
    {
        return await _userRepository.GetListOfAdminsAboutSendNotificationForArrivalNewConsultantInormations();
    }

    //Register Consultant
    public async Task RegisterConsultant(string mobile)
    {
        #region Get User By Mobile

        var user = await GetUserByMobile(mobile);

        #endregion

        #region Add Nurse Role To User

        var userRole = new UserRole()
        {
            RoleId = 15,
            UserId = user.Id
        };

        await _context.UserRoles.AddAsync(userRole);

        await _context.SaveChangesAsync();

        #endregion
    }

    //Register Labratory
    public async Task LabratoryConsultant(string mobile)
    {
        #region Get User By Mobile

        var user = await GetUserByMobile(mobile);

        #endregion

        #region Add Labratory Role To User

        var userRole = new UserRole()
        {
            RoleId = 16,
            UserId = user.Id
        };

        await _context.UserRoles.AddAsync(userRole);

        await _context.SaveChangesAsync();

        #endregion
    }

    //Register Dentist
    public async Task DentistConsultant(string mobile)
    {
        #region Get User By Mobile

        var user = await GetUserByMobile(mobile);

        #endregion

        #region Add Dentist Role To User

        var userRole = new UserRole()
        {
            RoleId = 19,
            UserId = user.Id
        };

        await _context.UserRoles.AddAsync(userRole);

        await _context.SaveChangesAsync();

        #endregion
    }

    public async Task RegisterPharmacy(string mobile)
    {
        #region Get User By Mobile

        var user = await GetUserByMobile(mobile);

        #endregion

        #region Add Pharmacy Role To User

        var userRole = new UserRole()
        {
            RoleId = 6,
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

    public async Task<ActiveMobileByActivationCodeResult> ActiveUserMobile(ActiveMobileByActivationCodeViewModel activeMobileByActivationCodeViewModel)
    {
        #region Get User By Mobile

        if (!await IsExistUserByMobile(activeMobileByActivationCodeViewModel.Mobile.SanitizeText()))
        {
            return ActiveMobileByActivationCodeResult.AccountNotFound;
        }

        var user = await GetUserByMobile(activeMobileByActivationCodeViewModel.Mobile.SanitizeText());
        if (user == null) return ActiveMobileByActivationCodeResult.AccountNotFound;

        #endregion

        #region Validation Activation Code

        if (user.MobileActivationCode != activeMobileByActivationCodeViewModel.MobileActiveCode)
        {
            return ActiveMobileByActivationCodeResult.AccountNotFound;
        }

        #endregion

        #region Update User 

        user.IsMobileConfirm = true;
        user.MobileActivationCode = new Random().Next(10000, 999999).ToString();

        await _context.SaveChangesAsync();

        #endregion

        return ActiveMobileByActivationCodeResult.Success;
    }

    #endregion

    #region Admin

    //Get List Of Admins About Send Notification For Arrival New Nurses Inormations
    public async Task<List<string>?> GetListOfAdminsAboutSendNotificationForArrivalNewNursesInormations()
    {
        return await _userRepository.GetListOfAdminsAboutSendNotificationForArrivalNewNursesInormations();
    }

    //Count Of Users 
    public async Task<int> CountOfUsers()
    {
        return await _userRepository.CountOfUsers();
    }

    //Get List Of Admins and Supporters User Id For Send Notification  For Home Pharmacy
    public async Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInHomePharmacy()
    {
        return await _userRepository.GetAdminsAndSupportersNotificationForSendNotificationInHomePharmacy();
    }

    //Get List Of Admins and Supporters User Id For Send Notification For Online Request
    public async Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInOnlineVisit()
    {
        return await _userRepository.GetAdminsAndSupportersNotificationForSendNotificationInOnlineVisit();
    }

    //Get List Of Admins and Supporters User Id For Send Notification For Home Visit
    public async Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInHomeVisit()
    {
        return await _userRepository.GetAdminsAndSupportersNotificationForSendNotificationInHomeVisit();
    }

    //Get List Of Admins and Supporters User Id For Send Notification For Home Laboratory
    public async Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInHomeLaboratory()
    {
        return await _userRepository.GetAdminsAndSupportersNotificationForSendNotificationInHomeLaboratory();
    }

    //Get List Of Admins and Supporters User Id For Send Notification For Death Certificate
    public async Task<List<string>?> GetAdminsAndSupportersNotificationForSendNotificationInDeathCertificate()
    {
        return await _userRepository.GetAdminsAndSupportersNotificationForSendNotificationInDeathCertificate();
    }

    //Get List Of Admins and Supporters 
    public async Task<List<string>?> GetAllAdminsAndSupportersNotification()
    {
        return await _userRepository.GetAllAdminsAndSupportersNotification();
    }

    //Get List Of Admins 
    public async Task<List<User>?> GetListOfAdmins()
    {
        return await _userRepository.GetListOfAdmins();
    }

    //Get List Of Supporters
    public async Task<List<User>?> GetListOfSupporters()
    {
        return await _userRepository.GetListOfSupporters();
    }

    //Get Home Pharmacy Supporters
    public async Task<List<User>?> GetHomePharmacySupporters()
    {
        return await _userRepository.GetHomePharmacySupporters();
    }

    //Get Home Visit Supporters
    public async Task<List<User>?> GetHomeVisitSupporters()
    {
        return await _userRepository.GetHomeVisitSupporters();
    }

    //Get Death Certificate Supporters
    public async Task<List<User>?> GetDeathCertificateSupporters()
    {
        return await _userRepository.GetDeathCertificateSupporters();
    }

    //Get Online Visit Supporters
    public async Task<List<User>?> GetOnlineVisitSupporters()
    {
        return await _userRepository.GetOnlineVisitSupporters();
    }

    //Get Home Nurse Supporters
    public async Task<List<User>?> GetHomeNurseSupporters()
    {
        return await _userRepository.GetHomeNurseSupporters();
    }

    //Update User 
    public async Task UpdateUser(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    //Filter User In Modal
    public async Task<Domain.ViewModels.UserPanel.FilterUserViewModel> FilterUsersInModal(Domain.ViewModels.UserPanel.FilterUserViewModel filter)
    {
        var query = _context.Users
            .Include(u => u.UserRoles)
            .OrderByDescending(p => p.CreateDate)
            .AsQueryable();

        #region order

        switch (filter.OrderType)
        {
            case FilterUserOrderType.CreateDate_ASC:
                query = query.OrderBy(u => u.CreateDate);
                break;
            case FilterUserOrderType.CreateDate_DES:
                query = query.OrderByDescending(u => u.CreateDate);
                break;
        }

        #endregion

        #region filter

        if ((!string.IsNullOrEmpty(filter.Email)))
        {
            query = query.Where(u => u.Email.Contains(filter.Email));
        }
        if ((!string.IsNullOrEmpty(filter.Mobile)))
        {
            query = query.Where(u => u.Mobile.Contains(filter.Mobile));
        }
        if ((!string.IsNullOrEmpty(filter.Username)))
        {
            query = query.Where(u => u.Username.Contains(filter.Username));
        }

        #endregion

        #region paging

        await filter.Paging(query);

        #endregion

        return filter;
    }

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

        if (!string.IsNullOrEmpty(edit.NationalId) && !await IsValidNationalIdForUserEditByAdmin(edit.NationalId, user.Id))
        {
            return AdminEditUserInfoResult.NotValidNationalId;
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

        #region Check That If User Has Role Then Update other Information That Related By Role Informations 

        var userRoles = await _userRepository.GetUserRoles(user.Id);

        if (userRoles != null && userRoles.Any())
        {
            //If User Is Doctor
            if (userRoles.Contains("Doctor"))
            {
                //Validation Of Doctor Organization 
                var doctorOffice = await _organizationService.GetDoctorOrganizationByUserId(user.Id);

                if (doctorOffice != null && doctorOffice.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice)
                {
                    //Get Doctor By UserId
                    var doctor = await _doctorService.GetDoctorByUserId(user.Id);

                    if (doctor != null)
                    {
                        //Get Doctors Informations By Doctor Id
                        var info = await _doctorService.GetDoctorsInformationByUserId(user.Id);

                        if (info != null)
                        {
                            info.NationalCode = user.NationalId;
                            info.GeneralPhone = user.ExtraPhoneNumber;

                            //Update Doctror Personal Information 
                            await _doctorService.UpdateDoctorsInfo(info);
                        }
                    }
                }
            }
        }

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

    //Validate For NAtional Id 
    public async Task<bool> IsValidNationalIdForUserEditByAdmin(string nationalId, ulong userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(s => !s.IsDelete && s.NationalId == nationalId.Trim());

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

    public async Task<AddNewUserResult> CreateUserFromDoctorPanel(AddEmployeeViewModel user, IFormFile? avatar, ulong MasterId)
    {
        #region Model State Validation 

        if (await IsExistUserByMobile(user.Mobile))
        {
            return AddNewUserResult.DuplicateMobileNumber;
        }

        #endregion

        #region Add New User

        var newUser = new User()
        {
            CreateDate = DateTime.Now,
            Mobile = user.Mobile.SanitizeText(),
            Password = PasswordHasher.EncodePasswordMd5(user.Password.SanitizeText()),
            IsAdmin = false,
            EmailActivationCode = CodeGenerator.GenerateUniqCode(),
            MobileActivationCode = CodeGenerator.GenerateUniqCode(),
            IsEmailConfirm = false,
            IsMobileConfirm = false,
            Username = user.Mobile.SanitizeText(),
        };

        if (avatar != null && avatar.IsImage())
        {
            var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(avatar.FileName);
            avatar.AddImageToServer(imageName, PathTools.UserAvatarPathServer, 270, 270, PathTools.UserAvatarPathThumbServer);
            newUser.Avatar = imageName;
        }

        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();

        #endregion

        #region Get Organization By User Id 

        var organization = await _organizationService.GetDoctorOrganizationByUserId(MasterId);
        if (organization == null) return AddNewUserResult.DuplicateMobileNumber;

        #endregion

        #region Add New Organization Member

        OrganizationMember member = new OrganizationMember()
        {
            UserId = newUser.Id,
            OrganizationId = organization.Id
        };

        await _context.OrganizationMembers.AddAsync(member);
        await _context.SaveChangesAsync();

        #endregion

        #region Add User Role

        UserRole userRole = new UserRole()
        {
            RoleId = 5,
            UserId = newUser.Id,
        };

        await _context.UserRoles.AddAsync(userRole);
        await _context.SaveChangesAsync();

        #endregion

        return AddNewUserResult.Success;
    }

    //Create User From Laboratory Panel
    public async Task<AddNewUserResult> CreateUserFromLaboratoryPanel(AddLaboratoryEmployeeViewModel user, IFormFile? avatar, ulong MasterId)
    {
        #region Model State Validation 

        if (await IsExistUserByMobile(user.Mobile))
        {
            return AddNewUserResult.DuplicateMobileNumber;
        }

        #endregion

        #region Add New User

        var newUser = new User()
        {
            CreateDate = DateTime.Now,
            Mobile = user.Mobile.SanitizeText(),
            Password = PasswordHasher.EncodePasswordMd5(user.Password.SanitizeText()),
            IsAdmin = false,
            EmailActivationCode = CodeGenerator.GenerateUniqCode(),
            MobileActivationCode = CodeGenerator.GenerateUniqCode(),
            IsEmailConfirm = false,
            IsMobileConfirm = false,
            Username = user.Mobile.SanitizeText(),
        };

        if (avatar != null && avatar.IsImage())
        {
            var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(avatar.FileName);
            avatar.AddImageToServer(imageName, PathTools.UserAvatarPathServer, 270, 270, PathTools.UserAvatarPathThumbServer);
            newUser.Avatar = imageName;
        }

        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();

        #endregion

        #region Get Organization By User Id 

        var organization = await _organizationService.GetLaboratoryOrganizationByUserId(MasterId);
        if (organization == null) return AddNewUserResult.DuplicateMobileNumber;

        #endregion

        #region Add New Organization Member

        OrganizationMember member = new OrganizationMember()
        {
            UserId = newUser.Id,
            OrganizationId = organization.Id
        };

        await _context.OrganizationMembers.AddAsync(member);
        await _context.SaveChangesAsync();

        #endregion

        #region Add User Roles

        var userRole1 = new UserRole()
        {
            RoleId = 17,
            UserId = newUser.Id
        };
        await _context.AddAsync(userRole1);

        if (user.UserRoles != null && user.UserRoles.Any())
        {
            foreach (var roleId in user.UserRoles)
            {
                var userRole = new UserRole()
                {
                    RoleId = roleId,
                    UserId = newUser.Id
                };
                await _context.AddAsync(userRole);
            }

            await _context.SaveChangesAsync();
        }

        #endregion

        return AddNewUserResult.Success;
    }

    public async Task<UserPanelEditUserInfoViewModel> FillUserPanelEditUserInfoViewModel(ulong userId)
    {
        #region Get User By Id

        var user = await GetUserById(userId);

        if (user == null) return null;

        #endregion

        #region Fill View Model

        UserPanelEditUserInfoViewModel model = new UserPanelEditUserInfoViewModel()
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

        if (!string.IsNullOrEmpty(edit.NationalId) && !await IsValidNationalIdForUserEditByAdmin(edit.NationalId, user.Id))
        {
            return UserPanelEditUserInfoResult.NotValidNationalId;
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

        #region Check That If User Has Role Then Update other Information That Related By Role Informations 

        var userRoles = await _userRepository.GetUserRoles(user.Id);

        if (userRoles != null && userRoles.Any())
        {
            //If User Is Doctor
            if (userRoles.Contains("Doctor"))
            {
                //Validation Of Doctor Organization 
                var doctorOffice = await _organizationService.GetDoctorOrganizationByUserId(user.Id);

                if (doctorOffice != null && doctorOffice.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice)
                {
                    //Get Doctor By UserId
                    var doctor = await _doctorService.GetDoctorByUserId(user.Id);

                    if (doctor != null)
                    {
                        //Get Doctors Informations By Doctor Id
                        var info = await _doctorService.GetDoctorsInformationByUserId(user.Id);

                        if (info != null)
                        {
                            info.NationalCode = user.NationalId;
                            info.GeneralPhone = user.ExtraPhoneNumber;

                            //Update Doctror Personal Information 
                            await _doctorService.UpdateDoctorsInfo(info);
                        }
                    }
                }
            }
        }

        #endregion

        #region If Exist User By National Id In Population Covered Table

        if (await _populationCoveredService.IsExistRecordeByNationalId(edit.NationalId.Trim().ToLower().SanitizeText()))
        {
            #region Delete Population Covered 

            //Get Population Covered 
            var population = await _populationCoveredService.GetUserByNationalIdFromPopulationCovered(edit.NationalId);
            if (population == null) return UserPanelEditUserInfoResult.NotValidNationalId;

            //Delete Population Covered 
            population.IsDelete = true;

            //Update Population Covered 
            await _populationCoveredService.UpdatePopulationCovered(population);

            #region Send SMS To The Master Of Current Population 

            var master = await GetUserById(edit.UserId);
            if (master == null) return UserPanelEditUserInfoResult.NotValidNationalId;

            //Initial SMS Body With Algorithm
            var message = Messages.SendSMSToTheMasterOfPopulationCover(edit.NationalId, user.Mobile);
            await _smsservice.SendSimpleSMS(user.Mobile, message);

            #endregion

            #endregion
        }

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

    //Is Exist Any User By National Id 
    public async Task<bool> IsExistAnyUserByNationalId(string nationalId)
    {
        return await _userRepository.IsExistAnyUserByNationalId(nationalId);
    }

    #endregion
}
