using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.OnlineVisit;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.HomeVisit
{
    public class HomeVisitRequestDetailViewModel
    {
        #region properties

        public Request Request { get; set; }

        public PaitientRequestDetail PatientRequestDetail { get; set; }

        public Patient Patient { get; set; }

        public User User { get; set; }

        public HomeVisitRequestDetail HomeVisitRequestDetail { get; set; }

        public PatientRequestDateTimeDetail PatientRequestDateTimeDetail { get; set; }

        public List<RequestSelectedHealthHouseTariff>? TariffsSelected { get; set; }

        #endregion
    }
}
