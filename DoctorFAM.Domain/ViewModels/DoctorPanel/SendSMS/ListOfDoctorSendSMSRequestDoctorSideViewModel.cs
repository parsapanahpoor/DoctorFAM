using DoctorFAM.Domain.Enums.SendSMS.FromDoctors;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.SendSMS
{
    public class ListOfDoctorSendSMSRequestDoctorSideViewModel
    {
        #region properties

        public int CountOfSMS { get; set; }

        public ulong RequestId { get; set; }

        public DateTime CreateDate { get; set; }

        public SendSMSFromDoctorState SendSMSFromDoctorState { get; set; }

        public ulong Id { get; set; }

        #endregion
    }
}
