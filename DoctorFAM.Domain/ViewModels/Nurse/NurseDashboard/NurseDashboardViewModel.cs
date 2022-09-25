using DoctorFAM.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Nurse.NurseDashboard
{
    public class NurseDashboardViewModel 
    {
        #region properties

        public ICollection<Request> ListOfHomeNurseRequest { get; set; }

        #endregion
    }
}
