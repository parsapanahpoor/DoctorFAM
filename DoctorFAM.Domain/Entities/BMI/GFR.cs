using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.Diabet_Results;
using DoctorFAM.Domain.Enums.Gender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.BMI
{
    public class GFR : BaseEntity
    {
        #region properties

        public ulong? UserId { get; set; }

        public Gender Gender { get; set; }

        public int Weight { get; set; }

        public int Age{ get; set; }

        public int Keratenin { get; set; }

        public int GFRResult { get; set; }

        public GFRResult GFRtResultState { get; set; }


        #endregion

        #region relations

        public User User { get; set; }

        #endregion
    }
}
