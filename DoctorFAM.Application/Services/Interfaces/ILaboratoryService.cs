using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.ViewModels.Admin.Laboratory;
using DoctorFAM.Domain.ViewModels.Laboratory.Employee;
using DoctorFAM.Domain.ViewModels.Laboratory.LaboratoryInfo;
using DoctorFAM.Domain.ViewModels.Laboratory.LaboratorySideBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface ILaboratoryService
    {
        #region Laboratory Side 

        //Fill Laboratory Side Bar Panel
        Task<LaboratorySideBarViewModel> GetLaboratorySideBarInfo(ulong userId);

        //Is Exist Any Laboratory By This User Id 
        Task<bool> IsExistAnyLaboratoryByUserId(ulong userId);

        //Add Laboratory For First Time Loging To Laboratory Panel 
        Task AddLaboratoryForFirstTime(ulong userId);

        //Get Laboratory By User Id
        Task<Laboratory?> GetLaboratoryByUserId(ulong userId);

        //Get Laboratory Information By User Id
        Task<LaboratoryInfo?> GetLaboratoryInformationByUserId(ulong userId);

        //Fill Laboratory Info View Model
        Task<ManageLaboratoryInfoViewModel?> FillManageLaboratoryInfoViewModel(ulong userId);

        //Check Is Exist Laboratory Info By User ID
        Task<bool> IsExistAnyLaboratoryInfoByUserId(ulong userId);

        //Add Or Edit Laboratory Info From Laboratory Panel
        Task<AddOrEditLaboratoryInfoResult> AddOrEditLaboratoryInfoNursePanel(ManageLaboratoryInfoViewModel model);

        //Filter Laboratory Office Employees
        Task<FilterLaboratoryOfficeEmployeesViewmodel> FilterLaboratoryOfficeEmployees(FilterLaboratoryOfficeEmployeesViewmodel filter);

        #endregion

        #region Admin Side 

        //Filter Laboratory Info Admin Side
        Task<ListOfLaboratoryInfoViewModel> FilterListOfLaboratoryInfoViewModel(ListOfLaboratoryInfoViewModel filter);

        //Get Laboratory By Consultant Id
        Task<Laboratory?> GetLaboratoryById(ulong laboratoryId);

        //Fill Laboratory Info Detail ViewModel
        Task<LaboratoryInfoDetailAdminSideViewModel?> FillLaboratoryInfoDetailAdminSideViewModel(ulong ConsultantId);

        //Edit Laboratory Info From Admin Panel
        Task<EditLaboratoryInfoResult> EditLaboratoryInfoAdminSide(LaboratoryInfoDetailAdminSideViewModel model);

        #endregion
    }
}
