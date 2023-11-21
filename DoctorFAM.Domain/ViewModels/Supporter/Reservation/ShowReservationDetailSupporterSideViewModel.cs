using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.DoctorReservation;

namespace DoctorFAM.Domain.ViewModels.Supporter.Reservation
{
    public class ShowReservationDetailSupporterSideViewModel 
    {
        #region properties

        public User? Patient { get; set; }

        public User Doctor { get; set; }

        public DoctorReservationDate DoctorReservationDate { get; set; }

        public DoctorReservationDateTime DoctorReservationDateTime { get; set; }

        public string? WorkAddress { get; set; }

        public LogForAnotherPatient? LogForAnotherPatient { get; set; }

        #endregion
    }

    public record LogForAnotherPatient
    {
        public string? FristName { get; set; }

        public string? LastName { get; set; }
    }
}
