using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.SendSMS.FromDoctrors
{
    public class SendRequestOfSMSFromDoctorsToThePatientDetail : BaseEntity
    {
        #region properties

        public ulong SendRequestOfSMSFromDoctorsToThePatientId { get; set; }

        public ulong UserId { get; set; }

        #endregion

        #region relations

        #endregion
    }
}
