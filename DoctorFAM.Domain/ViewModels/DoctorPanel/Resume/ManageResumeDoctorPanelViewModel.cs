using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Resume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Resume
{
    public class ManageResumeDoctorPanelViewModel
    {
        #region properties

        public Domain.Entities.Resume.Resume Resume { get; set; }

        public User User { get; set; }

        public ResumeAboutMeDoctorPanelViewModel ResumeAboutMeDoctorPanelViewModel { get; set; }

        #endregion
    }
}
