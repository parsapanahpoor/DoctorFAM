using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.UserPanel.PopulationCovered
{
    public class FilterPopulationCoveredUserViewModel : BasePaging<Domain.Entities.PopulationCovered.PopulationCovered>
    {
        #region properties

        public ulong UserId { get; set; }

        [Display(Name = "NationalId")]
        public string? NationalId { get; set; }

        #endregion
    }
}
