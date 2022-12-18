using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Resume.Certificate
{
    public class CertificateResumeInAdminPanelViewModel
    {
        #region properties

        public ulong Id { get; set; }

        [MaxLength(300)]
        public string CertificateTitle { get; set; }

        [MaxLength(300)]
        public string ExporterRefrence { get; set; }

        public string ImageName { get; set; }

        public string? ValidityDate { get; set; }

        public string IssueDate { get; set; }

        #endregion
    }
}
