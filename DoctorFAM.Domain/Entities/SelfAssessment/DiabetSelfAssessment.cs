using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.SelfAssessment
{
    public class DiabetSelfAssessment : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public int FBS { get; set; }

        public int Twohpp { get; set; }

        public decimal A1C { get; set; }

        #endregion

        #region relations



        #endregion
    }
}
