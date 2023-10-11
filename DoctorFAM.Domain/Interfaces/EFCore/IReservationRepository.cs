#region Usings

using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Enums.DoctorReservation;
using DoctorFAM.Domain.ViewModels.Admin.Reservation;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment;
using DoctorFAM.Domain.ViewModels.Site.Reservation;
using DoctorFAM.Domain.ViewModels.Supporter.Reservation;
using DoctorFAM.Domain.ViewModels.UserPanel.Reservation;

#endregion

namespace DoctorFAM.Domain.Interfaces;

public interface IReservationRepository
{
    #region Doctor Panel 

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

    Task<FilterReservationSupporterSideViewModel?> FilterReservationSupporterPanelViewModel(FilterReservationSupporterSideViewModel filter);

    #endregion

    #region Site Side

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
