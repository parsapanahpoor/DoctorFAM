#region Usings

using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.FamilyDoctor.ParsaSystem;
using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.SendSMS.FromDoctrors;
using DoctorFAM.Domain.ViewModels.Admin.Laboratory;
using DoctorFAM.Domain.ViewModels.DoctorPanel.SendSMS;
using DoctorFAM.Domain.ViewModels.Laboratory.Employee;
using DoctorFAM.Domain.ViewModels.Laboratory.HomeLaboratory;
using DoctorFAM.Domain.ViewModels.Laboratory.LaboratorySideBar;

#endregion

namespace DoctorFAM.Domain.Interfaces;

public interface ILaboratoryRepository
{
    #region Laboratory Side 

    //Update Request For Send SMS From Laboratory To Patient
    Task UpdateRequestForSendSMSFromLaboratoryToPatient(SendRequestOfSMSFromDoctorsToThePatient request);

    //Get Request Detail For Send SMS From Laboratory To Patient By Request Id
    Task<List<SendRequestOfSMSFromDoctorsToThePatientDetail>> GetRequestDetailForSendSMSFromLaboratoryToPatientByRequestId(ulong requestId);

    //Get Count Of Laboratory Free SMS Sent
    Task<int?> GetCountOfLaboratoryFreeSMSSent(ulong laboratoryUserId);

    //Get List User That Laboratory Want To Send Them SMS
    Task<List<User>?> GetListUserThatLaboratoryWantToSendThemSMS(ulong requestDetailId);

    //Get Request For Send SMS From Laboratory To Patient By RequestId
    Task<SendRequestOfSMSFromDoctorsToThePatient?> GetRequestForSendSMSFromLaboratoryToPatientByRequestId(ulong requestId);

    //List Of Laboratory Send SMS Laboratory Doctor Side View Model
    Task<List<ListOfDoctorSendSMSRequestDoctorSideViewModel>?> ListOfLaboratorySendSMSRequestLaboratorySideViewModel(ulong laboratoryUserId);

    //Reduce Laboratory Free SMS Percentage Without Save Changes
    Task ReduceLaboratoryFreeSMSPercentageWithoutSaveChanges(ulong laboratoryId, int smsCount);

    //Add Send Request Of SMS From Laboratory To The Patient Detail To The Data Base
    Task AddSendRequestOfSMSFromLaboratorysToThePatientDetailToTheDataBase(SendRequestOfSMSFromDoctorsToThePatientDetail requestDetail);

    //Add Send Request Of SMS From Laboratory To The Patient
    Task AddSendRequestOfSMSFromLaboratoryToThePatient(SendRequestOfSMSFromDoctorsToThePatient request);

    //Get Count Of Laboratory SMS
    Task<int> GetCountOfLaboratorySMS(ulong laboratoryOWnerId);

    //List Of Laboratory User Excel File Uploaded
    Task<List<UserInsertedFromParsaSystem>?> ListOfLaboratoryUserExcelFileUploaded(ulong laboratoryUserId);

    //Create Request Excel File For Compelete From Admin 
    Task CreateRequestExcelFileForCompeleteFromAdmin(RequestForUploadExcelFileFromDoctorsToSite model);

    //Get Doctor's Free SMS Count
    Task<int> GetLaboratoryFreeSMSCount();

    Task<PatientRequestDateTimeDetail?> GetRequestDateTimeDetailByRequestDetailId(ulong requestId);

    Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId);

    Task<List<HomeLaboratoryRequestDetail>> GetHomeLaboratoryRequestDetailByRequestId(ulong requestId);

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

    //Add User Laboratory Member Role Without Save Changes
    Task AddUserLaboratoryMemberRoleWithoutSaveChanges(UserRole userRole);

    //Save Changes
    Task Savechanges();

    //Filter List Of Home Laboratory Request ViewModel From User Or Supporter Panel 
    Task<FilterListOfHomeLaboratoryRequestViewModel> FilterListOfHomeLaboratoryRequestViewModel(FilterListOfHomeLaboratoryRequestViewModel filter);

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
