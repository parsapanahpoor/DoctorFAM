#region usings

using DoctorFAM.Domain.Entities.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Admin.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Site.OnlineVisit;
using DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit;
using Microsoft.EntityFrameworkCore;

#endregion

namespace DoctorFAM.Domain.Interfaces;

public interface IOnlineVisitRepository
{
    #region Old Version 

    #region Site Side

    //Add Online Request Detail 
    Task AddOnlineRequestDetail(OnlineVisitRequestDetail model);

    //Get Activated And Online Visit Interests Online Visit For Send Correct Notification For Arrival Online Visit Request 
    Task<List<string?>> GetActivatedAndDoctorsInterestOnlineVisit();

    //Filter Online Visit Requests 
    Task<FilterOnlineVisitViewModel> FilterOnlineVisitRequests(FilterOnlineVisitViewModel filter);

    //Get Online Visit Request Detail 
    Task<OnlineVisitRequestDetail?> GetOnlineVisitRequestDetail(ulong requestId);

    #endregion

    #region Doctor Side

    //Filter Your Online Visit Request 
    Task<FilterOnlineVisitViewModel?> FilterYourOnlineVisitRequest(FilterOnlineVisitViewModel filter);

    #endregion

    #region User Panel Side 

    //Fill Online Visit Request Detail User Panel Side DTO
    Task<OnlineVisitRequestDetailUserPanelSideDTO?> FillOnlineVisitRequestDetailUserPanelSideDTO(ulong userId, ulong Id);

    //Filter User Onlien Visit Requests 
    Task<List<FilterOnlineVisitRequestUserPanelViewModel>> FilterOnlineVisitRequestUserPanel(FilterOnlineVisitRequestUserPanelViewModel filter);

    #endregion

    #region Admin And Supporter Side 

    //Filter Online Visit Requests Admin Side 
    Task<FilterOnlineVisitAdminSideViewModel> FilterOnlineVisitRequestsAdminSide(FilterOnlineVisitAdminSideViewModel filter);

    #endregion

    #endregion

    #region Doctor Panel

    //List Of Doctor Online Visti Request For Show In ViewComponent
    Task<List<ListOfLastestOnlineVisitRequestDoctorSideViewModel>?> ListOfDoctorOnlineVistiRequestForShowInViewComponent(ulong doctorUserId);

    //Show Online Visit User Request Detail
    Task<OnlineVisitUserRequestDetailDoctorSideViewModel?> ShowOnlineVisitUserRequestDetail(ulong doctorAndPatientRequestId);

    //Get Online Visit Doctor Reservation Date By Id
    Task<OnlineVisitDoctorsReservationDate?> GetOnlineVisitDoctorReservationDateById(ulong id);

    //Save Changes
    Task Savechanges();

    //Update Doctor And Patient Record
    void UpdateDoctorAndPatientRecordWithoutSaveChanges(OnlineVisitDoctorsAndPatientsReservationDetail request);

    //Update Online Visit Request Without Save Changes 
    void UpdateOnlineVisitRequestWithoutSaveChanges(OnlineVisitUserRequestDetail request);

    //Get Doctor And Patient Request Detail By Doctor User Id And Shift Id And Shift Time Id
    Task<OnlineVisitDoctorsAndPatientsReservationDetail?> GetDoctorAndPatientRequestDetailByDoctorUserIdAndShiftIdAndShiftTimeId(ulong doctorReservationId, ulong shiftId, ulong shiftTimeId);

    //Get Online Visit Doctor Reservation Id By Business Key And Doctor User Id
    Task<OnlineVisitDoctorsReservationDate> GetOnlineVisitDoctorReservationByBusinessKeyAndDoctorUserId(ulong doctorUserId, int businessKey);

    //Fill Online Visit User Request Detail Doctor Side ViewModel
    Task<OnlineVisitUserRequestDetailDoctorSideViewModel?> FillOnlineVisitUserRequestDetailDoctorSideViewModel(ulong requestId);

    //Get Online Visit User Request Detail By Id
    Task<OnlineVisitUserRequestDetail?> GetOnlineVisitUserRequestDetailById(ulong requestId);

    //Get Online Visit User Request Detail For Show In List Of Doctors Lastest Request
    Task<ListOfLastestOnlineVisitRequestDoctorSideViewModel?> GetOnlineVisitUserRequestDetailForShowInListOfDoctorsLastestRequest(DateTime dateTime, int businessKey, ulong workShiftId , ulong workShiftTimeId);

    //Get List Of Doctor Selected Shift Ids By Doctor Reservation Id
    Task<List<ulong>> GetListOfDoctorSelectedShiftIdsByDoctorReservationId(ulong doctorReservationId);

    //Get List Of Work Shift Time Ids By Work Shift Id
    Task<List<ulong>> GetListOfWorkShiftTimeIdsByWorkShiftId(ulong workShiftId);

    //Get List Of Doctor Online Visti Reservation Id By Doctor User Id
    Task<List<OnlineVisitDoctorsReservationDate>> GetListOfDoctorOnlineVistiReservationIdByDoctorUserId(ulong doctorUserId);

    //Select List For Show List Of Avalable Shifts 
    Task<List<SelectListViewModel>> SelectListForShowListOfAvailableShifts();

    //Show List Of Available Shifts For Select
    Task<List<ListOfAvailableShiftForSelectViewModel>?> ShowListOfAvailableShiftsForSelect();

    //Add OnlineVisitDoctorsReservationDate To The Data Base 
    Task AddOnlineVisitDoctorsReservationDateToTheDataBase(OnlineVisitDoctorsReservationDate model);

    //Add OnlineVisitDoctorSelectedWorkShift Without Save Changes
    Task AddOnlineVisitDoctorSelectedWorkShiftWithoutSaveChanges(OnlineVisitDoctorSelectedWorkShift model);

    //Get List Of Work Shifts Time Detail Id By Work Shift Id
    Task<List<ulong>> GetListOfWorkShiftsTimeDetailIdByWorkShiftId(ulong workShiftId);

    //Add OnlineVisitDoctorsAndPatientsReservationDetail To The Data Base Without Save Changes
    Task AddOnlineVisitDoctorsAndPatientsReservationDetailToTheDataBaseWithoutSaveChanges(OnlineVisitDoctorsAndPatientsReservationDetail model);

    //Save Changes
    Task SaveChanges();

    //Get Validates Work Shift Dates By Doctor UserId For Show In Doctor Panel 
    Task<List<ListOfWorkShiftDatesFromDoctorPanelViewModel>> GetValidatesWorkShiftDatesByDoctorUserIdForShowInDoctorPanel(ulong doctorUserId);

    //Is Exist Any Work Shift Date For Current Doctor
    Task<bool> IsExistAnyWorkShiftDateForCurrentDoctor(ulong doctorUserId, int businessKey);

    //Fill Work Shift Date Detail Doctor Panel 
    Task<List<WorkShiftDateDetailDoctorPanelViewModel>> FillWorkShiftDateDetailDoctorPanel(ulong OnlineVisitDoctorsReservationDateId);

    //Get Work Shift Date By OnlineVisitDoctorsReservationDateId
    Task<DateTime> GetWorkShiftDateByOnlineVisitDoctorsReservationDateId(ulong OnlineVisitDoctorsReservationDateId);

    //Is Exist Any OnlineVisitDoctorsReservationDate By Doctor UserId
    Task<bool> IsExistAnyOnlineVisitDoctorsReservationDateByDoctorUserId(ulong OnlineVisitDoctorsReservationDateId, ulong doctorUserId);

    //Fill OnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel
    Task<List<OnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel>?> FillOnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel(ulong doctorReservationDateId, ulong shiftId);

    #endregion

    #region Admin Side 

    //Count Of Waiting User Request
    Task<int> CountOfWaitingUserRequests();

    //Fill List Of Work Shifts Dates Admin Side View Model
    Task<List<ListOfWorkShiftsDatesAdminSideViewModel>> FillListOfWorkShiftsDatesAdminSideViewModel();

    //Get Doctor Work Shift Reservation Id By BusinessKet That Render From Dat
    Task<List<ulong>> GetDoctorWorkShiftReservationIdByBusinessKetThatRenderFromDate(int businessKey);

    //Get Doctor Work Shift Seleceted Reservation Dates By Doctor Work Shift Reservation Ids
    Task<List<OnlineVisitWorkShift>?> GetDoctorWorkShiftSelecetedReservationDateByDoctorWorkShiftReservationId(ulong selectedReservationId);

    //Fill ListOfDoctorsInSelectedShiftAdminSideViewModel
    Task<List<ListOfDoctorsInSelectedShiftAdminSideViewModel>> FillListOfDoctorsInSelectedShiftAdminSideViewModel(ulong workShiftId, int dateBusinessKey);

    //Fill OnlineVisitDoctorAndPatientInformationsAdminPanelSideViewModel
    Task<List<OnlineVisitDoctorAndPatientInformationsAdminPanelSideViewModel>?> FillOnlineVisitDoctorAndPatientInformationsAdminPanelSideViewModel(ulong doctorReservationDateId, ulong shiftId);

    //List Of Online Visit Requests History
    Task<List<ListOfOnlineVisitRequestsAdminSideViewModel>?> ListOfOnlineVisitRequestsHistory();

    #endregion

    #region Site Side 

    //Get Online Visit Work Work Time By Id 
    Task<string?> GetOnlineVisitWorkWorkTimeById(ulong onlineVisitWorkShiftId);

    //Get Online Visit Date Time By Business Key
    Task<DateTime?> GetOnlineVisitDateTimeByBusinessKey(int businessKey);

    //List Of Work Shift Days
    Task<List<ListOfDaysForShowSiteSideViewModel>> FillListOfDaysForShowSiteSideViewModel();

    //Get List Of Docotrs Reservation Dates With Date Business Key
    Task<List<ulong>> GetListOfDocotrsReservationDatesWithDateBusinessKey(int businessKey);

    //Fill ListOfShiftSiteSideViewModel
    Task<List<ListOfShiftSiteSideViewModel>> FillListOfShiftSiteSideViewModel(ulong listOFDoctorsInThisDay, int businessKey);

    //Get String Of Start Time And End Shift Time
    string GetStringOfStartTimeAndEndShiftTime(ulong WorkShiftDateTimeId);

    //Check That Is Exist Free Shift 
    Task<int> CheckThatIsExistFreeShift(ulong WorkShiftDateTimeId, ulong WorkShiftDateId, List<ulong> doctorReservations);

    //Add User Online Visit Request To The Data Base
    Task AddUserOnlineVisitRequestToTheDataBase(OnlineVisitUserRequestDetail model);

    //Get Online Visit User Request Detail By Id And User Id
    Task<OnlineVisitUserRequestDetail?> GetOnlineVisitUserRequestDetailByIdAndUserId(ulong id, ulong userId);

    //Update Online Visit User Request Detail To Finaly
    Task UpdateOnlineVisitUserRequestDetailToFinaly(OnlineVisitUserRequestDetail model);

    //Get Online Visit Doctor Reservations By Date BusinessKey
    Task<List<OnlineVisitDoctorsReservationDate>> GetOnlineVisitDoctorReservationsByDateBusinessKey(int businessKey);

    //Get List Of Online Visit Doctors Reservation By Work Shift Id And Work Shift Time Id
    Task<List<ulong>> GetListOfOnlineVisitDoctorsReservationByWorkShiftIdAndWorkShiftTimeId(ulong workShiftId, ulong workShiftTimeId);

    //Get Doctors Id By Online Visit Doctors Reservation Id And Date Business Key
    Task<ulong?> GetDoctorsIdByOnlineVisitDoctorsReservationIdAndDateBusinessKey(ulong id, int dateBusinessKey);

    //Update Randome Record Of Reservation Doctor And Patient For Exist Request For Select
    Task UpdateRandomeRecordOfReservationDoctorAndPatientForExistRequestForSelect(List<ulong> onlineVisitDoctorReservationId, ulong shiftTimeId, ulong shiftDateId);

    #endregion
}
