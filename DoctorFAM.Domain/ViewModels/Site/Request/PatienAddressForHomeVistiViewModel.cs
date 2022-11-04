using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.Site.Request
{
    public class PatienAddressForHomeVistiViewModel
    {
        #region properties

        [Display(Name = "کد درخواست")]
        public ulong RequestId { get; set; }

        public ulong PatientId { get; set; }

        [Display(Name = "نام کشور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public ulong CountryId { get; set; }

        [Display(Name = "نام استان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public ulong StateId { get; set; }

        [Display(Name = "نام شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public ulong CityId { get; set; }

        [Display(Name = "روستا")]
        public string? Vilage { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FullAddress { get; set; }

        [Display(Name = "تلفن ثابت")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public string Phone { get; set; }

        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public string Mobile { get; set; }

        [Display(Name = "فاصله از شهر")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public int Distance { get; set; }

        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        [Display(Name = "تاریخ مراجعه   ")]
        [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "تاریخ وارد شده معتبر نمی باشد")]
        public string SendDate { get; set; }

        [Display(Name = "ساعت مراجعه  ")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        [RegularExpression(@"2[0-4]|1[0-9]|[1-9]", ErrorMessage = "ساعت وارد شده معتبر نمی باشد ")]
        public int StartTime { get; set; }

        [Display(Name = "ساعت مراجعه  ")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        [RegularExpression(@"2[0-4]|1[0-9]|[1-9]", ErrorMessage = "ساعت وارد شده معتبر نمی باشد ")]
        public int EndTime { get; set; }

        [Display(Name = "پزشک خانم")]
        public bool FemalePhysician { get; set; }

        [Display(Name = "ویزیت اورژانسی")]
        public bool EmergencyVisit { get; set; }

        [Display(Name = "تزریق عضلانی")]
        public bool IntramuscularInjection { get; set; }

        [Display(Name = "تزریق جلدی یا زیر جلدی")]
        public bool DermalOrSubcutaneousInjection { get; set; }

        [Display(Name = "تزریق وریدی")]
        public bool ReedyInjection { get; set; }

        [Display(Name = "سرم تراپی")]
        public bool SerumTherapy { get; set; }

        [Display(Name = "اندازه گیری فشار خون")]
        public bool BloodPressureMeasurement { get; set; }

        [Display(Name = "گلوکومتری")]
        public bool Glucometry { get; set; }

        [Display(Name = "پالس اکسیمتری")]
        public bool PulseOximetry { get; set; }

        [Display(Name = "پانسمان کوچک")]
        public bool SmallDressing { get; set; }

        [Display(Name = "پانسمان بزرگ")]
        public bool GreatDressing { get; set; }

        [Display(Name = "لوله گذاری معده")]
        public bool GastricIntubation { get; set; }

        [Display(Name = "سوندگذاری مثانه")]
        public bool UrinaryBladder { get; set; }

        [Display(Name = "اکسیژن تراپی")]
        public bool OxygenTherapy { get; set; }

        [Display(Name = "نوار قلب")]
        public bool ECG { get; set; }

        #endregion
    }
}
