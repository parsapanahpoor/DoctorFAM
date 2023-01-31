using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.Gender;
using DoctorFAM.Domain.Enums.Race;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.ASCVD
{
    public class ASCVD : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public Race Race { get; set; }

        public int TotalCholesterol  { get; set; }

        public int SystolicBloodPressure { get; set; }

        public bool TreatmentforHypertension { get; set; }

        public bool DiabetesMelitus  { get; set; }

        public bool Smoker { get; set; }

        #endregion

        #region relation



        #endregion
    }
}
