using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Doctors
{
    public class DoctorsInfo : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public int NationalCode { get; set; }

        public int  MedicalSystemCode { get; set; }

        public string Education { get; set; }

        public string? Specialty { get; set; }

        public string MediacalFile { get; set; }

        public string? RejectDescription { get; set; }

        public DoctorsInfosType DoctorsInfosType { get; set; }

        #endregion

        #region Relations

        public User User { get; set; }

        #endregion
    }

    public enum DoctorsInfosType
    {
        Accepted,
        WatingForConfirm,
        Rejected
    }
}
