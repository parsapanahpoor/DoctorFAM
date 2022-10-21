using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FamilyDoctor.ParsaSystem;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DosctorSideBarInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Employees;
using DoctorFAM.Domain.ViewModels.DoctorPanel.ParsaSystem;
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

        //Show List Of SMS That Send From Doctor To Patient Incomes From Parsa System
        Task<List<LogForSendSMSToUsersIncomeFromParsa>?> ShowListOfSMSThatSendFromDoctorToPatientIncomesFromParsaSystem(ulong id, ulong doctorUserId);

        //Send SMS From Doctor To The Users That Income From Parsa Sysem 
        Task<bool> SendSMSFromDoctorToTheUsersThatIncomeFromParsaSysem(SendSMSToPatientViewModel model);

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

        Task<AddOrEditDoctorInfoResult> AddOrEditDoctorInfoDoctorsPanel(ManageDoctorsInfoViewModel model, IFormFile? MediacalFile);

        Task<Doctor?> GetDoctorByUserId(ulong userId);

        Task<Doctor?> GetDoctorById(ulong doctorId);

        Task<bool> IsExistAnyDoctorByUserId(ulong userId);

        Task AddDoctorForFirstTime(ulong userId);

        Task<List<DoctorsInterestInfo>> GetDoctorInterestsInfo();

        Task<DoctorInterestsViewModel> FillDoctorInterestViewModelFromDoctorPanel(ulong userId);

        Task<DoctorSelectedInterestResult> AddDoctorSelectedInterest(ulong interestId, ulong userId);

        Task<DoctorSelectedInterestResult> DeleteDoctorSelectedInterestDoctorPanel(ulong interestId, ulong userId);

        #endregion

        #region Admin Side 

        Task<ListOfDoctorsInfoViewModel> FilterDoctorsInfoAdminSide(ListOfDoctorsInfoViewModel filter);

        Task<DoctorsInfoDetailViewModel?> FillDoctorsInfoDetailViewModel(ulong doctorInfoId);

        Task<DoctorsInfo?> GetDoctorsInfoById(ulong doctorInfoId);

        Task<EditDoctorInfoResult> EditDoctorInfoAdminSide(DoctorsInfoDetailViewModel model, IFormFile? MediacalFile);

        #endregion

        #region Site Side 

        //Get List Of All Doctors
        Task<List<ListOfAllDoctorsViewModel>> ListOfDoctors();

        //Fill Doctor Page In Reservation Page 
        Task<DoctorPageInReservationViewModel?> FillDoctorPageDetailInReservationPage(ulong userId);

        //Fill Doctor Reservation Detail For Show Site Side View Model
        Task<ShowDoctorReservationDetailViewModel?> FillDoctorReservationDetailForShowSiteSide(ulong userId, string? loggedDateTime);

        //Get Doctro For Send Notification For Take Reservation Notification 
        Task<string?> GetDoctroForSendNotificationForTakeReservationNotification(ulong reservationDateTimeId);

        #endregion

        #region User Panel Side 

        //Get List Of Doctors With Family Doctor Interests
        Task<List<Doctor?>> FilterFamilyDoctorUserPanelSide(FilterFamilyDoctorUserPanelSideViewModel filter);

        //Fill Doctor Family Reservation Information Detail View Model
        Task<ShowDoctorInformationDetailViewModel?> FillShowDoctorInformationDetailViewModel(ulong doctorId);

        #endregion
    }
}
