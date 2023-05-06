using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.OnlineVisit
{
    public sealed class OnlineVisitDoctorsAndPatientsReservationDetail : BaseEntity
    {
        #region properties

        //Navigation Property
        public ulong OnlineVisitDoctorsReservationDateId { get; set; }

        //Navigation Property
        public ulong OnlineVisitWorkShiftDetail { get; set; }

        public ulong? PatientUserId { get; set; }

        //Navigation Property
        public ulong OnlineVisitWorkShiftId { get; set; }

        #endregion
    }
}
