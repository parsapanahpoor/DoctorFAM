using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Drugs
{
    public class Insulin : BaseEntity
    {
        #region properties

        public string InsulinName { get; set; }

        public bool LongEffect { get; set; }

        public bool ShortEffect { get; set; }

        #endregion

        #region relations

        #endregion
    }
}
