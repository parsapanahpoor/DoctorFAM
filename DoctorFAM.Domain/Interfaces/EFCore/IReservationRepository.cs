#region Usings

using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Enums.DoctorReservation;
using DoctorFAM.Domain.ViewModels.Admin.Reservation;
using DoctorFAM.Domain.ViewModels.BackgroundTasks.Reservation;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment;
using DoctorFAM.Domain.ViewModels.Site.Reservation;
using DoctorFAM.Domain.ViewModels.Supporter.Reservation;
using DoctorFAM.Domain.ViewModels.UserPanel.Reservation;
using Microsoft.EntityFrameworkCore;

#endregion

namespace DoctorFAM.Domain.Interfaces;

public interface IReservationRepository
{
    #region Doctor Panel 

    Task<List<SendSMSForReminderToReservationDTO>> SendSMSForReminderToReservation();

    Task<ListOfAppointmentsReceivedJoinDoctorSideDTO?> ListOfAppointmentsReceived(ListOfAppointmentsReceivedJoinDoctorSideDTO filter);

    //List Of People Who Have Visited
    Task<ListOfPeopleWhoHaveVisitedDoctorSideDTO?> ListOfPeopleWhoHaveVisited(ListOfPeopleWhoHaveVisitedDoctorSideDTO filter);

    //List Of Doctor Reservation Date After Date Time Now In Dentist Panel
    Task<List<DoctorReservationDate>> ListOfDoctorReservationDateAfterDateTimeNowInDentistPanel(ulong userId);

    //List Of Doctor Reservation Date After Date Time Now
    Task<List<DoctorReservationDate>> ListOfDoctorReservationDateAfterDateTimeNow(ulong userId);

    //Cancel Reservation Date Time State 
    Task CancelReservationDateTime(DoctorReservationDateTime reservationDateTime);

    //Save Changes
    Task Savechanges();

    //Add Reservation Date Cancelation
    Task AddReservationDateCancelation(ReservationDateCancelation date);

    //Add Reservation Date Time Cancelation 
    Task AddReservationDateTimeCancelation(ReservationDateTimeCancelation dateTime);

    //Get List Of Reservation Dete Time By Reservation Date Id For Select List  
    Task<List<SelectListViewModel>> GetReservationDateTimeByReservationDateIdSelectList(ulong reservationDateId, ulong userId);

    //Get Future Doctor Reservation For Cancel Reservation Request To List
    Task<List<DoctorReservationDate>> GetReservationsForAddCancelRequest(ulong userId);

    //Get Doctor Reservation Date By Date 
    Task<DoctorReservationDate?> GetDoctorReservationDateByDate(DateTime date, ulong userId);

    //In Add Reservation Date Check Date In Not Duplicate
    Task<bool> IsExistAnyDuplicateReservationDate(DateTime date, ulong userId);

    //This Is Filter For Reservation Date From Today 
    Task<List<DoctorReservationDate>?> FilterDoctorReservationDateSideWithoutPaging(FilterAppointmentViewModelWithoutPaging filter);

    Task<FilterAppointmentViewModel> FilterDoctorReservationDateSide(FilterAppointmentViewModel filter);

    //This Is Filter For Reservation Date From Today By Dentist Panel
    Task<FilterAppointmentViewModel?> FilterDoctorReservationDateSideByDentistPanel(FilterAppointmentViewModel filter);

    //This Is History Of All Records That In Reservation Date By User Id ByDentistPanel 
    Task<FilterAppointmentViewModel?> FiltrDoctorReservationDateHistoryByDentistPanel(FilterAppointmentViewModel filter);

    Task AddDoctorReservationDate(DoctorReservationDate doctorReservationDate);

    Task<FilterAppointmentViewModel> FiltrDoctorReservationDateHistory(FilterAppointmentViewModel filter);

    Task<List<DoctorReservationDateTime>?> GetListOfReservationDateTimesByReservationDateId(ulong reservationDateId);

    Task<FilterReservationDateTimeDoctorPAnel> FilterReservationDateTimeDoctorSide(FilterReservationDateTimeDoctorPAnel filter);

    //Filter Reservation Date Time Dentist Side
    Task<FilterReservationDateTimeDoctorPAnel?> FilterReservationDateTimeDentistSide(FilterReservationDateTimeDoctorPAnel filter);

    Task<DoctorReservationDate?> GetReservationDateByIdWithAsNoTracking(ulong reservationDateId);

    Task<DoctorReservationDate?> GetReservationDateById(ulong reservationDateId);

    Task UpdateReservationDate(DoctorReservationDate date);

    Task AddReservationDateTime(DoctorReservationDateTime dateTime);

    //Add Reservation Date Time With Return Id
    Task<ulong> AddReservationDateTimeWithReturnId(DoctorReservationDateTime dateTime);

    Task<DoctorReservationDateTime?> GetDoctorReservationDateTimeById(ulong reservationDateTimeId);

    //Get Doctor Reservation Date Time By Include Relation With Doctor Booking
    Task<DoctorReservationDateTime?> GetDoctorReservationDateTimeByIncludeRelationWithDoctorBooking(ulong reservationDateTimeId);

    Task UpdateReservationDateTime(DoctorReservationDateTime reservationDateTime);

    //Add Doctor Personal Booking 
    Task AddDoctorPersonalBooking(DoctorPersonalBooking booking);

    //Get Doctor Reservation Booking By Doctor Reservation Date Time 
    Task<DoctorPersonalBooking?> GetDoctorReservationBookingByDoctorReservationDateTime(ulong doctorReservationDateTimeId);

    #endregion

    #region User Panel 

    Task<FilterReservationViewModel?> FilterReservationUserPanelViewModel(FilterReservationViewModel filter);

    Task<FilterReservationViewModel?> FilterReservationUserPanelViewComponent(FilterReservationViewModel filter);

    //This Is Filter For Reservation Date From Today 
    Task<FilterDoctorFamilyReservationDateViewModel?> FilterFamilyDoctorReservationDateFromUserPanel(FilterDoctorFamilyReservationDateViewModel filter);

    //Filter Family Doctor Reservation DateTime In UserPanel ViewModel
    Task<FilterFamilyDoctorReservationDateTimeUserPanelViewModel?> FilterFamilyDoctorReservationDateTimeUserPanel(FilterFamilyDoctorReservationDateTimeUserPanelViewModel filter);

    #endregion

    #region Admin Panel 

    Task<DoctorFAM.Domain.ViewModels.Admin.Reservation.LogForAnotherPatient?> FillLogForAnotherPatient(ulong reservationId, ulong patientId);

    Task<FilterReservationAdminSideViewModel?> FilterReservationAdminPanelViewModel(FilterReservationAdminSideViewModel filter);

    Task AddLogForCloseReservation(LogForCloseReservation log);

    Task<FilterClosedReservationAdminViewModel?> FilterClosedReservationAdminPanelViewModel(FilterClosedReservationAdminViewModel filter);

    //List Of Request For Cancelation Reservation
    Task<FilterCancelReservationRequestsViewModel?> FilterCancelReservationRequestsViewModel(FilterCancelReservationRequestsViewModel filter);

    //List Of Request For Cancelation Reservatio Date Time 
    Task<FilterCancelationRequestReservationDateTimeViewModel?> FilterCancelationRequestReservationDateTime(FilterCancelationRequestReservationDateTimeViewModel filter);

    //List Of Doctor Personal Booking
    Task<List<DoctorPersonalBooking>> ListOfDoctorPersonalBooking();

    #endregion

    #region Supporter Panel 

    Task<LogForAnotherPatientUserSide?> FillLogForAnotherPatientUserSide(ulong reservationId, ulong patientId);

    Task<DoctorFAM.Domain.ViewModels.Supporter.Reservation.LogForAnotherPatient?> FillLogForAnotherPatientSupporterSide(ulong reservationId, ulong patientId);

    Task<FilterReservationSupporterSideViewModel?> FilterReservationSupporterPanelViewModel(FilterReservationSupporterSideViewModel filter);

    //Fill ListOfSelectedReservationsSupporterSideDTO
    Task<List<ListOfSelectedReservationsSupporterSideDTO>?> FillListOfSelectedReservationsSupporterSideDTO();

    Task<FilterWaitingForReservationRequestsSupporterSideViewModel?> FilterListOfWaitingForPaymentRequests(FilterWaitingForReservationRequestsSupporterSideViewModel filter);

    //Get Log For Waiting for Reservation Request By Id 
    Task<LogForDoctorReservationDateTimeWaitingForPayment?> GetLogForWaitingforReservationRequestById(ulong id);

    //Update Log For Waiting for Reservation Request By Id 
    void UpdateLogForWaitingforReservationRequestById(LogForDoctorReservationDateTimeWaitingForPayment model);

    //Add Comment For Log of Waiting For Payment Request Reservation 
    Task AddCommentForLogofWaitingForPaymentRequestReservation(LogForDoctorReservationDateTimeWaitingForPaymentComment comment);

    //Fill List Of Comments For Waiting For Payment Reservation Request Supporter Side DTO
    Task<List<ListOfCommentsForWaitingForPaymentReservationRequestSupporterSideDTO>?> FillListOfCommentsForWaitingForPaymentReservationRequestSupporterSideDTO(ulong id);

    //Add Comment For Waiting For Payment Reservation Request 
    Task AddCommentForWaitingForPaymentReservationRequest(LogForDoctorReservationDateTimeWaitingForPaymentComment comment);

    #endregion

    #region Site Side

    //Is Exist Any Waiting For Payment Reservation Request By User Id
    Task<ulong?> IsExistAnyWaitingForPaymentReservationRequestByUserId(ulong userId);

    //Get And Delete Another Patient 
    Task GetAndDeleteAnotherPatient(ulong reservationDateTimeId, ulong userId);

    //Remove Log For Reservation Date Times In Waiting For Payment State
    void RemoveLogForReservationDateTimesInWaitingForPaymentState(LogForDoctorReservationDateTimeWaitingForPayment model);

    //Get Log For Reservation Date Times In Waiting For Payment State
    Task<LogForDoctorReservationDateTimeWaitingForPayment?> GetLogForReservationDateTimesInWaitingForPaymentState(ulong doctorReservationDateTimeId, ulong userId);

    //Update Log For Reservation Date Times In Waiting For Payment State
    void UpdateLogForReservationDateTimesInWaitingForPaymentState(LogForDoctorReservationDateTimeWaitingForPayment model);

    //Log For Reservation Date Times In Waiting For Payment State
    Task LogForReservationDateTimesInWaitingForPaymentState(LogForDoctorReservationDateTimeWaitingForPayment model);

    //Get Doctor Reservation Alert By Doctor User Id
    Task<string?> GetDoctorReservationAlertByDoctorUserId(ulong userId);

    //Get List Of Reservation Request That Pass A Day For Pay Reservation Tariff
    Task GetListOfReservationRequestThatPassADayForPayReservationTariff();

    //Get List Of Doctor Reservation Date And Doctor Reservation Date Time For Show Site Side 
    Task<List<ListOfReservationDateAndReservationDateTimeViewModel>?> GetListOfDoctorReservationDateAndDoctorReservationDateTimeForShowSiteSide(ulong doctorUserId);

    //List Of Future Days Of Doctor Reservation 
    Task<List<DoctorReservationDate>> ListOfFutureDaysOfDoctorReservation(ulong doctorUserId);

    //Get Reservation Date By Reservation Date And User Id
    Task<DoctorReservationDate?> GetDoctorReservationDateByReservationDateAndUserId(DateTime reservationDate, ulong userId);

    //Get List Of Doctor Reservation Date Time By Reservation Date Id
    Task<List<DoctorReservationDateTime>?> GetListOfDoctorReservationDateTimeByReservationDateId(ulong reservationDateId);

    //Get Doctor Reservation Date Time Doctor Selected Reservation Type
    Task<DoctorReservationType> GetDoctorReservationDateTimeDoctorSelectedReservationType(ulong doctorReservationDateTimeId);

    //Get Patient User Informations For Get Reservation Time From Doctors
    Task<UserInfoForGetReservation?> GetPatientUserInformationsForGetReservationTimeFromDoctors(ulong userId);

    #endregion
}
