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

namespace DoctorFAM.Domain.Interfaces
{
    public interface IReservationRepository
    {
        #region Doctor Panel 

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

        #endregion

        #region Supporter Panel 

        Task<FilterReservationSupporterSideViewModel?> FilterReservationSupporterPanelViewModel(FilterReservationSupporterSideViewModel filter);

        #endregion
    }
}
