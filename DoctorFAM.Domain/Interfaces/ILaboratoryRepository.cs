using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.ViewModels.Admin.Laboratory;
using DoctorFAM.Domain.ViewModels.Laboratory.Employee;
using DoctorFAM.Domain.ViewModels.Laboratory.LaboratorySideBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface ILaboratoryRepository
    {
        #region Laboratory Side 

        //Check Is Exist Laboratory Info By User ID
        Task<bool> IsExistAnyLaboratoryInfoByUserId(ulong userId);

        //Fill Laboratory Side Bar Panel
        Task<LaboratorySideBarViewModel> GetLaboratorySideBarInfo(ulong userId);

        //Is Exist Any Laboratory By This User Id 
        Task<bool> IsExistAnyLaboratoryByUserId(ulong userId);

        //Add Laboratory To Data Base
        Task<ulong> AddLaboratory(Laboratory laboratory);

        //Get Laboratory By User Id
        Task<Laboratory?> GetLaboratoryByUserId(ulong userId);

        //Get Laboratory Information By User Id
        Task<LaboratoryInfo?> GetLaboratoryInformationByUserId(ulong userId);

        //Update Laboratory Info 
        Task UpdateLaboratoryInfo(LaboratoryInfo laboratoryInfo);

        //Add Laboratory Info
        Task AddLaboratoryInfo(LaboratoryInfo laboratoryInfo);

        //Filter Laboratory Office Employees
        Task<FilterLaboratoryOfficeEmployeesViewmodel> FilterLaboratoryOfficeEmployees(FilterLaboratoryOfficeEmployeesViewmodel filter);

        #endregion

        #region Admin Side

        //Filter Laboratory Info Admin Side
        Task<ListOfLaboratoryInfoViewModel> FilterListOfLaboratoryInfoViewModel(ListOfLaboratoryInfoViewModel filter);

        //Get LaboratoryInfo Info By Nurse Id
        Task<LaboratoryInfo?> GetLaboratoryInfoByLaboratoryId(ulong LaboratoryId);

        //Get Laboratory By Consultant Id
        Task<Laboratory?> GetLaboratoryById(ulong laboratoryId);

        //Get Laboratory Info By Laboratory Info Id
        Task<LaboratoryInfo?> GetLaboratoryInfoById(ulong laboratoryInfoId);

        #endregion
    }
}
