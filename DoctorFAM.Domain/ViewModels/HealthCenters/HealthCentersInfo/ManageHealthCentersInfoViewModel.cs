using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Enums.Gender;
using System.ComponentModel.DataAnnotations;

namespace DoctorFAM.Domain.ViewModels.HealthCenters.HealthCentersInfo;

public record ManageHealthCentersInfoViewModel
{
    #region properties

    public ulong UserId { get; set; }

    [Display(Name = "NationalId")]
    [Required(ErrorMessage = "Please Enter {0}")]
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "The entered national code is not valid")]
    public string NationalCode { get; set; }

    [Display(Name = "User Name")]
    [Required(ErrorMessage = "Please Enter {0}")]
    [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
    public string username { get; set; }

    public string? AvatarName { get; set; }

    [Display(Name = "Email")]
    [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
    [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
    public string? Email { get; set; }

    [Display(Name = "Mobile")]
    [MaxLength(20, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
    public string? Mobile { get; set; }

    [Display(Name = "First Name")]
    [Required(ErrorMessage = "Please Enter {0}")]
    public string? FirstName { get; set; }

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Please Enter {0}")]
    public string? LastName { get; set; }

    [Display(Name = "education")]
    [Required(ErrorMessage = "Please Enter {0}")]
    public string Education { get; set; }

    [Display(Name = "Work Address")]
    public string? WorkAddress { get; set; }

    [Display(Name = "The reason for the rejection of the information ")]
    public string? RejectDescription { get; set; }

    [Display(Name = "Country")]
    public ulong? CountryId { get; set; }

    [Display(Name = "State")]
    public ulong? StateId { get; set; }

    [Display(Name = "City")]
    public ulong? CityId { get; set; }

    [Display(Name = "Gender")]
    public Gender Gender { get; set; }

    [Display(Name = "BirthDay")]
    [Required(ErrorMessage = "Please Enter {0}")]
    [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "The information entered is not valid.")]
    public string BithDay { get; set; }

    [Display(Name = "Father Name")]
    [Required(ErrorMessage = "Please Enter {0}")]
    [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
    public string FatherName { get; set; }

    [Display(Name = "Home Phone Number")]
    [Required(ErrorMessage = "Please Enter {0}")]
    [MaxLength(150, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
    public string HomePhoneNumber { get; set; }

    public OrganizationInfoState? HealthCentersInfosType { get; set; }

    public string? GeneralPhone { get; set; }

    public string? HealthCenterFile { get; set; }

    public string HealthCenterName { get; set; }

    #endregion
}

public enum AddOrEditHealthCenterstInfoResult
{
    Success,
    Faild,
    FileNotUploaded,
    NotValidImage,
    NotValidNationalId,
    NationalId,
    NotValidEmail
}
