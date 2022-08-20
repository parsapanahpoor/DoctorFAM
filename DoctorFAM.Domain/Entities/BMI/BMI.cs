using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.BMI
{
    public class BMI : BaseEntity
    {
        #region properties

        public ulong? UserId { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public int BMIResult { get; set; }

        #endregion

        #region relations

        public User User { get; set; }

        #endregion
    }
}
