using DoctorFAM.Domain.Enums.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.FamilyDoctor
{
    public class FilterFamilyDoctorViewModel : BasePaging<Entities.FamilyDoctor.UserSelectedFamilyDoctor>
    {
        #region properties

        public string? PatientName { get; set; }

        public string? PatientMobile { get; set; }

        public string? PatientNationalId { get; set; }

        public string? DoctorName { get; set; }

        public string? DoctorMobile { get; set; }

        public string? DoctorNationalId { get; set; }

        public FamilyDoctorRequestDeleteState FamilyDoctorRequestDeleteState { get; set; }

        public FamilyDoctorRequestStateAdminFilter FamilyDoctorRequestStateAdminFilter { get; set; }

        #endregion
    }
}
