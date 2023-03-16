using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.News
{
    public class EditNewsAdminSideViewModel
    {

        #region Properties

        public ulong Id { get; set; }

        [Display(Name = "عنوان ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400)]
        public string Title { get; set; }

        [Display(Name = "لینک خبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400)]
        public string URL { get; set; }

        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        public string ShortDescription { get; set; }

        [Display(Name = "متن ")]
        public string? Description { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "درج نظر")]
        public bool CanInsertComment { get; set; }

        public string imagename { get; set; }

        [Display(Name = "سرگروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public ulong MainCategory { get; set; }

        [Display(Name = "زیر گروه")]
        public ulong? SubCategory { get; set; }

        [Display(Name = "تگ  ")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? NewsTag { get; set; }

        #endregion

    }

    public enum EditNewsFromAdminPanelResponse
    {
        [Display(Name = "موفق")]
        Success,
        [Display(Name = "ناموفق")]
        Faild,
        [Display(Name = "ناموفق")]
        ImageNotUploaded,
        [Display(Name = " نویسنده یافت نشده است ")]
        AuthorNotFound,
        [Display(Name = "توضیحات کامل وارد نشد  ")]
        DescriptionNotFound,
        [Display(Name = "دسته بندی وارد نشده است ")]
        MainCategoryNotFound,
        [Display(Name = "عکس یافت نشده است ")]
        ImageNotFound,
        [Display(Name = "مقاله ای یافت نشده است ")]
        NewsNotFound,
     
    }
}
