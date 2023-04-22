using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Enums.SendSMS.FromDoctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.SendSMS
{
    public class ShowRequestForSendSMSDetailAdminSideViewModel
    {
        #region properties

        public ulong RequestId { get; set; }

        public SendSMSFromDoctorState SendSMSFromDoctorState { get; set; }

        public string? RejectDescription { get; set; }

        public string SMSBody { get; set; }

        public List<User>? Users { get; set; }

        #endregion
    }
}
