using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Enums.DoctorReservation;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.UserPanel.Reservation
{
    public class FilterReservationViewModel : BasePaging<DoctorReservationDateTime>
    {
        #region properties

        public ulong UserId { get; set; }

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
