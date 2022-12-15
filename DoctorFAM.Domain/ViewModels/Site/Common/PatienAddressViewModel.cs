using DoctorFAM.Domain.Entities.SiteSetting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Common
{
    public class PatienAddressViewModel
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

        [Display(Name = "ساعت مراجعه ی پرستار")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        [RegularExpression(@"2[0-4]|1[0-9]|[1-9]", ErrorMessage = "ساعت وارد شده معتبر نمی باشد ")]
        public int StartTime { get; set; }

        public List<TariffForHealthHouseServices>? ListOfTariffs { get; set; }

        public List<ulong>? SelectedTariffs { get; set; }

        #endregion
    }

    public enum CreatePatientAddressResult
    {
        Success,
        Failed,
        PatientNotFound,
        RquestNotFound,
        LocationNotFound
    }
}
