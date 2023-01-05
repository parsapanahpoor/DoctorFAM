using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Speciality
{
    public class DoctorSelectedSpeciality : BaseEntity
    {
        #region properties

        public ulong DoctorId { get; set; }

        public ulong SpecialityId { get; set; }

        #endregion

        #region relations

        public Doctor Doctor { get; set; }

        #endregion
    }
}
