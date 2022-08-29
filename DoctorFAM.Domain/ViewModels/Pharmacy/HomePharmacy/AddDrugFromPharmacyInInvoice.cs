using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Pharmacy.HomePharmacy
{
    public class AddDrugFromPharmacyInInvoice
    {
        #region properties

        public ulong RequestDetailId { get; set; }

        public string DrugName { get; set; }

        public int Price { get; set; }

        #endregion
    }
}
