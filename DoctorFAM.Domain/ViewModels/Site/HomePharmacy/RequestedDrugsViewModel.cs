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

        [Display(Name ="کد نسخه ی دارو ")]
        [MaxLength(400, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? DrugTrakingCode { get; set; }

        public DrugRequestMethod DrugRequestMethod { get; set; }

        [Display(Name = "تصویر نسخه ی دارو ")]
        public string? DrugPrescription { get; set; }

        [Display(Name = "نام دارو ")]
        [MaxLength(400, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? DrugName { get; set; }

        [Display(Name = "تعداد دارو ")]
        [MaxLength(400, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? DrugCount { get; set; }

        [Display(Name = "توضیحات مورد نیاز  ")]
        public string? Description { get; set; }

        public List<HomePharmacyRequestDetail?> ListOfRequestedDrugs { get; set; }
    }

    public enum DrugRequestMethod
    {
        [Display(Name = "سفارش دارو با کد نسخه ی پزشک")]
        DrugTrakingCode,

        [Display(Name = "سفارش دارو تصویر نسخه ی پزشک")]
        DrugPrescription,

        [Display(Name = "سفارش دارو با نام دارو")]
        DrugName
    }

    public enum CreateDrugRequestSiteSideResult
    {
        Success,
        DetailNotValid
    }

}
