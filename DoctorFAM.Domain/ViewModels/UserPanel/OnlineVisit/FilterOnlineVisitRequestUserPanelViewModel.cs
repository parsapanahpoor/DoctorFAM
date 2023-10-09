using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;

namespace DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit
{
    public class FilterOnlineVisitRequestUserPanelViewModel
    {
        #region properties

        public ulong Id { get; set; }

        public ulong UserId{ get; set; }

        public string? WorkShiftDateTime { get; set; }

        public bool IsFinaly { get; set; }

        public DateTime DateTime { get; set; }

        #endregion
    }
}
