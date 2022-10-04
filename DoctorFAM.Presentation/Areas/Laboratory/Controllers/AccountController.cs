using BusinessPortal.Application.Services.Implementation;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Employees;
using DoctorFAM.Domain.ViewModels.Laboratory.Employee;
using DoctorFAM.Domain.ViewModels.UserPanel.Account;
using DoctorFAM.Web.Areas.Laboratory.ActionFilterAttributes;
using DoctorFAM.Web.Consultant.Controllers;
using DoctorFAM.Web.HttpManager;
using DoctorFAM.Web.Laboratory.Controllers;
using DoctorFAM.Web.Nurse.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Laboratory.Controllers
{
    public class AccountController : LaboratoryBaseController
    {
        #region ctor

        private readonly IUserService _userService;
        private readonly IDoctorsService _doctorService;
        private readonly IStringLocalizer<AccountController> _localizer;
        private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;
        private readonly IOrganizationService _organizationService;
        private readonly ILaboratoryService _laboratoryService;
        private readonly IPermissionService _permissionService;

        public AccountController(IUserService userService, IStringLocalizer<AccountController> localizer
                                , IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer , IDoctorsService doctorService,
                                    IOrganizationService organizationService, ILaboratoryService laboratoryService, IPermissionService permissionService)
        {
            _userService = userService;
            _localizer = localizer;
            _sharedLocalizer = sharedLocalizer;
            _doctorService = doctorService;
            _organizationService = organizationService;
            _laboratoryService = laboratoryService;
            _permissionService = permissionService;
        }

        #endregion

        #region Account And Profile Manager

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
                    return RedirectToAction("EditProfile", "Account", new { area = "Consultant" });
                case UserPanelEditUserInfoResult.Success:
                    TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                    return RedirectToAction("Index", "Home", new { area = "Consultant" });
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

        #endregion

        #region Manage Employees

        #region List Of Current Laboratory Office Employeesadd

        [IsUserLaboratory]
        public async Task<IActionResult> FilterEmployees(FilterLaboratoryOfficeEmployeesViewmodel filter)
        {
            filter.userId = User.GetUserId();
            return View(await _laboratoryService.FilterLaboratoryOfficeEmployees(filter));
        }

        #endregion

        #region create new user

        [IsUserLaboratory]
        public async Task<IActionResult> AddNewUser()
        {
            #region Page Data

            ViewData["Roles"] = await _permissionService.GetListOfLaboratoryRoles();

            #endregion

            return View();
        }

        [IsUserLaboratory]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewUser(AddLaboratoryEmployeeViewModel user, IFormFile? UserAvatar)
        {
            AddNewUserResult result = await _userService.CreateUserFromLaboratoryPanel(user, UserAvatar, User.GetUserId());

            switch (result)
            {
                case AddNewUserResult.DuplicateMobileNumber:
                    TempData[ErrorMessage] = _sharedLocalizer["Mobile Number is Duplicated"].Value;
                    break;

                case AddNewUserResult.Success:
                    TempData[SuccessMessage] = _sharedLocalizer["Operation Successfully"].Value;
                    return RedirectToAction("FilterEmployees");
            }

            #region Page Data

            ViewData["Roles"] = await _permissionService.GetListOfLaboratoryRoles();

            #endregion

            return View(user);
        }

        #endregion

        #region Delete Employee From Your Organization 

        [IsUserLaboratory]
        public async Task<IActionResult> DeleteEmployeeFromYourOrganization(ulong id)
        {
            var result = await _organizationService.DeleteEmployeeFromLaboratoryOfficeOrganization(id, User.GetUserId());

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
