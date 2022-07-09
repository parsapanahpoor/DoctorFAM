using DoctorFAM.Domain.Entities.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo
{
    public class DoctorInterestsViewModel
    {
        #region properties

        public List<DoctorsInterestInfo> DoctorInterests { get; set; }

        public List<DoctorsInterestInfo> DoctorSelectedInterests { get; set; }

        #endregion
    }
}
