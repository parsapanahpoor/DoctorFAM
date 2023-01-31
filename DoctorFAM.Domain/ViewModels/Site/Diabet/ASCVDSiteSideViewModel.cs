using DoctorFAM.Domain.Enums.ASCVD;
using DoctorFAM.Domain.Enums.Gender;
using DoctorFAM.Domain.Enums.Race;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Diabet
{
    public class ASCVDSiteSideViewModel
    {
        #region properties

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public Race Race { get; set; }

        public int TotalCholesterol { get; set; }

        public int HDLCholesterol { get; set; }

        public int SystolicBloodPressure { get; set; }

        public bool TreatmentforHypertension { get; set; }

        public bool DiabetesMelitus { get; set; }

        public bool Smoker { get; set; }

        #endregion
    }

    public class AddASCVDSiteSideResult
    {
        public double Predic { get; set; }

        public ASCVDStatus ASCVDStatus { get; set; }
    }
}
