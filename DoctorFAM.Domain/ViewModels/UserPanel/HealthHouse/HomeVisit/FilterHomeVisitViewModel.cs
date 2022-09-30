using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse.HomeVisit
{
    public class FilterHomeVisitViewModel : BasePaging<Request>
    {
        #region properties

        public ulong UserId { get; set; }

        #endregion
    }
}
