using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.SendSMS.FromDoctors
{
    public enum SendSMSFromDoctorState
    {
        WaitingForConfirm = 1,
        AcceptAndSent = 2,
        Decline = 3,
    }
}
