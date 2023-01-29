using DoctorFAM.Domain.ViewModels.Admin.Speciality;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorFAM.Domain.ViewModels.Common;

namespace DoctorFAM.Domain.ViewModels.Admin.Speciality
{
    public class CreateSpecialityViewModel 
    {
        [DisplayName("عنوان یکتا")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string UniqueName { get; set; }

        public List<CreateSpecialityInfoViewModel> SpecialityInfo { get; set; }

        public ulong? ParentId { get; set; }

        public ulong UniqueId { get; set; }

        public bool IsTitle { get; set; }

        public bool IsSpeciality { get; set; }

        public bool IsSuperSpeciality { get; set; }
    }

    public class CreateSpecialityInfoViewModel : BaseInfoViewModel
    {
        [Display(Name = "عنوان ")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string Title { get; set; }
    }

    public enum CreateSpecialityResult
    {
        Success,
        Fail,
        UniqNameIsExist,
        UniqIdIsExist,
    }
}
