using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Interest
{
    public class PharmacyInterests : BaseEntity
    {
        #region properties



        #endregion

        #region relation

        public ICollection<PharmacyInterestInfo> InterestInfo { get; set; }

        public ICollection<Pharmacy.PharmacySelectedInterests> PharmacySelectedInterests { get; set; }

        #endregion
    }
}
