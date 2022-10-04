using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Entities.OnlineVisit;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Consultant
{
    public class ConsultantRequestDetailAdminSideViewModel
    {
        #region properties

        public UserSelectedConsultant UserSelectedConsultant { get; set; }

        public User Patient { get; set; }

        public User Consultant { get; set; }

        #endregion
    }
}
