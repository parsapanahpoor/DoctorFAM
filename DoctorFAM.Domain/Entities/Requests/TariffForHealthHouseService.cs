using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.SiteSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Requests
{
    public class RequestSelectedHealthHouseTariff : BaseEntity
    {
        #region properties

        public ulong RequestId { get; set; }

        public ulong TariffForHealthHouseServiceId { get; set; }

        #endregion

        #region relations 

        public Request Request { get; set; }

        public TariffForHealthHouseServices TariffForHealthHouseService { get; set; }

        #endregion
    }
}
