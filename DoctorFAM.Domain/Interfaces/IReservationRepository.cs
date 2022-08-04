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

namespace DoctorFAM.Domain.Interfaces
{
    public interface IReservationRepository
    {
        #region Doctor Panel 

        //Cancel Reservation Date Time State 
        Task CancelReservationDateTime(DoctorReservationDateTime reservationDateTime);

        //Save Changes
        Task Savechanges();

        //Add Cancel Reservation Request To Data Base Without Save Changes
        Task AddCancelReservationRequest(CancelReservationRequest cancel);

        //Get List Of Reservation Dete Time By Reservation Date Id For Select List  
        Task<List<SelectListViewModel>> GetReservationDateTimeByReservationDateIdSelectList(ulong reservationDateId, ulong userId);

        //Get Future Doctor Reservation For Cancel Reservation Request To List
        Task<List<DoctorReservationDate>> GetReservationsForAddCancelRequest(ulong userId);

        //Get Doctor Reservation Date By Date 
        Task<DoctorReservationDate?> GetDoctorReservationDateByDate(DateTime date , ulong userId);

        //In Add Reservation Date Check Date In Not Duplicate
        Task<bool> IsExistAnyDuplicateReservationDate(DateTime date , ulong userId);

        Task<FilterAppointmentViewModel> FilterDoctorReservationDateSide(FilterAppointmentViewModel filter);

        Task AddDoctorReservationDate(DoctorReservationDate doctorReservationDate);

        Task<FilterAppointmentViewModel> FiltrDoctorReservationDateHistory(FilterAppointmentViewModel filter);

        Task<List<DoctorReservationDateTime>?> GetListOfReservationDateTimesByReservationDateId(ulong reservationDateId);

        Task<FilterReservationDateTimeDoctorPAnel> FilterReservationDateTimeDoctorSide(FilterReservationDateTimeDoctorPAnel filter);

        Task<DoctorReservationDate?> GetReservationDateById(ulong reservationDateId);

        Task UpdateReservationDate(DoctorReservationDate date);

        Task AddReservationDateTime(DoctorReservationDateTime dateTime);

        Task<DoctorReservationDateTime?> GetDoctorReservationDateTimeById(ulong reservationDateTimeId);

        Task UpdateReservationDateTime(DoctorReservationDateTime reservationDateTime);

        #endregion

        #region User Panel 

        Task<FilterReservationViewModel?> FilterReservationUserPanelViewModel(FilterReservationViewModel filter);

        Task<FilterReservationViewModel?> FilterReservationUserPanelViewComponent(FilterReservationViewModel filter);

        #endregion

        #region Admin Panel 

        Task<FilterReservationAdminSideViewModel?> FilterReservationAdminPanelViewModel(FilterReservationAdminSideViewModel filter);

        Task AddLogForCloseReservation(LogForCloseReservation log);

        Task<FilterClosedReservationAdminViewModel?> FilterClosedReservationAdminPanelViewModel(FilterClosedReservationAdminViewModel filter);

        #endregion

        #region Supporter Panel 

        Task<FilterReservationSupporterSideViewModel?> FilterReservationSupporterPanelViewModel(FilterReservationSupporterSideViewModel filter);

        #endregion
    }
}
