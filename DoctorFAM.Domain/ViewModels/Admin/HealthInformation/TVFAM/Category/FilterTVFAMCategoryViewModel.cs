using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Category
{
    public class FilterTVFAMCategoryViewModel : BasePaging<TVFAMCategoryInfo>
    {
        #region properties

        public string? Title { get; set; }

        public string? UniqueName { get; set; }

        public ulong? ParentId { get; set; }

        public Entities.HealthInformation.TVFAMCategory ParentTVFAMCategory { get; set; }

        #endregion
    }
}
