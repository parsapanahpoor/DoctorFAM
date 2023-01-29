using DoctorFAM.Domain.Entities.States;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DoctorFAM.Domain.Entities.Speciality;

namespace DoctorFAM.Domain.ViewModels.Admin.Speciality
{
    public class EditSpecialityViewModel
    {
        #region properties

        public ulong Id { get; set; }

        [DisplayName("عنوان تخصص یکتا")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string UniqueName { get; set; }

        public List<SpecialtiyInfo> CurrentInfos { get; set; }

        public List<EditSpecialityInfoViewModel> SpecialityInfo { get; set; }

        public ulong UniqueId { get; set; }

        public ulong? ParentId { get; set; }

        public bool IsTitle { get; set; }

        public bool IsSpeciality { get; set; }

        public bool IsSuperSpeciality { get; set; }

        #endregion
    }

    public class EditSpecialityInfoViewModel : BaseInfoViewModel
    {
        [Display(Name = "عنوان تخصص")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string Title { get; set; }
    }

    public enum EditSpecialityResult
    {
        Success,
        Fail,
        UniqNameIsExist,
        UniqueIdIsExist
    }
}
