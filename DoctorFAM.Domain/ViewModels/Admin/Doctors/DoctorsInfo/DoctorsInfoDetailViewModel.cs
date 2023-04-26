using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.Entities.Speciality;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Enums.Gender;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo
{
    public class DoctorsInfoDetailViewModel
    {
        #region properties

        public ulong Id { get; set; }

        public ulong UserId { get; set; }

        public ulong DoctorId { get; set; }

        [Display(Name = "NationalId")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The entered national code is not valid")]
        public string NationalCode { get; set; }

        [Display(Name = "Medical system code")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The entered national code is not valid")]
        public string MedicalSystemCode { get; set; }

        [Display(Name = "education")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string Education { get; set; }

        [Display(Name = "Specialty")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string? Specialty { get; set; }

        [Display(Name = "Medical record")]
        public string MediacalFile { get; set; }

        [Display(Name = "Work Address")]
        public List<WorkAddress>? WorkAddresses { get; set; }

        [Display(Name = "The reason for the rejection of the information ")]
        public string? RejectDescription { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Display(Name = "Clinic Phone")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The entered national code is not valid")]
        public string? ClinicPhone { get; set; }

        [Display(Name = "General Phone")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The entered national code is not valid")]
        public string? GeneralPhone { get; set; }

        public OrganizationInfoState DoctorsInfosType { get; set; }

        public List<DoctorsInterestInfo>? DoctorsInterests { get; set; }

        [Display(Name = "Doctor Skills")]
        public string? DoctorSkills { get; set; }

        public List<Entities.Speciality.Speciality>? DoctorsSelectedSpecialities { get; set; }

        public int? InPersonReservationTariffForDoctorPopulationCovered { get; set; }

        public int? OnlineReservationTariffForDoctorPopulationCovered { get; set; }

        public int? InPersonReservationTariffForAnonymousPersons { get; set; }

        public int? OnlineReservationTariffForAnonymousPersons { get; set; }

        [Display(Name = "تعداد پیامک های مجاز برای ارسال از پزشک به بیماران")]
        public int CountOFFreeSMSForDoctors { get; set; }

        #endregion
    }

    public enum EditDoctorInfoResult
    {
        success,
        faild,
        NationalId,
        InpersonReservationPopluationCoveredLessThanSiteShare,
        OnlineReservationPopluationCoveredLessThanSiteShare,
        InpersonReservationAnonymousePersoneLessThanSiteShare,
        OnlineReservationAnonymousePersoneLessThanSiteShare
    }
}
