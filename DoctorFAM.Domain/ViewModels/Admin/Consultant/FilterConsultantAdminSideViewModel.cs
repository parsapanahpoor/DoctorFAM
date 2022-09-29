using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Consultant
{
    public class FilterConsultantAdminSideViewModel : BasePaging<UserSelectedConsultant>
    {
        #region properties

        public ulong? UserId { get; set; }

        public string? Username { get; set; }

        public string? UserMobile { get; set; }

        public string? NationalId { get; set; }

        public string? ConsultantUsername { get; set; }

        public string? ConsultantUserMobile { get; set; }

        public string? ConsultantNatinalId { get; set; }

        public FilterRequestAdminSideOrder FilterRequestAdminSideOrder { get; set; }

        #endregion
    }
}
