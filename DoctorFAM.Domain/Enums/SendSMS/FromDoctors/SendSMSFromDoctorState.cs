using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.SendSMS.FromDoctors
{
    public enum SendSMSFromDoctorState
    {

        [Display(Name = "در انتظار تایید")] WaitingForConfirm = 1,
        [Display(Name = "تایید و ارسال ")] AcceptAndSent = 2,
        [Display(Name = "رد درخواست")] Decline = 3,
    }
}
