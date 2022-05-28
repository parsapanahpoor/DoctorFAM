using DoctorFAM.Domain.Entities.MarketCategory;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.MarketCategory
{
    public class EditMarketCategoryViewModel
    {
        #region properties

        public ulong Id { get; set; }

        [DisplayName("Unique Name")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string UniqueName { get; set; }

        public List<CategoryInfo> CurrentInfos { get; set; }

        public List<EditeMarketCategoryInfoViewModel> MarketCategoryInfo { get; set; }

        public ulong? ParentId { get; set; }

        #endregion
    }

    public class EditeMarketCategoryInfoViewModel : BaseInfoViewModel
    {
        [Display(Name = "Market Category title")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string Title { get; set; }
    }

    public enum EditMArketCategoryResult
    {
        Success,
        Fail,
        UniqNameIsExist
    }
}
