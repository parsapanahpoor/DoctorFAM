using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorFAM.Domain.ViewModels.Common;

namespace DoctorFAM.Domain.ViewModels.Admin.HealthInformation.RadioFAM.Category
{
    public class CreateRadioFAMCategoryViewModel
    {
        [DisplayName("عنوان یکتا")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string UniqueName { get; set; }

        public List<CreateRadioFAMCategoryInfoViewModel> RadioFAMCategoryInfos { get; set; }

        public ulong? ParentId { get; set; }
    }

    public class CreateRadioFAMCategoryInfoViewModel : BaseInfoViewModel
    {
        [Display(Name = "عنوان دسته بندی")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string Title { get; set; }
    }

    public enum CreateRadioFAMCategoryResult
    {
        Success,
        Fail,
        UniqNameIsExist
    }
}
