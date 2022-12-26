using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Enums.Gender;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor
{
    public class FilterFamilyDoctorUserPanelSideViewModel
    {
        #region properties

        public ulong? CountryId { get; set; }

        public ulong? StateId { get; set; }

        public ulong? CityId { get; set; }

        public string? Username { get; set; }

        public int? PageId { get; set; } = 1;

        public int? PageCount { get; set; }

        public int? Gender { get; set; }

        public int CountOfFollowers { get; set; }

        public bool YouFollowed { get; set; }

        #endregion
    }
}
