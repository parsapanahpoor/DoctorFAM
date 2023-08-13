#region Usings

using System.ComponentModel.DataAnnotations;

#endregion

namespace DoctorFAM.Domain.Enums.DoctorTitleName;

public enum DoctorTilteName
{
    [Display(Name = "ناشناس")]
    Anonymous,
    [Display(Name = "پزشک")]
    Doctor,
    [Display(Name = "پروفسور")]
    Professor,
}
