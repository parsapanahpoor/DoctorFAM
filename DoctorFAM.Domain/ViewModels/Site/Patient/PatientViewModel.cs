using DoctorFAM.Domain.Enums.Gender;
using DoctorFAM.Domain.Enums.InsuranceType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Patient
{
    public class PatientViewModel
    {
        [Display(Name = "کد درخواست")]
        public ulong RequestId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        public string PatientName { get; set; }

        [Display(Name = " نام خانوادگی")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        public string PatientLastName { get; set; }

        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public string NationalId { get; set; }

        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        public Gender Gender { get; set; }

        [Display(Name = "سن(سال)")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public int Age { get; set; }

        [Display(Name = "نوع بیمه")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        public ulong InsuranceId { get; set; }

        [Display(Name = "علت درخواست/ علایم بیمار")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        public string RequestDescription { get; set; }

        public ulong UserId { get; set; }
    }

    public enum CreatePatientResult
    {
        Success,
        RequestIdNotFound,
        Faild
    }
}
