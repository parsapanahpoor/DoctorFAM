using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Doctors
{
    public class DoctorsSelectedInterests : BaseEntity
    {
        #region properties

        public ulong DoctorId { get; set; }

        public ulong InterestId { get; set; }

        #endregion

        #region relations

        public Doctor Doctor { get; set; }

        public Interest.DoctorsInterest Interest { get; set; }

        #endregion
    }

    public enum DoctorSelectedInterestResult
    {
        Success,
        Faild,
        ItemIsExist,
        ItemNotExist,
        YouMustInsertLocationAndAddress
    }
}
