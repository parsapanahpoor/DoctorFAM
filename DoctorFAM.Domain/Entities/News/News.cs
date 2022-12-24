using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;

namespace DoctorFAM.Domain.Entities.News
{
    public class News : BaseEntity
    {
        #region Properties

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400)]
        public string Title { get; set; }

        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        public string ShortDescription { get; set; }

        [Display(Name = "لینک منبع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        public string URL { get; set; }

        [Display(Name = "متن")]
        public string? Description { get; set; }

        [Display(Name = "تصویر")]
        [MaxLength(200)]
        [Required]
        public string Image { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "درج نظر")]
        public bool CanInsertComment { get; set; }

        [Display(Name = "کلید کوتاه")]
        public string? ShortKey { get; set; }

        #endregion

        #region Relations

        public ICollection<NewsTag> NewsTags { get; set; }

        public ICollection<NewsComment> NewsComments { get; set; }

        public ICollection<NewsSelectedCategory> NewsSelectedCategories { get; set; }

        #endregion
    }
}
