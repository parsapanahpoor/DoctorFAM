using DoctorFAM.Domain.Entities.SiteSetting;
using DoctorFAM.Domain.Entities.States;
using System.ComponentModel.DataAnnotations;

namespace DoctorFAM.Domain.Entities.Languages
{
    public class Language
    {
        #region properties

        [Key]
        [Display(Name = "Language Name")]
        [MaxLength(200)]
        public string SystemName { get; set; }

        [Display(Name = "Title")]
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region relations

        public ICollection<LocationInfo> MyProperty { get; set; }

        #endregion
    }
}
