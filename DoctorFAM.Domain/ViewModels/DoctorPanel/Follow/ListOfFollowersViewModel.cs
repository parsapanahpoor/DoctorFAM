using DoctorFAM.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Follow
{
    public class ListOfFollowersViewModel
    {
        #region properties

        public User User { get; set; }

        public DateTime CreateDate { get; set; }

        #endregion
    }
}
