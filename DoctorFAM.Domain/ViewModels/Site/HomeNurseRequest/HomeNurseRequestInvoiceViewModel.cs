using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.ViewModels.Site.HomeVisitRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.HomeNurseRequest
{
    public class HomeNurseRequestInvoiceViewModel
    {
        #region properties

        public ulong RequestId { get; set; }

        public PaitientRequestDetail PaitientRequestDetail { get; set; }

        public List<HomeNurseInvoiceTariff> TariffForHealthHouseServices { get; set; }

        public PatientRequestDateTimeDetail PatientRequestDateTimeDetail { get; set; }

        public int HomeVisitTariff { get; set; }

        public int DistanceFromCityTarriff { get; set; }

        public int InvoiceSum { get; set; }

        public int OverTiming { get; set; }

        #endregion
    }

    public class HomeNurseInvoiceTariff
    {
        public string Title { get; set; }

        public string Price { get; set; }
    }
}
