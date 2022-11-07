using DoctorFAM.Domain.Entities.FamilyDoctor.VIPSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.ParsaSystem.VIPPatient
{
    public class SendSMSForRangeOfVIPInsertedPatientViewModel
    {
        [Display(Name = "متن پیامک")]
        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [MaxLength(100000, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string SMSBody { get; set; }

        public ulong DoctorUserId { get; set; }

        public List<VIPUserInsertedFromDoctorSystem> VIPUserInsertedFromDoctorSystem { get; set; }

        public string LabelName { get; set; }
    }
}
