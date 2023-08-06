#region Usings 

using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.ViewModels.Admin.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeLabratory;
using DoctorFAM.Domain.ViewModels.Admin.Laboratory;
using DoctorFAM.Domain.ViewModels.Laboratory.Employee;
using DoctorFAM.Domain.ViewModels.Laboratory.HomeLaboratory;
using DoctorFAM.Domain.ViewModels.Laboratory.LaboratoryInfo;
using DoctorFAM.Domain.ViewModels.Laboratory.LaboratorySideBar;

#endregion

namespace DoctorFAM.Application.Services.Interfaces;

public interface ILaboratoryService
{
    #region Laboratory Side 

    //Request For Epload Excel File From Site
    Task<bool> RequestForEploadExcelFileFromSite(RequestForUploadExcelFileFromDoctorsToSiteViewModel model, ulong userId);

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

    //Add Exist User To The Laboratory Organization 
    Task<bool> AddExistUserToTheLaboratoryOrganization(ulong userId, List<ulong> UserRoles, ulong laboratoryId);

    //Filter List Of Home Laboratory Request ViewModel From User Or Supporter Panel 
    Task<FilterListOfHomeLaboratoryRequestViewModel> FilterListOfHomeLaboratoryRequestViewModel(FilterListOfHomeLaboratoryRequestViewModel filter);

    //Show Home Laboratory Request Detail In Laboratory Panel
    Task<HomeLaboratoryRequestViewModel?> FillHomePharmacyRequestViewModel(ulong requestId, ulong userId);

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

    //Show Home Laboratory Request Detail In Admin And Supporter Panel
    Task<HomeLabratoryRequestDetailViewModel?> FillHomePharmacyRequestDetailAdminSide(ulong requestId, ulong userId);

    #endregion
}
