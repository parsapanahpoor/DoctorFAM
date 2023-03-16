using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DoctorFAM.Domain.Entities.Books
{
    public class Book:BaseEntity
    {
        #region Properties

        [Display(Name = "عنوان کتاب / مجله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400)]
        public string Title { get; set; }

        [Display(Name = "نویسنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(600)]
        public string Writer { get; set; }

        [Display(Name = "مترجم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(600)]
        public string Translator { get; set; }

        [Display(Name = "انتشارات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400)]
        public string Publisher { get; set; }

        [Display(Name = "سال انتشار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string YearOfPublish { get; set; }

        [Display(Name = "چکیده کتاب / مجله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        public string Introduction { get; set; }

        [Display(Name = "فایل کتاب / مجله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string BookFile { get; set; }

        [Display(Name = "تصویر")]
        [MaxLength(200)]
        [Required]
        public string Image { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        public string Price { get; set; }

        [Display(Name = "تعداد صفحات")]
        public int PagesNO { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "کلید کوتاه")]
        public string? ShortKey { get; set; }

        #endregion

        #region Relations

        //public ICollection<BookTag> BookTags { get; set; }

        //public ICollection<BookSelectedCategory> BookSelectedCategories { get; set; }

        #endregion
    }
}
