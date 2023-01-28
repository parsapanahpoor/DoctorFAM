using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Diabet
{
    public class SelfAssessmentSiteSideViewModel
    {
        #region properties

        public int FBS { get; set; }

        public int Twohpp { get; set; }

        public decimal A1C { get; set; }

        #endregion
    }
}
