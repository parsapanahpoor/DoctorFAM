using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.Admin.Books
{
    public class EditBookAdminSideViewModel
    {
        #region Properties

        public ulong Id { get; set; }

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
        public int Price { get; set; }

        [Display(Name = "تعداد صفحات")]
        public int PagesNO { get; set; }


        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "کلید کوتاه")]
        public string? ShortKey { get; set; }

        [Display(Name = "سرگروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public ulong MainCategory { get; set; }

        [Display(Name = "زیر گروه")]
        public ulong? SubCategory { get; set; }

        [Display(Name = "تگ  ")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? BookTag { get; set; }

        #endregion
    }

    public enum EditBookFromAdminPanelResponse
    {

        [Display(Name = "موفق")]
        Success,
        [Display(Name = "ناموفق")]
        Faild,
        [Display(Name = "ناموفق")]
        ImageNotUploaded,
        [Display(Name = " نویسنده یافت نشده است ")]
        WriterNotFound,
        [Display(Name = "دسته بندی وارد نشده است ")]
        MainCategoryNotFound,
        [Display(Name = "کتاب یافت نشد  ")]
        BookFileNotFound,
        [Display(Name = "عنوان یافت نشده است ")]
        TitleNotFound,
        [Display(Name = "تصویر کتاب یافت نشده است ")]
        ImageNotFound

    }
}
