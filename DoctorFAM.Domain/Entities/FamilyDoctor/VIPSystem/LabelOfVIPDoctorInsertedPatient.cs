using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.FamilyDoctor.VIPSystem
{
    public class LabelOfVIPDoctorInsertedPatient : BaseEntity
    {
        #region properties

        public ulong VIPUserInsertedFromDoctorSystemId { get; set; }

        public string LabelOfSickness { get; set; }

        #endregion
    }
}
