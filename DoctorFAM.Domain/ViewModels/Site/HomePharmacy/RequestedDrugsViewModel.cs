using DoctorFAM.Domain.Entities.Pharmacy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.HomePharmacy
{
    public class RequestedDrugsViewModel
    {
        public ulong RequestId { get; set; }

        [Display(Name ="کد رهگیری نسخه ")]
        [MaxLength(400, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? DrugTrakingCode { get; set; }

        [Display(Name = "تصویر نسخه ")]
        public string? DrugPrescription { get; set; }

        [Display(Name = "نام دارو/اقلام بهداشتی ")]
        [MaxLength(400, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? DrugName { get; set; }

        [Display(Name = " تعداد")]
        [MaxLength(400, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? DrugCount { get; set; }

        [Display(Name = "توضیحات ")]
        public string? Description { get; set; }

        public List<HomePharmacyRequestDetail?> ListOfRequestedDrugs { get; set; }
    }

    public enum CreateDrugRequestSiteSideResult
    {
        Success,
        DetailNotValid,
        MoreThanOneChoice,
        DrugNameAndImageIsNull,
        DrugCountIsNull,
        AllOfPropertiesAreNull
    }

}
