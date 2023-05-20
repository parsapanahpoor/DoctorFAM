using DoctorFAM.Domain.Entities.Account;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit
{
    public class OnlineVisitUserRequestDetailDoctorSideViewModel
    {
        #region properties

        public User User { get; set; }

        public string? WorkShift { get; set; }

        public string? WorkShiftTime { get; set; }

        public int BusinessKey { get; set; }

        public DateTime OnlineVisitRequestDate { get; set; }

        public ulong RequestId { get; set; }

        public bool IsRequestTakenByDoctor { get; set; }

        #endregion
    }
}
