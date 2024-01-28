using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.ResumeState;

namespace DoctorFAM.Domain.Entities.Resume
{
    public class Resume : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public ResumeState ResumeState { get; set; }

        public string? RejectedNote { get; set; }

        #endregion

        #region relation

        public User User { get; set; }

        public ResumeAboutMe ResumeAboutMe { get; set; }

        public ICollection<EducationResume> EducationResumes { get; set; }

        public ICollection<WorkHistoryResume> WorkHistoryResumes { get; set; }

        public ICollection<Honors> Honors { get; set; }

        public ICollection<ServiceResume> ServiceResumes { get; set; }

        public ICollection<WorkingAddressResume> WorkingAddressResume { get; set; }

        public ICollection<CertificateResume> CertificateResume { get; set; }

        public ICollection<GalleryResume> GalleryResume { get; set; }

        #endregion
    }
}
