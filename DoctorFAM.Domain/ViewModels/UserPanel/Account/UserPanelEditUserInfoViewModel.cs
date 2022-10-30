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
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string username { get; set; }

        public ulong UserId { get; set; }

        public string? AvatarName { get; set; }

        [Display(Name = "Mobile")]
        [MaxLength(20, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public string? Mobile { get; set; }

        [Display(Name = "Email")]
        [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        public string? Email { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string LastName { get; set; }

        [Display(Name = "BirthDay")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "The information entered is not valid.")]
        public string BithDay { get; set; }

        [Display(Name = "Father Name")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string FatherName { get; set; }

        [Display(Name = "NationalId")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public string NationalId { get; set; }

        [Display(Name = "Extra Phone Number")]
        [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public string? ExtraPhoneNumber { get; set; }

        [Display(Name = "Home Phone Number")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public string HomePhoneNumber { get; set; }

        [Display(Name = "Work Address")]
        public string? WorkAddress { get; set; }

    }

    public enum UserPanelEditUserInfoResult
    {
        NotValidImage,
        UserNotFound,
        Success,
        NotValidEmail,
        NationalId,
        NotValidNationalId
    }
}
