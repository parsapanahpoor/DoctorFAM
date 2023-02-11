using DoctorFAM.Domain.Enums.Gender;
using DoctorFAM.Domain.Enums.InsuranceType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.Site.OnlineVisit
{
    public class PatientDetailForOnlineVisitViewModel
    {
        #region properties

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

        [Display(Name = "نام کشور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public ulong CountryId { get; set; }

        [Display(Name = "نام استان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public ulong StateId { get; set; }

        [Display(Name = "نام شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public ulong CityId { get; set; }

        #endregion
    }
}
