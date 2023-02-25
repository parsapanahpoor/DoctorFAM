using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FamilyDoctor.ParsaSystem;
using DoctorFAM.Domain.Entities.FamilyDoctor.VIPSystem;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.ViewModels.Admin.Doctors;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.Admin.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.Admin.IncomingExcelFile;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DosctorSideBarInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Employees;
using DoctorFAM.Domain.ViewModels.DoctorPanel.ParsaSystem;
using DoctorFAM.Domain.ViewModels.DoctorPanel.ParsaSystem.VIPPatient;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Speciality;
using DoctorFAM.Domain.ViewModels.Site.BloodPressure;
using DoctorFAM.Domain.ViewModels.Site.Diabet;
using DoctorFAM.Domain.ViewModels.Site.Doctor;
using DoctorFAM.Domain.ViewModels.Site.Reservation;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IDoctorsService
    {
        #region Doctors Panel Side   

        //Delete Diabet Consultant Resume By Resume Id
        Task<bool> DeleteDiabetConsultantResumeByResumeId(ulong resumeId, ulong userId);

        //Delete Blood Pressure Consultant Resume By Resume Id
        Task<bool> DeleteBloodPressureConsultantResumeByResumeId(ulong resumeId, ulong userId);

        //Get Diabet Consualtant Resume By Id
        Task<DiabetConsultantsResume?> GetDiabetConsualtantResumeById(ulong resumeId);

        //Upload Doctor Diabet Consultant Resume File 
        Task<bool> UploadDoctorDiabetConsultantResumeFile(ulong userId, string? description, IFormFile? resumePicture);

        //Upload Doctor Blood Pressure Consultant Resume File 
        Task<bool> UploadDoctorBloodPressureConsultantResumeFile(ulong userId, string? description, IFormFile? resumePicture);

        //Get Doctor Diabet Consultant Resumes By Doctor User Id 
        Task<List<DiabetConsultantsResume>?> GetDoctorDiabetConsultantResumesByDoctorUserId(ulong doctorUserId);

        //Get Doctor Blood Pressure Consultant Resumes By Doctor User Id 
        Task<List<BloodPressureConsultantResume>?> GetDoctorBloodPressureConsultantResumesByDoctorUserId(ulong doctorUserId);

        //Fill Diabet Consultatn Resume View Model
        Task<UploadDiabetConsultatntDoctorSideViewModel?> FillDiabetConsultatnResumeViewModel(ulong userId);

        //Fill Blood Pressure Consultatn Resume View Model
        Task<UploadBloodPressureConsultatntDoctorSideViewModel?> FillBloodPressureConsultatnResumeViewModel(ulong userId);

        //Get Doctor Lable Of Sickness By Doctor User Id 
        Task<List<DoctorsLabelsForVIPInsertedDoctor>?> GetDoctorLableOfSicknessByDoctorUserId(ulong doctorUserId);

        //Send SMS From Doctor To The VIP Users That Income From Parsa Sysem 
        Task<bool> SendSMSFromVIPDoctorToTheUsersThatIncomeFromParsaSysem(ulong doctorUserId, List<ulong> patientIds, string SMSBody);

        //Fill ViewModel For Send SMS For Range Of VIP Patient
        Task<SendSMSForRangeOfVIPInsertedPatientViewModel?> FillSendSMSForRangeOfVIPInsertedPatientViewModel(string label, ulong doctorUserId);

        //change Excel File Request From Admin Or Supporter Panel 
        Task<bool> ChangeExcelFileRequestFromAdminOrSupporterPanel(RequestForUploadExcelFileDetailAdminSideViewModel model);

        //Send SMS From Doctor To The VIP Users That Income From Parsa Sysem 
        Task<bool> SendSMSFromVIPDoctorToTheUsersThatIncomeFromParsaSysem(SendSMSToPatientViewModel model);

        //Is Exist Any User VIP By This Mobile Number And NationalId In Current Doctor System File 
        Task<bool> IsExistAnyUserVIPByThisMobileNumberAndNationalIdInCurrentDoctorSystemFile(ulong doctorUserId, string mobileNumber, string NationalId);

        //List Of DOctor Parsa System Users
        Task<List<ListOfVIPIncommingUsers>?> ListOfDoctorVIPParsaSystemUsers(ulong DoctorUserId, ulong? sicknessLabelId);

        //Upload Excel File For VIP Patient That Income From Doctor System Organization
        Task<bool> UploadExcelFileForVIPPatientThatIncomeFromDoctorSystemOrganization(ulong userId, UploadExcelFileFromDoctorSystemViewModel model);

        //Update Doctor Personal Info With Save Changes 
        Task UpdateDoctorPersonalInfoWithSaveChanges(DoctorsInfo doctorsInfo);

        //Show List Of SMS That Send From Doctor To Patient Incomes From Parsa System
        Task<List<LogForSendSMSToUsersIncomeFromParsa>?> ShowListOfSMSThatSendFromDoctorToPatientIncomesFromParsaSystem(ulong id, ulong doctorUserId);

        //Show List Of SMS That Send From Doctor To VIP Patient Incomes From Parsa System
        Task<List<LogForSendSMSToVIPUsersIncomeFromDoctorSystem>?> ShowListOfSMSThatSendFromDoctorToVIPPatientIncomesFromParsaSystem(ulong id, ulong doctorUserId);

        //Send SMS From Doctor To The Users That Income From Parsa Sysem 
        Task<bool> SendSMSFromDoctorToTheUsersThatIncomeFromParsaSysem(SendSMSToPatientViewModel model);

        //Get VIP User From Parsa Incoming List By User Id And Doctor User Id
        Task<VIPUserInsertedFromDoctorSystem?> GetVIPUserFromParsaIncomingListByUserIdAndDoctorUserId(ulong doctorId, ulong parsaUserId);

        //List Of DOctor Parsa System Users
        Task<List<UserInsertedFromParsaSystem>?> ListOfDoctorParsaSystemUsers(ulong DoctorUserId);

        //Get List Of User That Comes From Parsa That Registered To Doctor FAM
        Task<List<UserInsertedFromParsaSystem>> GetListOfUserThatComesFromParsaThatRegisteredToDoctorFAM(ulong doctorId);

        //Remove User From Parsa System From Doctor Dashboard 
        Task<bool> RemoveUserFromParsaSystemFromDoctorDashboard(ulong doctorUserId, ulong userId);

        //Get User From Parsa Incoming List By User Id And Doctor User Id
        Task<UserInsertedFromParsaSystem?> GetUserFromParsaIncomingListByUserIdAndDoctorUserId(ulong doctorId, ulong parsaUserId);

        //Is Exist Any User By This Mobile Number In Current Doctor Parsa System File 
        Task<bool> IsExistAnyUserByThisMobileNumberInCurrentDoctorParsaSystemFile(ulong doctorUserId, string mobileNumber);

        //Check That Is User Has Any Active Family Doctor 
        Task<bool> CheckThatIsUserHasAnyActiveFamilyDoctor(string userMobile);

        //Check That Is Exist User By Mobile In User Population Covered
        Task<bool> CheckThatIsExistUserByMobileInUserPopulationCovered(ulong doctorUserId, string userMobile);

        //Refresh List Of Users That Come From Parsa System 
        Task<bool> RefreshListOfUsersThatComeFromParsaSystem(ulong userId);

        //Get List Of User That Comes From Parsa That Not Register To Doctor FAM
        Task<List<UserInsertedFromParsaSystem>> GetListOfUserThatComesFromParsaThatNotRegisterToDoctorFAM(ulong doctorId);

        //Get List Of User That Comes From Parsa
        Task<List<UserInsertedFromParsaSystem>> GetListOfUserThatComesFromParsa(ulong doctorId);

        //Upload Excel File That Get From Parsa System
        Task<bool> UploadExcelFileThatGetFromParsaSystem(ulong userId, IFormFile excelFile);

        //Get List Of Doctor Skills By Doctor Id
        Task<List<DoctorsSkils>> GetListOfDoctorSkillsByDoctorId(ulong doctorId);

        Task<List<DoctorsInterestInfo>> GetDoctorSelectedInterests(ulong doctorId);

        Task<FilterDoctorOfficeEmployeesViewmodel> FilterDoctorOfficeEmployees(FilterDoctorOfficeEmployeesViewmodel filter);

        Task<bool> IsExistAnyDoctorInfoByUserId(ulong userId);

        Task<DoctorSideBarViewModel> GetDoctorsSideBarInfo(ulong userId);

        Task<DoctorsInfo?> GetDoctorsInformationByUserId(ulong userId);

        Task<ManageDoctorsInfoViewModel?> FillManageDoctorsInfoViewModel(ulong userId);

        Task<AddOrEditDoctorInfoResult> AddOrEditDoctorInfoDoctorsPanel(ManageDoctorsInfoViewModel model, IFormFile? MediacalFile, IFormFile? UserAvatar);

        Task<Doctor?> GetDoctorByUserId(ulong userId);


        //List Of Arrival Excel Files Show In Admin Side 
        Task<List<ListOfArrivalExcelFiles>> FillListOfArrivalExcelFilesAdminSideViewModel();

        // Fill Request For Upload Excel File Detail Admin Side View Model
        Task<RequestForUploadExcelFileDetailAdminSideViewModel?> FillRequestForUploadExcelFileDetailAdminSideViewModel(ulong requestId);

        Task<Doctor?> GetDoctorById(ulong doctorId);

        Task<bool> IsExistAnyDoctorByUserId(ulong userId);

        Task AddDoctorForFirstTime(ulong userId);

        Task<List<DoctorsInterestInfo>> GetDoctorInterestsInfo();

        Task<DoctorInterestsViewModel> FillDoctorInterestViewModelFromDoctorPanel(ulong userId);

        Task<DoctorSelectedInterestResult> AddDoctorSelectedInterest(ulong interestId, ulong userId);

        Task<DoctorSelectedInterestResult> DeleteDoctorSelectedInterestDoctorPanel(ulong interestId, ulong userId);

        //Add Exist User To The Doctor Organization 
        Task<bool> AddExistUserToTheDoctorOrganization(ulong userId, ulong doctorId);

        //Decline Doctor Information By One Click 
        Task<bool> DeclineDoctorInformationByOneClick(ulong userId);

        //Request For Epload Excel File From Site
        Task<bool> RequestForEploadExcelFileFromSite(RequestForUploadExcelFileFromDoctorsToSiteViewModel model, ulong userId);

        //Fill List OF Doctors Speciality
        Task<List<ListOfSpecialityViewModel>?> FillListOFDoctorsSpeciality(ulong doctorId);

        //Update Doctor Speciality Selected
        Task<bool> UpdateDoctorSpecialitySelected(List<ulong>? speciallities, ulong userId);

        #endregion

        #region Admin Side 

        //List Of Doctors Population Covered Count Detail
        Task<List<ListOfDoctorsPopulationCoveredCountDetailViewModel>> ListOfDoctorsPopulationCoveredCountDetail();

        //Count Of All Doctors 
        Task<int> CountOfAllDoctors();

        //Get Diabet Consultant Resumes By UserId Admin Side
        Task<List<DiabetConsultantsResume>?> GetDiabetConsultanResumesByUserIdAdminSide(ulong userId);

        //Get Blood Pressure Consultant Resumes By UserId Admin Side
        Task<List<BloodPressureConsultantResume>?> GetBloodPressureConsultanResumesByUserIdAdminSide(ulong userId);

        Task<ListOfDoctorsInfoViewModel> FilterDoctorsInfoAdminSide(ListOfDoctorsInfoViewModel filter);

        Task<DoctorsInfoDetailViewModel?> FillDoctorsInfoDetailViewModel(ulong doctorInfoId);

        Task<DoctorsInfo?> GetDoctorsInfoById(ulong doctorInfoId);

        Task<EditDoctorInfoResult> EditDoctorInfoAdminSide(DoctorsInfoDetailViewModel model, IFormFile? MediacalFile);

        #endregion

        #region Site Side 

        //Get List Of Doctors Name
        Task<List<string>?> GetListOfDoctorsName();

        //Get List Of All Doctors
        Task<List<ListOfAllDoctorsViewModel>> ListOfDoctors();

        //Fill Doctor Page In Reservation Page 
        Task<DoctorPageInReservationViewModel?> FillDoctorPageDetailInReservationPage(ulong userId);

        //Fill Doctor Reservation Detail For Show Site Side View Model
        Task<ShowDoctorReservationDetailViewModel?> FillDoctorReservationDetailForShowSiteSide(ulong userId, string? loggedDateTime);

        //Get Doctro For Send Notification For Take Reservation Notification 
        Task<string?> GetDoctroForSendNotificationForTakeReservationNotification(ulong reservationDateTimeId);

        //Get List Of Doctors With Diabet Consultant Interests
        Task<List<Doctor>?> FilterDiabetConsultantsSiteSide(FilterDiabetConsultantsSiteSideViewModel filter);

        //Get List Of Doctors With Blood Pressure Consultant Interests
        Task<List<Doctor>?> FilterBloodPressureConsultantsSiteSide(FilterBloodPressureConsultantsSiteSideViewModel filter);

        //Get List Of Doctors With Diabet Speciality
        Task<List<Doctor>?> FilterDoctorsWithDiabetSpecialitySiteSide(FilterDoctorsWithDiabetSpecialitySiteSideViewModel filter);

        //Get List Of Doctors With Blood Pressure Speciality
        Task<List<Doctor>?> FilterDoctorsWithBloodPressureSpecialitySiteSide(FilterDoctorsWithBloodPressureSpecialitySiteSideViewModel filter);

        //Get Doctr Name With PArt Of Name
        Task<List<string>?> GetListOfDoctorsName(string doctorNamePart);

        #endregion

        #region User Panel Side 

        //Get List Of Doctors With Family Doctor Interests
        Task<List<Doctor?>> FilterFamilyDoctorUserPanelSide(FilterFamilyDoctorUserPanelSideViewModel filter);

        //Fill Doctor Family Reservation Information Detail View Model
        Task<ShowDoctorInformationDetailViewModel?> FillShowDoctorInformationDetailViewModel(ulong doctorId);

        #endregion
    }
}
