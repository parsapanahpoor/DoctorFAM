using DoctorFAM.Domain.Entities.Common;

namespace DoctorFAM.Domain.Entities.Doctors
{
    public class DoctorsSharePercentageTariffs : BaseEntity
    {
        #region properties

        public ulong DoctorUserId { get; set; }

        public int InPersonReservationTariffForDoctorPopulationCovered { get; set; }

        public int OnlineReservationTariffForDoctorPopulationCovered { get; set; }

        public int InPersonReservationTariffForAnonymousPersons { get; set; }

        public int OnlineReservationTariffForAnonymousPersons { get; set; }

        #endregion
    }
}
