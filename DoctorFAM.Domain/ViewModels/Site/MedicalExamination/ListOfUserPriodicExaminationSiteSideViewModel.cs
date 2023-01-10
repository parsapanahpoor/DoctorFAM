using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.PriodicExamination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.MedicalExamination
{
    public class ListOfUserPriodicExaminationSiteSideViewModel
    {
        #region properties

        public PriodicPatientsExamination? PriodicPatientsExaminations { get; set; }

        public User? Doctors { get; set; }

        #endregion
    }
}
