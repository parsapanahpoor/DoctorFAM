using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.DoctorTitleName;
using DoctorFAM.Domain.Enums.Gender;
using System.ComponentModel.DataAnnotations;

namespace DoctorFAM.Domain.Entities.Doctors;

public sealed class DoctorsInfo : BaseEntity
{
    #region properties

    public ulong DoctorId { get; set; }

    public string NationalCode { get; set; }

    public string MedicalSystemCode { get; set; }

    public string Education { get; set; }

    public string? Specialty { get; set; }

    public string MediacalFile { get; set; }

    public Gender Gender { get; set; }

    public string? GeneralPhone  { get; set; }

    public string? ClinicPhone { get; set; }

    [Display(Name = "تعداد پیامک رایگان برای ارسال از پزشک به بیماران")]
    public int CountOFFreeSMSForDoctors { get; set; }

    public DoctorTilteName DoctorTilteName { get; set; } = DoctorTilteName.Anonymous;

    public bool ContractWithFamilyDoctors { get; set; }

    #endregion

    #region Relations

    public Doctor Doctor { get; set; }

    #endregion
}

public enum OrganizationInfoState
{
    [Display(Name = "Accepted")]
    Accepted,
    [Display(Name = "WaitingForConfirm")]
    WatingForConfirm,
    [Display(Name = "Rejected")]
    Rejected,
    [Display(Name = "Register Now")]
    JustRegister
}
