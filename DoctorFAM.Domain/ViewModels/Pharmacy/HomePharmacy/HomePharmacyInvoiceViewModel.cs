using DoctorFAM.Domain.Entities.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Pharmacy.HomePharmacy
{
    public class HomePharmacyInvoiceViewModel
    {
        #region properties

        public HomePharmacyRequestDetail HomePharmacyRequestDetail { get; set; }

        public int? Price { get; set; }

        public string? DrugNameFromPharmacy { get; set; }

        public ulong? PricingId { get; set; }

        #endregion
    }
}
