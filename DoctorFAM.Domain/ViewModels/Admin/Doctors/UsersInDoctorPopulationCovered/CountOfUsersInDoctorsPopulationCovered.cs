using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Doctors.UsersInDoctorPopulationCovered
{
    public class CountOfUsersInDoctorsPopulationCovered
    {
        #region properties

        public int? CountOfAllUsers { get; set; }

        public int? CountOfUsersWithDoctorFamily { get; set; }

        public int? CountOfUsersWaitingForAcceptFromFamilyDoctors { get; set; }

        public int? CountOfUsersWithoutFamilyDoctors { get; set; }

        #endregion
    }
}
