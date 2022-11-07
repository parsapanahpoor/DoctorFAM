using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.FamilyDoctor.VIPSystem
{
    public class DoctorsLabelsForVIPInsertedDoctor : BaseEntity
    {
        #region properties

        public ulong DoctorUserId { get; set; }

        public string LabelName { get; set; }

        #endregion

        #region relation 

        public ICollection<LabelOfVIPDoctorInsertedPatient> LabelOfVIPDoctorInsertedPatient { get; set; }

        #endregion
    }
}
