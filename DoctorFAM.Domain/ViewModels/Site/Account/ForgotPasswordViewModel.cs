using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Display(Name = "تلفن همراه")]
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "موبایل وارد شده معتبر نمی باشد")]
        [Required(ErrorMessage = "این فیلد الزامی است .")]
        public string Mobile { get; set; }
    }
}
