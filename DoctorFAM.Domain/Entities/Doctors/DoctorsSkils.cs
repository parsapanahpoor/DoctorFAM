using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.Entities.Doctors
{
    public class DoctorsSkils : BaseEntity
    {
        #region properties

        public ulong DoctorId { get; set; }

        [MaxLength(400)]
        public string DoctorSkil { get; set; }

        #endregion

        #region relation

        public Doctor Doctor { get; set; }

        #endregion
    }
}
