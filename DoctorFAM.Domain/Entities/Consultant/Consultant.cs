using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Nurse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Consultant
{
    public class Consultant : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        #endregion

        #region relations 

        public User User { get; set; }

        public ConsultantInfo CounsultantInfo { get; set; }

        #endregion
    }
}
