using DoctorFAM.Domain.Entities.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Pharmacy.PharmacyInfo
{
    public class PharmacyInterestsViewModel
    {
        #region properties

        public List<PharmacyInterestInfo> PharmacyInterests { get; set; }

        public List<PharmacyInterestInfo> PharmacySelectedInterests { get; set; }

        #endregion
    }
}
