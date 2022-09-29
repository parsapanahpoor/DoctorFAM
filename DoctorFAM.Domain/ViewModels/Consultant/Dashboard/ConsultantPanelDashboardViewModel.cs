using DoctorFAM.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Consultant.Dashboard
{
    public class ConsultantPanelDashboardViewModel
    {
        #region properties

        public int CountOfPupolationCovered { get; set; }

        public List<User> ListOfRequestForConsultant { get; set; }

        #endregion
    }
}
