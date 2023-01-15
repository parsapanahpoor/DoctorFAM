using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.PeriodicTestType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.PeriodicTest
{
    public class PeriodicTest : BaseEntity
    {
        #region properties

        [MaxLength(500)]
        public string Name { get; set; }

        public int DurationPerMonth { get; set; }

        public PeriodicTestType PeriodicTestType { get; set; }

        #endregion

        #region relations

        public ICollection<UserPeriodicTest> UserPeriodicTests{ get; set; }

        #endregion
    }
}
