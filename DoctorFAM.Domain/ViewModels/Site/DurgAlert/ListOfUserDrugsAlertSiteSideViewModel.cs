using DoctorFAM.Domain.Entities.DurgAlert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.DurgAlert
{
    public class ListOfUserDrugsAlertSiteSideViewModel
    {
        #region properties

        public List<DrugAlert?> DrugAlerts { get; set; }

        #endregion
    }
}
