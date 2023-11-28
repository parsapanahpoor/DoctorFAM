using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.ViewModels.Admin.Doctor;
using DoctorFAM.Domain.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace DoctorFAM.Domain.ViewModels.Admin.HealthCenter;

public class ListOfHealthCenterInfoViewModel : BasePaging<Organization>
{
    #region Ctor

    public ListOfHealthCenterInfoViewModel()
    {
        HealthCentersState = HealthCentersState.All;
    }

    #endregion

    #region properties

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
    public string? NationalCode { get; set; }

    public HealthCentersState HealthCentersState{ get; set; }

    #endregion
}

public enum HealthCentersState
{
    [Display(Name = "Accepted")]
    Accepted,
    [Display(Name = "WaitingForConfirm")]
    WaitingForConfirm,
    [Display(Name = "Rejected")]
    Rejected,
    [Display(Name = "All")]
    All
}
