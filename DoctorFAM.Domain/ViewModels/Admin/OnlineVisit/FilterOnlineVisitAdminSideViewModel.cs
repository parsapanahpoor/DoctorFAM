using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.OnlineVisit
{
    public class FilterOnlineVisitAdminSideViewModel : BasePaging<Request>
    {
        #region properties

        public ulong? UserId { get; set; }

        public ulong? CountryId { get; set; }

        public ulong? CityId { get; set; }

        public ulong? StateId { get; set; }

        public string? Username { get; set; }

        public string? UserMobile { get; set; }

        public string? NationalId { get; set; }

        public string? DoctorUsername { get; set; }

        public string? DoctorUserMobile { get; set; }

        public string? DoctorNatinalId { get; set; }

        public FilterRequestAdminSideOrder FilterRequestAdminSideOrder { get; set; }

        public OnlineVisitRequestTypeForFilter OnlineVisitRequestTypeForFilter { get; set; }

        #endregion
    }
}
