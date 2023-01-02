using DoctorFAM.Domain.Entities.Common;
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

        public ulong UserId { get; set; }

        public ulong SpecialityId { get; set; }

        #endregion
    }
}
