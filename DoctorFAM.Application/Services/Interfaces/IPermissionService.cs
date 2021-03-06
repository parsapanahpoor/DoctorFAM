using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.Access;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IPermissionService
    {

        #region Check Permission

        Task<bool> HasUserPermission(ulong userId, string permissionName);

        #endregion

        #region Role

        Task<string> GetDoctorsInfosState(ulong userId);

        Task<FilterRolesViewModel> FilterRoles(FilterRolesViewModel filter);

        Task<bool> CreateRole(CreateRoleViewModel create);

        Task<bool> IsRoleNameValid(string name, ulong roleId);

        Task<EditRoleViewModel> FillEditRoleViewModel(ulong roleId);

        Task<Role?> GetRoleById(ulong roleId);

        Task<List<SelectListViewModel>> GetSelectRolesList();

        Task<EditRoleResult> EditRole(EditRoleViewModel edit);

        Task<bool> DeleteRole(ulong roleId);

        Task<GetUserRoles> GetUserRole(ulong userId);

        Task<bool> IsUserAdmin(ulong userId);

        Task<bool> IsUserDoctor(ulong userId);

        Task<bool> IsUserSupporter(ulong userId);

        #endregion
    }
}
