using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Enums.DoctorReservation;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace DoctorFAM.Domain.ViewModels.Supporter.Reservation
{
    public class FilterReservationSupporterSideViewModel : BasePaging<DoctorReservationDateTime>
    {
        #region properties

        public string? PatientName { get; set; }

        public string? DoctorName { get; set; }

        public string? PatientNationalNumber { get; set; }

        public string? DoctorNationalNumber { get; set; }

        public string? PatientMobile { get; set; }

        public string? DoctorMobile { get; set; }

        [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "The entered date is not valid")]
        public string? FromDate { get; set; }

        [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "The entered date is not valid")]
        public string? ToDate { get; set; }

        public FilterRequestOrder FilterRequestOrder { get; set; }

        public FilterReservationOrder FilterReservationOrder { get; set; }

        public FilterDoctorReservationState FilterDoctorReservationState { get; set; }

        public FilterDoctorReservationType FilterDoctorReservationType { get; set; }

        #endregion
    }
}
