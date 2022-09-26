using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Entities.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.UserPanel.Consultant
{
    public class ShowUserConsultantInfo
    {
        #region properties

        public User User { get; set; }

        public ConsultantInfo? ConsultantInfo { get; set; }

        #endregion
    }
}
