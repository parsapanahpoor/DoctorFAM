#region Usings

using DoctorFAM.Domain.Entities.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Admin.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Site.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit;

#endregion

namespace DoctorFAM.Application.Services.Interfaces;

public interface IOnlineVisitService
{
    #region Old Version 

    #region Site Side 

    //Create Online Visit Request
    Task<ulong?> CreateOnlineVisitRequest(ulong userId);

    //Validation For Create Patient 
    Task<CreatePatientResult> ValidateCreatePatient(PatientDetailForOnlineVisitViewModel model);

    Task<ulong> CreatePatientDetail(PatientDetailForOnlineVisitViewModel patient);

    //Add Online Vist Request 
    Task<bool> AddOnlineVisitRequest(OnlineVisitRquestDetailViewModel onlineVisitRquest, ulong userId);

    Task<bool> ChargeUserWallet(ulong userId, int price , ulong requestId);

    Task<bool> PayOnlineVisitTariff(ulong userId, int price , ulong requestId);

    //Get List Of Online Visit For Send Notification For Online Visit Notification 
    Task<List<string?>> GetListOfDoctorsForArrivalsOnlineVisitRequests();

    //Filter Online Visit Requests 
    Task<FilterOnlineVisitViewModel> FilterOnlineVisitRequests(FilterOnlineVisitViewModel filter);

    #endregion

    #region Doctor Side Panel 

    //Show Online Visit Request Detail Doctor Panel Side View Model 
    Task<OnlineVisitRequestDetailViewModel?> FillOnlineVisitRequestDetailDoctorPanelViewModel(ulong requestId);

    //Confirm Online Visit Request From Doctor 
    Task<bool> ConfirmOnlineVisitRequestFromDoctor(ulong requestId, ulong userId);

    //Filter Your Online Visit Request 
    Task<FilterOnlineVisitViewModel?> FilterYourOnlineVisitRequest(FilterOnlineVisitViewModel filter);

    #endregion

    #region User Panel 

    //Filter User Onlien Visit Requests 
    Task<FilterOnlineVisitRequestUserPanelViewModel> FilterOnlineVisitRequestUserPanel(FilterOnlineVisitRequestUserPanelViewModel filter);

    #endregion

    #region Admin And Supporter Side 

    //Filter Online Visit Requests Admin Side 
    Task<FilterOnlineVisitAdminSideViewModel> FilterOnlineVisitRequestsAdminSide(FilterOnlineVisitAdminSideViewModel filter);

    //Show Online Visit Request Detail Admin Panel Side View Model 
    Task<OnlineVisitRequestDetailAdminSideViewModel?> FillOnlineVisitRequestDetailAdminPanelViewModel(ulong requestId);

    #endregion

    #endregion

    #region Doctor Panel 

    //Show Online Visit User Request Detail
    Task<OnlineVisitUserRequestDetailDoctorSideViewModel?> ShowOnlineVisitUserRequestDetail(ulong doctorAndPatientRequestId, ulong memberUserId);

    //Confirm Online Visit Request From Doctor
    Task<bool> ConfirmOnlineVisitRequestFromDoctor(ulong requestId, ulong doctorMemberId, int businessKey);

    //Fill Show Online Visit Request Detail View Model
    Task<OnlineVisitUserRequestDetailDoctorSideViewModel?> FillShowOnlineVisitRequestDetail(ulong onlineVisitRequestId);

    //List Of Lastest Online Visit Request Doctor Side View Model
    Task<List<ListOfLastestOnlineVisitRequestDoctorSideViewModel>?> ListOfLastestOnlineVisitRequestDoctorSideViewModel(ulong memberUserId);

    //Select List For Show List Of Avalable Shifts 
    Task<List<SelectListViewModel>> SelectListForShowListOfAvailableShifts();

    //Show List Of Available Shifts For Select
    Task<List<ListOfAvailableShiftForSelectViewModel>?> ShowListOfAvailableShiftsForSelect();

    //Create Doctor Selected Online Visit Shift Date From Doctor Panel
    Task<CreateDoctorSelectedOnlineVisitShiftDateViewModelResult> CreateDoctorSelectedOnlineVisitShiftDateFromDoctorPanel(CreateDoctorSelectedOnlineVisitShiftDateViewModel model, ulong memberUserId);

    //List Of Work Shift Dates From Doctor Panel 
    Task<List<ListOfWorkShiftDatesFromDoctorPanelViewModel>?> FillListOfWorkShiftDatesFromDoctorPanelViewModel(ulong memberUserId);

    //Fill Work Shift Date Detail Doctor Panel 
    Task<List<WorkShiftDateDetailDoctorPanelViewModel>> FillWorkShiftDateDetailDoctorPanel(ulong OnlineVisitDoctorsReservationDateId ,ulong memberUserId);

    //Get Work Shift Date By OnlineVisitDoctorsReservationDateId
    Task<DateTime> GetWorkShiftDateByOnlineVisitDoctorsReservationDateId(ulong OnlineVisitDoctorsReservationDateId);

    //Fill OnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel
    Task<List<OnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel>?> FillOnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel(ulong doctorReservationDateId, ulong shiftId, ulong memberId);

    #endregion

    #region Admin Side 

    //Fill List Of Work Shifts Dates Admin Side View Model
    Task<List<ListOfWorkShiftsDatesAdminSideViewModel>> FillListOfWorkShiftsDatesAdminSideViewModel();

    //Fill ListOfWorkShiftDayDetailViewModel 
    Task<List<ListOfWorkShiftDayDetailViewModel>?> FillListOfWorkShiftDayDetailViewModel(int businessKey);

    //Fill ListOfDoctorsInSelectedShiftAdminSideViewModel
    Task<List<ListOfDoctorsInSelectedShiftAdminSideViewModel>> FillListOfDoctorsInSelectedShiftAdminSideViewModel(ulong workShiftId, int dateBusinessKey);

    //Fill OnlineVisitDoctorAndPatientInformationsAdminPanelSideViewModel
    Task<List<OnlineVisitDoctorAndPatientInformationsAdminPanelSideViewModel>?> FillOnlineVisitDoctorAndPatientInformationsAdminPanelSideViewModel(ulong doctorReservationDateId, ulong shiftId);

    #endregion

    #region Site Side 

    //List Of Work Shift Days
    Task<List<ListOfDaysForShowSiteSideViewModel>> FillListOfDaysForShowSiteSideViewModel();

    //Fill ListOfShiftSiteSideViewModel
    Task<List<ListOfShiftSiteSideViewModel>> FillListOfShiftSiteSideViewModel(int businessKey);

    //Select Shift And Redirect To Bank
    Task<SelectShiftAndRedirectToBankResult> SelectShiftAndRedirectToBank(SelectShiftAndRedirectToBankDTO model);

    // Add User Online Visit Request To The Data Base 
    Task<ulong> AddUserOnlineVisitRequestToTheDataBase(SelectShiftAndRedirectToBankDTO model);

    //Get Online Visit User Request Detail By Id And User Id
    Task<OnlineVisitUserRequestDetail?> GetOnlineVisitUserRequestDetailByIdAndUserId(ulong id, ulong userId);

    //Update Online Visit User Request Detail To Finaly
    Task UpdateOnlineVisitUserRequestDetailToFinaly(ulong id, ulong userId);

    //Pay Online Visit Tariff
    Task<bool> PayOnlineVisitTariff(ulong userId, int price, ulong? requestId);

    //Get List Of Doctor For Send Them Notification By Online Visit 
    Task<List<string>> GetListOfDoctorForSendThemNotificationByOnlineVisit(int businessKey, ulong workshiftId, ulong workShiftTimeId);

    //Update Randome Record Of Reservation Doctor And Patient For Exist Request For Select
    Task UpdateRandomeRecordOfReservationDoctorAndPatientForExistRequestForSelect(int businessKey, ulong workShiftId, ulong workShiftTimeId);

    #endregion
}
