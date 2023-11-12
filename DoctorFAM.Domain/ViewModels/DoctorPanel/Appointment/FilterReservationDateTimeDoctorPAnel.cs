using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Enums.DoctorReservation;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment
{
    public class FilterReservationDateTimeDoctorPAnel 
    {
        #region properties

        public ulong UserId { get; set; }

        public ulong ReservationDateId { get; set; }

        public List<DoctorReservationDateTimeDoctorSideViewModel> DoctorReservationDateTimes { get; set; }

        #endregion
    }

    public class DoctorReservationDateTimeDoctorSideViewModel
    {
        public ulong Id { get; set; }

        public ulong? PatientId { get; set; }

        public DoctorReservationState DoctorReservationState { get; set; }

        public DoctorReservationType? DoctorReservationType { get; set; }

        public DoctorReservationType? SelectedDoctorReservationType { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public bool DoctorBooking { get; set; }

        public DoctorReservationDateTimePatientDetailDoctorSideViewModel? PatientDetail { get; set; }

        public LogForGetAppoinmentForOtherPeopleDoctorPanelSide? LogForGetAppoinmentForOtherPeople { get; set; }
    }

    public class DoctorReservationDateTimePatientDetailDoctorSideViewModel
    {
        public string PatientUsername { get; set; }

        public string PatientMobile { get; set; }

        public ulong? PatientUserId { get; set; }
    }

    public class LogForGetAppoinmentForOtherPeopleDoctorPanelSide
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
