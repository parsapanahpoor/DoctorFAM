using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Interest
{
    public class BloodPressureConsultantResume : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public string? ResumePicture { get; set; }

        public string? Description { get; set; }

        #endregion

        #region relations 

        #endregion
    }
}
