using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.OnlineVisit
{
    public class ListOfWorkShiftsDatesAdminSideViewModel
    {
        #region properties

        public DateTime WorkShiftDate { get; set; }

        public int CountOfOnlineDoctors { get; set; }

        public int BusinessKey { get; set; }

        #endregion
    }
}
