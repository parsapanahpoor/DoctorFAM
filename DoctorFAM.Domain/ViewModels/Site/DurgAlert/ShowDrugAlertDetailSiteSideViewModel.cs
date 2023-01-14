using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.DurgAlert
{
    public class ShowDrugAlertDetailSiteSideViewModel
    {
        #region properties

        public List<int>? Houre { get; set; }

        public DateTime? DateTime { get; set; }

        #endregion
    }
}
