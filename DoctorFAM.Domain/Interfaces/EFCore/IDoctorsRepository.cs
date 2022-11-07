using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FamilyDoctor.ParsaSystem;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DosctorSideBarInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Employees;
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

        //Show List Of SMS That Send From Doctor To Patient Incomes From Parsa System
        Task<List<LogForSendSMSToUsersIncomeFromParsa>?> ShowListOfSMSThatSendFromDoctorToPatientIncomesFromParsaSystem(ulong id, ulong doctorUserId);

        //Add Log For Send SMS From Doctor To Users That Income From Parsa System Without SaveChanges
        Task AddLogForSendSMSFromDoctorToUsersThatIncomeFromParsaSystemWithoutSaveChanges(List<LogForSendSMSToUsersIncomeFromParsa> log);

        //Is Exist Any User From Parsa System In Doctor Parsa System List
        Task<bool> IsExistAnyUserFromParsaSystemInDoctorParsaSystemList(ulong parsaSystemUserId, ulong doctorUserId);

        //List Of DOctor Parsa System Users
        Task<List<UserInsertedFromParsaSystem>?> ListOfDoctorParsaSystemUsers(ulong DoctorUserId);

        //Get List Of User That Comes From Parsa That Registered To Doctor FAM
        Task<List<UserInsertedFromParsaSystem>> GetListOfUserThatComesFromParsaThatRegisteredToDoctorFAM(ulong doctorId);

        //Update Parsa System Record 
        Task UpdateParsaSystemRecord(UserInsertedFromParsaSystem parsa);

        //Get User From Parsa Incoming List By User Id And Doctor User Id
        Task<UserInsertedFromParsaSystem?> GetUserFromParsaIncomingListByUserIdAndDoctorUserId(ulong doctorId, ulong parsaUserId);

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

        Task<ListOfDoctorsInfoViewModel> FilterDoctorsInfoAdminSide(ListOfDoctorsInfoViewModel filter);

        Task<DoctorsInfo?> GetDoctorsInfoById(ulong doctorInfoId);

        Task<DoctorsInfo?> GetDoctorsInfoByDoctorId(ulong doctorId);

        Task<FilterDoctorOfficeEmployeesViewmodel> FilterDoctorOfficeEmployees(FilterDoctorOfficeEmployeesViewmodel filter);

        #endregion

        #region Site Side 

        //Get List Of All Doctors
        Task<List<ListOfAllDoctorsViewModel>> ListOfDoctors();

        #endregion

        #region User Panel Side 

        //Get List Of Doctors With Family Doctor Interests
        Task<List<Doctor?>> FilterFamilyDoctorUserPanelSide(FilterFamilyDoctorUserPanelSideViewModel filter);

        #endregion
    }
}
