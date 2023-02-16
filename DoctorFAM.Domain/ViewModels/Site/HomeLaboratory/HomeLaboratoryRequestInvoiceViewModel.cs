using DoctorFAM.Domain.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.HomeLaboratory
{
    public class HomeLaboratoryRequestInvoiceViewModel
    {
        #region properties

        public ulong RequestId { get; set; }

        public PaitientRequestDetail PaitientRequestDetail { get; set; }

        public PatientRequestDateTimeDetail PatientRequestDateTimeDetail { get; set; }

        public int HomeLaboratoryTariff { get; set; }

        public int InvoiceSum { get; set; }

        #endregion
    }

}
