using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.FamilyDoctor;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Entities.PopulationCovered;
using DoctorFAM.Domain.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.PopulationCovered
{
    public class ShowPopulationCoveredDetailViewModel
    {
        #region properties

        public UserSelectedFamilyDoctor UserSelectedFamilyDoctorRequest { get; set; }

        public User Patient { get; set; }

        public List<Entities.PopulationCovered.PopulationCovered>? PopulationCovered { get; set; }

        #endregion
    }
}
