using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.ViewModels.Admin.Reservation;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment;
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

        //Add Cancel Reservation Request 
        Task<bool> CreateCancelReservationRequestFromDoctorPanel(CancelReservationRequestViewModel model, ulong userId);

        //Get List Of Reservation Dete Time By Reservation Date Id For Select List  
        Task<List<SelectListViewModel>> GetReservationDateTimeByReservationDateIdSelectList(ulong reservationDateId, ulong userId);

        //Get Doctor Reservation Date By Date 
        Task<DoctorReservationDate?> GetDoctorReservationDateByDate(DateTime date , ulong userId);

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

        #endregion

        #region User Panel

        Task<FilterReservationViewModel?> FilterReservationUserPanelViewModel(FilterReservationViewModel filter);

        Task<ShowReservationDetailUserSideViewModel?> FillShowReservationUserSideViewModel(ulong reservationId, ulong userId);

        Task<FilterReservationViewModel?> FilterReservationUserPanelViewComponent(FilterReservationViewModel filter);

        #endregion

        #region Admin Panel 

        Task<FilterReservationAdminSideViewModel?> FilterReservationAdminPanelViewModel(FilterReservationAdminSideViewModel filter);

        Task<ShowReservationDetailAdminSideViewModel?> FillShowReservationDetailAdminSideViewModel(ulong reservationId);

        Task<FilterClosedReservationAdminViewModel?> FilterClosedReservationAdminPanelViewModel(FilterClosedReservationAdminViewModel filter);

        //List Of Request For Cancelation Reservation
        Task<FilterCancelReservationRequestsViewModel?> FilterCancelReservationRequestsViewModel(FilterCancelReservationRequestsViewModel filter);

        //List Of Request For Cancelation Reservatio Date Time 
        Task<FilterCancelationRequestReservationDateTimeViewModel?> FilterCancelationRequestReservationDateTime(FilterCancelationRequestReservationDateTimeViewModel filter);

        #endregion

        #region Supporter Panel 

        Task<FilterReservationSupporterSideViewModel?> FilterReservationSupporterPanelViewModel(FilterReservationSupporterSideViewModel filter);

        Task<ShowReservationDetailSupporterSideViewModel?> FillShowReservationDetailSupporterSideViewModel(ulong reservationId);

        #endregion

        #region Site Side 

        //Get Reservation Date By Reservation Date And User Id
        Task<DoctorReservationDate?> GetDoctorReservationDateByReservationDateAndUserId(DateTime reservationDate, ulong userId);

        //Get Reservation Date By Reservation Date And User Id
        Task<DoctorReservationDate?> GetDoctorReservationDateByReservationDateAndUserId(string reservationDate, ulong userId);

        //Get Reservation Date Time By Reservation Date And User Id
        Task<List<DoctorReservationDateTime>?> GetDoctorReservationDateByReservationDateTimeAndUserId(string loggedreservationDate, ulong userId);

        #endregion
    }
}
