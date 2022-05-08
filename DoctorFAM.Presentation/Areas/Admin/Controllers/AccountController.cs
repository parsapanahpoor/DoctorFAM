using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin;
using DoctorFAM.Domain.ViewModels.Admin.Account;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class AccountController : AdminBaseController
    {
        #region Ctor

        public IUserService _userService;

        public IPermissionService _permissionService;

        public AccountController(IUserService userService, IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }

        #endregion

        #region Manage User

        #region Users List

        [HttpGet]
        public async Task<IActionResult> FilterUsers(FilterUserViewModel filter)
        {
            var result = await _userService.FilterUsers(filter);

            ViewData["Roles"] = await _permissionService.GetSelectRolesList();

            return View(result);
        }

        #endregion

        #region User Detail

        public async Task<IActionResult> AccountDetail(ulong id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null) return NotFound();

            return View(user);
        }

        #endregion

        #region Edit User

        [HttpGet]
        public async Task<IActionResult> EditUserInfo(ulong id)
        {
            #region Fill View Model

            var result = await _userService.FillAdminEditUserInfoViewModel(id);

            if (result == null) return NotFound();

            #endregion

            #region Page Data

            ViewData["Roles"] = await _permissionService.GetSelectRolesList();
          
            #endregion

            return View(result);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserInfo(AdminEditUserInfoViewModel edit, IFormFile? UserAvatar)
        {
            #region Model State Validation

            if (!ModelState.IsValid)
            {
                #region Page Data

                ViewData["Roles"] = await _permissionService.GetSelectRolesList();

                #endregion

                TempData[ErrorMessage] = "مقادیر ورودی معتبر نمی باشد .";
                return View(edit);
            }

            #endregion

            #region Edit User Method

            var result = await _userService.EditUserInfo(edit, UserAvatar);

            switch (result)
            {
                case AdminEditUserInfoResult.NotValidImage:
                    TempData[ErrorMessage] = "تصویر انتخاب شده معتبر نمی باشد .";
                    break;
                case AdminEditUserInfoResult.UserNotFound:
                    TempData[ErrorMessage] = "کاربر مورد نظر یافت نشد .";
                    return RedirectToAction("FilterUsers", "Account", new { area = "Admin" });
                case AdminEditUserInfoResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد .";
                    return RedirectToAction("AccountDetail", "Account", new { area = "Admin", id = edit.UserId });
                case AdminEditUserInfoResult.NotValidEmail:
                    TempData[ErrorMessage] = "ایمیل وارد شده از قبل در سایت موجود است";
                    break;
                case AdminEditUserInfoResult.NotValidMobile:
                    TempData[ErrorMessage] = "موبایل وارد شده از قبل در سایت موجود است";
                    break;
                case AdminEditUserInfoResult.NotValidBirthDate:
                    TempData[ErrorMessage] = "تاریخ وارد شده نمی تواند بزرگتر از الان باشد .";
                    break;
            }


            #endregion

            #region Page Data

            ViewData["Roles"] = await _permissionService.GetSelectRolesList();

            #endregion

            return View(edit);
        }

        #endregion

        #region Change Password

        [HttpGet]
        public async Task<IActionResult> ChangePassword(ulong userId)
        {
            var model = new ChangePasswordInAdminViewModel()
            {
                UserId = userId
            };
            return PartialView("_ChangePasswordPartial", model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordInAdminViewModel passwordViewModel)
        {
            var result = await _userService.ChangePasswordInAdmin(passwordViewModel);

            if (!result)
            {
                return JsonResponseStatus.Error();
            }

            return JsonResponseStatus.Success();
        }

        #endregion

        #region LoginWithUser

        public async Task<IActionResult> LoginWithUser(ulong userId)
        {
            var user = await _userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound();
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties { IsPersistent = false };

            await HttpContext.SignInAsync(principal, properties);

            return RedirectToAction("SecPage", "Home", new { area = "" });
        }

        #endregion


        #endregion

    }
}
