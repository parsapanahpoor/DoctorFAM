using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Account
{
    public class RegisterUserViewModel
    {
        [Display(Name = "تلفن همراه")]
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "موبایل وارد شده معتبر نمی باشد")]
        [Required(ErrorMessage = "این فیلد الزامی است .")]
        public string Mobile { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [MaxLength(100, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Compare("Password", ErrorMessage = "کلمه های عبور مغایرت دارند .")]
        public string RePassword { get; set; }

        public bool? DoctorsRegister { get; set; }

        public bool? SellerRegister { get; set; }

        public bool? PharmacyRegister { get; set; }

        public bool? NurseRegister { get; set; }

        public bool? ConsultantRegister { get; set; }
        
        public bool? LabratoryRegister { get; set; }

        public bool? DentistRegister { get; set; }

        public bool SiteRoles { get; set; }
    }

    public enum RegisterUserResult
    {
        Success,       
        MobileExist,
        SiteRoleNotAccept
    }
}
