using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Site.HomeNurseRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.DeathCertificate
{
    public class DeathCertificateRequestInvoiceViewModel
    {
        #region properties

        public ulong RequestId { get; set; }

        public PaitientRequestDetail PaitientRequestDetail { get; set; }

        public List<DeathCertificateInvoiceTariff> TariffForHealthHouseServices { get; set; }

        public int DeathCertificateTariff { get; set; }

        public int DistanceFromCityTarriff { get; set; }

        public int InvoiceSum { get; set; }

        #endregion
    }

    public class DeathCertificateInvoiceTariff
    {
        public string Title { get; set; }

        public string Price { get; set; }
    }
}
