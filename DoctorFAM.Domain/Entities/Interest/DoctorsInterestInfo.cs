using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Interest
{
    public class DoctorsInterestInfo : BaseEntity
    {
        #region properties

        public string LanguageId { get; set; }

        public ulong InterestId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        #endregion

        #region relations

        public Language Language { get; set; }

        public DoctorsInterest Interest { get; set; }

        #endregion
    }
}
