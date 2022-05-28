using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.MarketCategory
{
    public class FilterMarketCategoryViewModel : BasePaging<Domain.Entities.MarketCategory.CategoryInfo>
    {
        #region properties

        public string? Title { get; set; }

        public string? UniqueName { get; set; }

        public ulong? ParentId { get; set; }

        public MarketCategoryStatus MarketCategoryStatus { get; set; }

        public Entities.MarketCategory.Category ParentMarketCategory { get; set; }

        #endregion
    }

    public enum MarketCategoryStatus
    {
        [Display(Name = "All")] All,
        [Display(Name = "NotDeleted")] NotDeleted,
        [Display(Name = "Deleted")] Deleted,
    }
}
