using DoctorFAM.Domain.Enums.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Product
{
    public class EditProductAdminViewModel
    {
        #region properties

        public ulong ProductId { get; set; }

        public string ProductImage { get; set; }

        [Display(Name = "عنوان محصول  ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ProductTitle { get; set; }

        [Display(Name = "شرح کوتاه  محصول ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ShortDescription { get; set; }

        [Display(Name = "شرح کامل محصول ")]
        public string? LongDescription { get; set; }

        public int? OfferPercent { get; set; }

        public bool? IsInOffer { get; set; }

        [Display(Name = "قیمت ")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "قیمت وارد شده معتبر نمی باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }

        public string? RejectedNote { get; set; }

        public ProductSaleType ProductSaleType { get; set; }

        [Display(Name = "تعداد ")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "تعداد وارد شده معتبر نمی باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ProductsCount { get; set; }

        [Display(Name = "توضیح محصولات فروش بسته ای  ")]
        public string? PackedProductsDescription { get; set; }

        [Display(Name = "زیر گروه اول ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public ulong FirstCategory { get; set; }

        [Display(Name = "زیر گروه دوم ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public ulong SecondeCategory { get; set; }

        [Display(Name = "زیر گروه سوم ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public ulong ThirdCategory { get; set; }

        [Display(Name = "زیر گروه چهارم ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public ulong FourthCategory { get; set; }

        [Display(Name = "تگ  ")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? ProductTag { get; set; }

        public ProductsState ProductsState { get; set; }

        #endregion
    }
    public enum EditProductAdminPanelResult
    {
        LongDescription,
        Categories,
        ImageName,
        PackedNote,
        Faild,
        UserNotFound,
        Success,
        prodcutNotFound
    }
}
