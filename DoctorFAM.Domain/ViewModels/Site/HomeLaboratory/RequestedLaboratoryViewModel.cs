using DoctorFAM.Domain.Entities.Laboratory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.HomeLaboratory
{
    public class RequestedLaboratoryViewModel
    {
        public ulong RequestId { get; set; }

        [Display(Name = "کد رهگیری نسخه ")]
        [MaxLength(400, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? ExperimentTrakingCode { get; set; }

        [Display(Name = "تصویر نسخه ")]
        public string? DrugPrescription { get; set; }

        [Display(Name = "نام آزمایش ")]
        [MaxLength(400, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? ExperimentName { get; set; }        

        [Display(Name = "توضیحات ")]
        public string? Description { get; set; }

        public List<HomeLaboratoryRequestDetail?> ListOfRequestedLaboratory { get; set; }
    }
    public enum CreateLaboratoryRequestSiteSideResult
    {
        Success,
        DetailNotValid,
        MoreThanOneChoice,
        ExperimentNameAndImageIsNull,        
        AllOfPropertiesAreNull
    }
}
