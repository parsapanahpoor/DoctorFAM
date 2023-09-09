#region Usings 

using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

#endregion

namespace DoctorFAM.Domain.ViewModels.Admin.Tourist;

public class ListOfTouristInfoViewModel : BasePaging<Organization>
{
    #region Ctor

    public ListOfTouristInfoViewModel()
    {
        TouristState = TouristState.All;
    }

    #endregion

    #region properties

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }

    [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
    public string? NationalCode { get; set; }

    public TouristState TouristState { get; set; }

    #endregion
}
public enum TouristState
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
