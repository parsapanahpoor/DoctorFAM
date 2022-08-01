using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Pharmacy
{
    public class PharmacyInfo : BaseEntity
    {
        #region properties

        public ulong PharmacyId { get; set; }

        public int NationalCode { get; set; }

        #endregion

        #region Relations

        public Pharmacy Pharmacy { get; set; }

        #endregion
    }
}
