using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.HealthInformation
{
    public class TVFAMCategoryInfo : BaseEntity
    {
        #region properties

        public string LanguageId { get; set; }

        public ulong TVFAMCategoryId { get; set; }

        [Required]
        [MaxLength(260)]
        public string Title { get; set; }

        #endregion

        #region relation

        public Language Language { get; set; }

        public TVFAMCategory TVFAMCategory { get; set; }

        #endregion
    }
}
