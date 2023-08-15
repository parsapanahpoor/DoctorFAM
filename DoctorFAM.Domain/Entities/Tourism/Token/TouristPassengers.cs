using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.Tourist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Tourism.Token
{
    public sealed class TouristPassengers : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public ulong TouristId { get; set; }

        public TouristPassengersInfoState PassengerInfoState { get; set; }

        public int RequiredAmount { get; set; }

        #endregion
    }
}
