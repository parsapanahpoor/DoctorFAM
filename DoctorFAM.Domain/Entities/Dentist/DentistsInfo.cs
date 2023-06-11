#region Usings

using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.Gender;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;


#endregion

namespace DoctorFAM.Domain.Entities.Dentist;

public class DentistsInfo : BaseEntity
{
    #region properties

    public ulong UserId { get; set; }

    public ulong DentistId { get; set; }

    public string NationalCode { get; set; }

    public string MedicalSystemCode { get; set; }

    public string Education { get; set; }

    public string? Specialty { get; set; }

    public string MediacalFile { get; set; }

    public Gender Gender { get; set; }

    public string? GeneralPhone { get; set; }

    public string? ClinicPhone { get; set; }

    [Display(Name = "تعداد پیامک رایگان برای ارسال از پزشک به بیماران")]
    public int CountOFFreeSMSForDoctors { get; set; }

    #endregion
}
