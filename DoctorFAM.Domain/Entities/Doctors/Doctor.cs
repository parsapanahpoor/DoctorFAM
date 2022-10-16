using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Doctors
{
    public class Doctor : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        #endregion

        #region relations 

        public User User { get; set; }

        public DoctorsInfo DoctorsInfos { get; set; }

        public ICollection<DoctorsSkils> DoctorsSkils { get; set; }

        #endregion
    }
}
