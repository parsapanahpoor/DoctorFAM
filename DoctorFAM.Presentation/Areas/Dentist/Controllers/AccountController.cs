#region Usings

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Dentist.Employees;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Employees;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
namespace DoctorFAM.Web.Areas.Dentist.Controllers;

#endregion

public class AccountController : DentistBaseController
{
    #region Ctor

    private readonly IUserService _userService;
    private readonly IStringLocalizer<AccountController> _localizer;
    private readonly IStringLocalizer<SharedLocalizer.SharedLocalizer> _sharedLocalizer;
    private readonly IOrganizationService _organizationService;
    private readonly IDentistService _dentistService;

    public AccountController(IUserService userService, IStringLocalizer<AccountController> localizer
                            , IStringLocalizer<SharedLocalizer.SharedLocalizer> sharedLocalizer,
                                IOrganizationService organizationService , IDentistService dentistService)
    {
        _userService = userService;
        _localizer = localizer;
        _sharedLocalizer = sharedLocalizer;
        _organizationService = organizationService;
        _dentistService = dentistService;
    }

    #endregion

    #region Manage Employees

    #region List Of Current Dentist Office Employeesadd

    public async Task<IActionResult> FilterEmployees(FilterDentistOfficeEmployeesViewmodel filter)
    {
        filter.userId = User.GetUserId();

        return View(await _dentistService.FilterDentistOfficeEmployees(filter));
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
        AddNewUserResult result = await _userService.CreateUserFromDentistPanel(user, UserAvatar, User.GetUserId());

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

    #region Check Is Exist Any User By This Mobile Number In Modal

    [HttpGet("/CheckEmployeeIsExistInDentistPanel/{mobile}")]
    public async Task<IActionResult> CheckEmployeeIsExistInDentistPanel(string mobile)
    {
        var res = await _userService.IsExistUserByMobile(mobile);

        if (res)
        {
            return PartialView("_CheckEmployeeIsExistInDentistPanel", await _userService.GetUserByMobile(mobile));
        }

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "کاربر یافت شده است.");
    }

    #endregion

    #region Delete Employee From Your Organization 

    public async Task<IActionResult> DeleteEmployeeFromYourOrganization(ulong id)
    {
        var result = await _organizationService.DeleteEmployeeFromDentistOfficeOrganization(id, User.GetUserId());

        if (result)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, _sharedLocalizer["Operation Successfully"].Value);
        }

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, _sharedLocalizer["The operation has failed"].Value);
    }

    #endregion

    #region Select Exist User For This Organization Or Any Organization 

    public async Task<IActionResult> SelectExistUserForThisOrganization(ulong userId)
    {
        #region Check The User State 

        var res = await _dentistService.AddExistUserToTheDentistOrganization(userId, User.GetUserId());
        if (res)
        {
            TempData[SuccessMessage] = "عملیات باموفقیت انجام شده است.";
            return RedirectToAction(nameof(FilterEmployees));
        }

        #endregion

        TempData[ErrorMessage] = ".اطلاعات وارد شده صحیح نمی باشد";
        return RedirectToAction(nameof(FilterEmployees));
    }

    #endregion

    #endregion
}
