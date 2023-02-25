using DoctorFAM.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Doctors
{
    public class ListOfDoctorsPopulationCoveredCountDetailViewModel
    {
        #region properties

        public User Doctor { get; set; }

        public int ActiveUsersCount { get; set; }

        public int UsersPopulationCoveredCount { get; set; }

        #endregion
    }
}
