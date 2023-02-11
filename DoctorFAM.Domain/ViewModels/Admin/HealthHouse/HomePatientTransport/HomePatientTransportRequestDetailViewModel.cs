using DoctorFAM.Domain.Enums.Gender;
using DoctorFAM.Domain.Enums.InsuranceType;
using DoctorFAM.Domain.Enums.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomePatientTransport
{
    public class HomePatientTransportRequestDetailViewModel
    {
        #region properties

        public ulong RequestId { get; set; }

        public string Username { get; set; }

        public string Mobile { get; set; }

        public string? Email { get; set; }

        public string? Country { get; set; }

        public string? State { get; set; }

        public string? City { get; set; }

        public string? Vilage { get; set; }

        public string? FullAddress { get; set; }

        public string? Phone { get; set; }

        public string? RequestDetailMobile { get; set; }

        public int? Distance { get; set; }

        public RequestState RequestState { get; set; }

        public string? PatientName { get; set; }

        public string? PatientLastName { get; set; }

        public string? NationalId { get; set; }

        public Gender? Gender { get; set; }

        public int? Age { get; set; }

        public string? Insurance { get; set; }

        public string? RequestDescription { get; set; }

        #endregion

    }
}
