using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Certificate
{
    public class CertificateResumeInSitePanelViewModel
    {
        #region properties

        public ulong Id { get; set; }

        [MaxLength(300)]
        public string CertificateTitle { get; set; }

        [MaxLength(300)]
        public string ExporterRefrence { get; set; }

        public string ImageName { get; set; }

        #endregion
    }
}
