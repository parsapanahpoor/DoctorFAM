using System.ComponentModel.DataAnnotations;

namespace DoctorFAM.Domain.Enums.HealthCenter;

public enum DoctorSelectedHealthCenterState
{
    [Display(Name ="درانتظار بررسی")]
    WaitingForResponse,

    [Display(Name = "تایید شده")]
    Accept,

    [Display(Name = "رد شده")]
    Decline
}
