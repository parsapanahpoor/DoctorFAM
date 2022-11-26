using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.HealthInformation
{
    public class RadioFAMCategory : BaseEntity
    {
        #region properties

        [Required]
        [MaxLength(200)]
        public string UniqueName { get; set; }

        public ulong? ParentId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        #endregion

        #region relations

        public ICollection<RadioFAMCategoryInfo> RadioFAMCategoryInfos { get; set; }

        public RadioFAMCategory Parent { get; set; }

        #endregion
    }
}
