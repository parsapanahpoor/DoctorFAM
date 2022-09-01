using DoctorFAM.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.UserPanel.Home
{
    public class HomeDashboardViewModel
    {
        #region properties

        public List<Request> ListOfInProgressRequests { get; set; }

        #endregion
    }
}
