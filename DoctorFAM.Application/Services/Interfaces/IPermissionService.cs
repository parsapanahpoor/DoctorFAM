#region Usings

using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.Access;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.Dentist.SideBar;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DosctorSideBarInfo;
namespace DoctorFAM.Application.Services.Interfaces;

#endregion

public interface IPermissionService
{
    #region Check Permission

    //Get Dentist Side Bar Info
    Task<DentistSideBarViewModel> GetDentistSideBarInfo(ulong userId);

    Task<bool> HasUserPermission(ulong userId, string permissionName);

    #endregion

    #region Role

    //Check Is User Master Of Laboratory 
    Task<bool> CheckIsUserMasterOfLaboratory(ulong userId);

    //Check Is User Has Permission To Consultant Panel 
    Task<bool> IsUserConsultant(ulong userId);

    Task<List<Role>> GetListOfRoles();

    Task<DoctorSideBarViewModel> GetDoctorsInfosState(ulong userId);

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

    Task<bool> IsUserDoctorOrDoctorEmployee(ulong userId);

    //Check Is User Has Permission To Dentist Panel 
    Task<bool> IsUserDentist(ulong userId);

    //Check Is User Has Permission To Dentist Panel 
    Task<bool> IsUserDentistOrDentistEmployee(ulong userId);

    Task<bool> IsUserPharmacy(ulong userId);

    Task<bool> IsUserSupporter(ulong userId);

    //Check Is User Has Permission To Nurse Panel 
    Task<bool> IsUserNurse(ulong userId);

    //Check Is User Has Permission To Laboratory Panel 
    Task<bool> IsUserLaboratory(ulong userId);

    //Check Is User Has Permission To Tourism Panel 
    Task<bool> IsUserTourism(ulong userId);

    //Get List Of Laboratory Roles
    Task<List<Role>> GetListOfLaboratoryRoles();

    Task<List<string>?> GetUserRoleses(ulong userId);

    Task<List<string>?> GetUserRolesesWithAsNoTracking(ulong userId);

    #endregion
}
