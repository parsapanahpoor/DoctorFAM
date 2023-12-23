using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.HealtInformation;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorFAM.Domain.Entities.HealthInformation
{
    public class HealthInformation : BaseEntity
    {
        #region properties

        public ulong? OwnerId { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string longDescription { get; set; }

        public HealthInformationType HealthInformationType { get; set; }

        public string File { get; set; }

        public string? Picture { get; set; }

        public bool ShowInSite { get; set; }

        public bool ShowInDoctorPanel { get; set; }

        public HealtInformationFileState HealtInformationFileState { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool ShowInfinity { get; set; }

        public string? RejectNote { get; set; }

        public bool Lastest { get; set; }

        public bool ShowInLanding { get; set; }

        #endregion

        #region relations

        [ForeignKey("OwnerId")]
        public User User { get; set; }

        public ICollection<HealthInformationTag> HealthInformationTags { get; set; }

        public ICollection<RadioFAMSelectedCategory> RadioFAMSelectedCategory { get; set; }

        public ICollection<TVFAMSelectedCategory> TVFAMSelectedCategory { get; set; }

        #endregion
    }
}
