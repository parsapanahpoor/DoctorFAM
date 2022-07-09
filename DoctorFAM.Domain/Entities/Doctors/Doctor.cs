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

        public DoctorsInfosType DoctorsInfosType { get; set; }

        public string? RejectDescription { get; set; }

        #endregion

        #region relations 

        public User User { get; set; }

        public DoctorsInfo DoctorsInfos { get; set; }

        #endregion
    }
}
