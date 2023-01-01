using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Languages;
using DoctorFAM.Domain.Entities.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Speciality
{
    public class SpecialtiyInfo : BaseEntity
    {
        #region properties

        public string LanguageId { get; set; }

        public ulong SpecialityId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        #endregion

        #region relations

        public Language Language { get; set; }

        public Speciality Speciality { get; set; }

        #endregion
    }
}
