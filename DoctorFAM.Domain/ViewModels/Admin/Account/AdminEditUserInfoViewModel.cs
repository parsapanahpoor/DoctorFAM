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
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string username { get; set; }

        public ulong UserId { get; set; }

        public string? AvatarName { get; set; }

        [Display(Name = "Mobile")]
        [MaxLength(20, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [RegularExpression(@"[0-9]+$", ErrorMessage = "The information entered is not valid.")]
        public string Mobile { get; set; }

        [Display(Name = "Email")]
        [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        public string? Email { get; set; }


        [Display(Name = "First Name")]
        [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string? FirstName { get; set; }

        [Display(Name = "LastName")]
        [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string? LastName { get; set; }

        [Display(Name = "BirthDay")]
        [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "The information entered is not valid.")]
        public string? BithDay { get; set; }

        [Display(Name = "Father Name")]
        [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string? FatherName { get; set; }

        [Display(Name = "NationalId")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public string? NationalId { get; set; }

        [Display(Name = "Extra Phone Number")]
        [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public string? ExtraPhoneNumber { get; set; }

        [Display(Name = "Home Phone Number")]
        [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public string? HomePhoneNumber { get; set; }

        [Display(Name = "Work Address")]
        public string? WorkAddress { get; set; }

        public bool IsMobileConfirm { get; set; } = false;

        public bool IsEmailConfirm { get; set; } = false;

        public bool IsBan { get; set; } = false;

        public bool IsAdmin { get; set; } = false;

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
        NotValidBirthDate,
        NotValidNationalId
    }
}
