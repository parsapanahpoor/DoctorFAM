using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Speciality
{
    public class Speciality : BaseEntity
    {
        #region properties

        [MaxLength(200)]
        [Required]
        public string UniqueName { get; set; }

        public ulong? ParentId { get; set; }

        public ulong UniqueId { get; set; }

        #endregion

        #region relation 

        public Speciality Parent { get; set; }

        public ICollection<SpecialtiyInfo> SpecialtiyInfo { get; set; }

        #endregion
    }
}
