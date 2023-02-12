using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Insurance
{
    public class Insurance: BaseEntity
    {
        #region properties

        public string Title { get; set; }

        #endregion

        #region properties

        public ICollection<Patient.Patient> Patients { get; set; }

        public ICollection<PopulationCovered.PopulationCovered> PopulationCovered { get; set; }

        #endregion
    }
}
