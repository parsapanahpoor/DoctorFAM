using DoctorFAM.Domain.Entities.SiteSetting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.Site.DeathCertificate
{
    public class PatienAddressForDeathCertificateViewModel
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

        public List<TariffForHealthHouseServices>? ListOfTariffs { get; set; }

        public List<ulong>? SelectedTariffs { get; set; }

        #endregion

    }
}
