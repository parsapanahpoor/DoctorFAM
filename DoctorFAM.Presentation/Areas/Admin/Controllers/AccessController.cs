using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.ViewModels.Access;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class AccessController : AdminBaseController
    {
        #region Ctor

        private readonly IPermissionService _permissionService;

        public IStringLocalizer<AccessController> _localizer;

        public AccessController(IPermissionService permissionService , IStringLocalizer<AccessController> localizer)
        {
            _permissionService = permissionService;
            _localizer = localizer;
        }

        #endregion

        #region Role

        #region Create Role

        public IActionResult CreateRole()
        {
            ViewData["Permissions"] = PermissionsList.Permissions.Where(s => !s.IsDelete).ToList();

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel create)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Permissions"] = PermissionsList.Permissions.Where(s => !s.IsDelete).ToList();
                TempData[ErrorMessage] = _localizer["Input values ​​are not valid"].Value;
                return View(create);
            }

            if (create.Permissions == null || !create.Permissions.Any())
            {
                ViewData["Permissions"] = PermissionsList.Permissions.Where(s => !s.IsDelete).ToList();
                TempData[ErrorMessage] = _localizer["Selecting at least one access is required"].Value;
                return View(create);
            }

            var result = await _permissionService.CreateRole(create);

            if (result)
            {
                TempData[SuccessMessage] = _localizer["mission accomplished"].Value;
                return RedirectToAction("FilterRoles", "Access", new { area = "Admin" });
            }

            TempData[WarningMessage] = _localizer["The unique name already exists"].Value;
            ViewData["Permissions"] = PermissionsList.Permissions.Where(s => !s.IsDelete).ToList();

            return View(create);
        }

        #endregion

        #region Filter Roles

        public async Task<IActionResult> FilterRoles(FilterRolesViewModel filter)
        {
            var result = await _permissionService.FilterRoles(filter);

            return View(result);
        }

        #endregion

        #region Edit Role

        public async Task<IActionResult> EditRole(ulong id)
        {
            var result = await _permissionService.FillEditRoleViewModel(id);

            if (result == null)
            {
                return NotFound();
            }

            ViewData["Permissions"] = PermissionsList.Permissions.Where(s => !s.IsDelete).ToList();

            return View(result);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(EditRoleViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Permissions"] = PermissionsList.Permissions.Where(s => !s.IsDelete).ToList();
                TempData[ErrorMessage] = _localizer["Input values ​​are not valid"].Value;
                return View(edit);
            }

            if (edit.Permissions == null || !edit.Permissions.Any())
            {
                ViewData["Permissions"] = PermissionsList.Permissions.Where(s => !s.IsDelete).ToList();
                TempData[ErrorMessage] = _localizer["Selecting at least one access is required"].Value;
                return View(edit);
            }

            var result = await _permissionService.EditRole(edit);

            switch (result)
            {
                case EditRoleResult.Success:
                    TempData[SuccessMessage] = _localizer["mission accomplished"].Value;
                    return RedirectToAction("FilterRoles", "Access", new { area = "Admin" });
                case EditRoleResult.RoleNotFound:
                    TempData[ErrorMessage] = _localizer["The role could not be found"].Value;
                    return RedirectToAction("FilterRoles", "Access", new { area = "Admin" });
                case EditRoleResult.UniqueNameExists:
                    TempData[WarningMessage] = _localizer["The unique name already exists"].Value;
                    break;
            }

            ViewData["Permissions"] = PermissionsList.Permissions.Where(s => !s.IsDelete).ToList();

            return View(edit);
        }

        #endregion

        #region Delete Role

        public async Task<IActionResult> DeleteRole(ulong roleId)
        {
            var result = await _permissionService.DeleteRole(roleId);

            if (result)
            {
                return JsonResponseStatus.Success();
            }

            return JsonResponseStatus.Error();
        }

        #endregion

        #endregion
    }
}
