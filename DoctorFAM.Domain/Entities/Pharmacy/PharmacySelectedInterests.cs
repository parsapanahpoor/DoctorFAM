using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Pharmacy
{
    public class PharmacySelectedInterests : BaseEntity
    {
        #region properties

        public ulong PharmacyId { get; set; }

        public ulong InterestId { get; set; }

        #endregion

        #region relations

        public Pharmacy Pharmacy { get; set; }

        public Interest.PharmacyInterests Interest { get; set; }

        #endregion
    }
    public enum PharmacySelectedInterestResult
    {
        Success,
        Faild,
        ItemIsExist,
        ItemNotExist
    }
}
