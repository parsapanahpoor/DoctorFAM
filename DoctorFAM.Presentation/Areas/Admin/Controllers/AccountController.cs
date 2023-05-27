#region Usings

using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin;
using DoctorFAM.Domain.ViewModels.Admin.Account;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

#endregion

namespace DoctorFAM.Web.Areas.Admin.Controllers;

public class AccountController : AdminBaseController
{
    #region Ctor

    public IUserService _userService;

    public IPermissionService _permissionService;

    private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;

    public AccountController(IUserService userService, IPermissionService permissionService , IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer)
    {
        _userService = userService;
        _permissionService = permissionService;
        _sharedLocalizer = sharedLocalizer;
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

        ViewData["Roles"] = await _permissionService.GetListOfRoles();
      
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

            ViewData["Roles"] = await _permissionService.GetListOfRoles();

            #endregion

            TempData[ErrorMessage] = _sharedLocalizer["The input values ​​are not valid"].Value;
            return View(edit);
        }

        #endregion

        #region Edit User Method

        var result = await _userService.EditUserInfo(edit, UserAvatar);

        switch (result)
        {
            case AdminEditUserInfoResult.NotValidImage:
                TempData[ErrorMessage] = _sharedLocalizer["Image Is Not Valid ."].Value;
                break;
            case AdminEditUserInfoResult.UserNotFound:
                TempData[ErrorMessage] = _sharedLocalizer["User Not Found"].Value;
                return RedirectToAction("FilterUsers", "Account", new { area = "Admin" });
            case AdminEditUserInfoResult.Success:
                TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                return RedirectToAction("AccountDetail", "Account", new { area = "Admin", id = edit.UserId });
            case AdminEditUserInfoResult.NotValidEmail:
                TempData[ErrorMessage] = _sharedLocalizer["The entered email is already available on the site"].Value;
                break;
            case AdminEditUserInfoResult.NotValidMobile:
                TempData[ErrorMessage] = "The entered Mobile is already available on the site";
                break;
            case AdminEditUserInfoResult.NotValidNationalId:
                TempData[ErrorMessage] = _sharedLocalizer["The entered National is already available on the site"].Value;
                break;
        }


        #endregion

        #region Page Data

        ViewData["Roles"] = await _permissionService.GetListOfRoles();

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

        return RedirectToAction("Index", "Home", new { area = "" });
    }

    #endregion

    #endregion

    #region Cooperation Request 

    #region Seen Cooperation Request

    public async Task<IActionResult> SeenCooperationRequest(ulong cooperationRequestId)
    {
        #region Seen Cooperation Request 

        var res = await _userService.SeenCooperationRequests(cooperationRequestId);
        if (res )
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "عملیات با موفقیت انجام شده است.");
        }

        #endregion

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات با شکست مواجه شده است.");
    }

    #endregion

    #region List Of Cooperation Requests

    public async Task<IActionResult> ListOfCooperationRequest()
    {
        return View(await _userService.ListOfCooperationRequests());
    }

    #endregion

    #region Delete Cooperation Request

    public async Task<IActionResult> DeleteCooperationRequest(ulong cooperationRequestId)
    {
        #region Seen Cooperation Request 

        var res = await _userService.DeleteCooperationRequests(cooperationRequestId);
        if (res )
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "عملیات با موفقیت انجام شده است.");
        }

        #endregion

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات با شکست مواجه شده است.");
    }

    #endregion

    #endregion
}
