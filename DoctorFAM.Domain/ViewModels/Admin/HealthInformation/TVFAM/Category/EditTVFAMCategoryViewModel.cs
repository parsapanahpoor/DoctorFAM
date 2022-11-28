using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.Entities.HealthInformation;

namespace DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Category
{
    public class EditTVFAMCategoryViewModel
    {
        #region properties

        public ulong Id { get; set; }

        [DisplayName("عنوان یکتا")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string UniqueName { get; set; }

        public List<TVFAMCategoryInfo> CurrentInfos { get; set; }

        public List<EditTVFAMCategoryInfoViewModel> TVFAMCategoryInfos { get; set; }

        public ulong? ParentId { get; set; }

        #endregion
    }
    public class EditTVFAMCategoryInfoViewModel : BaseInfoViewModel
    {
        [Display(Name = "عنوان دسته بندی سرویس")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string Title { get; set; }
    }

    public enum EditTVFAMCategoryResult
    {
        Success,
        Fail,
        UniqNameIsExist
    }
}
