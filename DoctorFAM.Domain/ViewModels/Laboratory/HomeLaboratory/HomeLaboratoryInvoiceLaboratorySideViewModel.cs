using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Entities.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Laboratory.HomeLaboratory
{
    public class HomeLaboratoryInvoiceLaboratorySideViewModel
    {
        #region properties

        public HomeLaboratoryRequestDetail HomeLaboratoryRequestDetail { get; set; }

        public int? Price { get; set; }

        public string? DrugNameFromPharmacy { get; set; }

        public ulong? PricingId { get; set; }

        #endregion
    }
}
