#region Usings

using DoctorFAM.Domain.Entities.Doctors;
using System.ComponentModel.DataAnnotations;

#endregion

namespace DoctorFAM.Domain.ViewModels.Tourism.TouristInfo;

public class ManageTouristInfoViewModel
{
    #region properties

    public ulong UserId { get; set; }

    [Display(Name = "NationalId")]
    [Required(ErrorMessage = "Please Enter {0}")]
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "The entered national code is not valid")]
    public string NationalCode { get; set; }

    [Display(Name = "First Name")]
    [Required(ErrorMessage = "Please Enter {0}")]
    public string? FirstName { get; set; }

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Please Enter {0}")]
    public string? LastName { get; set; }

    [Display(Name = "education")]
    public string? Education { get; set; }

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

    public OrganizationInfoState? TouristInfosType { get; set; }

    #endregion
}

public enum AddOrEditTouristInfoResult
{
    Success,
    Faild,
    FileNotUploaded
}
