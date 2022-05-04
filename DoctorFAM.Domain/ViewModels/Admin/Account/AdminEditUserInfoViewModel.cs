using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Account
{
    public class AdminEditUserInfoViewModel
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string username { get; set; }

        public ulong UserId { get; set; }

        public string? AvatarName { get; set; }

        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [RegularExpression(@"[0-9]+$", ErrorMessage = "شماره وارد شده معتبر نمی باشد")]
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string Mobile { get; set; }

        [Display(Name = "ایمیل")]
       
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نیست .")]
        public string? Email { get; set; }

        public bool IsMobileConfirm { get; set; } = false;

        public bool IsEmailConfirm { get; set; } = false;

        public bool IsBan { get; set; } = false;

        public bool IsAdmin { get; set; } = false;

        public bool BanForChat { get; set; }

        public bool BanForComment { get; set; }

        public bool BanForTicket { get; set; }

        [Display(Name = "انتخاب نقش های کاربر")]
        public List<ulong>? UserRoles { get; set; }
    }

    public enum AdminEditUserInfoResult
    {
        NotValidImage,
        UserNotFound,
        Success,
        NotValidEmail,
        NotValidMobile,
        NotValidBirthDate
    }
}
