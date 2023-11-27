using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.WorkAddress;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.Admin.HealthCenter;

public record HealthCenterInfoDetailViewModel
{
    #region properties

    public ulong Id { get; set; }

    public ulong UserId { get; set; }

    public ulong HealthCenterId { get; set; }

    [Display(Name = "NationalId")]
    [Required(ErrorMessage = "Please Enter {0}")]
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "The entered national code is not valid")]
    public string NationalCode { get; set; }

    [Display(Name = "Work Address")]
    public List<WorkAddress>? WorkAddresses { get; set; }

    [Display(Name = "The reason for the rejection of the information ")]
    public string? RejectDescription { get; set; }

    public OrganizationInfoState HealthCenterInfosType { get; set; }

    #endregion
}

public enum EditHealthCenterInfoResult
{
    success,
    faild
}
