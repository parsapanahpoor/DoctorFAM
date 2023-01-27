using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FamilyDoctor.ParsaSystem;
using DoctorFAM.Domain.Entities.FamilyDoctor.VIPSystem;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DosctorSideBarInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Employees;
using DoctorFAM.Domain.ViewModels.Site.Diabet;
using DoctorFAM.Domain.ViewModels.Site.Doctor;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IDoctorsRepository
    {
        #region Doctors Panel Side

        //Update Diabet Consultant Resume 
        Task UpdateDiabetConsultantResume(DiabetConsultantsResume diabet);

        //Update Blood Pressure Consultant Resume 
        Task UpdateBloodPressureConsultantResume(BloodPressureConsultantResume bloodPressure);

        //Get Diabet Consualtant Resume By Id
        Task<DiabetConsultantsResume?> GetDiabetConsualtantResumeById(ulong resumeId);

        //Get Blood Pressure Consualtant Resume By Id
        Task<BloodPressureConsultantResume?> GetBloodPressureConsualtantResumeById(ulong resumeId);

        //Upload Resume From Diabet Consultant 
        Task UploadResumeFroDiabetConsultant(DiabetConsultantsResume diabet);

        //Upload Resume From Blood Pressure Consultant 
        Task UploadResumeFroBloodPressureConsultant(BloodPressureConsultantResume bloodPressure);

        //Get Doctor Diabet Consultant Resumes By Doctor User Id 
        Task<List<DiabetConsultantsResume>?> GetDoctorDiabetConsultantResumesByDoctorUserId(ulong doctorUserId);

        //Get Doctor Blood Pressure Consultant Resumes By Doctor User Id 
        Task<List<BloodPressureConsultantResume>?> GetDoctorBloodPressureConsultantResumesByDoctorUserId(ulong doctorUserId);

        //Create Request Excel File For Compelete From Admin 
        Task CreateRequestExcelFileForCompeleteFromAdmin(RequestForUploadExcelFileFromDoctorsToSite model);

        //List Of DOctor VIP Parsa System UsersWith Sickness Label Id
        Task<List<VIPUserInsertedFromDoctorSystem>?> ListOfDOctorVIPParsaSystemUsers(ulong DoctorUserId, ulong sicknessLabelId);

        //Get Doctor Lable Of Sickness By Doctor User Id 
        Task<List<DoctorsLabelsForVIPInsertedDoctor>?> GetDoctorLableOfSicknessByDoctorUserId(ulong doctorUserId);

        //Get List Of VIP Inserted PAtient With Label Name
        Task<List<VIPUserInsertedFromDoctorSystem>?> GetListOfVIPInsertedPAtientWithLabelName(ulong labelId, ulong doctorUserId);

        //Add Doctor Label For Inserted VIP Users
        Task AddDoctorLabelForInsertedVIPUsers(DoctorsLabelsForVIPInsertedDoctor label);

        //Get Label By Doctor User Id And Label Name 
        Task<DoctorsLabelsForVIPInsertedDoctor?> GetLabelByDoctorUserIdAndLabelName(string labelName, ulong doctorUserId);

        //Add New Label Of Sickness To The Existing Users 
        Task AddNewLabelOfSicknessToTheExistingUsers(ulong doctorUserId, string mobileNumber, string NationalId, string label);

        //Is Exist Any User VIP By This Mobile Number And NationalId In Current Doctor System File 
        Task<bool> IsExistAnyUserVIPByThisMobileNumberAndNationalIdInCurrentDoctorSystemFile(ulong doctorUserId, string mobileNumber, string NationalId);

        //Is Exist Any User VIP By This Id In Current Doctor System File 
        Task<bool> IsExistAnyUserVIPByThisIdInCurrentDoctorSystemFile(ulong doctorUserId, ulong vipUserId);

        //Add Label Of Sickness To Vip Users That Income From Doctor System  
        Task AddLabelOfSicknessToVipUsersThatIncomeFromDoctorSystem(LabelOfVIPDoctorInsertedPatient label);

        //Get Label Of Sickness From VIP Users
        Task<List<string>> GetLabelOfSicknessFromVIPUsers(ulong incomeUserId);

        //List Of DOctor VIP Parsa System Users
        Task<List<VIPUserInsertedFromDoctorSystem>?> ListOfDOctorVIPParsaSystemUsers(ulong DoctorUserId);

        //Add Range Of VIP User From Parsa System To The Data Base
        Task TaskAddRangeOfVIPUserFromParsaSystemToTheDataBase(List<VIPUserInsertedFromDoctorSystem> list);

        //Show List Of SMS That Send From Doctor To Patient Incomes From Parsa System
        Task<List<LogForSendSMSToUsersIncomeFromParsa>?> ShowListOfSMSThatSendFromDoctorToPatientIncomesFromParsaSystem(ulong id, ulong doctorUserId);

        //Show List Of SMS That Send From Doctor To VIP Patient Incomes From Parsa System
        Task<List<LogForSendSMSToVIPUsersIncomeFromDoctorSystem>?> ShowListOfSMSThatSendFromDoctorToVIPPatientIncomesFromParsaSystem(ulong id);

        //Add Log For Send SMS From Doctor To Users That Income From Parsa System Without SaveChanges
        Task AddLogForSendSMSFromDoctorToUsersThatIncomeFromParsaSystemWithoutSaveChanges(List<LogForSendSMSToUsersIncomeFromParsa> log);

        //Add Log For Send SMS From Doctor To VIP Users That Income From Parsa System Without SaveChanges
        Task AddLogForSendSMSFromDoctorToVIPUsersThatIncomeFromParsaSystemWithoutSaveChanges(List<LogForSendSMSToVIPUsersIncomeFromDoctorSystem> log);

        //Is Exist Any User From Parsa System In Doctor Parsa System List
        Task<bool> IsExistAnyUserFromParsaSystemInDoctorParsaSystemList(ulong parsaSystemUserId, ulong doctorUserId);

        //Is Exist Any User From VIP Parsa System In Doctor Parsa System List
        Task<bool> IsExistAnyVIPUserFromParsaSystemInDoctorParsaSystemList(ulong parsaSystemUserId, ulong doctorUserId);

        //List Of DOctor Parsa System Users
        Task<List<UserInsertedFromParsaSystem>?> ListOfDoctorParsaSystemUsers(ulong DoctorUserId);

        //Get List Of User That Comes From Parsa That Registered To Doctor FAM
        Task<List<UserInsertedFromParsaSystem>> GetListOfUserThatComesFromParsaThatRegisteredToDoctorFAM(ulong doctorId);

        //Update Parsa System Record 
        Task UpdateParsaSystemRecord(UserInsertedFromParsaSystem parsa);

        //Update VIP Parsa System Record 
        Task UpdateVIPParsaSystemRecord(VIPUserInsertedFromDoctorSystem parsaVIP);

        //Get User From Parsa Incoming List By User Id And Doctor User Id
        Task<UserInsertedFromParsaSystem?> GetUserFromParsaIncomingListByUserIdAndDoctorUserId(ulong doctorId, ulong parsaUserId);

        //Get VIP User From Parsa Incoming List By User Id And Doctor User Id
        Task<VIPUserInsertedFromDoctorSystem?> GetVIPUserFromParsaIncomingListByUserIdAndDoctorUserId(ulong doctorId, ulong parsaUserId);

        //Is Exist Any User By This Mobile Number In Current Doctor Parsa System File 
        Task<bool> IsExistAnyUserByThisMobileNumberInCurrentDoctorParsaSystemFile(ulong doctorUserId, string mobileNumber);

        //Check That Is User Has Any Active Family Doctor 
        Task<bool> CheckThatIsUserHasAnyActiveFamilyDoctor(string userMobile);

        //Check That Is Exist User By Mobile In User Population Covered
        Task<bool> CheckThatIsExistUserByMobileInUserPopulationCovered(ulong doctorUserId, string userMobile);

        //Save Changes
        Task SaveChanges();

        //Refres Patient From User Inserts Parsa System
        Task RefresPatientFromUserInsertsParsaSystemWithoutSaveChanges(UserInsertedFromParsaSystem user);

        //Get List Of User That Comes From Parsa That Not Register To Doctor FAM
        Task<List<UserInsertedFromParsaSystem>> GetListOfUserThatComesFromParsaThatNotRegisterToDoctorFAM(ulong doctorId);

        //Get List Of User That Comes From Parsa
        Task<List<UserInsertedFromParsaSystem>> GetListOfUserThatComesFromParsa(ulong doctorId);

        //Add Range Of User From Parsa System To The Data Base
        Task AddRangeOfUserFromParsaSystemToTheDataBase(List<UserInsertedFromParsaSystem> list);

        //Remove Doctor Skills
        Task RemoveDoctorSkills(List<DoctorsSkils> doctorSkill);

        //Get List Of Doctor Skills By Doctor Id
        Task<List<DoctorsSkils>> GetListOfDoctorSkillsByDoctorId(ulong doctorId);

        //Add Doctor Selected Skils Without Save Changes
        Task AddDoctorSelectedSkilsWithoutSaveChanges(DoctorsSkils doctorsSkils);

        Task<DoctorSideBarViewModel> GetDoctorsSideBarInfo(ulong userId);

        Task<DoctorsInfo?> GetDoctorsInformationByUserId(ulong userId);

        Task UpdateDoctorsInfo(DoctorsInfo doctorsInfo);

        Task AddDoctorsInfo(DoctorsInfo doctorsInfo);

        Task<Doctor?> GetDoctorByUserId(ulong userId);

        Task UpdateDoctorState(Doctor doctor);

        Task<ulong> AddDoctor(Doctor doctor);

        Task<Doctor?> GetDoctorById(ulong doctorId);

        Task<bool> IsExistAnyDoctorInfoByUserId(ulong userId);

        Task<bool> IsExistAnyDoctorByUserId(ulong userId);

        Task<List<DoctorsInterestInfo>> GetDoctorInterestsInfo();

        Task<List<DoctorsInterestInfo>> GetDoctorSelectedInterests(ulong doctorId);

        Task AddDoctorSelectedInterest(DoctorsSelectedInterests doctorsSelectedInterests);

        Task<bool> IsExistInterestForDoctor(ulong interestId, ulong doctorId);

        Task<bool> IsExistInterestById(ulong interestId);

        Task DeleteDoctoreSelectedInterest(DoctorsSelectedInterests item);

        Task<DoctorsSelectedInterests?> GetDoctorSelectedInterestByDoctorIdAndInetestId(ulong interestId, ulong doctorId);

        Task<DoctorsSelectedInterests> GetDoctorSelectedInterestByDoctorIdAndInterestId(ulong interestId, ulong doctorId);

        #endregion

        #region Admin Side 

        //Update Request Excel File For Compelete From Admin 
         Task UpdateRequestExcelFileForCompeleteFromAdmin(RequestForUploadExcelFileFromDoctorsToSite model);

        //Get Request Excel File By Id 
        Task<RequestForUploadExcelFileFromDoctorsToSite?> GetRequestExcelFileById(ulong requetsId);

        //Get Lastest Request For Uplaod Excel File
        Task<List<RequestForUploadExcelFileFromDoctorsToSite>> GetLastestRequestForUplaodExcelFile();

        Task<ListOfDoctorsInfoViewModel> FilterDoctorsInfoAdminSide(ListOfDoctorsInfoViewModel filter);

        Task<DoctorsInfo?> GetDoctorsInfoById(ulong doctorInfoId);

        Task<DoctorsInfo?> GetDoctorsInfoByDoctorId(ulong doctorId);

        Task<FilterDoctorOfficeEmployeesViewmodel> FilterDoctorOfficeEmployees(FilterDoctorOfficeEmployeesViewmodel filter);

        #endregion

        #region Site Side 

        //Get List Of Doctors Name
        Task<List<string>?> GetListOfDoctorsName();

        //Get List Of All Doctors
        Task<List<ListOfAllDoctorsViewModel>> ListOfDoctors();

        //Get List Of Doctors With Diabet Consultant Interests
        Task<List<Doctor>?> FilterDiabetConsultantsSiteSide(FilterDiabetConsultantsSiteSideViewModel filter);

        //Get List Of Doctors With Diabet Speciality
        Task<List<Doctor>?> FilterDoctorsWithDiabetSpecialitySiteSide(FilterDoctorsWithDiabetSpecialitySiteSideViewModel filter);

        #endregion

        #region User Panel Side 

        //Get List Of Doctors With Family Doctor Interests
        Task<List<Doctor?>> FilterFamilyDoctorUserPanelSide(FilterFamilyDoctorUserPanelSideViewModel filter);

        #endregion
    }
}
