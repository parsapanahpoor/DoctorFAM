using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.SelfAssessment
{
    public class BloodPressureSelfAssessment : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public int Systolic { get; set; }

        public int Diastolic { get; set; }

        #endregion

        #region properties



        #endregion
    }
}
