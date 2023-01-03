using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.Entities.Speciality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Speciality
{
    public class ListOfSpecialityViewModel
    {
        #region properties

        public SpecialtiyInfo SpecialtiyInfo { get; set; }

        public bool SelectedFromDoctor { get; set; }

        #endregion
    }
}
