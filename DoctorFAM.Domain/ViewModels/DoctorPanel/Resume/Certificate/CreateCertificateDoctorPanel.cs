using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Certificate
{
    public class CreateCertificateDoctorPanel
    {
        #region properties

        [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string CertificateTitle { get; set; }

        [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string ExporterRefrence { get; set; }

        public string? ValidityDate { get; set; }

        public string IssueDate { get; set; }

        #endregion
    }
}
