using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.News
{
    public class EditNewsCategoryViewModel
    {
        #region Properties

        public ulong NewsCategoryId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(260)]
        public string Title { get; set; }

        [Display(Name = "عنوان در Url")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string UniqueName { get; set; }

        public ulong? ParentId { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        #endregion

    }

    public enum EditNewsCategoryResult
    {
        [Display(Name = "موفق")]
        success,
        [Display(Name = "ناموفق")]
        Fiald,
        [Display(Name = "دسته بندی تکراری است ")]
        CategoryIsExist,
    }
}
