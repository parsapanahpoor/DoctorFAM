using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.WorkAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor
{
    public class ShowUserFamilyDoctorInfo
    {
        #region properties

        public User User { get; set; }

        public DoctorsInfo? DoctorsInfo { get; set; }

        #endregion
    }
}
