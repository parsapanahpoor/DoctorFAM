using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Requests
{
    public class PaitientRequestDetail : BaseEntity
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
        public string Phone { get; set; }

        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        public string Mobile { get; set; }

        [Display(Name = "فاصله از شهر")]
        public int Distance { get; set; }

        #endregion

        #region relations

        public Request Request { get; set; }

        public Patient.Patient Patient { get; set; }

        [InverseProperty("PaitientRequestDetailCountries")]
        [ForeignKey("CountryId")]
        public Location Country { get; set; }

        [InverseProperty("PaitientRequestDetailCities")]
        [ForeignKey("CityId")]
        public Location City { get; set; }

        [InverseProperty("PaitientRequestDetailStates")]
        [ForeignKey("StateId")]
        public Location State { get; set; }

        #endregion
    }
}
