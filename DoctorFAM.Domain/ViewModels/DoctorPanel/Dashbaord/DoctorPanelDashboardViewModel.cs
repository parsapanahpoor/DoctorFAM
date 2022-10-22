using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.FamilyDoctor.ParsaSystem;
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

        public List<UserInsertedFromParsaSystem> UserNotSendSMS { get; set; }

        public List<UserInsertedFromParsaSystem> UserSendSMS { get; set; }

        #endregion
    }
}
