using DoctorFAM.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.NavBar
{
    public class LastestFamilyDoctorRequestForShowInNavBarViewModel
    {
        #region properties

        public bool HasAccessForShow { get; set; }

        public int RequestCount { get; set; }

        public List<LastestFamilyDoctorRequestForShowInNavBarDetailViewModel>? Detail { get; set; }

        #endregion
    }

    public class LastestFamilyDoctorRequestForShowInNavBarDetailViewModel
    {
        public User Users { get; set; }

        public DateTime DateTimes { get; set; }
    }
}
