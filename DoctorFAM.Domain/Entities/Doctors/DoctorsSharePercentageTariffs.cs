using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
