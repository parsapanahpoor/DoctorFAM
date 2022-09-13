using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.PopulationCovered
{
    public class ListOfDoctorPopulationCoveredViewModel : BasePaging<User>
    {
        #region properties

        public ulong UserId { get; set; }

        public string? Username { get; set; }

        public string? Mobile { get; set; }

        public string? NationalId { get; set; }

        #endregion
    }
}
