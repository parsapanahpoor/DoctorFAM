using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;

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

        #endregion

    }
}
