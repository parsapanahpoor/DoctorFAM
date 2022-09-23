using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Nurse
{
    public class Nurse : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        #endregion

        #region relations 

        public User User { get; set; }

        public NurseInfo NurseInfo { get; set; }

        #endregion
    }
}
