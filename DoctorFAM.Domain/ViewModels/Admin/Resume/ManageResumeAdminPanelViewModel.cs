using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.Admin.Resume.Certificate;
using DoctorFAM.Domain.ViewModels.Admin.Resume.Gallery;
using DoctorFAM.Domain.ViewModels.Admin.Resume.Honor;
using DoctorFAM.Domain.ViewModels.Admin.Resume.Service;
using DoctorFAM.Domain.ViewModels.Admin.Resume.WorkHistory;
using DoctorFAM.Domain.ViewModels.Admin.Resume.WorkingAddress;
using DoctorFAM.Domain.ViewModels.Admin.Resume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Resume
{
    public class ManageResumeAdminPanelViewModel
    {
        #region properties

        public Domain.Entities.Resume.Resume Resume { get; set; }

        public User User { get; set; }

        public ResumeAboutMeAdminPanelViewModel ResumeAboutMeAdminPanelViewModel { get; set; }

        public List<EducationResumeInAdminPanelViewModel>? EducationResume { get; set; }

        public List<WorkHistoryResumeInAdminPanelViewModel>? WorkHistoryResume { get; set; }

        public List<HonorResumeInAdminPanelViewModel>? HonorResume { get; set; }

        public List<ServiceResumeInAdminPanelViewModel>? ServiceResume { get; set; }

        public List<WorkingAddressResumeInAdminPanelViewModel>? WorkingAddressResume { get; set; }

        public List<CertificateResumeInAdminPanelViewModel>? CertificateResume { get; set; }

        public List<GalleryResumeInAdminPanelViewModel>? GalleryResume { get; set; }

        #endregion
    }
}
