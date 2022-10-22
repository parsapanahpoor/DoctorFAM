using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.FamilyDoctor.ParsaSystem
{
    public class LogForSendSMSToUsersIncomeFromParsa : BaseEntity
    {
        #region properties

        public ulong DoctorUserId { get; set; }

        public ulong ParsaUserId { get; set; }

        public string SMSBody { get; set; }

        #endregion

        #region relations


        #endregion
    }
}
