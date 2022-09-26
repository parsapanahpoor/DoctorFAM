using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Entities.FamilyDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Consultant.ConsultantRequest
{
    public class ShowPopulationCoveredDetailViewModel
    {
        #region properties

        public UserSelectedConsultant UserSelectedConsultant { get; set; }

        public User Patient { get; set; }

        public List<Entities.PopulationCovered.PopulationCovered>? PopulationCovered { get; set; }

        #endregion
    }
}
