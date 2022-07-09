using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.DosctorSideBarInfo
{
    public class DoctorSideBarViewModel
    {
        #region properties

        public string DoctorInfoState { get; set; }

        public bool DoctorFamily { get; set; }

        public bool HomeVisit { get; set; }

        public bool DeathCertificate { get; set; }

        public bool OnlineVisit { get; set; }

        #endregion
    }
}
