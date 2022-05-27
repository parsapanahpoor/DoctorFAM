using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomePharmacy
{
    public class RequestedDrugsAdminSideViewModel
    {
        #region properties

        [Display(Name = "کد رهگیری نسخه ")]
        public string? DrugTrakingCode { get; set; }

        [Display(Name = "تصویر نسخه ")]
        public string? DrugPrescription { get; set; }

        [Display(Name = "نام دارو/اقلام بهداشتی ")]
        public string? DrugName { get; set; }

        [Display(Name = " تعداد")]
        public string? DrugCount { get; set; }

        [Display(Name = "توضیحات ")]
        public string? Description { get; set; }

        public string? DrugImage { get; set; }

        #endregion
    }
}
