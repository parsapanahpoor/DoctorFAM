using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.ViewModels.Account;
using DoctorFAM.Domain.ViewModels.Site.Account;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DoctorFAM.Web.Controllers
{
    public class AccountController : SiteBaseController
    {
        #region Ctor

        private readonly IUserService _userService;
        private readonly ISMSService _smsservice;
        private readonly ISiteSettingService _siteSettingService;

        public AccountController(IUserService userService, ISMSService smsservice, ISiteSettingService siteSettingService)
        {
            _userService = userService;
            _smsservice = smsservice;
            _siteSettingService = siteSettingService;
        }

        #endregion

        #region Register

        [HttpGet("Register")]
        [RedirectHomeIfLoggedInActionFilter]
        public IActionResult Register(bool? doctors, bool? seller , bool? pharmacy , bool? nurse)
        {
            #region About Doctors & Seller & Pharmacy

            ViewBag.DoctorsRegister = doctors;

            ViewBag.SellerRegister = seller;

            ViewBag.PharmacyRegister = pharmacy;

            ViewBag.NurseRegister = nurse;

            #endregion

            return View();
        }

        [HttpPost("Register"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel register)
        {
            #region Model State Validations

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "مقادیر وارد شده معتبر نمی باشد . ";
                return View(register);
            }

            #endregion

            #region Register User Methods

            var result = await _userService.RegisterUser(register);

            switch (result)
            {
                case RegisterUserResult.MobileExist:
                    TempData[ErrorMessage] = "تلفن همراه وارد شده تکراری می باشد";
                    TempData[InfoMessage] = "در صورتی که از قبل در سایت ثبت نام کردید از گزینه ی ورود به سایت استفاده کنید";
                    ModelState.AddModelError("Mobile", "تلفن همراه وارد شده تکراری می باشد");
                    break;

                case RegisterUserResult.SiteRoleNotAccept:
                    TempData[ErrorMessage] = "قوانین سایت باید پذیرفته شوند ";
                    break;

                case RegisterUserResult.Success:
                    TempData[SuccessMessage] = "ثبت نام شما با موفقیت انجام شد .";
                    TempData[InfoMessage] = $"پیامی  حاوی کد فعالسازی حساب کاربری به {register.Mobile} ارسال شد .";

                    #region Doctors Register

                    if (register.DoctorsRegister == true)
                    {
                        await _userService.RegisterDoctors(register.Mobile);
                    }

                    #endregion

                    #region Seller Register

                    if (register.SellerRegister == true)
                    {
                        await _userService.RegisterSeller(register.Mobile);
                    }

                    #endregion

                    #region Pharmacy Register

                    if (register.PharmacyRegister == true)
                    {
                        await _userService.RegisterPharmacy(register.Mobile);
                    }

                    #endregion

                    #region Nurse Register

                    if (register.NurseRegister == true)
                    {
                        await _userService.RegisterNurse(register.Mobile);
                    }

                    #endregion

                    return RedirectToAction("ActiveUserByMobileActivationCode", new { Mobile = register.Mobile });
            }

            #endregion

            return View(register);
        }

        #endregion

        #region Active mobile user

        [HttpGet("Active-mobile/{Mobile}/{Resend?}")]
        public async Task<IActionResult> ActiveUserByMobileActivationCode(string Mobile, bool Resend = false)
        {
            #region Model State Validation 

            if (Mobile == null)
            {
                return NotFound();
            }

            #endregion

            #region Is Exist User 

            if (await _userService.IsExistUserByMobile(Mobile) == false)
            {
                return NotFound();
            }

            #endregion

            #region Resend SMS

            if (Resend)
            {
                await _userService.ResendActivationCodeSMS(Mobile);
            }

            #endregion

            #region Get User By User ID

            var user = await _userService.GetUserByMobile(Mobile);

            #endregion

            #region Time Counter Initilize



            if (await _siteSettingService.IsExistSiteSetting())
            {
                var SiteSettingSMSTimer = await _siteSettingService.GetSMSTimer();

                if (SiteSettingSMSTimer == null)
                {
                    TempData[WarningMessage] = "لطفا با پشتیبان تماس بگیرید .";
                    return RedirectToAction(nameof(Login));
                }

                DateTime expireMinut = user.ExpireMobileSMSDateTime.Value.AddMinutes(SiteSettingSMSTimer);

                var TimerMinut = expireMinut - DateTime.Now;

                ViewBag.Time = TimerMinut.TotalMinutes * 60;
            }

            ViewBag.Mobile = Mobile;

            #endregion

            return View();
        }

        [HttpPost("Active-mobile/{Mobile}/{Resend?}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ActiveUserByMobileActivationCode(ActiveMobileByActivationCodeViewModel activeMobileByActivationCodeViewModel)
        {
            #region Active User Mobile

            if (ModelState.IsValid)
            {
                var result = await _userService.ActiveUserMobile(activeMobileByActivationCodeViewModel);
                switch (result)
                {
                    case ActiveMobileByActivationCodeResult.Success:
                        TempData[SuccessMessage] = "حساب کاربری شما با موفقیت فعال شد!";
                        return RedirectToAction(nameof(Login));

                    case ActiveMobileByActivationCodeResult.AccountNotFound:
                        TempData[ErrorMessage] = "اطلاعات وارد شده اشتباه می باشد!";
                        return RedirectToAction("ActiveUserByMobileActivationCode", new { Mobile = activeMobileByActivationCodeViewModel.Mobile, Resend = false });
                }
            }

            #endregion

            return View(activeMobileByActivationCodeViewModel);
        }

        #endregion

        #region Login

        [HttpGet("Login")]
        [RedirectHomeIfLoggedInActionFilter]
        public IActionResult Login(string ReturnUrl = "")
        {
            var result = new LoginUserViewModel();

            if (!string.IsNullOrEmpty(ReturnUrl))
            {
                result.ReturnUrl = ReturnUrl;
            }

            return View(result);
        }

        [HttpPost("Login"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel login)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "مقادیر وارد شده معتبر نمی باشد .";
                return View(login);
            }

            var result = await _userService.CheckUserForLogin(login);

            switch (result)
            {
                case LoginResult.UserNotFound:
                    TempData[ErrorMessage] = "کاربری با اطلاعات وارد شده یافت نشد .";
                    break;
                case LoginResult.UserIsBan:
                    TempData[WarningMessage] = "دسترسی شما به سایت محدود شده است .";
                    break;
                case LoginResult.MobileNotActivated:
                    TempData[WarningMessage] = "حساب کاربری شما فعال نشده است";
                    return RedirectToAction("ActiveUserByMobileActivationCode", new { Mobile = login.Mobile, Resend = true });

                case LoginResult.Success:

                    #region Login User

                    // var user = await _userService.GetUserByEmail(login.Mobile);
                    var user = await _userService.GetUserByMobile(login.Mobile);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Username)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties { IsPersistent = login.RememberMe };

                    await HttpContext.SignInAsync(principal, properties);

                    #endregion

                    #region Send Wellcome SMS

                    var message = Messages.SendSMSForLogin();

                    await _smsservice.SendSimpleSMS(login.Mobile, message);

                    #endregion

                    TempData[SuccessMessage] = $"خوش آمدید {user.Username}";

                    #region Return To URL

                    if (!string.IsNullOrEmpty(login.ReturnUrl))
                    {
                        return Redirect(login.ReturnUrl);
                    }

                    #endregion

                    return Redirect("/");
            }

            return View(login);

        }

        #endregion

        #region Email Activation

        [HttpGet("Activate-Account/{mobileActivationCode}")]
        public async Task<IActionResult> AccountActivation(string mobileActivationCode)
        {
            if (string.IsNullOrEmpty(mobileActivationCode))
            {
                TempData[ErrorMessage] = "کد فعالسازی شما معتبر نمی باشد لطفا مجدد تلاش کنید .";
                return RedirectToAction("Login", "Account");
            }

            var result = await _userService.AccountActivation(mobileActivationCode);

            if (result)
            {
                TempData[SuccessMessage] = "حساب کاربری شما با موفقیت فعال شد .";
            }
            else
            {
                TempData[ErrorMessage] = "کد فعالسازی شما معتبر نمی باشد لطفا مجدد تلاش کنید .";
            }

            return RedirectToAction("Login", "Account");
        }

        #endregion

        #region forgot password

        [HttpGet("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost("ForgotPassword"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgetPasswordViewModel forgot)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RecoverUserPassword(forgot);
                switch (result)
                {
                    case ForgotPasswordResult.VerificationSmsFaildFromParsGreen:
                        TempData[ErrorMessage] = " کد تایید جدید برای شما ارسال نشد!";
                        TempData[ErrorMessage] = "لطفا با پشتیبانی سایت تماس بگیرید!";
                        ModelState.AddModelError("Mobile", "لطفا با پشتیبانی سایت تماس بگیرید");
                        break;
                    case ForgotPasswordResult.NotFound:
                        TempData[WarningMessage] = "کاربر مورد نظر یافت نشد";
                        break;
                    case ForgotPasswordResult.FailSendEmail:
                        TempData[WarningMessage] = "در ارسال ایمیل مشکلی رخ داد";
                        break;
                    case ForgotPasswordResult.UserIsBlocked:
                        TempData[ErrorMessage] = "حساب کاربری شما بسته شده است!";
                        break;
                    case ForgotPasswordResult.SuccessSendEmail:
                        TempData[WarningMessage] = "کد جدید برای شما ارسال شد";
                        return RedirectToAction("ResetPassword", "Account", new { mobile = forgot.Mobile });
                    case ForgotPasswordResult.Success:
                        TempData[SuccessMessage] = "کد تایید جدید برای شما ارسال شد";
                        return RedirectToAction("ResetPassword", "Account", new { mobile = forgot.Mobile });
                }
            }

            return View(forgot);
        }

        #endregion

        #region reset password

        [HttpGet("reset-pass/{mobile}")]
        public async Task<IActionResult> ResetPassword(string mobile, bool resend)
        {
            #region Send Model To View

            ViewBag.Mobile = mobile;

            var user = await _userService.GetUserByMobile(mobile);

            if (user == null) return NotFound();

            if (resend)
            {
                await _userService.ResendActivationCodeSMS(mobile);
            }

            if (await _siteSettingService.IsExistSiteSetting())
            {
                var SiteSettingSMSTimer = await _siteSettingService.GetSMSTimer();

                if (SiteSettingSMSTimer == null)
                {
                    TempData[WarningMessage] = "لطفا با پشتیبان تماس بگیرید .";
                    return RedirectToAction(nameof(Login));
                }

                DateTime expireMinut = user.ExpireMobileSMSDateTime.Value.AddMinutes(SiteSettingSMSTimer);

                var TimerMinut = expireMinut - DateTime.Now;

                ViewBag.Time = TimerMinut.TotalMinutes * 60;
            }

            #endregion

            return View();
        }

        [HttpPost("reset-pass/{mobile}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string mobile, ResetPasswordViewModel reset)
        {
            if (ModelState.IsValid)
            {
                var res = await _userService.ResetUserPassword(reset, mobile);
                switch (res)
                {
                    case ResetPasswordResult.NotFound:
                        TempData[WarningMessage] = "کاربری با مشخصات وارد شده یافت نشد";
                        return Redirect("/");
                    case ResetPasswordResult.WrongActiveCode:
                        TempData[ErrorMessage] = "کد تایید وارد شده صحیح نمی باشد";
                        break;
                    case ResetPasswordResult.Success:
                        TempData[SuccessMessage] = "کلمه عبور شما با موفقیت تغییر پیدا کرد";
                        await HttpContext.SignOutAsync();
                        return RedirectToAction("Login", "Account", new { area = "" });
                }
            }
            return View(reset);
        }

        #endregion

        #region Logout

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            TempData[SuccessMessage] = "عملیات با موفقیت انجام شده است ";
            return Redirect("/");
        }

        #endregion
    }
}
