#region Usings

using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Access;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.Dentist.SideBar;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DosctorSideBarInfo;
using Microsoft.EntityFrameworkCore;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Data.DbContext;
namespace BusinessPortal.Application.Services.Implementation;

#endregion

public class PermissionService : IPermissionService
{
    #region Ctor

    public IUserService _userService { get; set; }
    public DoctorFAMDbContext _context { get; set; }
    public IDoctorsService _doctorsService;
    public IDentistService _dentistService;

    public PermissionService(DoctorFAMDbContext context, IUserService userServie, IDoctorsService doctorsService , IDentistService dentistService)
    {
        _context = context;
        _userService = userServie;
        _doctorsService = doctorsService;
        _dentistService = dentistService;
    }

    #endregion

    #region Check Permission

    //Get Dentist Side Bar Info
    public async Task<DentistSideBarViewModel> GetDentistSideBarInfo(ulong userId)
    {
        return await _dentistService.GetDentistSideBarInfo(userId);
    }

    public async Task<DoctorSideBarViewModel> GetDoctorsInfosState(ulong userId)
    {
        return await _doctorsService.GetDoctorsSideBarInfo(userId);
    }

    public async Task<bool> HasUserPermission(ulong userId, string permissionName)
    {
        // get user
        var user = await _userService.GetUserById(userId);

        // check user exists
        if (user == null) return false;

        // admin user access any where
        if (user.IsAdmin) return true;

        // check user access not limited
        if (!user.IsMobileConfirm || user.IsBan)
        {
            return false;
        }

        // get permission from permission list
        var permission = PermissionsList.Permissions.FirstOrDefault(s => s.PermissionUniqueName == permissionName);

        // check permission exists
        if (permission == null) return false;

        // get user roles
        var userRoles = await _context.UserRoles
            .Where(s => s.UserId == userId && !s.IsDelete)
            .ToListAsync();

        // check user has any roles
        if (!userRoles.Any()) return false;

        // get user role Ids list
        var userRoleIds = userRoles.Select(s => s.RoleId).ToList();

        // check user has permission
        var result = await _context.RolePermissions.AnyAsync(s =>
            s.PermissionId == permission.Id && userRoleIds.Contains(s.RoleId) && !s.IsDelete);

        return result;
    }


    #endregion

    #region Role

    public async Task<List<SelectListViewModel>> GetSelectRolesList()
    {
        return await _context.Roles.Where(s => !s.IsDelete).Select(s => new SelectListViewModel
        {
            Id = s.Id,
            Title = s.Title
        }).ToListAsync();
    }

    public async Task<List<Role>> GetListOfRoles()
    {
        return await _context.Roles.Where(s => !s.IsDelete).ToListAsync();
    }

    //Get List Of Laboratory Roles
    public async Task<List<Role>> GetListOfLaboratoryRoles()
    {
        return await _context.Roles.Where(p => !p.IsDelete && p.ParentId == 17).ToListAsync();
    }

    public async Task<bool> IsRoleNameValid(string name, ulong roleId)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(s => s.RoleUniqueName.Equals(name.Trim().ToLower()));

        if (role == null) return true;

        if (roleId != 0 && role.Id == roleId)
        {
            return true;
        }

        return false;
    }

    public async Task<bool> CreateRole(CreateRoleViewModel create)
    {
        if (!await IsRoleNameValid(create.RoleUniqueName, 0))
        {
            return false;
        }

        // add role
        var role = new Role
        {
            RoleUniqueName = create.RoleUniqueName,
            Title = create.Title,
            ParentId = create.ParentId
        };

        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();

        // add permissions
        if (create.Permissions != null && create.Permissions.Any())
        {
            foreach (var permissionId in create.Permissions)
            {
                var rolePermission = new RolePermission
                {
                    PermissionId = permissionId,
                    RoleId = role.Id
                };

                await _context.AddAsync(rolePermission);
            }
            await _context.SaveChangesAsync();
        }

        return true;
    }


    public async Task<FilterRolesViewModel> FilterRoles(FilterRolesViewModel filter)
    {
        var query = _context.Roles.Include(p => p.Parent).Where(s => !s.IsDelete).AsQueryable();

        #region Filter

        if (!string.IsNullOrEmpty(filter.RoleTitle))
        {
            query = query.Where(s => s.Title.Contains(filter.RoleTitle));
        }

        if (!string.IsNullOrEmpty(filter.RoleUniqueName))
        {
            query = query.Where(s => s.RoleUniqueName.Contains(filter.RoleUniqueName));
        }

        if (filter.ParentId != null)
        {
            query = query.Where(a => a.ParentId == filter.ParentId);
            filter.ParentRole = await _context.Roles.FirstOrDefaultAsync(a => a.Id == filter.ParentId);
        }

        else
        {
            query = query.Where(a => a.ParentId == null);
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    public async Task<EditRoleViewModel> FillEditRoleViewModel(ulong roleId)
    {
        var role = await GetRoleById(roleId);

        if (role == null)
        {
            return null;
        }

        var permissionIds = await _context.RolePermissions.Where(s => !s.IsDelete && s.RoleId == roleId)
            .Select(s => s.PermissionId).ToListAsync();

        var result = new EditRoleViewModel
        {
            Id = roleId,
            RoleUniqueName = role.RoleUniqueName,
            Title = role.Title,
            Permissions = permissionIds,
            ParentId = role.ParentId
        };

        return result;
    }

    public async Task<Role?> GetRoleById(ulong roleId)
    {
        return await _context.Roles.FirstOrDefaultAsync(s => s.Id == roleId && !s.IsDelete);
    }

    public async Task<EditRoleResult> EditRole(EditRoleViewModel edit)
    {
        var role = await GetRoleById(edit.Id);

        if (role == null)
        {
            return EditRoleResult.RoleNotFound;
        }

        if (!await IsRoleNameValid(edit.RoleUniqueName, edit.Id))
        {
            return EditRoleResult.UniqueNameExists;
        }

        role.Title = edit.Title;
        role.RoleUniqueName = edit.RoleUniqueName;
        role.ParentId = edit.ParentId;

        _context.Update(role);
        await _context.SaveChangesAsync();

        // remove all permissions
        var rolePermissions =
            await _context.RolePermissions.Where(s => !s.IsDelete && s.RoleId == edit.Id).ToListAsync();

        _context.RolePermissions.RemoveRange(rolePermissions);
        await _context.SaveChangesAsync();

        // add permissions
        if (edit.Permissions != null && edit.Permissions.Any())
        {
            foreach (var permissionId in edit.Permissions)
            {
                var rolePermission = new RolePermission
                {
                    PermissionId = permissionId,
                    RoleId = role.Id
                };

                await _context.AddAsync(rolePermission);
            }
            await _context.SaveChangesAsync();
        }

        return EditRoleResult.Success;
    }

    public async Task<bool> DeleteRole(ulong roleId)
    {
        var role = await GetRoleById(roleId);

        if (role == null)
        {
            return false;
        }

        role.IsDelete = true;

        _context.Update(role);
        await _context.SaveChangesAsync();

        // remove all permissions
        var rolePermissions =
            await _context.RolePermissions.Where(s => !s.IsDelete && s.RoleId == roleId).ToListAsync();

        _context.RolePermissions.RemoveRange(rolePermissions);
        await _context.SaveChangesAsync();

        #region Remove Role Childs

        var childs = await _context.Roles.Where(p => p.IsDelete && p.ParentId == role.Id).ToListAsync();

        if (childs != null || childs.Any())
        {
            foreach (var item in childs)
            {
                item.IsDelete = true;
            }
        }

        //Delete User Role 
        var userRoles = await _context.UserRoles.Where(p => !p.IsDelete && p.RoleId == role.Id).ToListAsync();

        if (userRoles != null || userRoles.Any())
        {
            foreach (var item in userRoles)
            {
                _context.UserRoles.Remove(item);
            }
        }

        await _context.SaveChangesAsync();

        #endregion

        return true;
    }

    public async Task<List<string>?> GetUserRoleses(ulong userId)
    {
        List<string> returnModel = new List<string>();

        #region Get User 

        var user = await _userService.GetUserById(userId);

        if (user.IsAdmin)
        {
            returnModel.Add("Admin");
        }

        #endregion

        #region Get All Of User Roles

        var userRoles = await _context.UserRoles.Include(p => p.Role).Where(p => p.UserId == userId && !p.IsDelete)
                                                            .Select(p => p.Role.RoleUniqueName).ToListAsync();

        #endregion

        #region check user Role

        if (userRoles.Any() && userRoles.Contains("Admin"))
        {
            returnModel.Add("Admin");
        }

        if (userRoles.Any() && userRoles.Contains("Doctor"))
        {
            returnModel.Add("Doctor");
        }

        if (userRoles.Any() && userRoles.Contains("Support"))
        {
            returnModel.Add("Support");
        }

        if (userRoles.Any() && userRoles.Contains("Seller"))
        {
            returnModel.Add("Seller");
        }

        if (userRoles.Any() && userRoles.Contains("Pharmacy"))
        {
            returnModel.Add("Pharmacy");
        }

        if (userRoles.Any() && userRoles.Contains("Nurse"))
        {
            returnModel.Add("Nurse");
        }

        if (userRoles.Any() && userRoles.Contains("Consultant"))
        {
            returnModel.Add("Consultant");
        }

        if (userRoles.Any() && userRoles.Contains("DoctorOfficeEmployee"))
        {
            returnModel.Add("DoctorOfficeEmployee");
        }

        if (userRoles.Any() && userRoles.Contains("LaboratoryOfficeEmployee"))
        {
            returnModel.Add("LaboratoryOfficeEmployee");
        }

        if (userRoles.Any() && userRoles.Contains("Labratory"))
        {
            returnModel.Add("Labratory");
        }

        #endregion

        return returnModel;
    }

    public async Task<List<string>?> GetUserRolesesWithAsNoTracking(ulong userId)
    {
        List<string> returnModel = new List<string>();

        #region Get User 

        if (await _context.Users.AsNoTracking().AnyAsync(p => !p.IsDelete && p.Id == userId && p.IsAdmin))
        {
            returnModel.Add("Admin");
        }

        #endregion

        #region Get All Of User Roles

        List<ulong>? userSelectedRoles = await _context.UserRoles
                                      .AsNoTracking()
                                      .Where(p => p.UserId == userId && !p.IsDelete)
                                      .Select(p => p.RoleId)
                                      .ToListAsync();

        if (userSelectedRoles is not null && userSelectedRoles.Any())
        {
            foreach (var roleId in userSelectedRoles)
            {
                string? roleName = await _context.Roles
                                                 .AsNoTracking()
                                                 .Where(p => !p.IsDelete && p.Id == roleId)
                                                 .Select(p => p.RoleUniqueName)
                                                 .FirstOrDefaultAsync();

                if (!string.IsNullOrEmpty(roleName))
                {
                    #region check user Role

                    if (roleName == "Admin")
                    {
                        returnModel.Add("Admin");
                    }

                    if (roleName == "Doctor")
                    {
                        returnModel.Add("Doctor");
                    }

                    if (roleName == "Support")
                    {
                        returnModel.Add("Support");
                    }

                    if (roleName == "Seller")
                    {
                        returnModel.Add("Seller");
                    }

                    if (roleName == "Pharmacy")
                    {
                        returnModel.Add("Pharmacy");
                    }

                    if (roleName == "Nurse")
                    {
                        returnModel.Add("Nurse");
                    }

                    if (roleName == "Consultant")
                    {
                        returnModel.Add("Consultant");
                    }

                    if (roleName == "DoctorOfficeEmployee")
                    {
                        returnModel.Add("DoctorOfficeEmployee");
                    }

                    if (roleName == "LaboratoryOfficeEmployee")
                    {
                        returnModel.Add("LaboratoryOfficeEmployee");
                    }

                    if (roleName == "Labratory")
                    {
                        returnModel.Add("Labratory");
                    }

                    if (roleName == "Dentist")
                    {
                        returnModel.Add("Dentist");
                    }

                    if (roleName == "DentistOfficeEmployee")
                    {
                        returnModel.Add("DentistOfficeEmployee");
                    }

                    if (roleName == "Tourism")
                    {
                        returnModel.Add("Tourism");
                    }

                    #endregion
                }
            }

        }

        #endregion

        return returnModel;
    }

    public async Task<GetUserRoles> GetUserRole(ulong userId)
    {
        #region Get User 

        var user = await _userService.GetUserById(userId);

        if (user.IsAdmin) return GetUserRoles.Admin;

        #endregion

        #region Get All Of User Roles

        var userRoles = await _context.UserRoles.Include(p => p.Role).Where(p => p.UserId == userId && !p.IsDelete)
                                                            .Select(p => p.Role.RoleUniqueName).ToListAsync();

        #endregion

        #region check user Role

        if (userRoles.Any() && userRoles.Contains("Admin")) return GetUserRoles.Admin;

        if (userRoles.Any() && userRoles.Contains("Doctor")) return GetUserRoles.Doctor;

        if (userRoles.Any() && userRoles.Contains("Support")) return GetUserRoles.Supporter;

        if (userRoles.Any() && userRoles.Contains("Seller")) return GetUserRoles.Seller;

        if (userRoles.Any() && userRoles.Contains("Pharmacy")) return GetUserRoles.Pharmacy;

        if (userRoles.Any() && userRoles.Contains("Nurse")) return GetUserRoles.Nurse;

        if (userRoles.Any() && userRoles.Contains("Consultant")) return GetUserRoles.Consultant;

        if (userRoles.Any() && userRoles.Contains("DoctorOfficeEmployee")) return GetUserRoles.DoctorOfficeEmployee;

        if (userRoles.Any() && userRoles.Contains("LaboratoryOfficeEmployee")) return GetUserRoles.LaboratoryOfficeEmployee;

        if (userRoles.Any() && userRoles.Contains("Labratory")) return GetUserRoles.Laboratory;

        if (!userRoles.Any()) return GetUserRoles.User;

        #endregion

        return GetUserRoles.User;
    }

    public async Task<bool> IsUserAdmin(ulong userId)
    {
        var result = await GetUserRoleses(userId);

        if (result == null || !result.Any()) return false;

        if (result.Contains("Admin")) return true;

        return false;
    }

    public async Task<bool> IsUserDoctor(ulong userId)
    {
        var result = await GetUserRoleses(userId);

        if (result == null || !result.Any()) return false;

        if (result.Contains("Admin")) return true;

        if (result.Contains("Doctor")) return true;

        return false;
    }

    //Check Is User Has Permission To Dentist Panel 
    public async Task<bool> IsUserDentist(ulong userId)
    {
        var result = await GetUserRolesesWithAsNoTracking(userId);

        if (result == null || !result.Any()) return false;

        if (result.Contains("Admin")) return true;

        if (result.Contains("Dentist")) return true;

        return false;
    }

    //Check Is User Has Permission To Dentist Panel 
    public async Task<bool> IsUserDentistOrDentistEmployee(ulong userId)
    {
        var result = await GetUserRolesesWithAsNoTracking(userId);

        if (result == null || !result.Any()) return false;

        if (result.Contains("Admin")) return true;

        if (result.Contains("Dentist")) return true;

        if (result.Contains("DentistOfficeEmployee")) return true;

        return false;
    }

    public async Task<bool> IsUserDoctorOrDoctorEmployee(ulong userId)
    {
        var result = await GetUserRoleses(userId);

        if (result == null || !result.Any()) return false;

        if (result.Contains("Admin")) return true;

        if (result.Contains("Doctor")) return true;

        if (result.Contains("DoctorOfficeEmployee")) return true;

        return false;
    }

    //Check Is User Has Permission To Nurse Panel 
    public async Task<bool> IsUserNurse(ulong userId)
    {
        var result = await GetUserRoleses(userId);

        if (result == null || !result.Any()) return false;

        if (result.Contains("Admin")) return true;

        if (result.Contains("Nurse")) return true;

        return false;
    }

    //Check Is User Has Permission To Consultant Panel 
    public async Task<bool> IsUserConsultant(ulong userId)
    {
        var result = await GetUserRoleses(userId);

        if (result == null || !result.Any()) return false;

        if (result.Contains("Admin")) return true;

        if (result.Contains("Consultant")) return true;

        return false;
    }

    //Check Is User Has Permission To Laboratory Panel 
    public async Task<bool> IsUserLaboratory(ulong userId)
    {
        var result = await GetUserRoleses(userId);

        if (result == null || !result.Any()) return false;

        if (result.Contains("Admin")) return true;

        if (result.Contains("Labratory")) return true;

        if (result.Contains("LaboratoryOfficeEmployee")) return true;

        return false;
    }

    //Check Is User Master Of Laboratory 
    public async Task<bool> CheckIsUserMasterOfLaboratory(ulong userId)
    {
        var result = await GetUserRoleses(userId);

        if (result == null || !result.Any()) return false;

        if (result.Contains("Admin")) return true;

        if (result.Contains("Labratory")) return true;

        return false;
    }

    public async Task<bool> IsUserPharmacy(ulong userId)
    {
        //Get User By User ID
        var result = await GetUserRoleses(userId);

        if (result == null || !result.Any()) return false;

        if (result.Contains("Admin")) return true;

        if (result.Contains("Pharmacy")) return true;

        return false;
    }

    public async Task<bool> IsUserSupporter(ulong userId)
    {
        var result = await GetUserRoleses(userId);

        if (result == null || !result.Any()) return false;

        if (result.Contains("Admin")) return true;

        if (result.Contains("Support")) return true;

        return false;
    }

    #endregion
}
