using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Nurse
{
    public class NurseInfo : BaseEntity
    {
        #region properties

        public ulong NurseId { get; set; }

        public int NationalCode { get; set; }

        public string? Education { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        #endregion

        #region Relations

        public Nurse Nurse { get; set; }

        #endregion
    }
}
