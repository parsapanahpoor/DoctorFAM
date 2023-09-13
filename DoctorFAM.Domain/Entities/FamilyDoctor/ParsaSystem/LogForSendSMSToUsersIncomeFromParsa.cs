using DoctorFAM.Domain.Entities.Common;

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
