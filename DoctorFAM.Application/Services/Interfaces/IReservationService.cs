using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.ViewModels.Admin.Reservation;
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

        //Get Doctor Reservation Date By Date 
        Task<DoctorReservationDate?> GetDoctorReservationDateByDate(DateTime date);

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

        #endregion

        #region Supporter Panel 

        Task<FilterReservationSupporterSideViewModel?> FilterReservationSupporterPanelViewModel(FilterReservationSupporterSideViewModel filter);

        Task<ShowReservationDetailSupporterSideViewModel?> FillShowReservationDetailSupporterSideViewModel(ulong reservationId);

        #endregion
    }
}
