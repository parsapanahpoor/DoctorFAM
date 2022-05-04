using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Location
{
    public class FilterLocationViewModel : BasePaging<Domain.Entities.States.LocationInfo>
    {
        #region properties

        public string? Title { get; set; }

        public string? UniqueName { get; set; }

        public ulong? ParentId { get; set; }

        public StateStatus LocationStatus { get; set; }

        public Entities.States.Location ParentLocation { get; set; }

        #endregion
    }

    public enum StateStatus
    {
        [Display(Name = "All")] All,
        [Display(Name = "NotDeleted")] NotDeleted,
        [Display(Name = "Deleted")] Deleted,
    }
}
