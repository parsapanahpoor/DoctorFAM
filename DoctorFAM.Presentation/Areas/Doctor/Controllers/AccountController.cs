using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Employees;
using DoctorFAM.Domain.ViewModels.UserPanel.Account;
using DoctorFAM.Web.Areas.Doctor.ActionFilterAttributes;
using DoctorFAM.Web.Doctor.Controllers;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Doctor.Controllers
{
    [IsUserDoctor]
    public class AccountController : DoctorBaseController
    {
        #region ctor

        private readonly IUserService _userService;
        private readonly IDoctorsService _doctorService;
        private readonly IStringLocalizer<AccountController> _localizer;
        private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;
        private readonly IOrganizationService _organizationService;

        public AccountController(IUserService userService, IStringLocalizer<AccountController> localizer
                                , IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer , IDoctorsService doctorService ,
                                    IOrganizationService organizationService)
        {
            _userService = userService;
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
            _doctorService = doctorService;
            _organizationService = organizationService;
        }

        #endregion

        #region Edit User

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            #region Fill View Model

            var result = await _userService.FillUserPanelEditUserInfoViewModel(User.GetUserId());

            if (result == null) return NotFound();

            #endregion

            return View(result);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(UserPanelEditUserInfoViewModel edit, IFormFile? UserAvatar)
        {
            #region Model State Validation

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = _sharedLocalizer["The input values ​​are not valid"].Value;
                return View(edit);
            }

            if (edit.UserId != User.GetUserId())
            {
                TempData[ErrorMessage] = _sharedLocalizer["User Not Found"].Value;
                return View(edit);
            }

            #endregion

            #region Edit User Method

            var result = await _userService.EditUserInfoInUserPanel(edit, UserAvatar);

            switch (result)
            {
                case UserPanelEditUserInfoResult.NotValidImage:
                    TempData[ErrorMessage] = _sharedLocalizer["Image Is Not Valid ."].Value;
                    break;
                case UserPanelEditUserInfoResult.UserNotFound:
                    TempData[ErrorMessage] = _sharedLocalizer["User Not Found"].Value;
                    return RedirectToAction("EditProfile", "Account", new { area = "Doctor" });
                case UserPanelEditUserInfoResult.Success:
                    TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                    return RedirectToAction("Index", "Home", new { area = "Doctor" });
                case UserPanelEditUserInfoResult.NotValidEmail:
                    TempData[ErrorMessage] = _sharedLocalizer["The entered email is already available on the site"].Value;
                    break;
                case UserPanelEditUserInfoResult.NationalId:
                    TempData[ErrorMessage] = _sharedLocalizer["National Id Is Not Valid"].Value;
                    break;
            }

            #endregion

            return View(edit);
        }

        #endregion

        #region Change Password

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangeUserPasswordViewModel model)
        {
            #region Model State Validation

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            #region change Password

            var result = await _userService.ChangeUserPasswordAsync(User.GetUserId(), model);

            switch (result)
            {
                case ChangeUserPasswordResponse.Success:
                    TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                    return RedirectToAction("Index", "Home");
                    break;

                case ChangeUserPasswordResponse.UserNotFound:
                    TempData[ErrorMessage] = _localizer["Your account not found, please re login"].Value;
                    break;

                case ChangeUserPasswordResponse.WrongPassword:
                    TempData[ErrorMessage] = _localizer["Current password is invalid"].Value;
                    break;

                default:
                    TempData[ErrorMessage] = _localizer["An error occurred in the change password process"].Value;
                    break;
            }

            #endregion

            return View(model);
        }

        #endregion

        #region Manage Employees

        #region List Of Current Doctor Office Employeesadd

        public async Task<IActionResult> FilterEmployees(FilterDoctorOfficeEmployeesViewmodel filter)
        {
            filter.userId = User.GetUserId();

            return View(await _doctorService.FilterDoctorOfficeEmployees(filter));
        }

        #endregion

        #region create new user

        public async Task<IActionResult> AddNewUser()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewUser(AddEmployeeViewModel user, IFormFile? UserAvatar)
        {
            AddNewUserResult result = await _userService.CreateUserFromDoctorPanel(user, UserAvatar, User.GetUserId());

            switch (result)
            {
                case AddNewUserResult.DuplicateMobileNumber:
                    TempData[ErrorMessage] = _sharedLocalizer["Mobile Number is Duplicated"].Value;
                    break;

                case AddNewUserResult.Success:
                    TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                    return RedirectToAction("FilterEmployees");
            }

            return View(user);
        }

        #endregion

        #region Delete Employee From Your Organization 

        public async Task<IActionResult> DeleteEmployeeFromYourOrganization(ulong id)
        {
            var result = await _organizationService.DeleteEmployeeFromYourOrganization(id , User.GetUserId());

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, _sharedLocalizer["Operation Successfully"].Value);
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, _sharedLocalizer["The operation has failed"].Value);
        }

        #endregion

        #endregion
    }
}
