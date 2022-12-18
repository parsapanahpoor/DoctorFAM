using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Nurse.HomeNurse
{
    public class HomeNurseRequestViewModel
    {
        #region properties

        public Request Request { get; set; }

        public PaitientRequestDetail PatientRequestDetail { get; set; }

        public PatientRequestDateTimeDetail PatientRequestDateTimeDetail { get; set; }

        public Patient Patient { get; set; }

        public User User { get; set; }

        public List<RequestSelectedHealthHouseTariff>? TariffSelected { get; set; }

        #endregion
    }
}
