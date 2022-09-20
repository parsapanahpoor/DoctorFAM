using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit
{
    public class FilterOnlineVisitRequestUserPanelViewModel : BasePaging<Request>
    {
        #region properties

        public ulong UserId{ get; set; }

        public FilterRequestAdminSideOrder FilterRequestAdminSideOrder { get; set; }

        public OnlineVisitRequestTypeForFilter OnlineVisitRequestTypeForFilter { get; set; }

        #endregion
    }
}
