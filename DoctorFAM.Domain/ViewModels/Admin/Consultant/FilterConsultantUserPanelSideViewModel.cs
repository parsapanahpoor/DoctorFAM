using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Consultant
{
    public class FilterConsultantUserPanelSideViewModel
    {
        #region properties

        public ulong? CountryId { get; set; }

        public ulong? StateId { get; set; }

        public ulong? CityId { get; set; }

        public string? Username { get; set; }

        public int? PageId { get; set; } = 1;

        public int? PageCount { get; set; }

        #endregion
    }
}
