using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Pharmacy
{
    public class HomePharmacyRequestDetailPrice : BaseEntity
    {
        #region properties

        public ulong HomePharmacyRequestDetailId { get; set; }

        public ulong SellerId { get; set; }

        public int Price { get; set; }

        public string? DrugNameFromPharmacy { get; set; }

        #endregion

        #region relation

        public HomePharmacyRequestDetail HomePharmacyRequestDetail { get; set; }

        [ForeignKey("SellerId")]
        public User User { get; set; }

        #endregion
    }
}
