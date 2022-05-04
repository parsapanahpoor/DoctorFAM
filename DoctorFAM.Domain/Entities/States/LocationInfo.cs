
using DoctorFAM.Domain.Entities.States;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Languages;
using System.ComponentModel.DataAnnotations;

namespace DoctorFAM.Domain.Entities.States
{
    public class LocationInfo : BaseEntity
    {
        #region properties

        public string LanguageId { get; set; }

        public ulong LocationId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        #endregion

        #region relations

        public Language Language { get; set; }

        public Location Location { get; set; }

        #endregion
    }
}
