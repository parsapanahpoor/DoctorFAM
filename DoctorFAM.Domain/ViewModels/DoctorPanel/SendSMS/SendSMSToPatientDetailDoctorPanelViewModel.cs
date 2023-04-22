using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Enums.SendSMS.FromDoctors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.SendSMS
{
    public class SendSMSToPatientDetailDoctorPanelViewModel
    {
        #region properties

        public string? RejectSMSDescription { get; set; }

        public ulong RequestId { get; set; }

        public List<User>? PatientId { get; set; }

        [Display(Name = "متن پیامک")]
        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [MaxLength(100000, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string SMSBody { get; set; }

        public ulong DoctorUserId { get; set; }

        public int CountOfUserPercentageSMS { get; set; }

        public SendSMSFromDoctorState? SendSMSFromDoctorState { get; set; }

        #endregion
    }
}
