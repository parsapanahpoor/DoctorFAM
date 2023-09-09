#region Admin Side

using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.WorkAddress;
using System.ComponentModel.DataAnnotations;

#endregion

namespace DoctorFAM.Domain.ViewModels.Admin.Tourist;

public class TouristInfoDetailAdminSideViewModel
{
    #region properties

    public ulong Id { get; set; }

    public ulong UserId { get; set; }

    public ulong TouristId { get; set; }

    [Display(Name = "NationalId")]
    [Required(ErrorMessage = "Please Enter {0}")]
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "The entered national code is not valid")]
    public string NationalCode { get; set; }

    [Display(Name = "education")]
    [Required(ErrorMessage = "Please Enter {0}")]
    public string? Education { get; set; }

    [Display(Name = "Work Address")]
    public List<WorkAddress>? WorkAddresses { get; set; }

    [Display(Name = "The reason for the rejection of the information ")]
    public string? RejectDescription { get; set; }

    public OrganizationInfoState TouristInfosType { get; set; }

    #endregion
}

public enum EditTouristInfoResult
{
    success,
    faild
}
