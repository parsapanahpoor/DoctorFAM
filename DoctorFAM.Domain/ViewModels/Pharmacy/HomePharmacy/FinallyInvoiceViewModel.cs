using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Pharmacy.HomePharmacy
{
    public class FinallyInvoiceViewModel
    {
        #region properties

        public User Patient { get; set; }

        public User Pharmacy { get; set; }

        public List<HomePharmacyInvoiceViewModel> HomePharmacyInvoiceViewModels { get; set; }

        public Request Request { get; set; }

        #endregion
    }
}
