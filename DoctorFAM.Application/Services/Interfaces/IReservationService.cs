using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.ViewModels.Admin.Reservation;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment;
using DoctorFAM.Domain.ViewModels.Site.Reservation;
using DoctorFAM.Domain.ViewModels.Supporter.Reservation;
using DoctorFAM.Domain.ViewModels.UserPanel.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IReservationService
    {
        #region Doctor Panel

        //List Of Doctor Reservation Date After Date Time Now
        Task<List<DoctorReservationDate>> ListOfDoctorReservationDateAfterDateTimeNow(ulong userId);

        //Add Reservation Date Time With Coputer   
        Task<bool> AddReservationDateTimeWithCoputer(AddReservationDateTimeWithComputerViewModel model, ulong userId);

        //Fill Add Reservation Date Time With Computer View Model
        Task<AddReservationDateTimeWithComputerViewModel?> FillAddReservationDateTimeWithComputerViewModel(ulong reservationDateId, ulong doctorId);

        //Add Cancel Reservation Request 
        Task<bool> CreateCancelReservationRequestFromDoctorPanel(CancelReservationRequestViewModel model, ulong userId);

        //Get List Of Reservation Dete Time By Reservation Date Id For Select List  
        Task<List<SelectListViewModel>> GetReservationDateTimeByReservationDateIdSelectList(ulong reservationDateId, ulong userId);

        //Get Doctor Reservation Date By Date 
        Task<DoctorReservationDate?> GetDoctorReservationDateByDate(DateTime date, ulong userId);

        //Get Future Doctor Reservation For Cancel Reservation Request 
        Task<List<SelectListViewModel>> GetReservationsForAddCancelRequest(ulong userId);

        Task<FilterAppointmentViewModel> FilterDoctorReservationDateSide(FilterAppointmentViewModel filter);

        //Add Reservation Date 
        Task<bool> AddReservationDate(AddReservationDateViewModel model, ulong userId);

        Task<FilterAppointmentViewModel> FiltrDoctorReservationDateHistory(FilterAppointmentViewModel filter);

        Task<List<DoctorReservationDateTime>?> GetListOfReservationDateTimesByReservationDateId(ulong reservationDateId);

        Task<FilterReservationDateTimeDoctorPAnel> FilterReservationDateTimeDoctorSide(FilterReservationDateTimeDoctorPAnel filter);

        Task<DoctorReservationDate?> GetReservationDateById(ulong reservationDateId);

        Task<bool> DeleteReservationDate(ulong reservationDateId, ulong userId);

        Task<AddReservationDateTimeViewModel?> FillAddReservationDateTime(ulong reservationDateId, ulong userId);

        Task<bool> AddReservationDateTimeDoctorPanel(AddReservationDateTimeViewModel model, ulong userId);

        Task<bool> DeleteReservationDateTime(ulong reservationDateTimeId, ulong userId);

        Task<DoctorReservationDateTime?> GetDoctorReservationDateTimeById(ulong reservationDateTimeId);

        Task<ShowPatientDetailViewModel?> ShowPatientDetailViewModel(ulong reservationDateTimeId, ulong userId);

        Task<bool> CloseReservation(ulong reservationTimeId);

        //Check Doctor Reservation Date Time Validation For Add Doctor Personal Patient (Doctor Booking)
        Task<DoctorPersonalBookingViewModel?> FillDoctorPersonalBooking(ulong reservationDateTimeId, ulong userId);

        //Get Doctor Reservation Booking By Doctor Reservation Date Time 
        Task<DoctorPersonalBooking?> GetDoctorReservationBookingByDoctorReservationDateTime(ulong doctorReservationDateTimeId);

        //Get Doctor Reservation Date Time By Include Relation With Doctor Booking
        Task<DoctorReservationDateTime?> GetDoctorReservationDateTimeByIncludeRelationWithDoctorBooking(ulong reservationDateTimeId);

        //Add Patient To Doctor Booking 
        Task<bool> AddPatientToDoctorBooking(DoctorPersonalBookingViewModel model, ulong userId);

        //Check That Is Doctor Reservation Is Doctor Personal Booking 
        Task<bool> CheckThatIsDoctorReservationIsDoctorPersonalBooking(ulong reservationId, ulong userId);

        #endregion

        #region User Panel

        Task<FilterReservationViewModel?> FilterReservationUserPanelViewModel(FilterReservationViewModel filter);

        Task<ShowReservationDetailUserSideViewModel?> FillShowReservationUserSideViewModel(ulong reservationId, ulong userId);

        Task<FilterReservationViewModel?> FilterReservationUserPanelViewComponent(FilterReservationViewModel filter);

        //This Is Filter For Reservation Date From Today 
        Task<FilterDoctorFamilyReservationDateViewModel?> FilterFamilyDoctorReservationDateFromUserPanel(FilterDoctorFamilyReservationDateViewModel filter);

        //Filter Family Doctor Reservation DateTime In UserPanel ViewModel
        Task<FilterFamilyDoctorReservationDateTimeUserPanelViewModel?> FilterFamilyDoctorReservationDateTimeUserPanel(FilterFamilyDoctorReservationDateTimeUserPanelViewModel filter);

        #endregion

        #region Admin Panel 

        Task<FilterReservationAdminSideViewModel?> FilterReservationAdminPanelViewModel(FilterReservationAdminSideViewModel filter);

        Task<ShowReservationDetailAdminSideViewModel?> FillShowReservationDetailAdminSideViewModel(ulong reservationId);

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

        Task<ShowReservationDetailSupporterSideViewModel?> FillShowReservationDetailSupporterSideViewModel(ulong reservationId);

        #endregion

        #region Site Side 

        //List Of Future Doctor Days For Reservation 
        Task<List<DoctorReservationDate>> ListOfFutureDaysOfDoctorReservation(ulong doctorUserId);

        Task<bool> ChargeUserWallet(ulong userId, int price);

        Task<bool> PayReservationTariff(ulong userId, int price);

        //Get Reservation Date By Reservation Date And User Id
        Task<DoctorReservationDate?> GetDoctorReservationDateByReservationDateAndUserId(DateTime reservationDate, ulong userId);

        //Get Reservation Date By Reservation Date And User Id
        Task<DoctorReservationDate?> GetDoctorReservationDateByReservationDateAndUserId(string reservationDate, ulong userId);

        //Get Reservation Date Time By Reservation Date And User Id
        Task<List<DoctorReservationDateTime>?> GetDoctorReservationDateByReservationDateTimeAndUserId(string loggedreservationDate, ulong userId);

        //Get Reservation Date Time To User Patient
        Task<bool> GetReservationDateTimeToUserPatient(ChooseTypeOfReservationViewModel model, ulong patientId);

        //Reserve Doctor Reservation Date Time After Success Payment
        Task ReserveDoctorReservationDateTimeAfterSuccessPayment(ulong reservationDateTimeId);

        #endregion
    }
}
