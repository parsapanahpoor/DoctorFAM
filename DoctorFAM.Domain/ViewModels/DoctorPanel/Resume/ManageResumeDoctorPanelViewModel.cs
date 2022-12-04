using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Resume;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Certificate;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Honor;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Service;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.WorkHistory;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.WorkingAddress;
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

        public List<EducationResumeInDoctorPanelViewModel>? EducationResume { get; set; }

        public List<WorkHistoryResumeInDoctorPanelViewModel>? WorkHistoryResume { get; set; }

        public List<HonorResumeInDoctorPanelViewModel>? HonorResume { get; set; }

        public List<ServiceResumeInDoctorPanelViewModel>? ServiceResume{ get; set; }

        public List<WorkingAddressResumeInDoctorPanelViewModel>? WorkingAddressResume { get; set; }

        public List<CertificateResumeInDoctorPanelViewModel>? CertificateResume { get; set; }

        #endregion
    }
}
