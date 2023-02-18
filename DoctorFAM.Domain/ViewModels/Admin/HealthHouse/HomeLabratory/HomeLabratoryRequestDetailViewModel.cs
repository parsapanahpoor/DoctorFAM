using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Insurance;
using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Enums.Gender;
using DoctorFAM.Domain.Enums.InsuranceType;
using DoctorFAM.Domain.Enums.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeLabratory
{
    public class HomeLabratoryRequestDetailViewModel
    {
        public Request Request { get; set; }

        public PaitientRequestDetail PatientRequestDetail { get; set; }

        public PatientRequestDateTimeDetail PatientRequestDateTimeDetail { get; set; }

        public Patient Patient { get; set; }

        public ICollection<HomeLaboratoryRequestDetail> HomeLaboratoryRequestDetail { get; set; }

        public User User { get; set; }
    }
}
