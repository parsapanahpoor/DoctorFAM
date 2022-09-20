using DoctorFAM.Domain.Entities.OnlineVisit;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IOnlineVisitRepository
    {
        #region Site Side

        //Add Online Request Detail 
        Task AddOnlineRequestDetail(OnlineVisitRequestDetail model);

        //Get Activated And Online Visit Interests Online Visit For Send Correct Notification For Arrival Online Visit Request 
        Task<List<string?>> GetActivatedAndDoctorsInterestOnlineVisit();

        //Filter Online Visit Requests 
        Task<FilterOnlineVisitViewModel> FilterOnlineVisitRequests(FilterOnlineVisitViewModel filter);

        //Get Online Visit Request Detail 
        Task<OnlineVisitRequestDetail?> GetOnlineVisitRequestDetail(ulong requestId);

        #endregion

        #region Doctor Side

        //Filter Your Online Visit Request 
        Task<FilterOnlineVisitViewModel?> FilterYourOnlineVisitRequest(FilterOnlineVisitViewModel filter);

        #endregion

        #region User Panel Side 

        //Filter User Onlien Visit Requests 
        Task<FilterOnlineVisitRequestUserPanelViewModel> FilterOnlineVisitRequestUserPanel(FilterOnlineVisitRequestUserPanelViewModel filter);

        #endregion
    }
}
