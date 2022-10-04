using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse.DeathCertificate
{
    public class FilterUserDeathCertificateRequestViewModel : BasePaging<Request>
    {
        #region properties

        public ulong UserId { get; set; }

        #endregion
    }
}
