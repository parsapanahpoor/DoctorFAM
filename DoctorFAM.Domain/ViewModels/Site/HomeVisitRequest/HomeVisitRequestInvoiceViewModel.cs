using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.SiteSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.HomeVisitRequest
{
    public class HomeVisitRequestInvoiceViewModel
    {
        #region properties

        public ulong RequestId { get; set; }

        public PaitientRequestDetail PaitientRequestDetail { get; set; }

        public PatientRequestDateTimeDetail PatientRequestDateTimeDetail { get; set; }

        public HomeVisitRequestDetail HomeVisitRequestDetail { get; set; }

        public List<HomeVisitInvoiceTariff> TariffForHealthHouseServices { get; set; }

        public int HomeVisitTariff { get; set; }

        public int DistanceFromCityTarriff { get; set; }

        public int EmergencyVisit { get; set; }

        public int InvoiceSum { get; set; }

        public int FemalePhysician { get; set; }

        public int OverTiming { get; set; }

        #endregion
    }

    public class HomeVisitInvoiceTariff
    {
        public string Title { get; set; }

        public string Price { get; set; }
    }
}
