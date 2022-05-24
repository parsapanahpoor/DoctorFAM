using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.UserPanel.Account
{
    public class UserPanelEditUserInfoViewModel
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [MaxLength(150, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string username { get; set; }

        public ulong UserId { get; set; }

        public string? AvatarName { get; set; }

        [Display(Name = "تلفن همراه")]
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? Mobile { get; set; }

        [Display(Name = "ایمیل")]

        [MaxLength(150, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نیست .")]
        public string? Email { get; set; }

    }

    public enum UserPanelEditUserInfoResult
    {
        NotValidImage,
        UserNotFound,
        Success,
        NotValidEmail,
    }
}
