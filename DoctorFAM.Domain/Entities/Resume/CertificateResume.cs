using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Resume
{
    public class CertificateResume : BaseEntity
    {
        #region properties

        public ulong ResumeId { get; set; }

        [MaxLength(300)]
        public string CertificateTitle { get; set; }

        [MaxLength(300)]
        public string ExporterRefrence { get; set; }

        public string ImageName { get; set; }

        public DateTime? ValidityDate { get; set; }

        public DateTime IssueDate { get; set; }

        #endregion

        #region relation

        public Resume Resume { get; set; }

        #endregion
    }
}
