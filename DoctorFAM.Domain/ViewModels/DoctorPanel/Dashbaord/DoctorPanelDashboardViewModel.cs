using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Dashbaord
{
    public class DoctorPanelDashboardViewModel
    {
        #region properties

        public int CountOfPupolationCovered { get; set; }

        public List<User> ListOfRequestForFamilyDoctor { get; set; }

        #endregion
    }
}
