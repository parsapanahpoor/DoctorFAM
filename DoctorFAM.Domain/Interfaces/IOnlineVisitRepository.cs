using DoctorFAM.Domain.Entities.OnlineVisit;
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

        #endregion
    }
}
