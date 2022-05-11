using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.HomePharmacy
{
    public class PatientRequestedDrugAddressViewModel
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
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Vilage { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FullAddress { get; set; }

        [Display(Name = "تلفن ثابت")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        public string Phone { get; set; }

        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        public string Mobile { get; set; }

        [Display(Name = "فاصله از شهر")]
        public int Distance { get; set; }

        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        [Display(Name = "تاریخ ارسال دارو ")]
        [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "تاریخ وارد شده معتبر نمی باشد")]
        public string SendDate { get; set; }

        [Display(Name = "شروع ساعت ارسال")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        public int StartTime { get; set; }

        [Display(Name = "پایان ساعت ارسال ")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        public int EndTime { get; set; }

        #endregion

    }
}
