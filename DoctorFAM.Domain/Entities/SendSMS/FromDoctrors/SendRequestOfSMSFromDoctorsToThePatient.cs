using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.SendSMS.FromDoctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.SendSMS.FromDoctrors
{
    public class SendRequestOfSMSFromDoctorsToThePatient : BaseEntity
    {
        #region properties

        public ulong DoctorUserId { get; set; }

        public SendSMSFromDoctorState SendSMSFromDoctorState { get; set; }

        public string? DeclineDescription { get; set; }

        public string SMSText { get; set; }

        #endregion

        #region relations

        #endregion
    }
}
